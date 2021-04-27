using Microsoft.AspNetCore.Authorization;
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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoUsuarioRepository.Listar());
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post(TipoUsuario novoTipoUsuario)
        {
            _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);

            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_tipoUsuarioRepository.BuscarPorId(id));
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _tipoUsuarioRepository.Deletar(id);

            return StatusCode(201);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            // Faz a chamada para o método
            _tipoUsuarioRepository.Atualizar(id, tipoUsuarioAtualizado);

            // Retorna um status code
            return StatusCode(204);
        }
    }
}
