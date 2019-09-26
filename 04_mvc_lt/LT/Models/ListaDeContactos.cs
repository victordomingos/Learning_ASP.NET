using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LT.Models
{
    public class ListaDeContactos
    {
        public int ID { get; set; }
        public string Cliente { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}