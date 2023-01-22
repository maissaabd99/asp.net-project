using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using testest.Models;
using static System.Net.Mime.MediaTypeNames;

namespace testest.Controllers
{
    [Authorize]
    public class QuestionsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Question
        [Route("Admin/Questions")]
        public ActionResult Index()
        {
            var questions = db.Questions.ToList();
            return View(questions);
        }

        // GET: Question/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Question/Create
        public ActionResult Create(QuestionViewModel qvm)
        {
            var question = new Question();
            var tests = db.Tests.ToList();
            qvm.tests = tests;
            qvm.question =question;
            return View(qvm);
        }

        // POST: Question/Create
        [HttpPost]
        public ActionResult Create(Question question)
        {
            var idtest = Request["select"];
            var aux  = Int32.Parse(idtest);
            var x = db.Tests.Find(aux);
            System.Diagnostics.Debug.WriteLine("Helooooooooooooo !!!!!!!!!!!!" + x.titreTest);
            System.Diagnostics.Debug.WriteLine("heyyyy hteree !!!!!!!!!!!!"+idtest);

            try
            {
                question = new Question
                {
                    texte = question.texte,
                    noteTotale = question.noteTotale,
                   
                };
                db.Questions.Add(question);
                db.SaveChanges();
                
                Test_Question testQuestion = new Test_Question()
                {
                    Question = question,
                    Test = x
                };
                db.Test_Questions.Add(testQuestion);
                db.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                QuestionViewModel qvm = new QuestionViewModel();
                var tests = db.Tests.ToList();
                qvm.tests = tests;
                qvm.question = new Question();
                return View(qvm);
            }
        }
       

        // GET: Question/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Question/Edit/5
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

        // GET: Question/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var question = db.Questions.Find(id);
            return View(question);
        }

        // POST: Question/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Question question)
        {
            var quest = db.Questions.Find(id);
            System.Diagnostics.Debug.WriteLine("Maissaaaaaaaaaaaa !!!!!!!!!!!!" + question.Id);
            try
            {
                foreach(var item in quest.Reponse)
                {
                    db.Reponses.Remove(item);
                    //db.SaveChanges();
                }
                db.Questions.Remove(quest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(quest);
            }
        }
        [HttpGet]
        public ActionResult AjouterReponse(int id)
        {
            var question = db.Questions.Find(id);
            var rvm = new ReponseViewModel();
            rvm.reponse = new Reponse();
            rvm.question = question;
            return View(rvm);
        }

        [HttpPost]
        public ActionResult AjouterReponse(int id,ReponseViewModel rep)
        {
            var quest = db.Questions.Find(id);
            try
            {
                var corr = Request["select"];
                var lasvalcorrecte = Int32.Parse(corr);
                byte[] intBytes = BitConverter.GetBytes(lasvalcorrecte);
                Array.Reverse(intBytes);
                byte[] result = intBytes;
                System.Diagnostics.Debug.WriteLine("Helooooooooooooo !!!!!!!!!!!!" + rep.reponse.texte);
                
                var rep1 = new Reponse
                {
                    texte = rep.reponse.texte,
                    correcte = result,
                    Question = quest
                };
                db.Reponses.Add(rep1);
                db.SaveChanges();
                var rvm = new ReponseViewModel();
                rvm.reponse = rep.reponse;
                rvm.question = quest;
                return View(rvm);
            }
            catch
            {
                var rvm = new ReponseViewModel();
                rvm.reponse = new Reponse();
                rvm.question = quest;
                return View(rvm);
            }
        }

        [HttpGet]
        public ActionResult ToutesLesReponses(int id)
        {
            var quest = db.Questions.Find(id);
            var allrep = quest.Reponse.AsEnumerable();
            return View(allrep);
        }
        [HttpGet]
        public ActionResult EditReponse(int id)
        {
           
            var rep = db.Reponses.Find(id);
           
            return View(rep);
        }

        [HttpPost]
        public ActionResult EditReponse(int id,Reponse reponse)
        {
            var corr = Request["select"];
            System.Diagnostics.Debug.WriteLine("Helooooooooooooo !!!!!!!!!!!!" + corr);

            var lasvalcorrecte = Int32.Parse(corr);
            byte[] intBytes = BitConverter.GetBytes(lasvalcorrecte);
            Array.Reverse(intBytes);
            byte[] result = intBytes;

            var rep = db.Reponses.Find(id);
            rep.texte = reponse.texte;
            rep.correcte = result;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteReponse(int id)
        {

            var rep = db.Reponses.Find(id);
            return View(rep);
        }

        [HttpPost]
        public ActionResult DeleteReponse(int id,Reponse reponse)
        {
            var rep = db.Reponses.Find(id);
            try
            {
                db.Reponses.Remove(rep);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(rep);
            }

        }
    }
}
