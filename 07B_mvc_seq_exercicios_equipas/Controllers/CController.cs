using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EquipaMembros2019.DAL;
using EquipaMembros2019.Models;

namespace EquipaMembros2019.Controllers
{
    public class CController : Controller
    {
        EquipasContext dbPointer = new EquipasContext();

        // GET: C
public ActionResult Index()
{
//preparação da drop 1:
List<Equipa> listadasequipas = dbPointer.Tequipas.ToList();
//construir a selectlist, indicando a chave e o campo a ser mostrado:
var sel1 = new SelectList(listadasequipas, "id", "nomeequipa");
ViewBag.EQUIPAS = sel1;






//preparação da drop 2:
List<Membro> listademembros = dbPointer.Tmembros.ToList();
var sel2 = new SelectList(listademembros, "id", "nomemembro");
ViewBag.MEMBROS = sel2;


return View();
}
    }
}