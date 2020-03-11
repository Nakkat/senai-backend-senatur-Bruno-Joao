using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.Repositories;

namespace Senai.Senatur.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class UsuariosController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _estudioRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IUsuarioRepository _usuarioRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista todos os estúdios
        /// </summary>
        /// <returns>Uma lista de estúdios e um status code 200 - Ok</returns>

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult Get()
        {
            // Retora a resposta da requisição fazendo a chamada para o método
            return Ok(_usuarioRepository.ListarUsuarios());
        }

        /// <summary>
        /// Busca um estúdio através do ID
        /// </summary>
        /// <param name="id">ID do estúdio que será buscado</param>
        /// <returns>Um estúdio buscado e um status code 200 - Ok</returns>

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retora a resposta da requisição fazendo a chamada para o método
            return Ok(_usuarioRepository.BuscarUsuariosPorId(id));
        }

        /// <summary>
        /// Cadastra um novo estúdio
        /// </summary>
        /// <param name="novoUsuario">Objeto novoEstudio que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            // Tenta fazer o método
            try
            {
                // Faz a chamada para o método
                _usuarioRepository.CadastrarUsuario(novoUsuario);

                // Retorna um status code
                return StatusCode(201);
            }
            // Caso contrário retorna uma mensagem de erro de má requisição
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Altera um estúdio
        /// </summary>
        /// <param name="id">Id do estúdio que será buscado</param>
        /// <param name="UsuarioAtualizado">Objeto estudioAtualizado que será alterado</param>
        /// <returns>Um Status Code 204 (No Content)</returns>
        
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario UsuarioAtualizado)
        {
            // Cria um objeto em Estudios para armazenar  IdBuscado
            Usuario UsuarioBuscado = _usuarioRepository.BuscarUsuariosPorId(id);

            // Se o Id do estúdio buscado for nulo :
            if (UsuarioBuscado == null)
            {
                return NotFound
                    (
                        new
                        {
                            mensagem = "Usuário não encontrado",
                            erro = true
                        }
                    );
            }

            // Tenta fazer o método
            try
            {
                _usuarioRepository.AtualizarUsuario(id, UsuarioAtualizado);

                return NoContent();
            }

            // Caso contrário : 
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta um estúdio
        /// </summary>
        /// <param name="id">Id do estúdio que será deletado</param>
        /// <returns>Um status code 200</returns>
        
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _usuarioRepository.DeletarUsuario(id);

                return Ok("Usuário deletado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}