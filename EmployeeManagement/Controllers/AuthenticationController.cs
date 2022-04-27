namespace EmployeeManagement.Controllers
{
    using EmployeeManagement.Models;
    using EmployeeManagement.Repository.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="authManager"></param>
        public AuthenticationController(ILogger<BaseController> logger, IAuthenticationManager authManager) : base(logger, authManager)
        {
        }

        /// <summary>
        /// Authenticate credentials
        /// </summary>
        /// <param name="userCred"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCredentialsModel userCred)
        {
            string result = authenticationManager.ValidateCredentials(userCred.Username, userCred.Password);

            if (result == null)
                return Unauthorized();

            return Ok(result);
        }

    }
}
