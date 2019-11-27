using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_tracking_exercise.Models
{
    public class Envio
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Estado { get; set; }
        public DateTime DataExpedicao { get; set; }


        public int DestinatarioId { get; set; }
        public virtual Destinatario Destinatario { get; set; }


    }
}