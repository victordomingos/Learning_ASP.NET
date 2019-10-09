using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EquipaMembros2019.DAL;
using EquipaMembros2019.Models;

namespace EquipaMembros2019.Controllers
{
public class DController : Controller
{
EquipasContext dbpointer = new EquipasContext();
// GET: D
public ActionResult Index(string id)
{
    List<Equipa> listagem = dbpointer.Tequipas.ToList();
    var sel = new SelectList(listagem, "id", "nomeequipa");
    ViewBag.EQUIPAS = sel;

    if (string.IsNullOrEmpty(id))
        ViewBag.id = "(ainda não clicou...)";
                else
                    ViewBag.id = id;




    return View();
}
}
}