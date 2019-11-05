using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleExercise.Models
{
    public class Shipment
    {
        public int id { get; set; }
        public string costumer { get; set; }
        public string code { get; set; }
        public DateTime date { get; set; }
    }
}