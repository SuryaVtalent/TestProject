using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPIFProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoWebAPIController : ControllerBase
    {
        [HttpGet]
        [Route("Addition")]
        public IActionResult Addition(int x,int y)
        {
            try
            {  
                return Ok(x + y);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
