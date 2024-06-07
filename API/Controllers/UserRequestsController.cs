using Application.Dtos.RequestModel.UserRequest;
using Application.Dtos.ResponseModel;
using Application.IServices;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Application.Dtos.ResponseModel.UserRequest;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class UserRequestsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserRequestService _userRequestService;

        public UserRequestsController(IMapper mapper, IUserRequestService userRequestService)
        {
            _mapper = mapper;
            _userRequestService = userRequestService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var userId = Guid.Parse(User.FindFirstValue("userId"));
                var response = await _userRequestService.GetUserRequest(userId);
                if (response.StatusCode == 200)
                {
                    return Ok(new PaginatedResponse<IEnumerable<GetUserRequestResponse>>
                    {
                        StatusCode = 200,
                        Body = _mapper.Map<IEnumerable<GetUserRequestResponse>>(response.Body),
                        Total = response.Body.Count()
                    });
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUserRequestRequest createUserRequestRequest)
        {
            try
            {
                var userId = Guid.Parse(User.FindFirstValue("userId"));
                var userRequest = _mapper.Map<UserRequest>(createUserRequestRequest);
                userRequest.RequesterId = userId;
                return Ok(await _userRequestService.Insert(userRequest));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                return Ok(await _userRequestService.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
