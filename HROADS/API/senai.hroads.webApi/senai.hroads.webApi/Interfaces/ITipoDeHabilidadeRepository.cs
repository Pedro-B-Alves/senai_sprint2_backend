using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo TipoDeHabilidadeRepository
    /// </summary>
    interface ITipoDeHabilidadeRepository
    {
        /// <summary>
        /// Lista todos os tipos de habilidades
        /// </summary>
        /// <returns>Uma lista de tipos de habilidades</returns>
        List<TipoDeHabilidade> Listar();

        /// <summary>
        /// Busca um tipo de habilidade através do seu ID
        /// </summary>
        /// <param name="id">ID do tipo de habilidade que será buscado</param>
        /// <returns>Um tipo de habilidade buscado</returns>
        TipoDeHabilidade BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo tipo de habilidade
        /// </summary>
        /// <param name="novoTipoHab">Objeto novoTipoHab que será cadastrado</param>
        void Cadastrar(TipoDeHabilidade novoTipoHab);

        /// <summary>
        /// Atualiza um tipo de habilidade existente
        /// </summary>
        /// <param name="id">ID do tipo de habilidade que será atualizado</param>
        /// <param name="tipoHabAtualizada">Objeto tipoHabAtualizada com as novas informações</param>
        void Atualizar(int id, TipoDeHabilidade tipoHabAtualizada);

        /// <summary>
        /// Deleta um tipo de habilidade existente
        /// </summary>
        /// <param name="id">ID do tipo de habilidade que será deletado</param>
        void Deletar(int id);
    }
}
