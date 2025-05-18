using Business.Dtos.Requests.User;
using Business.Dtos.Responses.User;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IUserService
{
    Task<List<GetUserResponse>> GetAllAsync();
    Task<GetUserResponse> GetByIdAsync(int id);
    Task<CreatedUserResponse> AddAsync(CreateUserRequest request);
    Task<UpdatedUserResponse> UpdateAsync(UpdateUserRequest request);
    Task<DeletedUserResponse> DeleteAsync(int id);
}
