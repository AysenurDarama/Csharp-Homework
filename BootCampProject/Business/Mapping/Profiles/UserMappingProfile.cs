using AutoMapper;
using Business.Dtos.Requests.User;
using Business.Dtos.Responses.User;
using Entities;

namespace Business.Mapping.Profiles;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<CreateUserRequest, User>();
        CreateMap<UpdateUserRequest, User>();

        CreateMap<User, CreatedUserResponse>();
        CreateMap<User, UpdatedUserResponse>();
        CreateMap<User, DeletedUserResponse>();
        CreateMap<User, GetUserResponse>();
    }
}