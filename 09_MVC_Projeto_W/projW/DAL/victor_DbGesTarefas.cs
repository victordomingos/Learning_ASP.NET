using projW.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace projW.DAL
{
    public class victor_DbGesTarefas : DbContext
    {
        public DbSet<Tarefa> Tarefas { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

    }
}