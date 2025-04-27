using Business.Abstract;
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

    public EmployeeManager(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<List<Employee>> GetAllAsync()
    {
        return (List<Employee>)await _employeeRepository.GetAllAsync();
    }

    public async Task<Employee> GetByIdAsync(int id)
    {
        return await _employeeRepository.GetByIdAsync(id);
    }

    public async Task<Employee> AddAsync(Employee employee)
    {
        return await _employeeRepository.AddAsync(employee);
    }

    public async Task<Employee> UpdateAsync(Employee employee)
    {
        return await _employeeRepository.UpdateAsync(employee);
    }

    public async Task DeleteAsync(Employee employee)
    {
        await _employeeRepository.DeleteAsync(employee);
    }
}
