using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private string stringConexao = "Data Source=LAPTOP-RHR31CVJ; initial catalog=inlock_games_manha; integrated security=true";

        /// <summary>
        /// Busca um estudio através do seu id
        /// </summary>
        /// <param name="id">id do estudio que será buscado</param>
        /// <returns>Um estudio buscado ou null caso não seja encontrado</returns>
        public EstudioDomain BuscarPorId(int id)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string querySelectById = "SELECT * FROM estudios WHERE idEstudio = @ID";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader rdr para receber os valores do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // Passa o valor para o parâmetro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Verifica se o resultado da query retornou algum registro
                    if (rdr.Read())
                    {
                        // Se sim, instancia um novo objeto estudioBuscado do tipo EstudioDomain
                        EstudioDomain estudioBuscado = new EstudioDomain()
                        {
                            // Atribui à propriedade idEstudio o valor da coluna "idEstudio" da tabela do banco de dados
                            idEstudio = Convert.ToInt32(rdr["idEstudio"]),

                            // Atribui à propriedade nomeEstudio o valor da coluna "nomeEstudio" da tabela do banco de dados
                            nomeEstudio = rdr["NomeEstudio"].ToString()
                        };

                        // Retorna o estudioBuscado com os dados obtidos
                        return estudioBuscado;
                    }

                    // Se não, retorna null
                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastra um novo estudio
        /// </summary>
        /// <param name="novoEstudio">Objeto novoEstudio com as informações que serão cadastradas</param>
        public void Cadastrar(EstudioDomain novoEstudio)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryInsert = "INSERT INTO estudios(nomeEstudio) VALUES(@Nome)";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor para o parâmetro @Nome
                    cmd.Parameters.AddWithValue("@Nome", novoEstudio.nomeEstudio);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os estudios
        /// </summary>
        /// <returns>Uma lista de estudios</returns>
        public List<EstudioDomain> ListarTodos()
        {
            // Cria uma lista listaEstudios onde serão armazenados os dados
            List<EstudioDomain> listaEstudios = new List<EstudioDomain>();

            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT * FROM estudios";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader rdr para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        // Instacia um objeto estudio do tipo EstudioDomain
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            // Atribui à propriedade idEstudio o valor da primeira coluna da tabela do banco de dados
                            idEstudio = Convert.ToInt32(rdr[0]),

                            // Atribui à propriedade nomeEstudio o valor da segunda coluna da tabela do banco de dados
                            nomeEstudio = rdr[1].ToString()
                        };

                        // Adiciona o objeto estudio à lista listaEstudios
                        listaEstudios.Add(estudio);
                    }
                }
            }

            // Retorna a lista de estudios
            return listaEstudios;
        }
    }
}
