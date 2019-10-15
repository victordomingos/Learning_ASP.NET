using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projW.Models
{
    public class Tarefa
    {
        public int ID { get; set; }
        
        [Display(Name="Título")]
        public string Titulo { get; set; }
        [Display(Name = "Equipa")]
        public string Equipa { get; set; }

        
        
        [Display(Name = "DataRegisto")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}")]
        public DateTime DataRegisto { get; set; }

        [Display(Name = "DataLimite")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DataLimite { get; set; }

        [Display(Name = "Coima?")]
        public bool SujeitaCoima { get; set; }

        public string TipoImportancia { get; set; }

        public string Descritivo { get; set; }

        public bool Estado { get; set; }




    }
}