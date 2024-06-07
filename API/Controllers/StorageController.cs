using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly IStorageService _storageService;

        public StorageController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpPost]
        public IActionResult GetStorageUrl(IFormFile file)
        {
            var responseStorageUrl = _storageService.GetStorageUrl(file);
            return Ok(responseStorageUrl);
        }

        [HttpGet("GetObjectFinalVersionId/{objectKey}")]
        public async Task<IActionResult> GetObjectFinalVersionId(string objectKey)
        {
            var responseVersionId = await _storageService.GetObjectFinalVersionId(objectKey);
            return Ok(responseVersionId);
        }
    }
}