using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EquipaMembros2019.Models;

namespace EquipaMembros2019.ViewModel
{
    public class EquipaMembros
    {
        public IEnumerable<Equipa> Equipas { get; set; }

        public IEnumerable<Membro> Membros { get; set; }
    }
}