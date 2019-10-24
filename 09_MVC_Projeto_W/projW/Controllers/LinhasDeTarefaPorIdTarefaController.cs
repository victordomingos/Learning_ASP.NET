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
    public class LinhasDeTarefaPorIdTarefaController : Controller
    {
        private victor_DbGesTarefas db = new victor_DbGesTarefas();

        // GET: LinhasDeTarefaPorIdTarefa
        public ActionResult Index(int? tarefaId)
        {
            var linhaDeTarefa = db.LinhaDeTarefa.Include(l => l.Tarefa);

            if (!tarefaId.HasValue)
            {
                tarefaId = -1;
            }
            else
            {
                ViewBag.TAREFAID = tarefaId;
            }
            
            linhaDeTarefa = linhaDeTarefa.Where(l => l.TarefaID == tarefaId);
           

            return View(linhaDeTarefa.ToList());
        }

        // GET: LinhasDeTarefaPorIdTarefa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LinhaDeTarefa linhaDeTarefa = db.LinhaDeTarefa.Find(id);
            if (linhaDeTarefa == null)
            {
                return HttpNotFound();
            }
            return View(linhaDeTarefa);
        }

        // GET: LinhasDeTarefaPorIdTarefa/Create
        public ActionResult Create()
        {
            ViewBag.TarefaID = new SelectList(db.Tarefas, "ID", "Titulo");
            return View();
        }

        // POST: LinhasDeTarefaPorIdTarefa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descritivo,DataDaLinha,TarefaID")] LinhaDeTarefa linhaDeTarefa)
        {
            if (ModelState.IsValid)
            {
                db.LinhaDeTarefa.Add(linhaDeTarefa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TarefaID = new SelectList(db.Tarefas, "ID", "Titulo", linhaDeTarefa.TarefaID);
            return View(linhaDeTarefa);
        }

        // GET: LinhasDeTarefaPorIdTarefa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LinhaDeTarefa linhaDeTarefa = db.LinhaDeTarefa.Find(id);
            if (linhaDeTarefa == null)
            {
                return HttpNotFound();
            }
            ViewBag.TarefaID = new SelectList(db.Tarefas, "ID", "Titulo", linhaDeTarefa.TarefaID);
            return View(linhaDeTarefa);
        }

        // POST: LinhasDeTarefaPorIdTarefa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descritivo,DataDaLinha,TarefaID")] LinhaDeTarefa linhaDeTarefa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(linhaDeTarefa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TarefaID = new SelectList(db.Tarefas, "ID", "Titulo", linhaDeTarefa.TarefaID);
            return View(linhaDeTarefa);
        }

        // GET: LinhasDeTarefaPorIdTarefa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LinhaDeTarefa linhaDeTarefa = db.LinhaDeTarefa.Find(id);
            if (linhaDeTarefa == null)
            {
                return HttpNotFound();
            }
            return View(linhaDeTarefa);
        }

        // POST: LinhasDeTarefaPorIdTarefa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LinhaDeTarefa linhaDeTarefa = db.LinhaDeTarefa.Find(id);
            db.LinhaDeTarefa.Remove(linhaDeTarefa);
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
