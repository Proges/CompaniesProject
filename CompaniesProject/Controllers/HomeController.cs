using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompaniesProject.Models;

namespace CompaniesProject.Controllers
{
    public class HomeController : Controller
    {
        CompaniesRepository cr = new CompaniesRepository();

        public ActionResult Index()
        {
            return View(cr.ShowAllCompanies());
        }

        public ActionResult Details(int id)
        {            
            return View(cr.ShowCompany(id));
        }


        public ActionResult Loggin()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Loggin(string email, string password)
        {
            string userName = cr.UserLoggin(email, password);

            if (userName != null)
            {
                Session["userName"] = userName;
                Session["userId"] = cr.UserId;
                return RedirectToAction("Index", "User");
            }
            else return RedirectToAction("Loggin");
        }

    }
}
