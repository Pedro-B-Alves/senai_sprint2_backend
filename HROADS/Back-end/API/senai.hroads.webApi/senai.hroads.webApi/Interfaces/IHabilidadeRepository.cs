using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo HabilidadeRepository
    /// </summary>
    interface IHabilidadeRepository
    {
        /// <summary>
        /// Lista todas as habilidades
        /// </summary>
        /// <returns>Uma lista de habilidades</returns>
        List<Habilidade> Listar();

        /// <summary>
        /// Busca uma habilidade através do seu ID
        /// </summary>
        /// <param name="id">ID da habilidade que será buscada</param>
        /// <returns>Uma habilidade buscada</returns>
        Habilidade BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova habilidade
        /// </summary>
        /// <param name="novaHab">Objeto novaHab que será cadastrada</param>
        void Cadastrar(Habilidade novaHab);

        /// <summary>
        /// Atualiza uma habilidade existente
        /// </summary>
        /// <param name="id">ID da habilidade que será atualizada</param>
        /// <param name="habAtualizada">Objeto habAtualizada com as novas informações</param>
        void Atualizar(int id, Habilidade habAtualizada);

        /// <summary>
        /// Deleta uma habilidade existente
        /// </summary>
        /// <param name="id">ID da habilidade que será deletada</param>
        void Deletar(int id);
    }
}
