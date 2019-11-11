using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using projW.Models;


namespace projW.ViewModel
{
    public class FuncionarioTarefas
    {
        public IEnumerable<Funcionario> Funcionarios { get; set; }
        public IEnumerable<Tarefa> Tarefas { get; set; }
        public IEnumerable<LinhaDeTarefa> LinhasDeTarefa { get; set; }
    }
}