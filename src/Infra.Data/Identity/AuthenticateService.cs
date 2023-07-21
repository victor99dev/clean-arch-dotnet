using Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace Infra.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        public readonly UserManager<ApplicationUser> _userManager;
        public readonly SignInManager<ApplicationUser> _singInManager;
        public Task<bool> Authenticate(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterUser(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}