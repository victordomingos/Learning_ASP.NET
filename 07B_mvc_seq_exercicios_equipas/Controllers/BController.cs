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
            //criar lista com a estutura do modelo equipa:
            List<Equipa> listadasequipas = db.Tequipas.ToList();
            ViewBag.Equipas = listadasequipas;


            //para o modelo membro:
            ViewBag.Membros = (List<Membro>)db.Tmembros.ToList();

            return View();
        }

    }
}
