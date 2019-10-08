using System.Collections.Generic;
namespace EquipaMembros2019.Models
{
    public class Equipa
    {
        public int Id { get; set; }
        public string NomeEquipa { get; set; }

        //cada equipa pode ter uma coleção de membros:
        public virtual ICollection<Membro> Membros { get; set; }
    }
}


