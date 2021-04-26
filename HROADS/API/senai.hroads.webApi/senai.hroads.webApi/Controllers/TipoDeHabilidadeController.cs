using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDeHabilidadeController : ControllerBase
    {
        /// <summary>
        /// Objeto _tipoHabRepository que irá receber todos os métodos definidos na interface ITipoDeHabilidadeRepository
        /// </summary>
        private ITipoDeHabilidadeRepository _tipoHabRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _tipoHabRepository para que haja a referência nos métodos implementas no repositório TipoDeHabilidadeRepository
        /// </summary>
        public TipoDeHabilidadeController()
        {
            _tipoHabRepository = new TipoDeHabilidadeRepository();
        }

        /// <summary>
        /// Lista todos os tipos de habilidades
        /// </summary>
        /// <returns>Uma lista de tipos de habilidades e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_tipoHabRepository.Listar());
        }

        /// <summary>
        /// Busca um tipo de habilidade através do seu ID
        /// </summary>
        /// <param name="id">ID do tipo de habilidade que será buscado</param>
        /// <returns>Um tipo de habilidade encontrado e um status code 200 - Ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_tipoHabRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo tipo de habilidade
        /// </summary>
        /// <param name="novoTipoHab">Objeto novoTipoHab que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(TipoDeHabilidade novoTipoHab)
        {
            // Faz a chamada para o método
            _tipoHabRepository.Cadastrar(novoTipoHab);

            // Retorna um status code
            return StatusCode(201);
        }
    }
}
