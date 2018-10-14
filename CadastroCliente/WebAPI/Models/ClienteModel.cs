using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Util;

namespace WebAPI.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Data_Cadastro { get; set; }
        public string Cpf_Cnpj { get; set; }
        public string Data_Nascimento { get; set; }
        public string Tipo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

        public void RegistrarCliente()
        {
            DAL objDAL = new DAL();

            string sql = "INSERT INTO clientes(Bairro,Cep,Cidade,Complemento,Cpf_Cnpj,Data_Cadastro,Data_Nascimento,Email,Logradouro,Nome,Numero,Telefone,Tipo,UF)" +
                          $"VALUES('{Bairro}', '{Cep}','{Cidade}','{Complemento}','{Cpf_Cnpj}','{DateTime.Parse(Data_Cadastro).ToString("yyyy/MM/dd")}','{DateTime.Parse(Data_Nascimento).ToString("yyyy/MM/dd")}'," +
                          $"'{Email}','{Logradouro}','{Nome}','{Numero}','{Telefone}','{Tipo}', '{UF}')";

            objDAL.ExecutaComandosSql(sql);
        }

        public List<ClienteModel> Listagem()
        {
            List<ClienteModel> lista = new List<ClienteModel>();
            ClienteModel item;
            DAL objDAL = new DAL();

            string sql = "SELECT * FROM CLIENTES ORDER BY NOME ASC";
            DataTable dados = objDAL.RetornaDataTable(sql);

            for (int i = 0; i < dados.Rows.Count; i++)
            {
                item = new ClienteModel()
                {
                    Id = int.Parse(dados.Rows[i]["Id"].ToString()),
                    Bairro = dados.Rows[i]["Bairro"].ToString(),
                    Cep = dados.Rows[i]["Cep"].ToString(),
                    Cidade = dados.Rows[i]["Cidade"].ToString(),
                    Complemento = dados.Rows[i]["Complemento"].ToString(),
                    Cpf_Cnpj = dados.Rows[i]["Cpf_Cnpj"].ToString(),                    
                    Data_Cadastro = DateTime.Parse(dados.Rows[i]["Data_Cadastro"].ToString()).ToString("dd/MM/yyyy"),                    
                    Data_Nascimento = DateTime.Parse(dados.Rows[i]["Data_Nascimento"].ToString()).ToString("dd/MM/yyyy"),
                    Email = dados.Rows[i]["Email"].ToString(),
                    Logradouro = dados.Rows[i]["Logradouro"].ToString(),
                    Nome = dados.Rows[i]["Nome"].ToString(),
                    Numero = dados.Rows[i]["Numero"].ToString(),
                    Telefone = dados.Rows[i]["Telefone"].ToString(),
                    Tipo = dados.Rows[i]["Tipo"].ToString(), 
                    UF = dados.Rows[i]["UF"].ToString()
                };
                lista.Add(item);
            }
            return lista;
        }

        public ClienteModel RetornaClientePorId(int id)
        {
            ClienteModel item;
            DAL objDAL = new DAL();

            string sql = $"SELECT * FROM clientes WHERE id = {id}";
            DataTable dados = objDAL.RetornaDataTable(sql);

            item = new ClienteModel()
            {
                Id = int.Parse(dados.Rows[0]["Id"].ToString()),
                Bairro = dados.Rows[0]["Bairro"].ToString(),
                Cep = dados.Rows[0]["Cep"].ToString(),
                Cidade = dados.Rows[0]["Cidade"].ToString(),
                Complemento = dados.Rows[0]["Complemento"].ToString(),
                Cpf_Cnpj = dados.Rows[0]["Cpf_Cnpj"].ToString(),
                Data_Cadastro = DateTime.Parse(dados.Rows[0]["Data_Cadastro"].ToString()).ToString("dd/MM/yyyy"),
                Data_Nascimento = DateTime.Parse(dados.Rows[0]["Data_Nascimento"].ToString()).ToString("dd/MM/yyyy"),
                Email = dados.Rows[0]["Email"].ToString(),
                Logradouro = dados.Rows[0]["Logradouro"].ToString(),
                Nome = dados.Rows[0]["Nome"].ToString(),
                Numero = dados.Rows[0]["Numero"].ToString(),
                Telefone = dados.Rows[0]["Telefone"].ToString(),
                Tipo = dados.Rows[0]["Tipo"].ToString(),
                UF = dados.Rows[0]["UF"].ToString()
            };
            return item;
        }

        public void AtualizarCliente()
        {
            DAL objDAL = new DAL();

            string sql = "update clientes set " +
                            $"bairro='{Bairro}'," +
                            $"cep='{Cep}'," +
                            $"cidade='{Cidade}'," +
                            $"complemento='{Complemento}'," +
                            $"cpf_cnpj='{Cpf_Cnpj}'," +                           
                            $"data_cadastro='{DateTime.Parse(Data_Cadastro).ToString("yyyy/MM/dd")}'," +                            
                            $"data_nascimento='{DateTime.Parse(Data_Nascimento).ToString("yyyy/MM/dd")}'," +
                            $"email='{Email}'," +
                            $"logradouro='{Logradouro}'," +
                            $"nome='{Nome}'," +
                            $"numero='{Numero}'," +
                            $"telefone='{Telefone}'," +
                            $"tipo='{Tipo}'," +
                            $"uf='{UF}' WHERE id={Id}";

            objDAL.ExecutaComandosSql(sql);
        }

        public void Excluir(int id) {
            DAL objDAL = new DAL();
            string sql = $"DELETE FROM CLIENTES WHERE id={id}";
            objDAL.ExecutaComandosSql(sql);
        }
    }
}
