using Amsterdam_Experience.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Amsterdam_Experience.Controllers
{
    public class LoginController : Controller

    {
        ModelDbContext db = new ModelDbContext();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Utenti u)
        {
            var utente = db.Utenti.FirstOrDefault(user =>

                user.username == u.username && user.password == u.password);

            Session["users"] = u.idUtenti;
            FormsAuthentication.SetAuthCookie(utente.username, false);
            return RedirectToAction("Index", "Home");



        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Register(Utenti u)
        {
            u.role = "User";
            db.Utenti.Add(u);
            db.SaveChanges();
            return RedirectToAction("Login", "Login");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}