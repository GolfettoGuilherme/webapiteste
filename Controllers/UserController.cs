using Microsoft.AspNetCore.Mvc;

namespace Teste02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("ListUsers")]
        public JsonResult ListUsers()
        {
            return new JsonResult(new {id = 1, nome = "guilherme"});
        }    
    }
}