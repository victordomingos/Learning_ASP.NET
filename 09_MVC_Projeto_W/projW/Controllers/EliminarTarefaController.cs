using projW.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projW.Controllers
{
    public class EliminarTarefaController : Controller
    {
        private victor_DbGesTarefas db = new victor_DbGesTarefas();

        // GET: EliminarTarefa
        public ActionResult Index(int? tarefaId, string really_delete)
        {
            ViewBag.STATUS = null;

            if (tarefaId.HasValue)
            {
                if (!String.IsNullOrEmpty(really_delete) && really_delete == "sim")
                {
                    ViewBag.TAREFAID = tarefaId.ToString();
                    try
                    {
                        var tarefa = db.Tarefas.Where(t => t.ID == tarefaId).First();
                        db.Tarefas.Remove(tarefa);
                        ViewBag.STATUS = db.SaveChanges();

                        ViewBag.SHOW_CONFIRMATION = 0;
                    }
                    catch (InvalidOperationException)
                    {
                        // não foram encontrados registos
                        ViewBag.STATUS = 0;
                    }
                    catch (Exception)
                    {
                        // outro erro...
                        ViewBag.STATUS = -1;
                    }

                }
                else
                {
                    ViewBag.TAREFAID = tarefaId.ToString();
                    ViewBag.SHOW_CONFIRMATION = 1;
                }
            }
            else
            {
                ViewBag.TAREFAID = "";
                ViewBag.REALLY_DELETE = 0;
                ViewBag.SHOW_CONFIRMATION = 0;
            }

            return View();
        }
    }
}