using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amsterdam_Experience.Models
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        ModelDbContext db = new ModelDbContext();
        public ActionResult Index()
        {


            return View(db.Esperienze.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Esperienze e, HttpPostedFileBase img)
        {


            if (img != null && img.ContentLength > 0)
            {
                e.fotoEsperienza = img.FileName;
                string name = img.FileName;
                string path = Server.MapPath("~/Content/img/") + img.FileName;
                img.SaveAs(path);
            }
            db.Esperienze.Add(e);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            Esperienze p = db.Esperienze.Find(id);
            return View(p);

        }
        [HttpPost]
        public ActionResult Edit(Esperienze e, HttpPostedFileBase img)
        {
            if (ModelState.IsValid)
            {
                var esperienze = db.Esperienze.Find(e.idEsperienze);
                esperienze.nomeEsperienza = e.nomeEsperienza;
                esperienze.descrizioneEsperienza = e.descrizioneEsperienza;
                esperienze.fotoEsperienza = e.fotoEsperienza;
                esperienze.prezzoEsperienza = e.prezzoEsperienza;
                esperienze.dataEsperienza = e.dataEsperienza;
                db.Entry(esperienze).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(e);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Esperienze exper = db.Esperienze.Find(id);
            db.Esperienze.Remove(exper);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
    }