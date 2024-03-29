﻿using System;
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
                
        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataRegisto { get; set; }

        [Display(Name = "Prazo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataLimite { get; set; }

        [Display(Name = "Coima")]
        public bool SujeitaCoima { get; set; }


        public string Descritivo { get; set; }

        public bool Estado { get; set; }



        public int ClienteID { get; set; }
        public virtual Cliente Cliente { get; set; }



        public int TipoPrioridadeID { get; set; }
        public virtual TipoPrioridade TipoPrioridade { get; set; }
        

        public int TipoTarefaID { get; set; }
        public virtual TipoTarefa TipoTarefa { get; set; }

        
        public int FuncionarioID { get; set; }
        public virtual Funcionario Funcionario { get; set; }


        public ICollection<LinhaDeTarefa> LinhasDeTarefa { get; set; }

    }
}