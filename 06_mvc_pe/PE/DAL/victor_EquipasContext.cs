using System.Data.Entity;
using PE.Models;

namespace PE.DAL
{
    public class Victor_EquipasContext : DbContext
    {
        public DbSet<Equipa> Tequipa { get; set; }
    }
}