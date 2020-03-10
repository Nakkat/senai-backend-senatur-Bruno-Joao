using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        Senatur_ManhaContext ctx = new Senatur_ManhaContext();

        public TipoUsuario BuscarTipoUsuarioPorId(int id)
        {
            return ctx.TipoUsuario.FirstOrDefault(e => e.IdTipoUsuario == id);
        }

        public List<TipoUsuario> ListarTiposdeUsuario()
        {
            return ctx.TipoUsuario.ToList();
        }
    }
}
