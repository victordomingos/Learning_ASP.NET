using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EquipaMembros2019.Controllers
{
    public class AController : Controller
    {
        // GET: A
        public ActionResult Index()
        {
            var listaDeNomes = new List<string>();
            listaDeNomes.Add("F. C. Porto");
            listaDeNomes.Add("S. L. Benfica");
            listaDeNomes.Add("Belenenses");
            listaDeNomes.Add("Atlético de Valdevez");
            listaDeNomes.Add("ADECAS");
            listaDeNomes.Add("Desportivo das Bananas");
            listaDeNomes.Add("Grupo Desportivo Tomate Feroz");
            listaDeNomes.Sort();

            ViewBag.LISTA = new SelectList(listaDeNomes);

            return View();
        }
    }
}