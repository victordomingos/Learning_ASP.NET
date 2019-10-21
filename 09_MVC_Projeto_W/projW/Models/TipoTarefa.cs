using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projW.Models
{
    public class TipoTarefa
    {
        public int Id { get; set; }
        
        public string DesignacaoTipoTarefa { get; set; }

        public ICollection<Tarefa> Tarefas { get; set; }
    }
}