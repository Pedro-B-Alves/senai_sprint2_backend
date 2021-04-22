using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        /// <summary>
        /// Objeto _jogoRepository que irá receber todos os métodos definidos na interface IJogoRepository
        /// </summary>
        private IJogoRepository _jogoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _jogoRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public JogosController()
        {
            _jogoRepository = new JogoRepository();
        }

        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Uma lista de jogos e um status code</returns>
        /// http://localhost:5000/api/jogos
        /// Qualquer usuário logado pode listar
        /// [Authorize] => verifica se o usuário está logado
        [Authorize]
        [HttpGet("Listar")]
        public IActionResult Get()
        {
            // Cria uma lista nomeada listaJogos para receber os dados
            List<JogoDomain> listaJogos = _jogoRepository.ListarTodos();

            // Retorna o status code 200 (Ok) com a lista de jogos no formato JSON
            return Ok(listaJogos);
        }

        /// <summary>
        /// Busca um jogo através do seu id
        /// </summary>
        /// <param name="id">id do jogo que será buscado</param>
        /// <returns>Um jogo buscado ou NotFound caso nenhum jogo seja encontrado</returns>
        /// http://localhost:5000/api/jogos/1
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Cria um objeto jogoBuscado que irá receber o jogo buscado no banco de dados
            JogoDomain jogoBuscado = _jogoRepository.BuscarPorId(id);

            // Verifica se nenhum jogo foi encontrado
            if (jogoBuscado == null)
            {
                // Caso não seja encontrado, retorna um status code 404 - Not Found com a mensagem personalizada
                return NotFound("Nenhum jogo foi encontrado!");
            }

            // Caso seja encontrado, retorna o jogo buscado com um status code 200 - Ok
            return Ok(jogoBuscado);
        }

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo">Objeto novoJogo recebido na requisição</param>
        /// <returns>Um status code 201 - Created</returns>
        /// http://localhost:5000/api/jogos
        /// [Authorize(Roles = "administrador"] => verifica se o usuário está logado e se ele possui a permissão (se é administrador)
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post(JogoDomain novoJogo)
        {
            // Faz a chamada para o método .Cadastrar()
            _jogoRepository.Cadastrar(novoJogo);

            // Retorna um status code 201 - Created
            return StatusCode(201);
        }

    }
}
