using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CiaTecnica.Models
{
    public class Cliente
    {
        [Display(Name = "ID")]
        [DisplayFormat(DataFormatString = "{0:0000}", ApplyFormatInEditMode = true)]
        public int IdCliente { get; set; }

        //[Required(ErrorMessage = "O CPF ou CNPJ do cliente deverá ser informado.")]
        [Display(Name = "CPF/CNPJ")]
        public string NrCpfCnpj { get; set; }

        //[Required(ErrorMessage = "O Nome ou Razão Social do cliente deverá ser informado.")]
        [Display(Name = "Nome/Razão")]
        public string NmClienteRazao { get; set; }


        //[Required(ErrorMessage = "O Sobrenome ou Nome Fantasia do cliente deverá ser informado.")]
        [Display(Name = "Sobrenome/Nome Fantasia")]
        public string NmSobreFantasia { get; set; }

        //[Required(ErrorMessage = "O Tipo de Pessoa do cliente deverá ser informado.")]
        [Display(Name = "Tipo Pessoa")]
        public int TpPessoa { get; set; }

        [Display(Name = "Nascimento")]
        public DateTime? DtNascimento { get; set; }

        //[Required(ErrorMessage = "O CEP do cliente deverá ser informado.")]
        [Display(Name = "CEP")]
        public string NrCep { get; set; }

        //[Required(ErrorMessage = "O Logradouro do cliente deverá ser informado.")]
        [Display(Name = "Logradouro")]
        public string NmLogradouro  { get; set; }

        //[Required(ErrorMessage = "O Numero do cliente deverá ser informado.")]
        [Display(Name = "Numero")]
        public int NrNumero { get; set; }

        [Display(Name = "Complemento")]
        public string NmComplemento { get; set; }

        //[Required(ErrorMessage = "O Bairro do cliente deverá ser informado.")]
        [Display(Name = "Bairro")]
        public string NmBairro { get; set; }

        //[Required(ErrorMessage = "A Cidade do cliente deverá ser informado.")]
        [Display(Name = "Cidade")]
        public string NmCidade { get; set; }

        //[Required(ErrorMessage = "O Estado (UF) do cliente deverá ser informado.")]
        [Display(Name = "UF")]
        public string NmUF { get; set; }

        public Retorno oRetorno { get; set; }

        public Cliente()
        {
            IdCliente = 0;
            NrCpfCnpj = "";
            NmClienteRazao = "";
            NmSobreFantasia = "";
            TpPessoa = 1;
            DtNascimento = null;
            NrCep = "";
            NmLogradouro  = "";
            NrNumero = 0;
            NmComplemento = "";
            NmBairro = "";
            NmCidade = "";
            NmUF = "";
            oRetorno = new Retorno();
        }

        public Cliente consistirDados(Cliente oCliente)
        {
            // Validar nome do cliente / razão social
            //oCliente.NmClienteRazao = oCliente.NmClienteRazao.Trim();
            if (oCliente.NmClienteRazao == null || oCliente.NmClienteRazao.Trim() == "")
            {
                oRetorno.Erro = true;
                oRetorno.Mensagem = oRetorno.Mensagem + "Nome do cliente ou Razão Social deve ser informado." + "<br />";
            }
            else if (oCliente.NmClienteRazao.Length > 15)
            {
                oRetorno.Erro = true;
                oRetorno.Mensagem = oRetorno.Mensagem + "Nome do cliente ou Razão Social  deve ter no maxímo 15 caracteres." + "<br />";
            }

            // Validar sobre nome do cliente / Nome Fantasia
            //oCliente.NmSobreFantasia = oCliente.NmSobreFantasia.Trim();
            if (oCliente.NmSobreFantasia == null || oCliente.NmSobreFantasia.Trim() == "")
            {
                oRetorno.Erro = true;
                oRetorno.Mensagem = oRetorno.Mensagem + "Sobrenome do cliente ou Nome Fantasia deve ser informado." + "<br />";
            }
            else if (oCliente.NmSobreFantasia.Length > 15)
            {
                oRetorno.Erro = true;
                oRetorno.Mensagem = oRetorno.Mensagem + "Sobrenome do cliente ou Nome Fantasia deve ter no maxímo 15 caracteres." + "<br />";
            }

            // Validar CEP do cliente
            //oCliente.NrCep = oCliente.NrCep.Trim();
            if (oCliente.NrCep == null || oCliente.NrCep.Trim() == "")
            {
                oRetorno.Erro = true;
                oRetorno.Mensagem = oRetorno.Mensagem + "CEP do cliente deve ser informado." + "<br />";
            }
            else if (oCliente.NrCep.Length != 8)
            {
                oRetorno.Erro = true;
                oRetorno.Mensagem = oRetorno.Mensagem + "CEP do cliente deve ter  8 caracteres." + "<br />";
            }

            // Validar Logradouro do cliente
            //oCliente.NmLogradouro = oCliente.NmLogradouro.Trim();
            if (oCliente.NmLogradouro == null || oCliente.NmLogradouro.Trim() == "")
            {
                oRetorno.Erro = true;
                oRetorno.Mensagem = oRetorno.Mensagem + "Logradouro do cliente deve ser informado." + "<br />";
            }
            else if (oCliente.NmLogradouro.Length > 50)
            {
                oRetorno.Erro = true;
                oRetorno.Mensagem = oRetorno.Mensagem + "Logradouro do cliente deve ter  50 caracteres." + "<br />";
            }

            // Validar Numero de Endereço do cliente
            if (oCliente.NrNumero == 0)
            {
                oRetorno.Erro = true;
                oRetorno.Mensagem = oRetorno.Mensagem + "Numero do Endereço do cliente deve ser informado." + "<br />";
            }

            // Validar Complemento de Endereço do cliente
            if (NmComplemento == null)
            {
                NmComplemento = "";
            }
            // Validar Bairro do cliente
            //oCliente.NmBairro = oCliente.NmBairro.Trim();
            if (oCliente.NmBairro == null || oCliente.NmBairro.Trim() == "")
            {
                oRetorno.Erro = true;
                oRetorno.Mensagem = oRetorno.Mensagem + "Bairro do cliente deve ser informado." + "<br />";
            }
            else if (oCliente.NmBairro.Length > 50)
            {
                oRetorno.Erro = true;
                oRetorno.Mensagem = oRetorno.Mensagem + "Bairro do cliente deve ter  50 caracteres." + "<br />";
            }

            // Validar Cidade do cliente
            //oCliente.NmCidade = oCliente.NmCidade.Trim();
            if (oCliente.NmCidade == null || oCliente.NmCidade.Trim() == "")
            {
                oRetorno.Erro = true;
                oRetorno.Mensagem = oRetorno.Mensagem + "Cidade do cliente deve ser informado." + "<br />";
            }
            else if (oCliente.NmCidade.Length > 50)
            {
                oRetorno.Erro = true;
                oRetorno.Mensagem = oRetorno.Mensagem + "Cidade do cliente deve ter  50 caracteres." + "<br />";
            }

            // Validar UF do cliente
            //oCliente.NmUF = oCliente.NmUF.Trim();
            if (oCliente.NmUF == null || oCliente.NmUF.Trim() == "")
            {
                oRetorno.Erro = true;
                oRetorno.Mensagem = oRetorno.Mensagem + "Estado do cliente deve ser informado." + "<br />";
            }
            else if (oCliente.NmUF.Length > 2)
            {
                oRetorno.Erro = true;
                oRetorno.Mensagem = oRetorno.Mensagem + "Estado do cliente deve ter  2 caracteres." + "<br />";
            }

            // validar CPF / CNPJ do cliente
            if (oCliente.TpPessoa == 1)
            {
                // Validar CPF e Data de Aniversário
            }
            else
            {
                // Validar CNPJ
            }
            return oCliente;
        }



    }
}