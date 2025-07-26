using AutoMapper;
using Business.Abstract;
using Business.Dtos.Requests.User;
using Business.Dtos.Responses.User;
using Entities;
using Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class UserManager : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserManager(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<List<GetUserResponse>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return _mapper.Map<List<GetUserResponse>>(users);
    }

    public async Task<GetUserResponse> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return _mapper.Map<GetUserResponse>(user);
    }

    public async Task<CreatedUserResponse> AddAsync(CreateUserRequest request)
    {
        var user = _mapper.Map<User>(request);
        var createdUser = await _userRepository.AddAsync(user);
        return _mapper.Map<CreatedUserResponse>(createdUser);
    }

    public async Task<UpdatedUserResponse> UpdateAsync(UpdateUserRequest request)
    {
        var user = _mapper.Map<User>(request);
        var updatedUser = await _userRepository.UpdateAsync(user);
        return _mapper.Map<UpdatedUserResponse>(updatedUser);
    }

    public async Task<DeletedUserResponse> DeleteAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        var deletedUser = await _userRepository.DeleteAsync(user);
        return _mapper.Map<DeletedUserResponse>(deletedUser);
    }

    public async Task AddAsync(User user)
    {
        await _userRepository.AddAsync(user);
    }

}

