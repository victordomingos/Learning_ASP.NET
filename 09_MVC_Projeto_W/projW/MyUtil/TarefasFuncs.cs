using projW.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projW.MyUtil
{
    public class TarefasFuncs
    {
        private readonly victor_DbGesTarefas db = new victor_DbGesTarefas();

        public int GetClienteID(string nome)
        {
            try
            {
                return db.Clientes.FirstOrDefault(c => c.NomeCliente == nome).Id;
            }
            catch (ArgumentNullException)
            {
                return -1;
            }
        }


        public string GoodMorning()
        {
            var h = DateTime.Now.Hour;

            if (h < 12)
                return "Good morning!";
            else if (h < 20)
                return "Good afternoon!";
            else
                return "Good evening!";
        }
        
    }
}