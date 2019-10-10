using EquipaMembros2019.DAL;
using EquipaMembros2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EquipaMembros2019.Controllers
{
    public class IController : Controller
    {
        private EquipasContext db = new EquipasContext();
        
        // GET: I
        public ActionResult Index()
        {
            // Listar todas as equipas
            var lista_de_equipas = from e in db.Tequipas select e;
            ViewBag.TODOS = lista_de_equipas.ToList();

            // Contar o total de equipas
            ViewBag.NUM_EQUIPAS = db.Tequipas.Count();
            
            // Listar todas as equipas, por ordem alfabética
            ViewBag.TODOS_ALFA = lista_de_equipas.OrderBy(e => e.NomeEquipa).ToList();
            

            // Listar todas as equipas, por ordem alfabética inversa
            ViewBag.TODOS_ALFA_DESC = lista_de_equipas.OrderByDescending(e => e.NomeEquipa).ToList();


            // Qual é o nome da equipa nº 3?
                        //Equipa registo = db.Tequipas.Find(3);
                        //ViewBag.THREE_NAME = registo.NomeEquipa;
            ViewBag.THREE_NAME = db.Tequipas.Find(3).NomeEquipa;


            // Qual é o nome da equipa nº 88?
            try
                { ViewBag.UNKOWN_NAME = db.Tequipas.Find(88).NomeEquipa; }
            catch (NullReferenceException)
                { ViewBag.UNKOWN_NAME = "N/A"; }


            //// Alternativa:
            //
            //Equipa reg = db.Tequipas.Find(88);
            //if (reg != null)
            //    { ViewBag.UNKOWN_NAME = reg.NomeEquipa; }
            //else
            //    { ViewBag.UNKOWN_NAME = "N/A"; }

            
            // Qual é o primeiro registo?
            ViewBag.FIRST_RECORD = db.Tequipas.First().NomeEquipa;


            // Existe(m) equipa(s) chamada(s) "Arsenal da Devesa"?
            string nome = "Arsenal da Devesa";
            var lista_arsenal = db.Tequipas.Where(eq => eq.NomeEquipa.Contains(nome)).ToList();
            int num_regs = lista_arsenal.Count();
            
            if(num_regs == 0) 
            { 
                ViewBag.ARSENAL = "Não existe nenhuma equipa com esse nome."; 
            }
            else if (num_regs == 1)
            {
                ViewBag.ARSENAL = $"Sim, existe um clube com esse nome (ID: {lista_arsenal.First().Id}).";
            }
            else
            {
                string lista_ids = "";
                for (int i = 0; i < lista_arsenal.Count(); i++)
                {
                    lista_ids += $"{lista_arsenal[i].Id.ToString()}";
                    if (i < lista_arsenal.Count()-1)
                        { lista_ids += ", ";}
                }

                ViewBag.ARSENAL = $"Existem vários clubes com esse nome (IDs: {lista_ids})."; 
            }


            // Quantos membros tem a equipa 4?
            ViewBag.MEMBROS_EQ4 = db.Tmembros
                    .Where(m => m.Equipa.Id == 4)
                    .Count();


            // Quantos membros tem a equi+a Arsenal da Devesa?
            ViewBag.MEMBROS_ARSENAL = db.Tmembros
                    .Where(m => m.Equipa.NomeEquipa == "Arsenal da Devesa")
                    .Count();
            
            //// Alternativa:

            //int cod_equipa = db.Tequipas.FirstOrDefault(i => i.NomeEquipa == "Arsenal da Devesa").Id;  //localizar chave primária da equipa
            //ViewBag.MEMBROS_ARSENAL = db.Tmembros                                                      //
            //        .Where(m => m.Equipa.Id == cod_equipa)
            //        .Count();


            return View();
        }
    }
}