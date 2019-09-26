using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LT.DAL;
using LT.Models;

namespace LT.Controllers
{
    public class ListaDeContactosController : Controller
    {
        private DbContactos db = new DbContactos();

        // GET: ListaDeContactos
        public ActionResult Index(string txt_pesquisa)
        {
            var T = from s in db.Tcontactos select s;

            if (string.IsNullOrEmpty(txt_pesquisa))
            {
                return View(T.ToList());
            }
            else
            {
                ViewBag.txt_pesquisa = txt_pesquisa;
               
                T = T.Where(s => s.Cliente.ToUpper().Contains(txt_pesquisa));
                return View(T.ToList());
            }
            
        }

        // GET: ListaDeContactos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaDeContactos listaDeContactos = db.Tcontactos.Find(id);
            if (listaDeContactos == null)
            {
                return HttpNotFound();
            }
            return View(listaDeContactos);
        }

        // GET: ListaDeContactos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListaDeContactos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Cliente,Telefone,Email")] ListaDeContactos listaDeContactos)
        {
            if (ModelState.IsValid)
            {
                db.Tcontactos.Add(listaDeContactos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(listaDeContactos);
        }

        // GET: ListaDeContactos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaDeContactos listaDeContactos = db.Tcontactos.Find(id);
            if (listaDeContactos == null)
            {
                return HttpNotFound();
            }
            return View(listaDeContactos);
        }

        // POST: ListaDeContactos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Cliente,Telefone,Email")] ListaDeContactos listaDeContactos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listaDeContactos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listaDeContactos);
        }

        // GET: ListaDeContactos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaDeContactos listaDeContactos = db.Tcontactos.Find(id);
            if (listaDeContactos == null)
            {
                return HttpNotFound();
            }
            return View(listaDeContactos);
        }

        // POST: ListaDeContactos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListaDeContactos listaDeContactos = db.Tcontactos.Find(id);
            db.Tcontactos.Remove(listaDeContactos);
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
