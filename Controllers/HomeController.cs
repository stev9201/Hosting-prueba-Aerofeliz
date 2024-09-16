using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;




namespace ProyectoAerofeliz.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Pagina de contacto";

            return View();
        }

        public ActionResult Destinos()
        {
            ViewBag.Message = "Nacionales e Internacionales";

            return View();
        }

    }
}