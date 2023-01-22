using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testest.Models;

namespace testest.Controllers
{
    [Authorize]
    public class TestsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
             
        // GET: Test
        public ActionResult Index()
        {
            var tests = db.Tests.ToList();
            return View(tests);
        }

        // GET: Test/Details/5
        public ActionResult Details(int id)
        {
            var restests = db.Test_Questions.Where(x => x.Test.Id == id).ToList();
            var test = db.Tests.Find(id);
            return View(restests);
        }

        // GET: Test/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Test/Create
        [HttpPost]
        public ActionResult Create(Test test)
        {
            try
            {
                test = new Test
                {
                    titreTest = test.titreTest,
                    duree = test.duree,
                    nbrQuestion = test.nbrQuestion
                };
                db.Tests.Add(test);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Test/Edit/5
        public ActionResult Edit(int id)
        {
            var test = db.Tests.Find(id);

            return View(test);
        }

        // POST: Test/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Test testupdated)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                else
                {
                    var test = db.Tests.Find(id);
                    test.titreTest = testupdated.titreTest;
                    test.nbrQuestion= testupdated.nbrQuestion;
                    test.duree = testupdated.duree;

                    db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View(testupdated);
            }
        }

        // GET: Test/Delete/5
        public ActionResult Delete(int id)
        {
            var test = db.Tests.Find(id);
            return View(test);
           
        }

        // POST: Test/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Test test)
        {
            try
            {
                var findtest = db.Tests.Find(id);
                db.Tests.Remove(findtest);
                db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(test);
            }
        }
    }
}
