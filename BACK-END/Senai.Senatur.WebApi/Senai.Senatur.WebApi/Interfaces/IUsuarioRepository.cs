using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> ListarUsuarios();

        void CadastrarUsuario(Usuario novoUsuario);

        void AtualizarUsuario(int id, Usuario usuarioAtualizado);

        void DeletarUsuario(int id);

        Usuario BuscarUsuariosPorId(int id);

        Usuario BuscarPorEmailSenha(string Email, string Senha);
    }
}
