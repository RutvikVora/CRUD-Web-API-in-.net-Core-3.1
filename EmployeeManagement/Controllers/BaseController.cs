namespace EmployeeManagement.Controllers
{
    using EmployeeManagement.Repository.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly ILogger<BaseController> _logger;
        protected readonly IAuthenticationManager authenticationManager;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="authManager"></param>
        public BaseController(ILogger<BaseController> logger,
        IAuthenticationManager authManager)
        {
            _logger = logger;
            authenticationManager = authManager;
        }
    }
}
