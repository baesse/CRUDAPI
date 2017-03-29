using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDAAPI.Models
{
    public class Cliente
    {
       
        public int Cpf { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Identidade    { get; set; }
        public string TituloEleitor { get; set; }
        public string NomeMae { get; set; }
        public string NomePai { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }

        public Cliente()
        {

        }

        public Cliente(int Cpf ,string Nome, string Sobrenome, string Identidade, string TituloEleitor, string NomeMae, string NomePa,string Endereco,string Numero)
        {
            this.Cpf = Cpf;
            this.Nome = Nome;
            this.Sobrenome = Sobrenome;
            this.Identidade = Identidade;
            this.TituloEleitor = TituloEleitor;
            this.NomeMae = NomeMae;
            this.NomePai = NomePa;
            this.Endereco = Endereco;
            this.Numero = Numero;

        }

        public void InseriNovoCliente(Cliente NovoCliente)
        {
            MySqlConnection conexao = Models.Banco.GetConexao();
            MySqlCommand Comando = Models.Banco.GetCommando(conexao);
            Comando.CommandText = "INSERT INTO CAD_USUARIO (CPF,NOME,SOBRENOME,IDENTIDADE,TITULOELEITOR,NOMEMAE,NOMEPAI,ENDERECO,NUMERO) VALUES (@CPF,@NOME,@SOBRENOME,@INDETIDADE,@TITULOELEITO,@NOMEMAE,@NOMEPAI,@ENDERECO,@NUMERO)";
            Comando.Parameters.AddWithValue("@CPF", NovoCliente.Cpf);
            Comando.Parameters.AddWithValue("@NOME", NovoCliente.Nome);
            Comando.Parameters.AddWithValue("@SOBRENOME", NovoCliente.Sobrenome);
            Comando.Parameters.AddWithValue("@INDETIDADE", NovoCliente.Identidade);
            Comando.Parameters.AddWithValue("@TITULOELEITO", NovoCliente.TituloEleitor);
            Comando.Parameters.AddWithValue("@NOMEMAE", NovoCliente.NomeMae);
            Comando.Parameters.AddWithValue("@NOMEPAI", NovoCliente.NomePai);
            Comando.Parameters.AddWithValue("@ENDERECO", NovoCliente.Endereco);
            Comando.Parameters.AddWithValue("@NUMERO", NovoCliente.Numero);

            Comando.ExecuteNonQuery();
            conexao.Close();
            
        }



        public Cliente BuscaCliente(int cpf)
        {
            MySqlConnection conexao = Models.Banco.GetConexao();
            MySqlCommand Comando = Models.Banco.GetCommando(conexao);
            Comando.CommandText = "select CPF,NOME,SOBRENOME,IDENTIDADE,TITULOELEITOR,NOMEMAE,NOMEPAI,ENDERECO,NUMERO from cad_usuario where cpf=@cpf";
            Comando.Parameters.AddWithValue("@CPF", cpf);

            MySqlDataReader reader = Banco.GetReader(Comando);
           

            while (reader.Read()){

                Cliente cliente = new Cliente(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7),reader.GetString(8));
                return cliente;

            }
            return null;


            
        }
        

        public Cliente ListaCliente(int id)
        {
            MySqlConnection conexao = Models.Banco.GetConexao();
            MySqlCommand Comando = Models.Banco.GetCommando(conexao);
            Comando.CommandText = "select CPF,NOME,SOBRENOME,IDENTIDADE,TITULOELEITOR,NOMEMAE,NOMEPAI,ENDERECO,NUMERO from cad_usuario where cpf=@cpf";
            Comando.Parameters.AddWithValue("@CPF", id);

            MySqlDataReader reader = Banco.GetReader(Comando);


            while (reader.Read())
            {

                Cliente cliente = new Cliente(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8));
                return cliente;

            }
            return null;

        }


    }
}