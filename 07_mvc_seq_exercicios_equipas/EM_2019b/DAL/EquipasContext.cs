using System.Data.Entity;

using EquipaMembros2019.Models;

namespace EquipaMembros2019.DAL
{
    public class EquipasContext :DbContext
    {
        public DbSet <Equipa> Tequipas { get; set; }
        public DbSet <Membro> Tmembros { get; set; }
    }
}


