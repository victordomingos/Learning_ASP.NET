using projW.DAL;
using projW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projW.Controllers
{
    public class EliminarLinhaDeTarefaController : Controller
    {
        private victor_DbGesTarefas db = new victor_DbGesTarefas();

        // GET: EliminarTarefa
        public ActionResult Index(int? linhaId, string apagarMesmo)
        {
            ViewBag.STATUS = null;
            ViewBag.MSG = "";

            if (linhaId.HasValue)
            {
                LinhaDeTarefa linha = db.LinhaDeTarefa.Find(linhaId);
                try
                {
                    Tarefa t = db.Tarefas.Find(linha.TarefaID);
                    //int n_linhas_tarefa = t.LinhasDeTarefa.Count();
                    int n_linhas_tarefa = db.LinhaDeTarefa.Count(l => l.TarefaID == t.ID);

                    if (n_linhas_tarefa == 1)
                    {
                        ViewBag.MSG = "Não é possível eliminar a linha indicada, " +
                            "uma vez que a tarefa correspondente não contém mais linhas.";
                        ViewBag.STATUS = 0;
                    }
                    else
                    {
                        ViewBag.STATUS = 0;
                        ViewBag.SHOW_CONFIRMATION = 1;

                        // Caso o utilizador já tenha confirmado que pretende mesmo apagar                                
                        if (!String.IsNullOrEmpty(apagarMesmo) && apagarMesmo == "sim")
                        {
                            ViewBag.LINHAID = linhaId.ToString();
                            try
                            {
                                db.LinhaDeTarefa.Remove(linha);
                                ViewBag.STATUS = db.SaveChanges();
                                ViewBag.SHOW_CONFIRMATION = 0;
                                ViewBag.MSG = "A linha de tarefa foi eliminada com sucesso!";
                            }
                            catch (InvalidOperationException)
                            {
                                // não foram encontrados registos
                                ViewBag.MSG = "Não foi encontrada nenhuma linha de tarefa com o número " + linhaId + ".";
                                ViewBag.STATUS = 0;

                            }
                            catch (Exception)
                            {
                                // outro erro...
                                ViewBag.MSG = "Ocorreu um erro.";
                                ViewBag.STATUS = -1;
                            }

                        }
                        // Caso o utilizador ainda não tenha confirmado
                        else
                        {
                            ViewBag.LINHAID = linha.Id.ToString();
                            ViewBag.SHOW_CONFIRMATION = 1;
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    //Msg não é possível eliminar porque tarefa não tem linhas
                    ViewBag.MSG = "Não foi encontrada nenhuma linha de tarefa com o número " + linhaId + ".";
                    ViewBag.STATUS = 0;
                }
                                
            }
            // Caso a textbox não tenha um id
            else
            {
                ViewBag.LINHAID = "";
                ViewBag.MSG = "";
                ViewBag.REALLY_DELETE = 0;
                ViewBag.SHOW_CONFIRMATION = 0;
            }

            return View();
        }
    }
}