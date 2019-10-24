using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using projW.DAL;
using projW.Models;

namespace projW.Controllers
{
    public class TarefasPorClienteController : Controller
    {
        private victor_DbGesTarefas db = new victor_DbGesTarefas();

        // GET: TarefasPorCliente
        public ActionResult Index(int? ClienteID)
        {
            List<Cliente> listaClientes = db.Clientes.ToList();
            var sLista = new SelectList(listaClientes, "Id", "NomeCliente");
            ViewBag.CLIENTES = sLista;



            var tarefas = db.Tarefas.Include(t => t.Cliente)
                    .Include(t => t.Funcionario)
                    .Include(t => t.TipoPrioridade)
                    .Include(t => t.TipoTarefa);

            if (!ClienteID.HasValue)
            {
                tarefas = tarefas.Where(t => t.Cliente.Id == ClienteID);
            }


            ViewBag.TOTAL = tarefas.Count();
            ViewBag.CLIENTEID = ClienteID;
            
            return View(tarefas.ToList());
        }

        // GET: TarefasPorCliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefa tarefa = db.Tarefas.Find(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            return View(tarefa);
        }

        // GET: TarefasPorCliente/Create
        public ActionResult Create()
        {
            ViewBag.ClienteID = new SelectList(db.Clientes, "Id", "NomeCliente");
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "Id", "NomeFuncionario");
            ViewBag.TipoPrioridadeID = new SelectList(db.TiposDePrioridade, "Id", "DesignacaoPrioridade");
            ViewBag.TipoTarefaID = new SelectList(db.TiposDeTarefa, "Id", "DesignacaoTipoTarefa");
            return View();
        }

        // POST: TarefasPorCliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Titulo,Equipa,DataRegisto,DataLimite,SujeitaCoima,Descritivo,Estado,ClienteID,TipoPrioridadeID,TipoTarefaID,FuncionarioID")] Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                db.Tarefas.Add(tarefa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteID = new SelectList(db.Clientes, "Id", "NomeCliente", tarefa.ClienteID);
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "Id", "NomeFuncionario", tarefa.FuncionarioID);
            ViewBag.TipoPrioridadeID = new SelectList(db.TiposDePrioridade, "Id", "DesignacaoPrioridade", tarefa.TipoPrioridadeID);
            ViewBag.TipoTarefaID = new SelectList(db.TiposDeTarefa, "Id", "DesignacaoTipoTarefa", tarefa.TipoTarefaID);
            return View(tarefa);
        }

        // GET: TarefasPorCliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefa tarefa = db.Tarefas.Find(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "Id", "NomeCliente", tarefa.ClienteID);
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "Id", "NomeFuncionario", tarefa.FuncionarioID);
            ViewBag.TipoPrioridadeID = new SelectList(db.TiposDePrioridade, "Id", "DesignacaoPrioridade", tarefa.TipoPrioridadeID);
            ViewBag.TipoTarefaID = new SelectList(db.TiposDeTarefa, "Id", "DesignacaoTipoTarefa", tarefa.TipoTarefaID);
            return View(tarefa);
        }

        // POST: TarefasPorCliente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Titulo,Equipa,DataRegisto,DataLimite,SujeitaCoima,Descritivo,Estado,ClienteID,TipoPrioridadeID,TipoTarefaID,FuncionarioID")] Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarefa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "Id", "NomeCliente", tarefa.ClienteID);
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "Id", "NomeFuncionario", tarefa.FuncionarioID);
            ViewBag.TipoPrioridadeID = new SelectList(db.TiposDePrioridade, "Id", "DesignacaoPrioridade", tarefa.TipoPrioridadeID);
            ViewBag.TipoTarefaID = new SelectList(db.TiposDeTarefa, "Id", "DesignacaoTipoTarefa", tarefa.TipoTarefaID);
            return View(tarefa);
        }

        // GET: TarefasPorCliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefa tarefa = db.Tarefas.Find(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            return View(tarefa);
        }

        // POST: TarefasPorCliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tarefa tarefa = db.Tarefas.Find(id);
            db.Tarefas.Remove(tarefa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
