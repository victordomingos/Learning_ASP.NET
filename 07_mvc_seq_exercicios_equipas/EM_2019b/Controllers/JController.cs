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
    public class JController : Controller
    {
        private EquipasContext db = new EquipasContext();

        // GET: J
        public ActionResult Index(int? id_equipa)
        {
            ViewBag.EQUIPAS = new SelectList(db.Tequipas.ToList(), "id", "nomeequipa");
            List<Membro> tmembros;

            if (id_equipa.HasValue)
                { tmembros = db.Tmembros.Where(m => m.EquipaID == id_equipa).ToList(); }
            else
                { tmembros = db.Tmembros.ToList(); }
            
            return View(tmembros);
        }

        // GET: J/Details/5
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

        // GET: J/Create
        public ActionResult Create()
        {
            ViewBag.EquipaID = new SelectList(db.Tequipas, "Id", "NomeEquipa");
            return View();
        }

        // POST: J/Create
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

        // GET: J/Edit/5
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

        // POST: J/Edit/5
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

        // GET: J/Delete/5
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

        // POST: J/Delete/5
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
