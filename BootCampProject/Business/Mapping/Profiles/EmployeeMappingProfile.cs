using AutoMapper;
using Business.Dtos.Requests.Employee;
using Business.Dtos.Responses.Employee;
using Entities;

namespace Business.Mapping.Profiles;

public class EmployeeMappingProfile : Profile
{
    public EmployeeMappingProfile()
    {
        CreateMap<CreateEmployeeRequest, Employee>();
        CreateMap<UpdateEmployeeRequest, Employee>();

        CreateMap<Employee, CreatedEmployeeResponse>();
        CreateMap<Employee, UpdatedEmployeeResponse>();
        CreateMap<Employee, DeletedEmployeeResponse>();
        CreateMap<Employee, GetEmployeeResponse>();
    }
}