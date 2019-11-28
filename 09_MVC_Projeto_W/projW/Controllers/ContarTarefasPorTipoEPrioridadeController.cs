using projW.DAL;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace projW.Controllers
{
    public class ContarTarefasPorTipoEPrioridadeController : Controller
    {
        private victor_DbGesTarefas db = new victor_DbGesTarefas();

        // GET: ContarTarefasPorTipoEPrioridade
        public ActionResult Index(int? tipoTarefa, int? prioridade)
        {
            var tarefas = db.Tarefas.Include(t => t.Cliente)
                                    .Include(t => t.TipoPrioridade)
                                    .Include(t => t.TipoTarefa);

            ViewBag.TIPOSDETAREFA = new SelectList(db.TiposDeTarefa, "Id", "DesignacaoTipoTarefa");
            ViewBag.TIPOSDEPRIORIDADE = new SelectList(db.TiposDePrioridade, "Id", "DesignacaoPrioridade");

            ViewBag.TIPO = 0;
            if (tipoTarefa.HasValue)
            {
                ViewBag.TIPO = tipoTarefa;
                tarefas = tarefas.Where(t => t.TipoTarefaID == tipoTarefa);
            }

            ViewBag.PRIORIDADE = 0;
            if (prioridade.HasValue)
            {
                ViewBag.PRIORIDADE = prioridade;
                tarefas = tarefas.Where(t => t.TipoPrioridadeID == prioridade);
            }
            
            ViewBag.CONTAGEM = tarefas.Count().ToString();
            return View();
        }
    }
}