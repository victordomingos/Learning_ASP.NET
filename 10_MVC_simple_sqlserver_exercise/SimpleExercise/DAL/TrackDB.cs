using SimpleExercise.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimpleExercise.DAL
{
    public class TrackDB : DbContext
    {
        public DbSet<Shipment> Shipments { get; set; }
    }
}