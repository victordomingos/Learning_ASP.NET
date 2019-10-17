using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projW.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }


        public ICollection<Tarefa> Tarefas { get; set; }
    }
}