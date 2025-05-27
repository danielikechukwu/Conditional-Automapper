using AutoMapper;
using ConditionalAutomapperDemo.DTOs;
using ConditionalAutomapperDemo.Models;

namespace ConditionalAutomapperDemo.MappingProfiles
{
    public class StudentMappingProfile : Profile
    {
        public StudentMappingProfile() {

            // Configure mapping from Employee to EmployeeDTO
            CreateMap<Staff, StaffDTO>()

                //Storing N/A in the destination Address Property, if Source Address is NULL
                .ForMember(dest => dest.Address, opt => opt.NullSubstitute("N/A"))
                //Storing System in the destination CreatedBy Property, if Source CreatedBy is NULL
                .ForMember(dest => dest.CreatedBy, opt => opt.NullSubstitute("System"))
                //Storing Current Date and Time in the destination CreatedOn Property, if Source CreatedOn is NULL
                .ForMember(dest => dest.CreatedOn, opt => opt.NullSubstitute(DateTime.Now));
        }


    }
}
