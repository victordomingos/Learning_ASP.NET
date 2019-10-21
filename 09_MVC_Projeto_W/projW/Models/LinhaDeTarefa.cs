using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projW.Models
{
    public class LinhaDeTarefa
    {
        public int Id { get; set; }
        public string Descritivo { get; set; }

        [Display(Name = "Prazo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataDaLinha { get; set; }
        


        public int TarefaID { get; set; }
        public virtual Tarefa Tarefa{ get; set; }
    }
}