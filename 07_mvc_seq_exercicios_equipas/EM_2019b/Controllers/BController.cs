using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EquipaMembros2019.DAL;
using EquipaMembros2019.Models;

namespace EquipaMembros2019.Controllers
{
    public class BController : Controller
    {
        private EquipasContext db = new EquipasContext();

        // GET: B
        public ActionResult Index()
        {
            List<Equipa> listaDeEquipas = db.Tequipas.ToList();
            ViewBag.EQUIPAS = listaDeEquipas;
            return View();
        }
        

    }
}
