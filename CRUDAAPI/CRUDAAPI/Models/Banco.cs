using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDAAPI.Models
{
    public class Banco
    {
        public static MySqlConnection GetConexao()
        {
            MySqlConnection Conexao = new MySqlConnection("Server=localhost;Database=apiap;Uid=root;Pwd=75395146;");
            Conexao.Open();
            return Conexao;

        }

        public static MySqlCommand GetCommando(MySqlConnection Conexao)
        {
            MySqlCommand Comando = Conexao.CreateCommand();
            return Comando;

        }

        public static MySqlDataReader GetReader(MySqlCommand Comando)
        {
            MySqlDataReader reader = Comando.ExecuteReader();
            return reader;
        }

        public static void FecharConexao()
        {
            

        }
    }
}