using Microsoft.AspNetCore.Mvc;

namespace Teste02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HackController : Controller
    {
        [HttpGet("GetTeste")]
        public JsonResult GetTeste()
        {
            var contexto = new ContextoSql();
            var dados = contexto.GetLinha();
            return new JsonResult(dados);
        }
    }
}