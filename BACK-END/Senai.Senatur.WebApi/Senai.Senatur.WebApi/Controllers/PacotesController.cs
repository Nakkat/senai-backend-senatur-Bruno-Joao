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
    public class PacotesController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _estudioRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IPacoteRepository _pacoteRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public PacotesController()
        {
            _pacoteRepository = new PacoteRepository();
        }

        /// <summary>
        /// Lista todos os estúdios
        /// </summary>
        /// <returns>Uma lista de estúdios e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Retora a resposta da requisição fazendo a chamada para o método
            return Ok(_pacoteRepository.ListarPacotes());
        }

        /// <summary>
        /// Busca um estúdio através do ID
        /// </summary>
        /// <param name="id">ID do estúdio que será buscado</param>
        /// <returns>Um estúdio buscado e um status code 200 - Ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retora a resposta da requisição fazendo a chamada para o método
            return Ok(_pacoteRepository.BuscarPacotesPorId(id));
        }

        /// <summary>
        /// Cadastra um novo estúdio
        /// </summary>
        /// <param name="novoPacote">Objeto novoEstudio que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = Administrador)]
        [HttpPost]
        public IActionResult Post(Pacote novoPacote)
        {
            // Tenta fazer o método
            try
            {
                // Faz a chamada para o método
                _pacoteRepository.CadastrarPacote(novoPacote);

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
        /// <param name="pacoteAtualizado">Objeto estudioAtualizado que será alterado</param>
        /// <returns>Um Status Code 204 (No Content)</returns>
         
        [Authorize(Roles = Administrador)]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Pacote pacoteAtualizado)
        {
            // Cria um objeto em Estudios para armazenar  IdBuscado
            Pacote pacoteBuscado = _pacoteRepository.BuscarPacotesPorId(id);

            // Se o Id do estúdio buscado for nulo :
            if (pacoteBuscado == null)
            {
                return NotFound
                    (
                        new
                        {
                            mensagem = "Pacote não encontrado",
                            erro = true
                        }
                    );
            }

            // Tenta fazer o método
            try
            {
                _pacoteRepository.AtualizarPacote(id, pacoteAtualizado);

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

        [Authorize(Roles = Administrador)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _pacoteRepository.DeletarPacote(id);

                return Ok("Pacote deletado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}