using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using teste_webapi.Context;

namespace teste_webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly AgendaContext _context;
        public ContatoController(AgendaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
            return Ok();
        }

        // Busca contato por id
        [HttpGet("{id}")] // recebe na rota um parametro id
        public IActionResult ObterPorID(int id)
        {
            var contato = _context.Contatos.Find(id);

            // testa se contato é nulo
            if (contato == null)
            {
                return NotFound();
            }

            return Ok(contato);
        }

        // buca contato por nome
        [HttpGet("ObterPorNome")]
        public IActionResult ObterPorNome(string nome)
        {
            // faz pesquisa pelo nome
            var contatos = _context.Contatos.Where(c => c.Nome.Contains(nome));
            return Ok(contatos);
        }

        // metodo para atualizar contato
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Contato contatoModificado)
        {
            var contatoNoBancoDeDados = _context.Contatos.Find(id);
            if (contatoNoBancoDeDados == null)
            {
                return NotFound();
            }

            contatoNoBancoDeDados.Nome = contatoModificado.Nome;
            contatoNoBancoDeDados.Telefone = contatoModificado.Telefone;
            contatoNoBancoDeDados.Ativo = contatoModificado.Ativo;

            _context.Contatos.Update(contatoNoBancoDeDados);
            _context.SaveChanges();// salva alteracao no banco

            return Ok(contatoNoBancoDeDados);
        }

        // metodo para deletar
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var contatoNoBancoDeDados = _context.Contatos.Find(id);
            if (contatoNoBancoDeDados == null)
            {
                return NotFound();
            }

            _context.Contatos.Remove(contatoNoBancoDeDados);
            _context.SaveChanges(); // salva alteracao no banco

            return NoContent();
        }
    }
}