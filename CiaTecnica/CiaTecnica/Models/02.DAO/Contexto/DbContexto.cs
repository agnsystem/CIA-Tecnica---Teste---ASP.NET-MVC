using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CiaTecnica.Models
{
    public class DbContexto : IDisposable
    {
        private readonly SqlConnection minhaConexao;

        // >>> Construtor (executa toda vez a classe for estanciada)
        public DbContexto()
        {
            //minhaConexao = new SqlConnection(ConfigurationManager.ConnectionStrings["dbCiaTecnica"].ConnectionString);
            minhaConexao = new SqlConnection(@"data source=.\SQLEXPRESS;Initial Catalog=dbCiaTecnica;User ID=sa;Password=express@2008");
            minhaConexao.Open();
        }

        public void ExecutaComando(string strQuery)
        {
            var cmdCommando = new SqlCommand
            {
                CommandText = strQuery,
                CommandType = CommandType.Text,
                Connection = minhaConexao
            };
            cmdCommando.ExecuteNonQuery();
        }

        public SqlDataReader ExecutarComandoDataReader(string strQuery)
        {
            var cmdComando = new SqlCommand(strQuery, minhaConexao);
            return cmdComando.ExecuteReader();
        }

        public void Dispose()
        {
            if (minhaConexao.State == ConnectionState.Open)
            {
                minhaConexao.Close();
            }
        }
    }
}