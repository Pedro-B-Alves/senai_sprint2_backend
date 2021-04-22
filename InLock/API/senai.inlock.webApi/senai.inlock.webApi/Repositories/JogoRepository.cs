using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string stringConexao = "Data Source=LAPTOP-RHR31CVJ; initial catalog=inlock_games_manha; integrated security=true";

        /// <summary>
        /// Busca um jogo através do seu id
        /// </summary>
        /// <param name="id">id do jogo que será buscado</param>
        /// <returns>Um jogo buscado ou null caso não seja encontrado</returns>
        public JogoDomain BuscarPorId(int id)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string querySelectById = "SELECT * FROM jogos WHERE idJogo = @ID";

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
                        // Se sim, instancia um novo objeto jogoBuscado do tipo JogoDomain
                        JogoDomain jogoBuscado = new JogoDomain()
                        {
                            // Atribui à propriedade idJogo o valor da coluna "idJogo" da tabela do banco de dados
                            idJogo = Convert.ToInt32(rdr["idJogo"]),

                            // Atribui à propriedade nomeJogo o valor da coluna "nomeJogo" da tabela do banco de dados
                            nomeJogo = rdr["nomeJogo"].ToString(),

                            descricao = rdr["descricao"].ToString(),

                            dataLancamento = Convert.ToDateTime(rdr["dataLancamento"]),

                            valor = Convert.ToInt32(rdr["valor"]),
                        };

                        // Retorna o jogoBuscado com os dados obtidos
                        return jogoBuscado;
                    }

                    // Se não, retorna null
                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo">Objeto novoJogo com as informações que serão cadastradas</param>
        public void Cadastrar(JogoDomain novoJogo)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryInsert = "INSERT INTO jogos(nomeJogo,descricao,dataLancamento,valor,idEstudio) VALUES(@Nome, @Descricao, @Data, @Valor, @IdEstudio)";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor para o parâmetro @Nome
                    cmd.Parameters.AddWithValue("@Nome", novoJogo.nomeJogo);
                    // Passa o valor para o parâmetro @Descricao
                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.descricao);

                    cmd.Parameters.AddWithValue("@Data", novoJogo.dataLancamento);

                    cmd.Parameters.AddWithValue("@Valor", novoJogo.valor);

                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.idEstudio);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Uma lista de jogos</returns>
        public List<JogoDomain> ListarTodos()
        {
            // Cria uma lista listaJogos onde serão armazenados os dados
            List<JogoDomain> listaJogos = new List<JogoDomain>();

            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT * FROM jogos";

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
                        // Instacia um objeto jogo do tipo JogoDomain
                        JogoDomain jogo = new JogoDomain()
                        {
                            // Atribui à propriedade idJogo o valor da primeira coluna da tabela do banco de dados
                            idJogo = Convert.ToInt32(rdr[0]),

                            // Atribui à propriedade nomeJogo o valor da segunda coluna da tabela do banco de dados
                            nomeJogo = rdr[1].ToString(),

                            descricao = rdr[2].ToString(),

                            dataLancamento = Convert.ToDateTime(rdr[3]),

                            valor = Convert.ToInt32(rdr[4]),

                            idEstudio = Convert.ToInt32(rdr[5]),
                        };

                        // Adiciona o objeto jogo à lista listaJogos
                        listaJogos.Add(jogo);
                    }
                }
            }

            // Retorna a lista de jogos
            return listaJogos;
        }
    }
}
