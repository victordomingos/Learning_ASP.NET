using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projW.Models
{
    public class TipoPrioridade
    {
        public int Id { get; set; }
        public string DesignacaoPrioridade { get; set; }

        public ICollection<Tarefa> Tarefas { get; set; }
    }
}