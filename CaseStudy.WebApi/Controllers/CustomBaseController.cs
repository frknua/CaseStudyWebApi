using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CaseStudy.Core.DTOs;
using System.Net;

namespace CaseStudy.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = Convert.ToInt32(response.StatusCode)
            };
        }
    }
}
