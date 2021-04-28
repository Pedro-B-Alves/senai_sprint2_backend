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
    /// Classe responsável pelo repositório dos Personagens
    /// </summary>
    public class PersonagemRepository : IPersonagemRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        HroadsContext ctx = new HroadsContext();

        /// <summary>
        /// Atualiza um personagem existente
        /// </summary>
        /// <param name="id">ID do personagem que será atualizado</param>
        /// <param name="persoAtualizado">Objeto persoAtualizado com as novas informações</param>
        public void Atualizar(int id, Personagem persoAtualizado)
        {
            // Busca um personagem através do id
            Personagem persoBuscado = ctx.Personagems.Find(id);

            // Verifica se os atributos do personagem foram informados
            if ((persoAtualizado.Nome != null) && (persoAtualizado.CapMana != null) && (persoAtualizado.CapVida != null) && (persoAtualizado.DataAtualizacao != null))
            {
                // Atribui os novos valores aos campos existentes
                persoBuscado.Nome = persoAtualizado.Nome;
                persoBuscado.CapMana = persoAtualizado.CapMana;
                persoBuscado.CapVida = persoAtualizado.CapVida;
                persoBuscado.DataAtualizacao = persoAtualizado.DataAtualizacao;
            }

            // Atualiza o personagem que foi buscado
            ctx.Personagems.Update(persoBuscado);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca uma habilidade através do seu ID
        /// </summary>
        /// <param name="id">ID do personagem que será buscado</param>
        /// <returns>Um personagem buscado</returns>
        public Personagem BuscarPorId(int id)
        {
            // Retorna o primeiro personagem encontrado para o ID informado
            return ctx.Personagems.FirstOrDefault(p => p.IdPersonagem == id);
        }

        /// <summary>
        /// Cadastra um novo personagem
        /// </summary>
        /// <param name="novoPerso">Objeto novoPerso que será cadastrado</param>
        public void Cadastrar(Personagem novaPerso)
        {
            // Adiciona esta novaPerso
            ctx.Personagems.Add(novaPerso);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um personagem existente
        /// </summary>
        /// <param name="id">ID do personagem que será deletado</param>
        public void Deletar(int id)
        {
            // Busca um personagem através do seu id
            Personagem persoBuscada = ctx.Personagems.Find(id);

            // Remove o personagem que foi buscado
            ctx.Personagems.Remove(persoBuscada);

            // Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os personagens
        /// </summary>
        /// <returns>Uma lista de personagens</returns>
        public List<Personagem> Listar()
        {
            // Retorna uma lista com todos os personagens
            return ctx.Personagems.ToList();
        }
    }
}
