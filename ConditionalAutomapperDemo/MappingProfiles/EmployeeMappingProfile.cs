using AutoMapper;
using ConditionalAutomapperDemo.DTOs;
using ConditionalAutomapperDemo.Models;

namespace ConditionalAutomapperDemo.MappingProfiles
{
    public class EmployeeMappingProfile : Profile
    {
public EmployeeMappingProfile() {
            // Configure mapping from Employee to EmployeeDTO
            // MemberList.None: Check neither source nor destination members, skipping validation
            CreateMap<Employee, EmployeeDTO>(MemberList.None);
        }
    }
}
