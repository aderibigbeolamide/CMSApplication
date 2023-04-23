using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CMSApplication.DTOs.RequestModel;
using CMSApplication.Interfaces.Services;

namespace CMSApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateUserController : ControllerBase
    {
        private readonly ICreateUserService _createUserService;
        public CreateUserController(ICreateUserService createUserService)
        {
            _createUserService = createUserService;
        }


        [HttpPost("CreateAdmin")]
        public async Task<IActionResult> CreateAdmin([FromForm] AddAdminRequestModel model)
        {
            var user = await _createUserService.CreateAdmin(model);
            if (user.Success == false)
            {
                return BadRequest(user);
            }
            return Ok(user);
        }

        [HttpPost("CreateDonor")]
        public async Task<IActionResult> CreateDonor([FromForm] CreateUserRequestModel model)
        {
            var user = await _createUserService.CreateDonor(model);
            if (user.Success == false)
            {
                return BadRequest(user);
            }
            return Ok(user);
        }

        [HttpPost("CreateNgo")]
        public async Task<IActionResult> CreateCharityHome([FromForm] CreateUserRequestModel model)
        {
            var user = await _createUserService.CreateCharityHome(model);
            if (user.Success == false)
            {
                return BadRequest(user);
            }
            return Ok(user);
        }

        [HttpPost("VerifyUser")]
        public async Task<IActionResult> VerifyUser([FromForm] VerifyUserRequestModel model)
        {
            var user = await _createUserService.VerifyUser(model);
            if(user.Success == false)
            {
                return BadRequest(user);
            }
            return Ok(user);
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser([FromRoute] string email)
        {
            var user = await _createUserService.GetUser(email);
            if (user.Success == false)
            {
                return BadRequest(user);
            }
            return Ok(user);
        }
    }
}
