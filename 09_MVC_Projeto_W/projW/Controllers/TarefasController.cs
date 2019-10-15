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
        private DbGesTarefas db = new DbGesTarefas();
        private List<Tarefa> lista;
        // GET: Tarefas
        public ActionResult Index(String filtro)
        {
            ViewBag.TOTAL_TAREFAS = db.Tarefas.Count();
            if (string.IsNullOrEmpty(ViewBag.FILTRO))
                { ViewBag.FILTRO = "Todas"; }
            else
                { ViewBag.FILTRO = filtro; }
              
            

            switch (filtro)
            {
                case "Terminadas":
                    lista = db.Tarefas.Where(t => t.Estado.Equals(true)).ToList();
                    ViewBag.RADIO_TODAS = 0;
                    ViewBag.RADIO_TERMINADAS = 1;
                    ViewBag.RADIO_PENDENTES = 0;
                    break;
                case "Pendentes":
                    lista = db.Tarefas.Where(t => t.Estado.Equals(false)).ToList();
                    ViewBag.RADIO_TODAS = 0;
                    ViewBag.RADIO_TERMINADAS = 0;
                    ViewBag.RADIO_PENDENTES = 1;
                    break;
                case "Todas": default:
                    lista = db.Tarefas.ToList();
                    ViewBag.RADIO_TODAS = 1;
                    ViewBag.RADIO_TERMINADAS = 0;
                    ViewBag.RADIO_PENDENTES = 0;
                    break;
            }
            ViewBag.TAREFAS_FILTRADAS = lista.Count();

            return View(lista.ToList());
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
            return View();
        }

        // POST: Tarefas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Titulo,Equipa,DataRegisto,DataLimite,SujeitaCoima,TipoImportancia,Descritivo,Estado")] Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                db.Tarefas.Add(tarefa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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
            return View(tarefa);
        }

        // POST: Tarefas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Titulo,Equipa,DataRegisto,DataLimite,SujeitaCoima,TipoImportancia,Descritivo,Estado")] Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarefa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
