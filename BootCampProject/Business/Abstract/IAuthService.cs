using Business.Dtos.Requests.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IAuthService
{
    Task<Core.Security.JWT.AccessToken> RegisterAsync(RegisterRequest request);
}
