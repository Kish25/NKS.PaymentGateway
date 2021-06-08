//Reference: https: //dejanstojanovic.net/aspnet/2020/july/basic-authentication-with-swagger-and-aspnet-core/
namespace NKS.Payments.API.Services
{
    using Interfaces;

    public class UserService: IUserService
    {
        public bool ValidateCredentials(string username, string password)
        {
            return true;
            // return username.Equals("me") && password.Equals("Pa$$WoRd");
        }
    }
}
