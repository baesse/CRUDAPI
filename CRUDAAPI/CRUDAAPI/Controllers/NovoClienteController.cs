using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace CRUDAAPI.Controllers
{
    public class NovoClienteController : ApiController
    {
        [HttpPost]
        public string IncluirNovoCliente(int Cpf,string Nome,string Sobrenome ,string Identidade, string TituloEleitor ,string NomeMae,string NomePai,string Endereco,string Numero)
        {

            Models.Cliente cliente = new Models.Cliente();
            cliente.Cpf = Cpf;
            cliente.Nome = Nome;
            cliente.Sobrenome = Sobrenome;
            cliente.Identidade = Identidade;
            cliente.TituloEleitor = TituloEleitor;
            cliente.NomeMae = NomeMae;
            cliente.NomePai = NomePai;
            cliente.Endereco = Endereco;
            cliente.Numero = Numero;
            cliente.InseriNovoCliente(cliente);


            return "Cliente inserido com sucesso";


        }

       


        public string GetCliente(int cpf)
        {
            Models.Cliente cliente = new Models.Cliente();

            cliente = cliente.BuscaCliente(cpf);


            StringBuilder clientecom = new StringBuilder();


            clientecom.Append(cliente.Nome);
            clientecom.Append(cliente.Cpf);
            clientecom.Append(cliente.Sobrenome);
            clientecom.Append(cliente.Identidade);
            clientecom.Append(cliente.TituloEleitor);
            clientecom.Append(cliente.NomeMae);
            clientecom.Append(cliente.NomePai);
            clientecom.Append(cliente.Endereco);
            clientecom.Append(cliente.Numero);
            string json = clientecom.ToString();

            return json;
            
        }


        [HttpGet]
        public string GetListaClientes(int id)
        {
            Models.Cliente cliente = new Models.Cliente();

            string jsongerado = "";

            List<Models.Cliente> lista = new List<Models.Cliente>();
            var json = JsonConvert.DeserializeObject<List<Models.Cliente>>(jsongerado);
            json = new List<Models.Cliente>();

           

            json.Add(cliente.ListaCliente(id));
            
            var json_se = JsonConvert.SerializeObject(json);

            return json_se.ToString();
        }







    }
}
