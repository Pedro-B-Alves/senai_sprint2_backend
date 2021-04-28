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
    public class PersonagensController : ControllerBase
    {
        /// <summary>
        /// Objeto _persoRepository que irá receber todos os métodos definidos na interface IPersonagemRepository
        /// </summary>
        private IPersonagemRepository _persoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _persoRepository para que haja a referência nos métodos implementados no repositório PersonagemRepository
        /// </summary>
        public PersonagensController()
        {
            _persoRepository = new PersonagemRepository();
        }

        /// <summary>
        /// Lista todos os personagens
        /// </summary>
        /// <returns>Uma lista de personagens e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_persoRepository.Listar());
        }

        /// <summary>
        /// Busca um personagem através do seu ID
        /// </summary>
        /// <param name="id">ID do personagem que será buscado</param>
        /// <returns>Um personagem encontrado e um status code 200 - Ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_persoRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo personagem
        /// </summary>
        /// <param name="novaPerso">Objeto novaPerso que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(Personagem novaPerso)
        {
            // Faz a chamada para o método
            _persoRepository.Cadastrar(novaPerso);

            // Retorna um status code
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um personagem existente
        /// </summary>
        /// <param name="id">ID do personagem que será atualizado</param>
        /// <param name="persoAtualizado">Objeto persoAtualizado com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Personagem persoAtualizado)
        {
            // Faz a chamada para o método
            _persoRepository.Atualizar(id, persoAtualizado);

            // Retorna um status code
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta um personagem existente
        /// </summary>
        /// <param name="id">ID do personagem que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método
            _persoRepository.Deletar(id);

            // Retorna um status code
            return StatusCode(204);
        }
    }
}
