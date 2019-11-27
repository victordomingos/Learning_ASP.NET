using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_tracking_exercise.DAL;
using MVC_tracking_exercise.Models;

namespace MVC_tracking_exercise.Controllers
{
    public class EnviosController : Controller
    {
        private DbTracking db = new DbTracking();

        // GET: Envios
        public ActionResult Index(string drop_estado)
        {
            var envios = db.Envios.Include(e => e.Destinatario);
            ViewBag.NUM_TOTAL = envios.Count();     // Count all records.       
            ViewBag.ESTADOS = new SelectList(db.Envios, "Estado", "Estado");
            
            if(!string.IsNullOrEmpty(drop_estado))
            {
                envios = envios.Where(e => e.Estado == drop_estado);
            }

            ViewBag.NUM_FILTRADAS = envios.Count(); // Count Filtered records

            return View(envios.ToList());
        }

        // GET: Envios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Envio envio = db.Envios.Find(id);
            if (envio == null)
            {
                return HttpNotFound();
            }
            return View(envio);
        }

        // GET: Envios/Create
        public ActionResult Create()
        {
            ViewBag.DestinatarioId = new SelectList(db.Destinatarios, "Id", "Nome");
            return View();
        }

        // POST: Envios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Estado,DataExpedicao,DestinatarioId")] Envio envio)
        {
            if (ModelState.IsValid)
            {
                db.Envios.Add(envio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DestinatarioId = new SelectList(db.Destinatarios, "Id", "Nome", envio.DestinatarioId);
            return View(envio);
        }

        // GET: Envios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Envio envio = db.Envios.Find(id);
            if (envio == null)
            {
                return HttpNotFound();
            }
            ViewBag.DestinatarioId = new SelectList(db.Destinatarios, "Id", "Nome", envio.DestinatarioId);
            return View(envio);
        }

        // POST: Envios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Estado,DataExpedicao,DestinatarioId")] Envio envio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(envio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DestinatarioId = new SelectList(db.Destinatarios, "Id", "Nome", envio.DestinatarioId);
            return View(envio);
        }

        // GET: Envios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Envio envio = db.Envios.Find(id);
            if (envio == null)
            {
                return HttpNotFound();
            }
            return View(envio);
        }

        // POST: Envios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Envio envio = db.Envios.Find(id);
            db.Envios.Remove(envio);
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
