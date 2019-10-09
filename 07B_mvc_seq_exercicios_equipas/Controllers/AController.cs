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
    public class AController : Controller
    {
        private EquipasContext db = new EquipasContext();

        // GET: A
    public ActionResult Index()
    {
        //declarar recipiente para conter strings
        var listadenomes = new List<string>(); 
        //inicializar a lista:
        listadenomes.Add("Benfica");
        listadenomes.Add("Porto");
        listadenomes.Add("Braga");
        listadenomes.Add("Gil Vicente");
        listadenomes.Sort();

        //converter lista em selectlist:
        var sl = new SelectList(listadenomes);
        //enviar lista para a view:
        ViewBag.LISTA = sl;

        return View();
    }

    }
}


//var tmembros = db.Tmembros.Include(m => m.Equipa);