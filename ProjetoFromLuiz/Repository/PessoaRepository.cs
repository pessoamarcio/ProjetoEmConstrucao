using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ProjetoFromLuiz.Repository
{
    public class PessoaRepository
    {
        private static List<Pessoa> baseDePessoas = new List<Pessoa>
        {
            new Pessoa { Id = 1, Nome = "João", Idade = 25, Email = "joao@email.com"},
            new Pessoa { Id = 2, Nome = "Maria", Idade = 30, Email = "maria@email.com"},
            new Pessoa { Id = 3, Nome = "Pedro", Idade = 18, Email = "pedro@email.com"}
        };

        public void AdicionarPessoa(Pessoa novaPessoa)
        {
            novaPessoa.Id = baseDePessoas.Count + 1;
            baseDePessoas.Add(novaPessoa);
        }

        public List<Pessoa> ListarTodos()
        {
            return baseDePessoas;
        }

        public Pessoa ListarPessoaPorId(int id)
        {
            return baseDePessoas.FirstOrDefault(p => p.Id == id);
        }

        public void AtualizacaoDaPessoa(int id, Pessoa atualizacaoDaPessoa)
        {
            var pessoa = baseDePessoas.FirstOrDefault(p => p.Id == id);
            if (pessoa != null)
            {
                pessoa.Nome = atualizacaoDaPessoa.Nome;
                pessoa.Idade = atualizacaoDaPessoa.Idade;
                pessoa.Email = atualizacaoDaPessoa.Email;
            }

        }

        public bool AtualizacaoDaPessoaTeste(int id, Pessoa pessoaAtualizada)
        {
            var pessoa1 = baseDePessoas.FirstOrDefault(p => p.Id == id);

            if (pessoa1 == null)
            {
                return false;
            }

            else
            {
                pessoa1.Nome = pessoaAtualizada.Nome;
                pessoa1.Idade = pessoaAtualizada.Idade;
                pessoa1.Email = pessoaAtualizada.Email;
            }

            return true;
        }

        public void ExcluirPessoa(int id)
        {
            var pessoa = baseDePessoas.FirstOrDefault(p => p.Id == id);

            if (pessoa != null)
            {
                baseDePessoas.Remove(pessoa);
            }
        }
    }
}