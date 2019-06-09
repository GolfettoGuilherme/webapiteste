using Microsoft.AspNetCore.Mvc;
using Teste02.Models;

namespace Teste02.Controllers
{
    public class ProductController : Controller
    {
        
        [HttpGet("ListProducts")]
        public JsonResult ListProducts()
        {
            return new JsonResult(new {id =1, nome = "lista-productos"});
        }

        [HttpGet("GetProductById")]
        public JsonResult GetProductById(long id)
        {
            Product dto = new Product(){
                Id = id,
                Name = "Something",
                Description = "WhateverBro"
            };
            return new JsonResult(dto);
        }

        [HttpPost("SetProduct")]
        public JsonResult SetProduct(Product dto)
        {
            dto.Id = 1;
            return new JsonResult(dto);
        }

        [HttpPut("UpdateProduct")]
        public JsonResult UpdateProduct(Product newDto)
        {
            newDto.Name = "Alterado";
            return new JsonResult(newDto);
        }

        [HttpDelete("DeleteProduct")]
        public JsonResult DeleteProduct(long id)
        {
            ReturnStats ret = new ReturnStats(){
                Success = true,
                Message = "Deletado com sucesso"
            };
            return new JsonResult(ret);
        }
    }
}