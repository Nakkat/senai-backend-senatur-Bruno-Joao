using Microsoft.EntityFrameworkCore;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    // Herança dos métodos da interface
    public class UsuarioRepository : IUsuarioRepository
    {
        // Instanciar o contexto Senatur
        Senatur_ManhaContext ctx = new Senatur_ManhaContext();

        /// <summary>
        /// Atualizar um usuário
        /// </summary>
        /// <param name="id">Id do usuário que será buscado</param>
        /// <param name="usuarioAtualizado">Objeto usuarioAtualizado que será atualizado</param>
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

        /// <summary>
        /// Buscar email e a senha para fazer o login
        /// </summary>
        /// <param name="Email">Email do usuário que será buscado</param>
        /// <param name="Senha">Senha do usuário que será buscado</param>
        /// <returns>Retorna um token do login</returns>
        public Usuario BuscarPorEmailSenha(string Email, string Senha)
        {
            Usuario usuarioBuscado = ctx.Usuario.Include(u => u.IdTipoUsuarioNavigation).FirstOrDefault(a => a.Email == Email && a.Senha == Senha);

            return usuarioBuscado;
        }

        /// <summary>
        /// Buscar usuários por Id
        /// </summary>
        /// <param name="id">Id do usuário que será buscado</param>
        /// <returns>Retorna os dados de um usuário específico</returns>
        public Usuario BuscarUsuariosPorId(int id)
        {
            return ctx.Usuario.FirstOrDefault(e => e.IdUsuario == id);
        }

        /// <summary>
        /// Cadastrar um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario que será cadastrado</param>
        public void CadastrarUsuario(Usuario novoUsuario)
        {
            ctx.Usuario.Add(novoUsuario);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deletar um usuário
        /// </summary>
        /// <param name="id">Id do usuario que será buscado</param>
        public void DeletarUsuario(int id)
        {
            ctx.Usuario.Remove(BuscarUsuariosPorId(id));
            ctx.SaveChanges();
        }

        /// <summary>
        /// Listar usuários
        /// </summary>
        /// <returns>Retorna uma lista de usuários</returns>
        public List<Usuario> ListarUsuarios()
        {
            return ctx.Usuario.Include(u => u.IdTipoUsuarioNavigation).ToList();
        }
    }
}
