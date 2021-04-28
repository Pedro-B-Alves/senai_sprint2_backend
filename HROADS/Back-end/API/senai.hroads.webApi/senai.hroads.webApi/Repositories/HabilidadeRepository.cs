using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório das Habilidades
    /// </summary>
    public class HabilidadeRepository : IHabilidadeRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        HroadsContext ctx = new HroadsContext();

        /// <summary>
        /// Atualiza uma habilidade existente
        /// </summary>
        /// <param name="id">ID da habilidade que será atualizada</param>
        /// <param name="habAtualizada">Objeto habAtualizada com as novas informações</param>
        public void Atualizar(int id, Habilidade habAtualizada)
        {
            // Busca uma habilidade através do id
            Habilidade HabBuscada = ctx.Habilidades.Find(id);

            // Verifica se a habilidade foi informada
            if (habAtualizada.Habilidade1 != null)
            {
                // Atribui os novos valores aos campos existentes
                HabBuscada.Habilidade1 = habAtualizada.Habilidade1;
            }

            // Atualiza a habilidade que foi buscada
            ctx.Habilidades.Update(HabBuscada);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca uma habilidade através do seu ID
        /// </summary>
        /// <param name="id">ID da habilidade que será buscada</param>
        /// <returns>Uma habilidade buscada</returns>
        public Habilidade BuscarPorId(int id)
        {
            // Retorna a primeira habilidade encontrada para o ID informado
            return ctx.Habilidades.FirstOrDefault(h => h.IdHab == id);
        }

        /// <summary>
        /// Cadastra uma nova habilidade
        /// </summary>
        /// <param name="novaHab">Objeto novaHab que será cadastrada</param>
        public void Cadastrar(Habilidade novaHab)
        {
            // Adiciona esta novaHab
            ctx.Habilidades.Add(novaHab);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma habilidade existente
        /// </summary>
        /// <param name="id">ID da habilidade que será deletada</param>
        public void Deletar(int id)
        {
            // Busca uma habilidade através do seu id
            Habilidade habBuscada = ctx.Habilidades.Find(id);

            // Remove a habilidade que foi buscada
            ctx.Habilidades.Remove(habBuscada);

            // Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as habilidades
        /// </summary>
        /// <returns>Uma lista de habilidades</returns>
        public List<Habilidade> Listar()
        {
            // Retorna uma lista com todas as habilidades
            return ctx.Habilidades.ToList();
        }
    }
}
