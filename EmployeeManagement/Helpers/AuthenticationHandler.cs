namespace EmployeeManagement.Helpers
{
    using EmployeeManagement.Entities;
    using EmployeeManagement.Repository.Interfaces;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http.Headers;
    using System.Security.Claims;
    using System.Text;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;
    public class AuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        readonly IAuthenticationManager authenticationManager;
        private readonly EmployeeManagementContext employeeContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="authenticationManager"></param>
        /// <param name="options"></param>
        /// <param name="logger"></param>
        /// <param name="encoder"></param>
        /// <param name="clock"></param>        
        public AuthenticationHandler(IAuthenticationManager authenticationManager, EmployeeManagementContext employeeContext,
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
           this.authenticationManager = authenticationManager;
            this.employeeContext = employeeContext;
        }
        
        /// <summary>
        /// Handles the authenticate
        /// </summary>
        /// <returns>status of authentication</returns>
        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            try
            {
                AuthenticationHeaderValue authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                String[] credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter)).Split(':');
                string username = credentials.FirstOrDefault();
                string password = credentials.LastOrDefault();

                if (authenticationManager.ValidateCredentials(username, password) == null)
                    throw new ArgumentException("Invalid credentials");

                Employee emp = employeeContext.Employee.Where(x => x.EmpName == username && x.Password == password).FirstOrDefault();

                List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, Convert.ToString(emp.Id)),
                new Claim(ClaimTypes.Name, username)
            };
                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return System.Threading.Tasks.Task.FromResult(AuthenticateResult.Success(ticket));
            }
            catch (Exception ex)
            {
                return System.Threading.Tasks.Task.FromResult(AuthenticateResult.Fail($"Authentication failed: {ex.Message}"));
            }           
        }
    }
}
