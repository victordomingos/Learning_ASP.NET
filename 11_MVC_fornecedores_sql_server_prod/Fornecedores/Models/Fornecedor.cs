using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Fornecedores.Models
{
    public class Fornecedor
    {
        [DisplayName("ID")]
        public int ID { get; set; }
        
        [DisplayName("Cód.")]
        public string codigo { get; set; }

        [DisplayName("Nome do Fornecedor")]
        public string nome_do_fornecedor { get; set; }
        
    }
}