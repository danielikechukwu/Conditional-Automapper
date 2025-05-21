using AutoMapper;
using ConditionalAutomapperDemo.DTOs;
using ConditionalAutomapperDemo.Models;

namespace ConditionalAutomapperDemo.MappingProfiles
{
    public class CustomerOrderMappingProfile : Profile
    {
        public CustomerOrderMappingProfile() {

            // 1) Customer -> CustomerDto
            CreateMap<Customer, CustomerDTO>()
                .ForMember(dest => dest.Orders, 
                opt =>
                {
                    opt.PreCondition(src => src.IsActive);
                    // If not active, the Orders won't be mapped and remain empty in the DTO
                    opt.MapFrom(src => src.Orders);
                })
                // AfterMap: If total spending across all orders > 1000, append (VIP) to name
                .AfterMap((src, dest) =>
                {
                    decimal totalSpending = dest.Orders.Sum(o => o.OrderTotal);

                    if (totalSpending > 1000)
                        dest.Name += " (VIP)";
                });

            // 2) Product -> ProductDto
            CreateMap<Product, ProductDTO>();

            // 3) OrderItem -> OrderItemDto
            CreateMap<OrderItem, OrderItemDTO>()
                .ForMember(dest => dest.ProductName, opt =>
                {
                    // Pre-Condition: Only map ProductName if product is available
                    opt.PreCondition(src => src.Product.IsAvailable);

                    // If not available, dest.ProductName remains null
                    opt.MapFrom<string>(src => src.Product.Name);
                })
                .ForMember(dest => dest.SubTotal, opt =>
                {
                    // Condition: Only map SubTotal if Quantity > 0
                    opt.Condition((src, dest, srcValue, destValue) => src.Quantity > 0);

                    // If condition is true, map from entity's computed SubTotal
                    opt.MapFrom(src => src.SubTotal);
                });

            // 4) Order -> OrderDTO
            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.ShippingCost, opt =>
                {
                    // Condition: Only map shipping cost if order is shipped
                    opt.Condition((src, dest, srcValue, destValue) => src.IsShipped);

                    // If not shipped, ShippingCost remains default (0)
                    opt.MapFrom(src => src.ShippingCost);
                })
                .AfterMap((src, dest) =>
                {
                    // If shipping cost is negative for some reason, revert to 0
                    if(dest.ShippingCost < 0)
                    {
                        dest.ShippingCost = 0;
                    }

                    // Recalculate from item subtotals
                    decimal itemsTotal = dest.OrderItems.Sum(i => i.SubTotal);

                    dest.OrderTotal = itemsTotal < 0 ? 0 : itemsTotal;
                });
        }
    }
}
