using ASP.NET_Web_API_2.DataModel.User;
using System.Threading.Tasks;
using System.Web.Http.Description;
using ASP.NET_Web_API_2.DomainLogic.Security;
using ASP.NET_Web_API_2.Models;
using Microsoft.AspNetCore.Mvc;


namespace ASP.NET_Web_API_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        
        [ResponseType(typeof(User))]
        public async Task<ActionResult> Login([System.Web.Http.FromBody] LogIn logIn)
        {
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var test = await _authService.ValidateCredentials(logIn.UserName, logIn.Password,
                user: out var authUser);


            return test? (ActionResult) Ok(authUser) : NotFound();
        }

        [HttpGet]
        public ActionResult<string> GetTest()
        {
            return "test";
        }
    }
}