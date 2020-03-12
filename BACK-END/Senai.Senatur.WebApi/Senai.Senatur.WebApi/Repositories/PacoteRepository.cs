using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    // Herança dos métodos da interface
    public class PacoteRepository : IPacoteRepository
    {
        // Instancio o contexto Senatur
        Senatur_ManhaContext ctx = new Senatur_ManhaContext();

        /// <summary>
        /// Atualiza um pacote
        /// </summary>
        /// <param name="id">Id que será buscado</param>
        /// <param name="pacoteAtualizado">Objeto pacote atualizado que será atualizado</param>
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

        /// <summary>
        /// Buscar pacote por Id
        /// </summary>
        /// <param name="id">Id que será buscado</param>
        /// <returns>Retorna os dados de um pacote específico</returns>
        public Pacote BuscarPacotesPorId(int id)
        {
            return ctx.Pacote.FirstOrDefault(e => e.IdPacote == id);
        }

        /// <summary>
        /// Cadastrar um pacote
        /// </summary>
        /// <param name="novoPacote">Objeto novoPacote que será cadastrado</param>
        public void CadastrarPacote(Pacote novoPacote)
        {
            ctx.Pacote.Add(novoPacote);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deletar um pacote
        /// </summary>
        /// <param name="id">Id do pacote que será buscado</param>
        public void DeletarPacote(int id)
        {
            Pacote pacoteBuscado = ctx.Pacote.Find(id);

            ctx.Pacote.Remove(pacoteBuscado);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Listar pacotes
        /// </summary>
        /// <returns>Retorna uma lista de pacote</returns>
        public List<Pacote> ListarPacotes()
        {
            return ctx.Pacote.ToList();
        }

        /// <summary>
        /// Listar pacotes ativos
        /// </summary>
        /// <returns>Retorna uma lista de pacotes ativos</returns>
        public List<Pacote> ListarPacotesAtivos()
        {
            return ctx.Pacote.Where(p => p.Ativo == true).ToList();
        }

        /// <summary>
        /// Listar pacotes de uma determinada cidade
        /// </summary>
        /// <param name="cidadeBuscada"></param>
        /// <returns>Retorna uma lista de pacotes de uma cidade específica</returns>
        public List<Pacote> ListarPacotesCidades(string cidadeBuscada)
        {
            return ctx.Pacote.Where(p => p.NomeCidade == cidadeBuscada).ToList();
        }

        /// <summary>
        /// Listar pacotes inativos
        /// </summary>
        /// <returns>Retorna uma lista de pacotes inativos</returns>
        public List<Pacote> ListarPacotesInativos()
        {
            return ctx.Pacote.Where(p => p.Ativo == false).ToList();
        }

        /// <summary>
        /// Listar pacotes por ordem de preço
        /// </summary>
        /// <param name="ordem"></param>
        /// <returns>Retorna uma lista de pacotes ordenados por preço></returns>
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
