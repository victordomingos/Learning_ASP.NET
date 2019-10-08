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
    public class CController : Controller
    {
        private EquipasContext db = new EquipasContext();

        // GET: C
        public ActionResult Index()
        {
            var lista_equipas = db.Tequipas.ToList();
            var sel_list_equipas = new SelectList(lista_equipas, "id", "nomeequipa");
            ViewBag.EQUIPAS = sel_list_equipas;


            var lista_membros = db.Tmembros.ToList();
            var sel_list_membros = new SelectList(lista_membros, "id", "nomemembro");
            ViewBag.MEMBROS= sel_list_membros;

            return View();
        }

    }
}
