using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EquipaMembros2019.DAL;
using EquipaMembros2019.Models;

namespace EquipaMembros2019.Controllers
{
    public class MembroesController : Controller
    {
        private EquipasContext db = new EquipasContext();

        // GET: Membroes
        public ActionResult Index()
        {
            var tmembros = db.Tmembros.Include(m => m.Equipa);
            return View(tmembros.ToList());
        }

        // GET: Membroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membro membro = db.Tmembros.Find(id);
            if (membro == null)
            {
                return HttpNotFound();
            }
            return View(membro);
        }

        // GET: Membroes/Create
        public ActionResult Create()
        {
            ViewBag.EquipaID = new SelectList(db.Tequipas, "Id", "NomeEquipa");
            return View();
        }

        // POST: Membroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NomeMembro,EquipaID")] Membro membro)
        {
            if (ModelState.IsValid)
            {
                db.Tmembros.Add(membro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EquipaID = new SelectList(db.Tequipas, "Id", "NomeEquipa", membro.EquipaID);
            return View(membro);
        }

        // GET: Membroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membro membro = db.Tmembros.Find(id);
            if (membro == null)
            {
                return HttpNotFound();
            }
            ViewBag.EquipaID = new SelectList(db.Tequipas, "Id", "NomeEquipa", membro.EquipaID);
            return View(membro);
        }

        // POST: Membroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NomeMembro,EquipaID")] Membro membro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EquipaID = new SelectList(db.Tequipas, "Id", "NomeEquipa", membro.EquipaID);
            return View(membro);
        }

        // GET: Membroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membro membro = db.Tmembros.Find(id);
            if (membro == null)
            {
                return HttpNotFound();
            }
            return View(membro);
        }

        // POST: Membroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Membro membro = db.Tmembros.Find(id);
            db.Tmembros.Remove(membro);
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
