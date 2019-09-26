using LT.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LT.DAL
{
    public class DbContactos: DbContext
    {
        public DbSet<ListaDeContactos> Tcontactos { get; set; }
               

    }
}