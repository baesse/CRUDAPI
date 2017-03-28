using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CRUDAAPI.Models
{
    public class ConfigBanco
    {
        public MysqlConnection GetConexao()
        {
            MysqlConnection Conexao = new MysqlConnection();
            Conexao.Open();
            return Conexao;

        }

        public MysqlCommand GetCommando( MysqlConnection Conexao)
        {
            MysqlComman Comando = Conexao.CreateCommand();
            return Comando;

        }

        public MysqlDataReader GetReader(MysqlCommand Comando)
        {
            MysqlDataReader reader = Comando.ExcetuteReader();
            return reader;
        }

    }
}