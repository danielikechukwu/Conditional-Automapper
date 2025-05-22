using AutoMapper;
using ConditionalAutomapperDemo.Data;
using ConditionalAutomapperDemo.DTOs;
using ConditionalAutomapperDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConditionalAutomapperDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly EcommerceDbContext _context;
        private readonly IMapper _mapper;

        public CustomersController(EcommerceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("GetCustomers")]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetCustomers()
        {
            // Include Orders -> OrderItems -> Product
            var customers = await _context.Customers
                .Include(c => c.Orders)
                .ThenInclude(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ToListAsync();

            var customerDTOs = _mapper.Map<IEnumerable<CustomerDTO>>(customers);

            return Ok(customerDTOs);
        }

        [HttpGet("GetCustomerById/{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomerById([FromRoute] int id)
        {
            var customer = _context.Customers
                .Include (c => c.Orders)
                .ThenInclude (o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync();

            var customerDTO = _mapper.Map<CustomerDTO>(customer);

            return Ok(customerDTO);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> CreateCustomer([FromBody] CustomerDTO customerDTO)
        {
            var customer = new Customer
            {
                Name = customerDTO.Name ?? "New Customer",
                IsActive = true // default to active
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            var createdDTO = _mapper.Map<CustomerDTO>(customer);
            return Ok(createdDTO);
        }

    }
}
