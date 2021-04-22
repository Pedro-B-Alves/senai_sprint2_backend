using senai.inlock.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Interfaces
{
    interface IEstudioRepository
    {
        /// <summary>
        /// Retorna todos os estudios
        /// </summary>
        /// <returns>Uma lista de estudios</returns>
        List<EstudioDomain> ListarTodos();

        /// <summary>
        /// Busca um estudio através do seu id
        /// </summary>
        /// <param name="id">id do estudio que será buscado</param>
        /// <returns>Um objeto do tipo EstudioDomain que foi buscado</returns>
        EstudioDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo estudio
        /// </summary>
        /// <param name="novoEstudio">Objeto novoEstudio que será cadastrado</param>
        void Cadastrar(EstudioDomain novoEstudio);
    }
}
