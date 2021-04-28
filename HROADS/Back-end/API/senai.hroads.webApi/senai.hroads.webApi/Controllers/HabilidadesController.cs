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
    public class HabilidadesController : ControllerBase
    {
        /// <summary>
        /// Objeto _habRepository que irá receber todos os métodos definidos na interface IHabilidadeRepository
        /// </summary>
        private IHabilidadeRepository _habRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _habRepository para que haja a referência nos métodos implementados no repositório HabilidadeRepository
        /// </summary>
        public HabilidadesController()
        {
            _habRepository = new HabilidadeRepository();
        }

        /// <summary>
        /// Lista todas as habilidades
        /// </summary>
        /// <returns>Uma lista de habilidades e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_habRepository.Listar());
        }

        /// <summary>
        /// Busca uma habilidade através do seu ID
        /// </summary>
        /// <param name="id">ID da habilidade que será buscada</param>
        /// <returns>Uma habilidade encontrada e um status code 200 - Ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_habRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra uma nova habilidade
        /// </summary>
        /// <param name="novaHab">Objeto novaHab que será cadastrada</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(Habilidade novaHab)
        {
            // Faz a chamada para o método
            _habRepository.Cadastrar(novaHab);

            // Retorna um status code
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza uma habilidade existente
        /// </summary>
        /// <param name="id">ID da habilidade que será atualizada</param>
        /// <param name="habAtualizada">Objeto habAtualizada com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Habilidade habAtualizada)
        {
            // Faz a chamada para o método
            _habRepository.Atualizar(id, habAtualizada);

            // Retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta uma habilidade existente
        /// </summary>
        /// <param name="id">ID da habilidade que será deletada</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método
            _habRepository.Deletar(id);

            // Retorna um status code
            return StatusCode(204);
        }
    }
}
