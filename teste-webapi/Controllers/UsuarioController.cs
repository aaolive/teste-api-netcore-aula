using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace teste_webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("obterdata")] // definiu nome para rota
        public IActionResult ObterData()
        {
            var obj = new
            {
                data = DateTime.Now.Date.ToShortDateString(),
                hora = DateTime.Now.ToShortTimeString()
            };
            return Ok(obj);
        }

        // rota que recebe nome
        [HttpGet("saudacao/{nome}")]
        public IActionResult pegarNome(string nome)
        {
            var msgBoasVindas = $"Olá seja bem vindo {nome}";
            var obj=(Object)msgBoasVindas;
            return Ok(new { msgBoasVindas });
            //return Ok(obj);
        }

    }
}