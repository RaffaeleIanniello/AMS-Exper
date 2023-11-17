using Amsterdam_Experience.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Amsterdam_Experience.Controllers
{
    public class HomeController : Controller
        
    {
        ModelDbContext db = new ModelDbContext();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        [HttpGet]
        public ActionResult Visting()
        {
            ViewBag.Title = "Visit Page";
            return View();
        }
        public ActionResult AmsExp()
        {
            ViewBag.Title = "Visit Page";
            return View();
        }
        public ActionResult Van()
        {
            ViewBag.Title = "Visit Page";
            return View();
        }
        public ActionResult Bboat()
        {
            ViewBag.Title = "Visit Page";
            return View();
        }
        public ActionResult Fran()
        {
            ViewBag.Title = "Visit Page";
            return View();
        }
        public ActionResult Madame()
        {
            ViewBag.Title = "Visit Page";
            return View();
        }
        public ActionResult Edge()
        {
            ViewBag.Title = "Visit Page";
            return View();
        }
        public ActionResult Zaandam()
        {
            ViewBag.Title = "Visit Page";
            return View();
        }
        public ActionResult RedLight()
        {
            ViewBag.Title = "Visit Page";
            return View();
        }
        public ActionResult Rijks()
        {
            ViewBag.Title = "Visit Page";
            return View();
        }
        public ActionResult Johan()
        {
            ViewBag.Title = "Visit Page";
            return View();
        }
        public ActionResult MapperDam()
        {
            return View();
        }
        public ActionResult prenotaTour()

        {

            return View(db.Esperienze.ToList());
        }
        public ActionResult dettaglioTour(int? id)
        {
            Session["dettaglio"] = id;
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Esperienze expert = db.Esperienze.Find(id);
            if(expert == null)
            {
                return HttpNotFound();
            }
            return View(expert);
        }
        //public ActionResult prenotaDettagli(int id)
        //{
        //    Session["dettaglio"] = id;
        //    var dettagli = db.Esperienze.Where(e=>e.idEsperienze==id).FirstOrDefault();
        //    return View(dettagli);
        //}
        //[HttpPost]
        //public ActionResult prenotaDettagli(int id, Esperienze es)
        //{
        //    return View();
        //}
       
        public JsonResult aggiungiexp(int valorenumero, int idUrl) {

        Esperienze experience = db.Esperienze.Find(idUrl);
        Utenti utents = db.Utenti.FirstOrDefault((e)=>e.username==User.Identity.Name);
            for (int i = 0; i <= valorenumero; i++)
            {
                Ordini ordini = new Ordini();
                ordini.fkUtenti = utents.idUtenti;
                ordini.fkEsperienze = experience.idEsperienze;
                db.Ordini.Add(ordini);
            }
                db.SaveChanges();
             return Json(valorenumero);
         }
        public ActionResult Carrello(int id)
        {

            List<Esperienze> xper = db.Esperienze.ToList();
            xper.Reverse();
            Esperienze xperienc = xper[0];

            List<Ordini> orders = db.Ordini.Where((m) => m.fkEsperienze == id).ToList();
            foreach (Ordini o in orders)
            {
                xperienc.Ordini.Add(o);
            }
            return View(xperienc);
        }
    }
}
