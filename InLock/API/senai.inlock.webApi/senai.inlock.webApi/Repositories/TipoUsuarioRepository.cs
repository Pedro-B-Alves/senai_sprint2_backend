using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private string stringConexao = "Data Source=LAPTOP-RHR31CVJ; initial catalog=inlock_games_manha; integrated security=true";

        public tiposUsuarioDomain BuscarPorTipoUsuario(string titulo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT * FROM tiposUsuarios;";

                // comando cmd  com a query e a conexao
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@titulo", titulo);

                    con.Open();

                    // executa o comando e armazena os dados no objeto rdr
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        tiposUsuarioDomain tipoUsuario = new tiposUsuarioDomain
                        {
                            // atribuindo propiedades
                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"]),
                            titulo = rdr["titulo"].ToString()
                        };

                        // usuario buscado
                        return tipoUsuario;
                    }

                    // caso não encontre o tipo de usuario
                    return null;


                }
            }
        }
    }
}
