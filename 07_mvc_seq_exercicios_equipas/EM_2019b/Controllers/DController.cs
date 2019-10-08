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
    public class DController : Controller
    {
        private EquipasContext db = new EquipasContext();

        // GET: C
        public ActionResult Index(string id_equipa, string id_membro)
        {
            var lista_equipas = db.Tequipas.ToList();
            var sel_list_equipas = new SelectList(lista_equipas, "id", "nomeequipa");
            
            ViewBag.EQUIPAS = sel_list_equipas;

            if (!string.IsNullOrEmpty(id_equipa))
                { ViewBag.SELECTED_TEAM = id_equipa; }
            else
                { ViewBag.SELECTED_TEAM = "Nenhuma equipa selecionada."; }

            
            var lista_membros = db.Tmembros.ToList();
            var sel_list_membros = new SelectList(lista_membros, "id", "nomemembro");
            ViewBag.MEMBROS = sel_list_membros;


            if (!string.IsNullOrEmpty(id_membro))
                { ViewBag.SELECTED_MEMBER = id_membro; }
            else
                { ViewBag.SELECTED_MEMBER = "Nenhum membro selecionado."; }


            return View();
        }

    }
}
