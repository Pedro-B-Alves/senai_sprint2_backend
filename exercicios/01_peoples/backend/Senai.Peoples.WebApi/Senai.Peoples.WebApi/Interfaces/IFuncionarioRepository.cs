using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IFuncionarioRepository
    {
        List<FuncionarioDomain> ListarTodos();

        FuncionarioDomain BuscarPorId(int id);

        void Cadastrar(FuncionarioDomain novoFuncionario);

        void AtualizarId(int id, FuncionarioDomain funcionario);

        void Deletar(int id);
    }
}
