using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    // Herança dos métodos da interface
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        // Instanciar o contexto Senatur
        Senatur_ManhaContext ctx = new Senatur_ManhaContext();

        /// <summary>
        /// Buscar tipos de usuário por Id
        /// </summary>
        /// <param name="id">Id dos tipos de usuário que será buscado</param>
        /// <returns>Retorna os dados de um tipo de usuário específico</returns>
        public TipoUsuario BuscarTipoUsuarioPorId(int id)
        {
            return ctx.TipoUsuario.FirstOrDefault(e => e.IdTipoUsuario == id);
        }

        /// <summary>
        /// Listar tipos de usuário
        /// </summary>
        /// <returns>Retorna uma lista de tipos de usuário</returns>
        public List<TipoUsuario> ListarTiposdeUsuario()
        {
            return ctx.TipoUsuario.ToList();
        }
    }
}
