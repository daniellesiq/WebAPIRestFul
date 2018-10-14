using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
namespace WebAPI.Util
{
    public class DAL
    {
        /*Strings de conecção com banco de dados - Mysql*/
        private static string Server = "localhost";
        private static string Database = "clientedb";
        private static string User = "root";
        private static string Password = "";
        private MySqlConnection Connection;

        private string ConnectString = $"Server={Server};Database={Database};Uid={User};Pwd={Password};Sslmode=none;charset=utf8;";

        /*Método para fazer a conexão com o BD*/
        public DAL()
        {
            Connection = new MySqlConnection(ConnectString);
            Connection.Open();
        }

        /*Método que executa os comandos no BD*/
        public void ExecutaComandosSql(string sql)
        {
            MySqlCommand command = new MySqlCommand(sql, Connection);
            command.ExecuteNonQuery();
        }

        public DataTable RetornaDataTable(string sql)
        {
            MySqlCommand command = new MySqlCommand(sql, Connection);
            MySqlDataAdapter DataAdapter = new MySqlDataAdapter(command);
            DataTable Dados = new DataTable();
            DataAdapter.Fill(Dados);
            return Dados;
        }
    }
}
