using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using CP.Models;
using System.Data.Entity;

namespace CP.DAL
{
    public class CPContext
    {
        public DbSet<Categoria> Tcategorias { get; set; }

    }
}