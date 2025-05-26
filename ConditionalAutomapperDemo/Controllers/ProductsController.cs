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
    public class ProductsController : ControllerBase
    {
        private readonly EcommerceDbContext _context;
        private readonly IMapper _mapper;

        public ProductsController(EcommerceDbContext context, IMapper mapper) { 
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("GetProducts")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            List<Product> product = await _context.Products.ToListAsync();

            List<ProductDTO> productDTO = _mapper.Map<List<ProductDTO>>(product);

            return Ok(productDTO);

        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<ProductDTO>> UpdateProduct(int Id, ProductDTO productDTO)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == Id);

            if(product == null)
            {
                return NotFound("Product not found");
            }

            // AutoMapper will ignore null values in productDTO during mapping
            _mapper.Map(productDTO, product);

            await _context.SaveChangesAsync();

            return Ok(productDTO);

        }
    }
}
