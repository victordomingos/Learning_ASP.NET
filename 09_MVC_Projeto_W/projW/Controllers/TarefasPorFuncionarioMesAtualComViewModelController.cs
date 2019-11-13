using projW.DAL;
using projW.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projW.Controllers
{
    public class TarefasPorFuncionarioMesAtualComViewModelController : Controller
    {
        private victor_DbGesTarefas db = new victor_DbGesTarefas();

        // GET: TarefasPorFuncionarioMesAtualComViewModel
        public ActionResult Index(int? drop_funcionario, int? id, int? link_funcionario)
        {
            var viewModel = new FuncionarioTarefas();
            int id_func;

            try
            {
                id_func = db.Funcionarios.FirstOrDefault().Id;
            }
            catch(NullReferenceException)
            {
                id_func = -1;
            }

            ViewBag.ID_FUNCIONARIO = id_func;
            if (link_funcionario.HasValue)
            {
                ViewBag.ID_FUNCIONARIO = link_funcionario;
                id_func = Convert.ToInt32(link_funcionario);
            }

            ViewBag.DROP_FUNCIONARIO = drop_funcionario;
            if (drop_funcionario > 0)
            {
                ViewBag.ID_FUNCIONARIO = drop_funcionario;
                id_func = Convert.ToInt32(drop_funcionario);
            }

            ViewBag.FUNCIONARIOS = new SelectList(db.Funcionarios, "Id", "NomeFuncionario", id_func);

            

            if (id.HasValue && id != -1)
            {
                if (drop_funcionario > 0)
                    ViewBag.ID_TAREFA = -1;
                else
                    ViewBag.ID_TAREFA = id;
            }
            else
            {
                ViewBag.ID_TAREFA = -1;
            }

            viewModel.Tarefas = db.Tarefas.Where(t => t.FuncionarioID == id_func);
            viewModel.LinhasDeTarefa = db.LinhaDeTarefa.Where(l => l.TarefaID == id);

            return View(viewModel);
        }
    }
}