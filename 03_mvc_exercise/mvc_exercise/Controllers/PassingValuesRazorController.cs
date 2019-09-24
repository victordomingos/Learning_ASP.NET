using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_exercise.Controllers
{
    public class PassingValuesRazorController : Controller
    {
        // GET: PassingValues
        public ActionResult Index(string name)
        {

            if (string.IsNullOrEmpty(name))
            {
                ViewBag.X = "hello, everyone!";
            }
            else
            {
                ViewBag.X = $"hello, {name}!";
            }
            
            
            return View();
        }
    }
}