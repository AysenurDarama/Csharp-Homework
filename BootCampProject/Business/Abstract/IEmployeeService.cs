using Business.Dtos.Requests.Employee;
using Business.Dtos.Responses.Employee;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IEmployeeService
{
    Task<List<GetEmployeeResponse>> GetAllAsync();
    Task<GetEmployeeResponse> GetByIdAsync(int id);
    Task<CreatedEmployeeResponse> AddAsync(CreateEmployeeRequest request);
    Task<UpdatedEmployeeResponse> UpdateAsync(UpdateEmployeeRequest request);
    Task<DeletedEmployeeResponse> DeleteAsync(int id);
}
