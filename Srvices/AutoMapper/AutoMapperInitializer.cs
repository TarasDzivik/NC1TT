using AutoMapper;
using NC1TestTask.Data.Entities;
using NC1TestTask.Models.DTOs;

namespace NC1TestTask.Srvices.AutoMapper
{
    public class AutoMapperInitializer : Profile
    {
        public AutoMapperInitializer()
        {
            CreateMap<Department, DepartmentDTO>().ReverseMap();
            CreateMap<Department, CreateDepartmentDTO>().ReverseMap();

            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Employee, CreateEmployeeDTO>().ReverseMap();

            CreateMap<ProgrammingLanguage, ProgrammingLanguageDTO>().ReverseMap();
            CreateMap<ProgrammingLanguage, CreateProgrammingLanguageDTO>().ReverseMap();
        }
    }
}
