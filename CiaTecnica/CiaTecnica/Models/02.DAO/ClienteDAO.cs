using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CiaTecnica.Models
{
    public class ClienteDAO : IRepositorio<Cliente>
    {
        /// <summary>
        ///     Variavel contendo instrunção Select (sql) para obter todos os registros da tabela
        ///     Esta variávia é uma constante para facilitar na construção dos métodos listar todos
        ///     e listar objetos por uma condição qualquer
        /// </summary>
        #region constante
        private readonly string sqlSelect = "SELECT IdCliente      " + "\r" +
                                            "     , NrCpfCnPj      " + "\r" +
                                            "     , NmClienteRazao " + "\r" +
                                            "     , NmSobreFantasia" + "\r" +
                                            "     , TpPessoa       " + "\r" +
                                            "     , DtNascimento   " + "\r" +
                                            "     , NrCep          " + "\r" +
                                            "     , NmLogradouro   " + "\r" +
                                            "     , NrNumero       " + "\r" +
                                            "     , NmComplemento  " + "\r" +
                                            "     , NmBairro       " + "\r" +
                                            "     , NmCidade       " + "\r" +
                                            "     , NmUF           " + "\r" +
                                            "  FROM Cliente        " + "\r" +
                                            "";
        #endregion

        DbContexto oContexto = new DbContexto();

        /// <summary>Método responsável em presistir inclusão (insert) do objeto no banco de dados</summary>
        /// <param name="oCliente">objeto com dados (atributos) do cliente</param>
        private void inserirDados(Cliente oCliente)
        {
            var strQuery = "";
            try
            {
                strQuery += " INSERT INTO Cliente         " + "\r" +
                            "           ( NrCpfCnPj       " + "\r" +
                            "           , NmClienteRazao  " + "\r" +
                            "           , NmSobreFantasia " + "\r" +
                            "           , TpPessoa        " + "\r" +
                            "           , DtNascimento    " + "\r" +
                            "           , NrCep           " + "\r" +
                            "           , NmLogradouro    " + "\r" +
                            "           , NrNumero        " + "\r" +
                            "           , NmComplemento   " + "\r" +
                            "           , NmBairro        " + "\r" +
                            "           , NmCidade        " + "\r" +
                            "           , NmUF            " + "\r" +
                            "           )                 " + "\r" +
                            "    VALUES ('" + oCliente.NrCpfCnpj.ToString() + "'" + "\r" +
                            "         ,  '" + oCliente.NmClienteRazao.ToString().ToUpper() + "'" + "\r" +
                            "         ,  '" + oCliente.NmSobreFantasia.ToString().ToUpper() + "'" + "\r" +
                            "         ,  '" + oCliente.TpPessoa + "'" + "\r" +
                            "         ,  '" + formatarData_yyyyMMdd(oCliente.DtNascimento.ToString()) + "'" + "\r" +
                            "         ,  '" + oCliente.NrCep.ToString().ToUpper() + "'" + "\r" +
                            "         ,  '" + oCliente.NmLogradouro.ToString().ToUpper() + "'" + "\r" +
                            "         ,  '" + oCliente.NrNumero + "'" + "\r" +
                            "         ,  '" + oCliente.NmComplemento.ToString().ToUpper() + "'" + "\r" +
                            "         ,  '" + oCliente.NmBairro.ToString().ToUpper() + "'" + "\r" +
                            "         ,  '" + oCliente.NmCidade.ToString().ToUpper() + "'" + "\r" +
                            "         ,  '" + oCliente.NmUF.ToString().ToUpper() + "'" + "\r" +
                            "            )" + "\r" +
                            "";
                using (oContexto = new DbContexto())
                {
                    oContexto.ExecutaComando(strQuery);
                }
            }
            catch (Exception e)
            {
                // throw;
                oCliente.oRetorno.Erro = true;
                oCliente.oRetorno.Mensagem = "Erro DataBase (insert): " + e.Message + "<br /><br />";
                oCliente.oRetorno.Mensagem = oCliente.oRetorno.Mensagem + "Entre em contato com o suporte do sitema. ";
            }

        }

        /// <summary>Método responsável em presistir alterção (update) do objeto no banco de dados</summary>
        /// <param name="oCliente">objeto com dados (atributos) do cliente</param>
        private void alterarDados(Cliente oCliente)
        {
            var strQuery = "";
            try
            {
                strQuery += "update  Cliente set   ";
                strQuery += string.Format("       NrCpfCnpj       = '{0}', ", oCliente.NrCpfCnpj.Trim().ToUpper())      + "\r";
                strQuery += string.Format("       NmClienteRazao  = '{0}', ", oCliente.NmClienteRazao.Trim().ToUpper()) + "\r";
                strQuery += string.Format("       NmSobreFantasia = '{0}', ", oCliente.NmSobreFantasia.Trim().ToUpper()) + "\r";
                strQuery += string.Format("       TpPessoa        = '{0}', ", oCliente.TpPessoa)                         + "\r";
                strQuery += string.Format("       DtNascimento    = '{0}', ", oCliente.DtNascimento)                     + "\r";
                strQuery += string.Format("       NrCep           = '{0}', ", oCliente.NrCep.Trim().ToUpper())           + "\r";
                strQuery += string.Format("       NmLogradouro    = '{0}', ", oCliente.NmLogradouro.Trim().ToUpper())    + "\r";
                strQuery += string.Format("       NrNumero        = '{0}', ", oCliente.NrNumero)                         + "\r";
                strQuery += string.Format("       NmComplemento   = '{0}', ", oCliente.NmComplemento.Trim().ToUpper())   + "\r";
                strQuery += string.Format("       NmBairro        = '{0}', ", oCliente.NmBairro.Trim().ToUpper())        + "\r";
                strQuery += string.Format("       NmCidade        = '{0}', ", oCliente.NmCidade.Trim().ToUpper())        + "\r";
                strQuery += string.Format("       NmUF            = '{0}'  ", oCliente.NmUF.Trim().ToUpper())            + "\r";
                strQuery += string.Format(" where IdCliente = " + oCliente.IdCliente);
            }
            catch (Exception e)
            {
                // throw;
                oCliente.oRetorno.Erro = true;
                oCliente.oRetorno.Mensagem = "Erro DataBase (update): " + e.Message + "<br /><br />";
                oCliente.oRetorno.Mensagem = oCliente.oRetorno.Mensagem + "Entre em contato com o suporte do sitema. ";
            }
            using (oContexto = new DbContexto())
            {
                oContexto.ExecutaComando(strQuery);
            }
        }

        /// <summary>
        ///     Método responsável em definir se a persitência do objeto é uma Inclusão ou uma Alteração
        /// </summary>
        /// <param name="oEntidade">objeto com dados (atributos) do cliente</param>
        public void salvarDados(Cliente oEntidade)
        {
            // Validar ordem de Serviço
            oEntidade = oEntidade.consistirDados(oEntidade);

            if (oEntidade.oRetorno.Erro == false)
            {
                if (oEntidade.IdCliente > 0)
                    alterarDados(oEntidade);
                else
                    inserirDados(oEntidade);
            }

        }

        /// <summary>Método responsável em presistir exclusão (delete) do objeto no banco de dados</summary>
        /// <param name="oCliente">objeto com dados (atributos) do cliente</param>
        public void excluirDados(Cliente oEntidade)
        {
            var strQuery = string.Format(" DELETE Cliente where IdCliente = '{0}'", oEntidade.IdCliente);
            using (oContexto = new DbContexto())
            {
                oContexto.ExecutaComando(strQuery);
            }

        }

        /// <summary>
        ///     Metodo responsável em listar um objeto (registro) espéfico do bando de dados
        ///     comforme parâmetro informado na chamado do mesmo.
        /// </summary>
        /// <param name="ID">Id do cliente</param>
        /// <returns>Um objeto específico conforme parametro enviando na chamada do mesmo</returns>
        public Cliente ListarPorId(string Id)
        {
            var sqlQuery = sqlSelect + "  where iDCliente = " + int.Parse(Id.ToString());
            var oClientes = TransformarReaderEmListaDeObjetos(oContexto.ExecutarComandoDataReader(sqlQuery));

            return oClientes[0];
        }

        /// <summary>
        ///     Método responsável em listar todos os registros do banco de dados
        /// </summary>
        /// <returns>Lista de todos os objetos (resgistro) do banco de dados</returns>
        public IEnumerable<Cliente> ListarTodos()
        {
            return TransformarReaderEmListaDeObjetos(oContexto.ExecutarComandoDataReader(sqlSelect));
        }

        /// <summary>
        ///     Método responsável em transformar um objeto DataReader (parametro)
        ///     em uma lista genérica de objetos.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>List genérica de objetos (List)</returns>
        private List<Cliente> TransformarReaderEmListaDeObjetos(SqlDataReader reader)
        {
            var oAlunos = new List<Cliente>();
            while (reader.Read())
            {
                var tempObj = new Cliente()
                {
                    IdCliente        = ConvertReader.ConvertInt(reader["IdCliente"].ToString()),
                    NrCpfCnpj        = (string)reader["NrCpfCnPj"] ?? "",
                    NmClienteRazao   = (string)reader["NmClienteRazao"] ?? "",
                    NmSobreFantasia  = (string)reader["NmSobreFantasia"] ?? "",
                    TpPessoa         = ConvertReader.ConvertInt(reader["TpPessoa"].ToString()),
                    DtNascimento     = ConvertReader.ConvertDateTime(reader["DtNascimento"].ToString()),
                    NrCep            = (string)reader["NrCep"] ?? "",
                    NmLogradouro     = (string)reader["NmLogradouro"] ?? "",
                    NrNumero         = ConvertReader.ConvertInt(reader["NrNumero"].ToString()),
                    NmComplemento    = (string)reader["NmComplemento"] ?? "",
                    NmBairro         = (string)reader["NmBairro"] ?? "",
                    NmCidade         = (string)reader["NmCidade"] ?? "",
                    NmUF             = (string)reader["NmUF"] ?? "",
                };
                oAlunos.Add(tempObj);
            }
            reader.Close();
            return oAlunos;
        }

        /// <summary>
        /// Método responsável para formatar data para presistencia (yyyy-MM-dd)
        /// </summary>
        /// <param name="dtOrigem">Data no formato dd/MM/aaaa hh:mm:ss:mmm(datetim<e)/param>
        /// <returns>data (string) no formato yyyy-MM-dd</returns>
        private string formatarData_yyyyMMdd(string dtOrigem)
        {
            string dataFormatada = "";

            dataFormatada = dtOrigem.Substring(6, 4);
            dataFormatada = dataFormatada + "-";
            dataFormatada = dataFormatada + dtOrigem.Substring(3, 2);
            dataFormatada = dataFormatada + "-";
            dataFormatada = dataFormatada + dtOrigem.Substring(0, 2);

            return dataFormatada;
        }
    }
}