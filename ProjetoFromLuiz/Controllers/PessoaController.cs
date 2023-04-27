using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using ProjetoFromLuiz.Repository;

namespace ProjetoFromLuiz.Controllers
{
    public class PessoaController : Controller
    {
        private static PessoaRepository pessoaRepository;

        public PessoaController()
        {
            pessoaRepository = new PessoaRepository();
        }

        [HttpPost]
        [Route("api/pessoas")]
        public IActionResult AdicionarPessoa([FromBody] Pessoa novaPessoa)
        {
            if (novaPessoa == null)
            {
                return BadRequest();
            }

            pessoaRepository.AdicionarPessoa(novaPessoa);

            return Ok(novaPessoa);
        }

        [HttpGet]
        [Route("api/pessoas")]
        public IActionResult ListarTodasPessoas()
        {
            var pessoas = pessoaRepository.ListarTodos();
            return Ok(pessoas);
        }

        [HttpGet]
        [Route("api/pessoas/{id}")]
        public IActionResult ListarPessoasId(int id)
        {
            var pessoa = pessoaRepository.ListarPessoaPorId(id);

            if (pessoa == null)
            {
                return NotFound("Falhou!");

            }

            return Ok(pessoa);
        }

        [HttpPut]
        [Route("api/pessoas/{id}")]
        public IActionResult AtualizarPessoas(int id, [FromBody] Pessoa PessoaAtualizada)
        {
            if (PessoaAtualizada == null)
            {
                return BadRequest();

            }

            pessoaRepository.AtualizacaoDaPessoa(id, PessoaAtualizada);

            return Ok("Cadastro atualizado com sucesso!");
        }
        
        [HttpDelete]
        [Route("api/pessoas/{id}")]
        public IActionResult ExcluirPessoa(int id)
        {
            pessoaRepository.ExcluirPessoa(id);

            return Ok("Cadastro Deletado!");
        }
    }
}