using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_exercise.Controllers
{
    public class CalcController : Controller
    {
        // GET: Calc
        public ActionResult Index(string quantity, string price)
        {

            bool status;
            ViewBag.result = 0;

            if (string.IsNullOrEmpty(quantity))
            {
                ViewBag.qtyMsg = "Please insert quantity.";
            }
            else
            {
                ViewBag.qtyMsg = "";
            }
            if(string.IsNullOrEmpty(price))
            {
                ViewBag.priceMsg = "Please insert price.";
            }
            else
            {
                ViewBag.priceMsg = "";
            }


            status = float.TryParse(quantity, out float f_quantity);
            if(status && float.TryParse(quantity, out float f_price))
            {
                ViewBag.result = f_quantity * f_price;
            }
                        
            return View();
        }
    }
}