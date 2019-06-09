using Microsoft.AspNetCore.Mvc;
using Teste02.Models;

namespace Teste02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private Contexto GetContext()
        {
            return HttpContext.RequestServices.GetService(typeof(Contexto)) as Contexto;
        }

        [HttpGet("ListUsers")]
        public JsonResult ListUsers()
        {
            Contexto cont = GetContext(); 

            return new JsonResult(cont.GetUsers());
        }    

        [HttpGet("GetUserById")]
        public JsonResult GetUserById(long id)
        {
            return new JsonResult(new {id=id, nome = "Exemplo"});
        }

        [HttpPost("SetUser")]
        public JsonResult SetUser([FromBody] User dto)
        {
            Contexto cont = GetContext();

            var user = cont.InsertUser(dto);
            
            return new JsonResult(user);
        }

        [HttpPut("UpdateUser")]
        public JsonResult UpdateUser(User dto)
        {
            //image like an update to database
            return new JsonResult(dto);
        }

        [HttpDelete("DeleteUser")]
        public JsonResult DeleteUser(long id)
        {
            ReturnStats ret = new ReturnStats();
            ret.Success = true;
            ret.Message = "Usuario removido com sucesso";
            return new JsonResult(ret);
        }
        
    }
}