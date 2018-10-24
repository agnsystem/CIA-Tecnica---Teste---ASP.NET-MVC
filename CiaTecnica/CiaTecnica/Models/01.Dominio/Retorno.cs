using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CiaTecnica.Models
{
    public class Retorno
    {
        public Boolean Erro { get; set; }
        public int TipoErro { get; set; }
        public string Mensagem { get; set; }

        public Retorno()
        {
            Erro = false;
            TipoErro = 0;
            Mensagem = "";
        }
    }
}