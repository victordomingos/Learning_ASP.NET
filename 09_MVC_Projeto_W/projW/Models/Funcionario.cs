using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projW.Models
{
    public class Funcionario
    {
            public int Id { get; set; }
            public string NomeFuncionario { get; set; }

            public ICollection<Tarefa> Tarefas { get; set; }
     
    }
}