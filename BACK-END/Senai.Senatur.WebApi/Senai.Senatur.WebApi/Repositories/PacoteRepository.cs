using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class PacoteRepository : IPacoteRepository
    {
        Senatur_ManhaContext ctx = new Senatur_ManhaContext();

        public void AtualizarPacote(int id, Pacote pacoteAtualizado)
        {
            Pacote pacoteBuscado = ctx.Pacote.Find(id);

            if (pacoteAtualizado.NomePacote != null)
            {
                pacoteBuscado.NomePacote = pacoteAtualizado.NomePacote;
            }

            if (pacoteAtualizado.Descricao != null)
            {
                pacoteBuscado.Descricao = pacoteAtualizado.Descricao;
            }

            if (pacoteAtualizado.DataIda != null)
            {
                pacoteBuscado.DataIda = pacoteAtualizado.DataIda;
            }

            if (pacoteAtualizado.DataVolta != null)
            {
                pacoteBuscado.DataVolta = pacoteAtualizado.DataVolta;
            }

            if (pacoteAtualizado.Valor > 0)
            {
                pacoteBuscado.Valor = pacoteAtualizado.Valor;
            }

                pacoteBuscado.Ativo = pacoteAtualizado.Ativo;

            if (pacoteAtualizado.NomeCidade != null)
            {
                pacoteBuscado.NomeCidade = pacoteAtualizado.NomeCidade;
            }

            ctx.SaveChanges();
        }

        public Pacote BuscarPacotesPorId(int id)
        {
            return ctx.Pacote.FirstOrDefault(e => e.IdPacote == id);
        }

        public void CadastrarPacote(Pacote novoPacote)
        {
            ctx.Pacote.Add(novoPacote);

            ctx.SaveChanges();
        }

        public void DeletarPacote(int id)
        {
            Pacote pacoteBuscado = ctx.Pacote.Find(id);

            ctx.Pacote.Remove(pacoteBuscado);

            ctx.SaveChanges();
        }

        public List<Pacote> ListarPacotes()
        {
            return ctx.Pacote.ToList();
        }

        public List<Pacote> ListarPacotesAtivos()
        {
            return ctx.Pacote.Where(p => p.Ativo == true).ToList();
        }

        public List<Pacote> ListarPacotesCidades(string cidadeBuscada)
        {
            return ctx.Pacote.Where(p => p.NomeCidade == cidadeBuscada).ToList();
        }

        public List<Pacote> ListarPacotesInativos()
        {
            return ctx.Pacote.Where(p => p.Ativo == false).ToList();
        }

        public List<Pacote> ListarPacotesPorPreco(string ordem)
        {
            if (ordem == "Crescente")
            {
               return ctx.Pacote.OrderBy(p => p.Valor).ToList();
            }

            else if (ordem == "Decrescente")
            {
                return ctx.Pacote.OrderByDescending(p => p.Valor).ToList();
            }
            return null;
        }
    }
}
