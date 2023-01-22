using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.EnterpriseServices;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Web;
using System.Web.Mvc;
using testest.Models;

namespace testest.Controllers
{
    [Authorize(Roles =  "User")]
    [SecurityRole("User")]
  
    public class CandidatController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

            // GET: Candidat
            public ActionResult MesTestsQCM()
            {
            var useriD = User.Identity.GetUserId();
            var restests = db.Resultat_Tests.Where(x => x.Candidat.Id == useriD).AsEnumerable();
                //db.Users.Where(x=>x.Id == useriD).Include("Resultat_Tests").AsEnumerable(); 
            System.Diagnostics.Debug.WriteLine("heyyyy hteree !!!!!!!!!!!!!!!: " );

           // var restests = db.Entry(user).Reference(c => c.Resultat_Tests).Load();
            ///user.Include(x=>x.Res).ToList();
                //Resultat_Tests.Include("Test").ToList();
            return View(restests);
            }

        // GET: Candidat/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Candidat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Candidat/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Candidat/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Candidat/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Candidat/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Candidat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult DetailsTest(int id)
        {
            var testqcm = db.Tests.Find(id);
            return View(testqcm);
        }
    }
}
