//using Application.Interfaces;
using Application.Services;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserServices _userService;

        UserController(UserServices userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody]NewUserModel reqBody)
        {
            try
            {
                var result = _userService.RegisterUserAsync(reqBody.fullName, reqBody.Email, reqBody.Password);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}
