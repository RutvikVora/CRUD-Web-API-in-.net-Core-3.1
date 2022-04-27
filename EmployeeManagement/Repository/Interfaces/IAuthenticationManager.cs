namespace EmployeeManagement.Repository.Interfaces
{
    using System.Collections.Generic;
    public interface IAuthenticationManager
    {
        /// <summary>
        /// Validate Credentials
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        string ValidateCredentials(string username, string password);

        IDictionary<string, string> Tokens { get; }
    }
}
