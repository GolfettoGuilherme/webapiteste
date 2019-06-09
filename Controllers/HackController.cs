using System;
using System.Collections.Generic;
using System.Text;
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

        [HttpGet("Extracao/{idlinha}/{dataInicio}/{dataMax}")]
        public FileResult Extracao(string idlinha, DateTime dataInicio, DateTime dataMax)
        {
            var contexto = new ContextoSql();
            var dados = contexto.Extracao(idlinha,dataInicio, dataMax);
            string textoExtracao = "datadem;tipo;area;empresa;linha;pass_pgtdin;pass_pgtcomum;pass_pgtbu_comum;pass_pgt_estud;pass_pgtbu_estudm;pass_pgtbu_vt;pass_pgtbu_vtm;pass_pgtint_mcptm;pass_pgtint_mcptmm;pass_pgt;pass_int_onon;pass_grat;pass_grat_estud;total_pass";

            dados.ForEach(p => {
                textoExtracao += Environment.NewLine;
                textoExtracao +=  p.datadem + ";" +
                p.tipo + ";" +
                p.area + ";" +
                p.empresa + ";" +
                p.linha + ";" +
                p.pass_pgtdin + ";" +
                p.pass_pgtcomum + ";" +
                p.pass_pgtbu_comum + ";" +
                p.pass_pgt_estud + ";" +
                p.pass_pgtbu_estudm + ";" +
                p.pass_pgtbu_vt + ";" +
                p.pass_pgtbu_vtm + ";" +
                p.pass_pgtint_mcptm + ";" +
                p.pass_pgtint_mcptmm + ";" +
                p.pass_pgt + ";" +
                p.pass_int_onon + ";" +
                p.pass_grat + ";" +
                p.pass_grat_estud + ";" +
                p.total_pass + ";";

                
            });

            byte[] bytes = Encoding.ASCII.GetBytes(textoExtracao);

            return File(bytes, System.Net.Mime.MediaTypeNames.Application.Octet, "Extracao.csv");
        }
    }
}