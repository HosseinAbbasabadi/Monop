using Microsoft.AspNetCore.Mvc;
using UserManagement.Application;

namespace UserManagement.Presentation.RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserManagementApplication _userManagementApplication;

        public UserController(IUserManagementApplication userManagementApplication)
        {
            _userManagementApplication = userManagementApplication;
        }

        [HttpPost]
        public ActionResult Post([FromBody] RegisterUser command)
        {
            var registerResult = _userManagementApplication.Register(command);
            return registerResult.IsSuccessful() ? (ActionResult) Ok() : BadRequest();
        }
    }
}