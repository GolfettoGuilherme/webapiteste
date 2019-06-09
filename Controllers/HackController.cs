using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Teste02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HackController : Controller
    {

        [HttpGet("GetLinha/{idLinha}")]
        public JsonResult GetLinha(string idLinha)
        {
            var contexto = new ContextoSql();
            var dados = contexto.GetLinha(idLinha);
            return new JsonResult(dados);
        }

        [HttpGet("GetDadosLinha/{texto}")]
        public JsonResult GetDadosLinha(string texto)
        {
            var contexto = new ContextoSql();
            var dados = contexto.GetDadosLinha(texto);
            return new JsonResult(dados);
        }

        [HttpGet("spSelBuscaLinha/{idlinha}/{dataInicio}/{dataFim}")]
        public JsonResult spSelBuscaLinha(string idlinha, DateTime dataInicio, DateTime dataFim)
        {
            var contexto = new ContextoSql();
            var dados = contexto.spSelBuscaLinha(idlinha,dataInicio,dataFim);
            return new JsonResult(dados);
        }
    }
}