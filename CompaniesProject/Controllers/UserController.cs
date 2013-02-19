using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompaniesProject.Models;

namespace CompaniesProject.Controllers
{
    public class UserController : Controller
    {
        CompaniesRepository cr = new CompaniesRepository();
        

        public ActionResult Index()
        {
            return View(cr.ShowAllCompanies());
        }

        
        public ActionResult Details(int id)
        {
            Session["companyId"] = id;
            return View(cr.ShowCompany(id));
        }

        
        public ActionResult Create()
        {
            CompaniesTable newCompany = new CompaniesTable();
            return View(newCompany);
        } 

        
        [HttpPost]
        public ActionResult Create(CompaniesTable newCompany)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    cr.AddCompany(newCompany);
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            } 
            
            return View(newCompany);
            
        }
        
 
        public ActionResult Edit(int id)
        {            
            return View(cr.EditCompanyForm(id));
        }


        [HttpPost]
        public ActionResult Edit(int id, CompaniesTable editCompany)
        {
            try
            {
                cr.EditCompany(id, editCompany); 
                return RedirectToAction("Index");
            }
            catch
            {
                return View(editCompany);
            }
        }


        public ActionResult AddComment()
        {
            Company company = new Company();
            return View(company);
        }


        [HttpPost]
        public ActionResult AddComment(FormCollection collection)
        {
            string text = collection["commentArea"];
            try
            {
                if (ModelState.IsValid)
                {
                    cr.AddComment(Int32.Parse(Session["userId"].ToString()), Int32.Parse(Session["companyId"].ToString()), text);
                    return View("Details", cr.ShowCompany(Int32.Parse(Session["companyId"].ToString())));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(cr.ShowCompany(Int32.Parse(Session["companyId"].ToString())));
        }
              
    }
}
