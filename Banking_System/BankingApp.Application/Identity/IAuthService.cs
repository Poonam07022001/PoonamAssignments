using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Application.LoginModels;

namespace BankingApp.Application.Identity
{
   public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
        Task<RegisterResponse> Register(RegisterRequest registerRequest);
    }
}
