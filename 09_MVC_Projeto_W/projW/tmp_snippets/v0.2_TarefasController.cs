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
        public ActionResult Index(String filtro_estado, String filtro_coima, String txt_pesquisa)
        {
            ViewBag.TOTAL_TAREFAS = db.Tarefas.Count();
            if (string.IsNullOrEmpty(filtro_estado))
                { ViewBag.FILTRO_ESTADO = "todas"; }
            else
                { ViewBag.FILTRO_ESTADO = filtro_estado; }
            

            switch (filtro_estado)
            {
                case "terminadas":
                    lista = db.Tarefas.Where(t => t.Estado.Equals(true)).ToList();
                    ViewBag.RADIO_TODAS = 0;
                    ViewBag.RADIO_TERMINADAS = 1;
                    ViewBag.RADIO_PENDENTES = 0;
                    break;
                case "pendentes":
                    lista = db.Tarefas.Where(t => t.Estado.Equals(false)).ToList();
                    ViewBag.RADIO_TODAS = 0;
                    ViewBag.RADIO_TERMINADAS = 0;
                    ViewBag.RADIO_PENDENTES = 1;
                    break;
                case "todas": default:
                    lista = db.Tarefas.ToList();
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
                    lista = lista.Where(t => t.SujeitaCoima.Equals(true)).ToList();
                    ViewBag.RADIO_TODAS = 0;
                    ViewBag.RADIO_TERMINADAS = 1;
                    ViewBag.RADIO_PENDENTES = 0;
                    break;
                case "cem coima":
                    lista = db.Tarefas.Where(t => t.SujeitaCoima.Equals(false)).ToList();
                    ViewBag.RADIO_TODAS = 0;
                    ViewBag.RADIO_TERMINADAS = 0;
                    ViewBag.RADIO_PENDENTES = 1;
                    break;
                case "com e sem coima":
                default:
                    lista = lista.ToList();
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
                lista = lista.Where(t => t.Titulo.Contains(txt_pesquisa)).ToList();
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
