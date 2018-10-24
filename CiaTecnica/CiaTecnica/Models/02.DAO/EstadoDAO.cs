using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CiaTecnica.Models
{
    public class EstadoDAO
    {
        private readonly string sqlSelect = "SELECT IdEstado          " + "\r" +
                                            "     , NmUF              " + "\r" +
                                            "     , NmEstado          " + "\r" +
                                            "  FROM Estado            ";

        DbContexto oContexto = new DbContexto();


        /// <summary>
        ///     Método responsável em listar todos os registros do banco de dados
        /// </summary>
        /// <returns>Lista de todos os objetos (resgistro) do banco de dados</returns>
        public IEnumerable<Estado> ListarTodos()
        {
            return TransformarReaderEmListaDeObjetos(oContexto.ExecutarComandoDataReader(sqlSelect));
        }

        /// <summary>
        ///     Método responsável em transformar um objeto DataReader (parametro)
        ///     em uma lista genérica de objetos.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>List genérica de objetos (List)</returns>
        private List<Estado> TransformarReaderEmListaDeObjetos(SqlDataReader reader)
        {
            var oListaEstado = new List<Estado>();

            while (reader.Read())
            {
                var tempObj = new Estado()
                {
                    IdEstado = ConvertReader.ConvertInt(reader["IdEstado"].ToString()),
                    NmUF = (string)reader["NmUF"] ?? "",
                    NmEstado  = (string)reader["NmEstado"] ?? ""
                };

                oListaEstado.Add(tempObj);
            }

            return oListaEstado;
        }

    }
}