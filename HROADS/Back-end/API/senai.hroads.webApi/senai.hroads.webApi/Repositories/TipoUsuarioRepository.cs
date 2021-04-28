using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuarios.Find(id);

            if (tipoUsuarioAtualizado.Tipo != null)
            {
                tipoUsuarioBuscado.Tipo = tipoUsuarioAtualizado.Tipo;
            }

            ctx.TipoUsuarios.Update(tipoUsuarioBuscado);

            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPorId(int id)
        {
            // Retorna a classe buscada
            return ctx.TipoUsuarios.FirstOrDefault(t => t.IdTipoUsuario == id);
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            //Adiciona nova Classe
            ctx.TipoUsuarios.Add(novoTipoUsuario);

            //Salva as informações que serão salvas no BD
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TipoUsuario TipoUsuarioBuscado = ctx.TipoUsuarios.Find(id);

            ctx.TipoUsuarios.Remove(TipoUsuarioBuscado);

            ctx.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuarios.ToList();

        }
    }

}
