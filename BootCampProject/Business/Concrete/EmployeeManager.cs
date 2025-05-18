using AutoMapper;
using Business.Abstract;
using Business.Dtos.Requests.Employee;
using Business.Dtos.Responses.Employee;
using Entities;
using Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class EmployeeManager : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public EmployeeManager(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    public async Task<List<GetEmployeeResponse>> GetAllAsync()
    {
        var employees = await _employeeRepository.GetAllAsync();
        return _mapper.Map<List<GetEmployeeResponse>>(employees);
    }

    public async Task<GetEmployeeResponse> GetByIdAsync(int id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);
        return _mapper.Map<GetEmployeeResponse>(employee);
    }

    public async Task<CreatedEmployeeResponse> AddAsync(CreateEmployeeRequest request)
    {
        var employee = _mapper.Map<Employee>(request);
        var created = await _employeeRepository.AddAsync(employee);
        return _mapper.Map<CreatedEmployeeResponse>(created);
    }

    public async Task<UpdatedEmployeeResponse> UpdateAsync(UpdateEmployeeRequest request)
    {
        var employee = _mapper.Map<Employee>(request);
        var updated = await _employeeRepository.UpdateAsync(employee);
        return _mapper.Map<UpdatedEmployeeResponse>(updated);
    }

    public async Task<DeletedEmployeeResponse> DeleteAsync(int id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);
        var deleted = await _employeeRepository.DeleteAsync(employee);
        return _mapper.Map<DeletedEmployeeResponse>(deleted);
    }
}

