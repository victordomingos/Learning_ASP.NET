using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EquipaMembros2019.Models
{
    public class Membro
    {
        public int Id { get; set; }
        public string NomeMembro { get; set; }

        public int EquipaID { get; set; }
        public virtual Equipa  Equipa { get; set; }
    }
}

