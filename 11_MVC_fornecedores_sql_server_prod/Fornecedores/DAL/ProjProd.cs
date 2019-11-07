using Fornecedores.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Fornecedores.DAL
{
    public class ProjProd : DbContext
    {
        public DbSet<Fornecedor> TFornecedores { get; set; }

    }
}