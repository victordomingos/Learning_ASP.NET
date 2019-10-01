
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CP.Models;
using CP.DAL;

namespace CP.Controllers
{
    public class AController : Controller
    {
        CPContext dbPointer = new CPContext();

        // GET: A
        public ActionResult Index()
        {
            List<Categoria> listagem = dbPointer.Tcategorias.ToList();
            ViewBag.LISTAGEM = listagem;

            return View();
        }
    }
}