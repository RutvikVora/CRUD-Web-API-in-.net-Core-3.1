namespace EmployeeManagement.Repository
{
    using EmployeeManagement.Entities;
    using EmployeeManagement.Repository.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly EmployeeManagementContext employeeContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="employeeManagementContext"></param>
        public AuthenticationManager(EmployeeManagementContext employeeManagementContext)
        {
            employeeContext = employeeManagementContext;
        }

        private readonly IDictionary<string, string> tokens = new Dictionary<string, string>();

        public IDictionary<string, string> Tokens => tokens;

        /// <summary>
        /// Validate Credentials 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Bolean value</returns>
        public string ValidateCredentials(string username, string password)
        {
            if (!employeeContext.Employee.Where(x => x.EmpName == username && x.Password == password).Any())
            {
                return null;
            }

            string token = Guid.NewGuid().ToString();

            tokens.Add(token, username);

            return token;
        }
    }
}
