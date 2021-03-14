using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreWebApiTemplateProject.Model;
using System;
using System.Net;
using System.Threading.Tasks;

namespace NetCoreWebApiTemplateProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    public class BaseController : ControllerBase
    {
        private readonly ILogger<BaseController> _logger;
        private readonly IApiClient _apiClient;

        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
            _apiClient = new ApiClientFactory().CreateApiClient();
        }

        [HttpGet("GetData/{id}")]
        public async Task<IActionResult> GetData(string id)
        {
            _logger.LogError("GET GetData called with ID: " + id);

            if (string.IsNullOrEmpty(id))
            {
                throw new InvalidOperationException("ID needs to be defined");
            }

            var response = await _apiClient.GetDataAsync(id);
            if (response.IsSuccessful)
            {
                return Ok(response.Data);
            }

            var statusCode = response.StatusCode;

            if (statusCode == HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            else
            {
                return BadRequest(response.ErrorMessage);
            }
        }

        [HttpPost("PostData/{id}")]
        public async Task<IActionResult> PostData(string id, [FromBody] ExampleRequestObject request)
        {
            _logger.LogInformation("POST PostData called with ID: " + id);

            if (string.IsNullOrEmpty(id))
            { 
                throw new InvalidOperationException("ID needs to be defined");
            }

            if (request == null)
            {
                throw new InvalidOperationException("Request can not be null");
            }

            var response = await _apiClient.PostDataAsync(id, request);
            if (response.IsSuccessful)
            {
                return Ok(response.Data);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            else
            {
                _logger.LogError("POST PostData called with error: " + response.ErrorMessage);
                return BadRequest(response.ErrorMessage);
            }
        }
    }
}
