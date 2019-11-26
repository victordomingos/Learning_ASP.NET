using MVC_tracking_exercise.Models;
using System.Data.Entity;


namespace MVC_tracking_exercise.DAL
{
    public class DbTracking : DbContext
    {
        public DbSet<Destinatario> Destinatarios { get; set; }
        public DbSet<Envio> Envios { get; set; }

    }
}