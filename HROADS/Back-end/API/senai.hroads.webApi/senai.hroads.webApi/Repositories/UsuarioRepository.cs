using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            if (usuarioAtualizado.Email != null && usuarioAtualizado.Senha != null && usuarioAtualizado.IdTipoUsuario != null)
            {
                usuarioBuscado.Email = usuarioAtualizado.Email;
                usuarioBuscado.Senha = usuarioAtualizado.Senha;
                usuarioBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;
            }

            ctx.Usuarios.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int id)
        {
            // Retorna a usuario buscada
            return ctx.Usuarios.FirstOrDefault(t => t.IdUsuario == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            //Adiciona nova Classe
            ctx.Usuarios.Add(novoUsuario);

            //Salva as informações que serão salvas no BD
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            ctx.Usuarios.Remove(usuarioBuscado);

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();

        }

        public Usuario BuscarPorEmailSenha(string email, string senha)
        {
           return ctx.Usuarios.FirstOrDefault(t => t.Email == email && t.Senha == senha);
            
        }
    }
}
