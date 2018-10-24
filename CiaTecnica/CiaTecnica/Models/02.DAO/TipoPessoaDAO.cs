using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CiaTecnica.Models
{
    public class TipoPessoaDAO
    {
        private readonly string sqlSelect = "SELECT IdTipoPessoa              " + "\r" +
                                            "     , NmTipoPessoa              " + "\r" +
                                            "  FROM TipoPessoa                 ";

        DbContexto oContexto = new DbContexto();

        /// <summary>
        ///     Metodo responsável em listar um objeto (registro) espéfico do bando de dados
        ///     comforme parâmetro informado na chamado do mesmo.
        /// </summary>
        /// <param name="ID">Id do cliente</param>
        /// <returns>Um objeto específico conforme parametro enviando na chamada do mesmo</returns>
        public TipoPessoa ListarPorId(string Id)
        {
            var sqlQuery = sqlSelect + "  where IdTipoPessoa = " + int.Parse(Id.ToString());
            var oTipoPessoa = TransformarReaderEmListaDeObjetos(oContexto.ExecutarComandoDataReader(sqlQuery));

            return oTipoPessoa[0];
        }

        /// <summary>
        ///     Método responsável em listar todos os registros do banco de dados
        /// </summary>
        /// <returns>Lista de todos os objetos (resgistro) do banco de dados</returns>
        public IEnumerable<TipoPessoa> ListarTodos()
        {
            return TransformarReaderEmListaDeObjetos(oContexto.ExecutarComandoDataReader(sqlSelect));
        }

        /// <summary>
        ///     Método responsável em transformar um objeto DataReader (parametro)
        ///     em uma lista genérica de objetos.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>List genérica de objetos (List)</returns>
        private List<TipoPessoa> TransformarReaderEmListaDeObjetos(SqlDataReader reader)
        {
            var oListaTipoPessoa = new List<TipoPessoa>();

            while (reader.Read())
            {
                var tempObj = new TipoPessoa()
                {
                    IdTipoPessoa = ConvertReader.ConvertInt(reader["IdTipoPessoa"].ToString()),
                    NmTipoPessoa = (string)reader["NmTipoPessoa"] ?? ""
                };

                oListaTipoPessoa.Add(tempObj);
            }

            return oListaTipoPessoa;
        }

    }
}