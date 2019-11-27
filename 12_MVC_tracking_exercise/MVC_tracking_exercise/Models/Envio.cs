using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_tracking_exercise.Models
{
    public class Envio
    {
        public int Id { get; set; }
        [Display(Name="Código")]
        public string Codigo { get; set; }
        public string Estado { get; set; }
        [Display(Name = "Data de Expedição")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        public DateTime DataExpedicao { get; set; }

        [Display(Name = "Destinatário")]
        public int DestinatarioId { get; set; }
        public virtual Destinatario Destinatario { get; set; }


    }
}