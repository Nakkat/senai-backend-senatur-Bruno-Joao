using Microsoft.EntityFrameworkCore;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        Senatur_ManhaContext ctx = new Senatur_ManhaContext();

        public void AtualizarUsuario(int id, Usuario usuarioAtualizado)
        {
            Usuario usuario = ctx.Usuario.FirstOrDefault(e => e.IdUsuario == id);

            if (String.IsNullOrEmpty(usuarioAtualizado.Email) == false)
            {
                usuario.Email = usuarioAtualizado.Email;
            }

            if(String.IsNullOrEmpty(usuarioAtualizado.Senha)== false)
            {
                usuario.Senha = usuarioAtualizado.Senha;
            }
        }

        public Usuario BuscarPorEmailSenha(string Email, string Senha)
        {
            Usuario usuarioBuscado = ctx.Usuario.Include(u => u.IdTipoUsuarioNavigation).FirstOrDefault(a => a.Email == Email && a.Senha == Senha);

            return usuarioBuscado;
        }

        public Usuario BuscarUsuariosPorId(int id)
        {
            return ctx.Usuario.FirstOrDefault(e => e.IdUsuario == id);
        }

        public void CadastrarUsuario(Usuario novoUsuario)
        {
            ctx.Usuario.Add(novoUsuario);
            ctx.SaveChanges();
        }

        public void DeletarUsuario(int id)
        {
            ctx.Usuario.Remove(BuscarUsuariosPorId(id));
            ctx.SaveChanges();
        }

        public List<Usuario> ListarUsuarios()
        {
            return ctx.Usuario.Include(u => u.IdTipoUsuarioNavigation).ToList();
        }
    }
}
