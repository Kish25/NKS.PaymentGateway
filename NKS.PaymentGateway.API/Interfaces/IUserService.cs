namespace NKS.Payments.API.Interfaces
{
    using System;

    public interface IUserService
    {
        bool ValidateCredentials(String username, String password);
    }
}