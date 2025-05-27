using AutoMapper;
using ConditionalAutomapperDemo.DTOs;
using ConditionalAutomapperDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConditionalAutomapperDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private readonly IMapper _mapper;

        public List<Staff> listStaffs = new List<Staff>()
        {
            new Staff() {Id = 1, Name="Pranaya", Department="IT", Address = "BBSR",
                CreatedBy=null, CreatedOn=null},
            new Staff() {Id = 2, Name="Anurag", Department="HR", Address = null,
                CreatedBy=null, CreatedOn=DateTime.Now},
            new Staff() {Id = 3, Name="Priyanla", Department="HR", Address = null,
                CreatedBy="Admin", CreatedOn=null}
        };

        public StaffsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("{Id}")]
        public ActionResult<StaffDTO> GetStaff([FromRoute] int Id)
        {
            Staff staff = listStaffs.FirstOrDefault(staff => staff.Id == Id);

            if(staff == null)
            {
                return NotFound("Request Staff could not be located");
            }

            StaffDTO staffDTO = _mapper.Map<StaffDTO>(staff);

            return Ok(staffDTO);

        }
    }
}
