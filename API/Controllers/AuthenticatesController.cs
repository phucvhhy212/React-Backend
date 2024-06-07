using Application.Dtos.RequestModel.Authenticate;
using Application.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticatesController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;

        public AuthenticatesController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            try
            {
                return Ok(await _authenticateService.Login(request));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            try
            {
                return Ok(await _authenticateService.Register(request));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }
    }
}
