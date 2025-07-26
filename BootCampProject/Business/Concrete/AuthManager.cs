using Business.Abstract;
using Business.Dtos.Requests.User;
using Core.BusinessException;
using Core.Security;
using Core.Security.Entities;
using Core.Security.JWT;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class AuthManager : IAuthService
{
    private readonly IUserService _userService;
    private readonly ITokenHelper _tokenHelper;

    public AuthManager(IUserService userService, ITokenHelper tokenHelper)
    {
        _userService = userService;
        _tokenHelper = tokenHelper;
    }

    public async Task<AccessToken> RegisterAsync(RegisterRequest request)
    {
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Username = request.Username,
            Email = request.Email,
            NationalityIdentity = request.NationalityIdentity,
            DateOfBirth = request.DateOfBirth,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            UserType = request.UserType 
        };


        await _userService.AddAsync(user);

        return _tokenHelper.CreateToken(user, new List<OperationClaim>());
    }

    
}
