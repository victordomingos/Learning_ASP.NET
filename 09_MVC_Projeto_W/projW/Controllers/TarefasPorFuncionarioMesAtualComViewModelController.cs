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
        public ActionResult Index(int? id_funcionario, int? id_tarefa)
        {
            var viewModel = new FuncionarioTarefas();
            ViewBag.FUNCIONARIOS = new SelectList(db.Funcionarios, "Id", "NomeFuncionario");

            viewModel.Tarefas = db.Tarefas.Where(t => t.FuncionarioID == id_funcionario);
            viewModel.LinhasDeTarefa = db.LinhaDeTarefa.Where(l => l.TarefaID == id_tarefa);

            return View(viewModel);
        }
    }
}