using APIFilmes.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace APIFilmes.Helpers
{
    public class SQLHelper
    {
        private readonly MySqlConnection conexao = new MySqlConnection("server=localhost;user=root;database=Filmedb;password=root;");

        public bool existeTabela(string tabela)
        {
            var strQuery = $"SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = 'FilmeDb' AND table_name = '{tabela}'";
            var vComando = new MySqlCommand(strQuery, conexao);
            MySqlDataReader reader = (vComando.ExecuteReader());
            while (reader.Read())

            {
                int count = reader.GetInt32(0);

                return count == 1;
            }
            return false;
        }

    }
}
