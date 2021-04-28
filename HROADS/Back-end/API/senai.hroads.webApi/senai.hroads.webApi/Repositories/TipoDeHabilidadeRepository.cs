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
    /// Classe responsável pelo repositório dos Tipos De Habilidade
    /// </summary>
    public class TipoDeHabilidadeRepository : ITipoDeHabilidadeRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        HroadsContext ctx = new HroadsContext();

        /// <summary>
        /// Atualiza um tipo de habilidade existente
        /// </summary>
        /// <param name="id">ID do tipo de habilidade que será atualizado</param>
        /// <param name="tipoHabAtualizada">Objeto tipoHabAtualizada com as novas informações</param>
        public void Atualizar(int id, TipoDeHabilidade tipoHabAtualizada)
        {
            // Busca um tipo de habilidade através do id
            TipoDeHabilidade TipoHabBuscado = ctx.TipoDeHabilidades.Find(id);

            // Verifica se o Tipo do tipo de habilidade foi informado
            if (tipoHabAtualizada.Tipo != null)
            {
                // Atribui os novos valores aos campos existentes
                TipoHabBuscado.Tipo = tipoHabAtualizada.Tipo;
            }

            // Atualiza o tipo de habilidade que foi buscado
            ctx.TipoDeHabilidades.Update(TipoHabBuscado);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um tipo de habilidade através do seu ID
        /// </summary>
        /// <param name="id">ID do tipo de habilidade que será buscado</param>
        /// <returns>Um tipo de habilidade buscado</returns>
        public TipoDeHabilidade BuscarPorId(int id)
        {
            // Retorna o primeiro tipo de habilidade encontrado para o ID informado
            return ctx.TipoDeHabilidades.FirstOrDefault(t => t.IdTipoHab == id);
        }

        /// <summary>
        /// Cadastra um novo tipo de habilidade
        /// </summary>
        /// <param name="novoTipoHab">Objeto novoTipoHab que será cadastrado</param>
        public void Cadastrar(TipoDeHabilidade novoTipoHab)
        {
            // Adiciona este novoTipoHab
            ctx.TipoDeHabilidades.Add(novoTipoHab);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um tipo de habilidade existente
        /// </summary>
        /// <param name="id">ID do tipo de habilidade que será deletado</param>
        public void Deletar(int id)
        {
            // Busca um tipo de habilidade através do seu id
            TipoDeHabilidade tipoHabBuscado = ctx.TipoDeHabilidades.Find(id);

            // Remove o tipo de habilidade que foi buscado
            ctx.TipoDeHabilidades.Remove(tipoHabBuscado);

            // Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os tipos de habilidades
        /// </summary>
        /// <returns>Uma lista de tipos de habilidades</returns>
        public List<TipoDeHabilidade> Listar()
        {
            // Retorna uma lista com todos os tipos de habilidades
            return ctx.TipoDeHabilidades.ToList();
        }
    }
}
