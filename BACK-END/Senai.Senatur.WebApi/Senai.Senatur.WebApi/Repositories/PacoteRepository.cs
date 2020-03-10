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

            if(String.IsNullOrEmpty(pacoteAtualizado.NomePacote)== false)
            {
                pacoteBuscado.NomePacote = pacoteAtualizado.NomePacote;
            }

            if(String.IsNullOrEmpty(pacoteAtualizado.Descricao)== false)
            {
                pacoteBuscado.Descricao = pacoteAtualizado.Descricao;
            }

            if(pacoteAtualizado.DataIda !=null)
            {
                pacoteBuscado.DataIda = pacoteAtualizado.DataIda;
            }

            if(pacoteAtualizado.DataVolta !=null)
            {
                pacoteBuscado.DataVolta = pacoteAtualizado.DataVolta;
            }

            if(pacoteAtualizado.Valor == pacoteAtualizado.Valor)
            {
                pacoteBuscado.Valor = pacoteAtualizado.Valor;
            }

            if(pacoteAtualizado.Ativo == pacoteAtualizado.Ativo)
            {
                pacoteBuscado.Ativo = pacoteAtualizado.Ativo;
            }

            if(String.IsNullOrEmpty(pacoteAtualizado.NomeCidade))
            {
                pacoteBuscado.NomeCidade = pacoteAtualizado.NomeCidade;
            }
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
    }
}
