using System.Collections.Generic;


namespace MVC_tracking_exercise.Models
{
    public class Destinatario
    {
        public int Id { get; set; }
        public string Nome { get; set; }


        public ICollection<Envio> Envios { get; set; }

    }
}