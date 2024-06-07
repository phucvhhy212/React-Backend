using System.Security.Claims;
using Application.Dtos.RequestModel.BorrowingRequest;
using Application.Dtos.ResponseModel;
using Application.Dtos.ResponseModel.BorrowingRequest;
using Application.IServices;
using Application.Services;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowingRequestsController : ControllerBase
    {
        private readonly IBorrowingRequestService _borrowingRequestService;
        private readonly IMapper _mapper;

        public BorrowingRequestsController(IBorrowingRequestService borrowingRequestService, IMapper mapper)
        {
            _borrowingRequestService = borrowingRequestService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int currentPage, int pageSize, string? name, string? sortBy, string? sortOrder)
        {
            try
            {
                Func<IQueryable<BorrowingRequest>, IOrderedQueryable<BorrowingRequest>>? orderBy;
                switch (sortBy?.ToLower())
                {
                    case "requester":
                        orderBy = x => sortOrder != "desc" ? x.OrderBy(b => b.Requester.UserName) : x.OrderByDescending(b => b.Requester.UserName);
                        break;
                    case "id":
                        orderBy = x => sortOrder != "desc" ? x.OrderBy(b => b.Id) : x.OrderByDescending(b => b.Id);
                        break;
                    case "date":
                        orderBy = x => sortOrder != "desc" ? x.OrderBy(b => b.DateRequested) : x.OrderByDescending(b => b.DateRequested);
                        break;
                    case "status":
                        orderBy = x => sortOrder != "desc" ? x.OrderBy(b => b.Status) : x.OrderByDescending(b => b.Status);
                        break;
                    default:
                        orderBy = null;
                        break;
                }

                var response = await _borrowingRequestService.Get(
                    page: currentPage == 0 ? 1 : currentPage,
                    pageSize: pageSize == 0 ? 5 : pageSize,
                    filter: String.IsNullOrEmpty(name)
                        ? null
                        : x => x.Status.Contains(name) || x.Requester.UserName.Contains(name),
                    orderBy: String.IsNullOrEmpty(sortBy)
                        ? null
                        : orderBy,
                    includeProperties: "Requester");
                if (response.StatusCode == 200)
                {
                    return Ok(new PaginatedResponse<IEnumerable<BorrowingRequestResponse>>
                    {
                        StatusCode = 200,
                        Body = _mapper.Map<IEnumerable<BorrowingRequestResponse>>(response.Body),
                        Total = response.Total
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
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Post(CreateBorrowingRequestRequest request)
        {
            try
            {
                return Ok(await _borrowingRequestService.Insert(request));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("History")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetUserBorrowingHistory()
        {
            try
            {
                var userId = Guid.Parse(User.FindFirstValue("userId"));
                var response = await _borrowingRequestService.GetUserBorrowingHistory(userId);
                if (response.StatusCode == 200)
                {
                    return Ok(new BaseResponse<IEnumerable<UserBorrowingHistoryResponse>>
                    {
                        StatusCode = 200,
                        Body = _mapper.Map<IEnumerable<UserBorrowingHistoryResponse>>(response.Body)
                    });
                }

                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var response = await _borrowingRequestService.GetBorrowingRequestDetail(id);
                if (response.StatusCode == 200)
                {
                    return Ok(new BaseResponse<BorrowingRequestDetailResponse>
                    {
                        StatusCode = 200,
                        Body = _mapper.Map<BorrowingRequestDetailResponse>(response.Body)
                    });
                }

                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        [HttpPut("ChangeStatus")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeStatus(Guid id, string status)
        {
            try
            {
                var userId = Guid.Parse(User.FindFirstValue("userId"));
                return Ok(await _borrowingRequestService.ChangeStatus(id, userId, status));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

    }
}
