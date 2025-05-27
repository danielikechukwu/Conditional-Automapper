using AutoMapper;
using ConditionalAutomapperDemo.Data;
using ConditionalAutomapperDemo.DTOs;
using ConditionalAutomapperDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConditionalAutomapperDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EcommerceDbContext _context;
        private readonly IMapper _mapper;
         
        public List<Employee> listEmployees = new List<Employee>()
        {
            new Employee() {Id = 1, Name="Pranaya", Department="IT", Position = "DBA", Salary=1000,
                City="BBSR", State="Odisha", Country="India"},

            new Employee() {Id = 2, Name="Anurag", Department="HR", Position = "Developer", Salary=2000,
                City="CTC", State="Odisha", Country="India"}
        };

        public EmployeesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost("{Id}")]
        public ActionResult<EmployeeDTO> GetEmployee([FromRoute] int Id)
        {
            var employee = listEmployees.FirstOrDefault(e => e.Id == Id);

            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            var employeeDTO = _mapper.Map<EmployeeDTO>(employee);

            return Ok(employeeDTO);

        }
    }
}
