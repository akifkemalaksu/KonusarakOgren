using KonusarakOgren.Business.Interfaces;
using KonusarakOgren.Entities.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace KonusarakOgren.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserEngine _userEngine;

        public UsersController(IUserEngine userEngine)
        {
            _userEngine = userEngine;
        }

        [HttpPost]
        public IActionResult Post(AddUserRequestModel addUser)
        {
            var result = _userEngine.AddUser(addUser);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginRequestModel userLogin)
        {
            var result = _userEngine.Login(userLogin);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}