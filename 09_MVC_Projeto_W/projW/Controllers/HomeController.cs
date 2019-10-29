using DButils;
using projW.MyUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projW.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TarefasFuncs tf = new TarefasFuncs();
            MyDatabase db2 = new MyDatabase();

            ViewBag.SYSTEM_TIME = DateTime.Now.ToString("hh:mm");
            ViewBag.GREETING = tf.GoodMorning();

            string ssql = "SELECT COUNT(*) FROM Tarefas";
            ViewBag.TASK_COUNT = db2.ObterDados(ssql).Rows[0][0].ToString();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}