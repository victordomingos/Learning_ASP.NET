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
    public class TarefasController : Controller
    {
        private victor_DbGesTarefas db = new victor_DbGesTarefas();
        
        // GET: Tarefas
        //public ActionResult Index()
        //{
        //    var tarefas = db.Tarefas.Include(t => t.Cliente).Include(t => t.Funcionario).Include(t => t.TipoPrioridade).Include(t => t.TipoTarefa);
        //    return View(tarefas.ToList());
        //}
        public ActionResult Index(String filtro_estado, String filtro_coima, String txt_pesquisa)
        {
            ViewBag.TOTAL_TAREFAS = db.Tarefas.Count();
            if (string.IsNullOrEmpty(filtro_estado))
                { ViewBag.FILTRO_ESTADO = "todas"; }
            else
                { ViewBag.FILTRO_ESTADO = filtro_estado; }

            var tarefas = db.Tarefas.Include(t => t.Cliente).Include(t => t.Funcionario).Include(t => t.TipoPrioridade).Include(t => t.TipoTarefa);

            switch (filtro_estado)
            {
                case "terminadas":
                    tarefas = tarefas.Where(t => t.Estado.Equals(true));
                    ViewBag.RADIO_TODAS = 0;
                    ViewBag.RADIO_TERMINADAS = 1;
                    ViewBag.RADIO_PENDENTES = 0;
                    break;
                case "pendentes":
                    tarefas = tarefas.Where(t => t.Estado.Equals(false));
                    ViewBag.RADIO_TODAS = 0;
                    ViewBag.RADIO_TERMINADAS = 0;
                    ViewBag.RADIO_PENDENTES = 1;
                    break;
                case "todas":
                default:
                    ViewBag.RADIO_TODAS = 1;
                    ViewBag.RADIO_TERMINADAS = 0;
                    ViewBag.RADIO_PENDENTES = 0;
                    break;
            }


            if (string.IsNullOrEmpty(filtro_coima))
                { ViewBag.FILTRO_COIMA = "com e sem coima"; }
            else
                { ViewBag.FILTRO_COIMA = filtro_coima; }

            switch (filtro_coima)
            {
                case "com coima":
                    tarefas = tarefas.Where(t => t.SujeitaCoima.Equals(true));
                    ViewBag.RADIO_TODAS = 0;
                    ViewBag.RADIO_TERMINADAS = 1;
                    ViewBag.RADIO_PENDENTES = 0;
                    break;
                case "sem coima":
                    tarefas = tarefas.Where(t => t.SujeitaCoima.Equals(false));
                    ViewBag.RADIO_TODAS = 0;
                    ViewBag.RADIO_TERMINADAS = 0;
                    ViewBag.RADIO_PENDENTES = 1;
                    break;
                case "com e sem coima":
                default:
                    ViewBag.RADIO_TODAS = 1;
                    ViewBag.RADIO_TERMINADAS = 0;
                    ViewBag.RADIO_PENDENTES = 0;
                    break;
            }

            if (string.IsNullOrEmpty(txt_pesquisa))
                { ViewBag.FILTRO_PESQUISA = ""; }
            else
            {
                ViewBag.FILTRO_PESQUISA = txt_pesquisa;
                tarefas = tarefas.Where(t => t.Titulo.Contains(txt_pesquisa));
            }


            ViewBag.TAREFAS_FILTRADAS = tarefas.Count();

            return View(tarefas.ToList());
        }



        // GET: Tarefas/Details/5
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

        // GET: Tarefas/Create
        public ActionResult Create()
        {
            ViewBag.ClienteID = new SelectList(db.Clientes, "Id", "NomeCliente");
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "Id", "NomeFuncionario");
            ViewBag.TipoPrioridadeID = new SelectList(db.TiposDePrioridade, "Id", "DesignacaoPrioridade");
            ViewBag.TipoTarefaID = new SelectList(db.TiposDeTarefa, "Id", "DesignacaoTipoTarefa");
            return View();
        }

        // POST: Tarefas/Create
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

        // GET: Tarefas/Edit/5
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

        // POST: Tarefas/Edit/5
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

        // GET: Tarefas/Delete/5
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

        // POST: Tarefas/Delete/5
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
