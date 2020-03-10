using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        TipoUsuario BuscarTipoUsuarioPorId(int id);

        List<TipoUsuario> ListarTiposdeUsuario();
    }
}
