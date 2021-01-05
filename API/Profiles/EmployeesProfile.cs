using API.Dtos;
using API.Models;
using AutoMapper;

namespace API.Profiles
{
    public class EmployeesProfile:Profile
    {
        public EmployeesProfile()
        {
            CreateMap<EmployeeModel,EmployeeReadDto>();
            CreateMap<EmployeeCreateDto,EmployeeModel>();
            CreateMap<EmployeeUpdateDto,EmployeeModel>().ReverseMap();
        }
    }
}