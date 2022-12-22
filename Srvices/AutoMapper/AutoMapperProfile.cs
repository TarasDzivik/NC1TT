using AutoMapper;
using NC1TestTask.Data.DTOs;
using NC1TestTask.Data.Entities;

namespace NC1TestTask.Srvices.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, ProgrammingLanguageDto>().ReverseMap();
        }
    }
}
