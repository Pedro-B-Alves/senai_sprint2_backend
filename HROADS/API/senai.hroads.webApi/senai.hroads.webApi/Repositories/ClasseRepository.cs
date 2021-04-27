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
    /// Classe responsável pelo Repositório das Classes
    /// </summary>
    public class ClasseRepository : IClasseRepository
    {
        /// <summary>
        /// Objeto Contexto por onde serão chamados os Métodos do EF Core
        /// </summary>
        HroadsContext ctx = new HroadsContext();


        public void Atualizar(int id, Classe classeAtualizada)
        {
            Classe classeBuscada = ctx.Classes.Find(id);

            if (classeAtualizada.Classe1 != null)
            {
                classeBuscada.Classe1 = classeAtualizada.Classe1;
            }

            ctx.Classes.Update(classeBuscada);

            ctx.SaveChanges();
        }

        public Classe BuscarPorId(int id)
        {
            // Retorna a classe buscada
            return ctx.Classes.FirstOrDefault(t => t.IdClasse == id);
        }

        public void Cadastrar(Classe novaClasse)
        {
            //Adiciona nova Classe
            ctx.Classes.Add(novaClasse);
            
            //Salva as informações que serão salvas no BD
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Classe classeBuscada = ctx.Classes.Find(id);

            ctx.Classes.Remove(classeBuscada);

            ctx.SaveChanges();
        }

        public List<Classe> Listar()
        {
            return ctx.Classes.ToList();
        }
    }
}
