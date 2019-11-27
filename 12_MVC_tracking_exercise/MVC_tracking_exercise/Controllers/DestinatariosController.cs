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
    public class DestinatariosController : Controller
    {
        private DbTracking db = new DbTracking();

        // GET: Destinatarios
        public ActionResult Index()
        {
            return View(db.Destinatarios.ToList());
        }

        // GET: Destinatarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destinatario destinatario = db.Destinatarios.Find(id);
            if (destinatario == null)
            {
                return HttpNotFound();
            }
            return View(destinatario);
        }

        // GET: Destinatarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Destinatarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] Destinatario destinatario)
        {
            if (ModelState.IsValid)
            {
                db.Destinatarios.Add(destinatario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(destinatario);
        }

        // GET: Destinatarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destinatario destinatario = db.Destinatarios.Find(id);
            if (destinatario == null)
            {
                return HttpNotFound();
            }
            return View(destinatario);
        }

        // POST: Destinatarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] Destinatario destinatario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(destinatario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(destinatario);
        }

        // GET: Destinatarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destinatario destinatario = db.Destinatarios.Find(id);
            if (destinatario == null)
            {
                return HttpNotFound();
            }
            return View(destinatario);
        }

        // POST: Destinatarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Destinatario destinatario = db.Destinatarios.Find(id);
            db.Destinatarios.Remove(destinatario);
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
