using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_exercise.Controllers
{
    public class PassingValuesController : Controller
    {
        // GET: PassingValues
        public ActionResult Index()
        {
            ViewBag.X = "hello, everyone!";
            return View();
        }
    }
}