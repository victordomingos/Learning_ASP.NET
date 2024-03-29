﻿using System;
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
    public class TarefasPorFuncionarioMesAtualController : Controller
    {
        private victor_DbGesTarefas db = new victor_DbGesTarefas();

        // GET: TarefasPorFuncionárioMesAtual
        public ActionResult Index(int? FuncionarioId)
        {
            var tarefas = db.Tarefas.Include(t => t.Cliente).Include(t => t.Funcionario).Include(t => t.TipoPrioridade).Include(t => t.TipoTarefa);
            tarefas = tarefas.Where(t => t.DataLimite.Year == DateTime.Now.Year);
            tarefas = tarefas.Where(t => t.DataLimite.Month == DateTime.Now.Month);

            var funcs = db.Funcionarios.ToList();
            ViewBag.FUNCIONARIOS = new SelectList(funcs, "Id", "NomeFuncionario");


            if(FuncionarioId.HasValue)
            {
                tarefas = tarefas.Where( t => t.FuncionarioID == FuncionarioId);
            }

           
            return View(tarefas.ToList());
        }

        // GET: TarefasPorFuncionárioMesAtual/Details/5
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

        // GET: TarefasPorFuncionárioMesAtual/Create
        public ActionResult Create()
        {
            ViewBag.ClienteID = new SelectList(db.Clientes, "Id", "NomeCliente");
            ViewBag.FuncionarioID = new SelectList(db.Funcionarios, "Id", "NomeFuncionario");
            ViewBag.TipoPrioridadeID = new SelectList(db.TiposDePrioridade, "Id", "DesignacaoPrioridade");
            ViewBag.TipoTarefaID = new SelectList(db.TiposDeTarefa, "Id", "DesignacaoTipoTarefa");
            return View();
        }

        // POST: TarefasPorFuncionárioMesAtual/Create
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

        // GET: TarefasPorFuncionárioMesAtual/Edit/5
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

        // POST: TarefasPorFuncionárioMesAtual/Edit/5
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

        // GET: TarefasPorFuncionárioMesAtual/Delete/5
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

        // POST: TarefasPorFuncionárioMesAtual/Delete/5
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
