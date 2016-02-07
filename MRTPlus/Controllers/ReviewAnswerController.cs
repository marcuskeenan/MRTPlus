using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MRTPlus.Models;
using MRTPlus.DAL;

namespace MRTPlus.Controllers
{
    public class ReviewAnswerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /ReviewAnswer/
        public ActionResult Index()
        {
            var reviewanswers = db.ReviewAnswers.Include(r => r.Review).Include(r => r.ReviewQuestionOption);
            return View(reviewanswers.ToList());
        }

        // GET: /ReviewAnswer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewAnswer reviewAnswer = db.ReviewAnswers.Find(id);
            if (reviewAnswer == null)
            {
                return HttpNotFound();
            }
            return View(reviewAnswer);
        }

        // GET: /ReviewAnswer/Create
        public ActionResult Create(int? id)
        {
            ViewBag.ReviewID = new SelectList(db.Reviews, "ReviewID", "ReviewID");


           // var reviewquestion = db.ReviewQuestions.Where(r => r.ReviewQuestionID == id)
                //.Select(s => s.Title);
            
            
            var reviewquestion = (from p in db.ReviewQuestions
                           where  p.ReviewQuestionID == id
                           select p.Title).FirstOrDefault();

            int reviewtypeid = (from p in db.ReviewQuestions
                                where p.ReviewQuestionID == id
                                select p.ReviewTypeID).Single();

            var reviewtype = (from p in db.ReviewTypes
                                where p.ReviewTypeID == reviewtypeid
                                select p.Title).FirstOrDefault();
            //ViewBag.ReviewQuestionOptionID = new SelectList(db.ReviewQuestionOptions, "ReviewQuestionOptionID", "Title", "Score");
            //return View();

            var options = db.ReviewQuestionOptions.OrderBy(p => p.Score).Where(r => r.ReviewQuestionID == id)
                .Select(s => new
                {
               
                Text = "(" + s.Score + " points)    " + s.Title ,
                Value = s.ReviewQuestionOptionID
            })
            .ToList();

           

            ViewBag.OptionsList = new SelectList(options, "Value", "Text");
            ViewBag.ReviewQuestion = reviewquestion;
            ViewBag.ReviewType = reviewtype;
            return View();
        }

        // POST: /ReviewAnswer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ReviewAnswerID,ReviewID,ReviewQuestionOptionID")] ReviewAnswer reviewAnswer)
        {
            if (ModelState.IsValid)
            {
                db.ReviewAnswers.Add(reviewAnswer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReviewID = new SelectList(db.Reviews, "ReviewID", "ReviewID", reviewAnswer.ReviewID);
            ViewBag.ReviewQuestionOptionID = new SelectList(db.ReviewQuestionOptions, "ReviewQuestionOptionID", "Title", reviewAnswer.ReviewQuestionOptionID);
            return View(reviewAnswer);
        }

        // GET: /ReviewAnswer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewAnswer reviewAnswer = db.ReviewAnswers.Find(id);
            if (reviewAnswer == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReviewID = new SelectList(db.Reviews, "ReviewID", "ReviewID", reviewAnswer.ReviewID);
            ViewBag.ReviewQuestionOptionID = new SelectList(db.ReviewQuestionOptions, "ReviewQuestionOptionID", "Title", reviewAnswer.ReviewQuestionOptionID);
            return View(reviewAnswer);
        }

        // POST: /ReviewAnswer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ReviewAnswerID,ReviewID,ReviewQuestionOptionID")] ReviewAnswer reviewAnswer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reviewAnswer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReviewID = new SelectList(db.Reviews, "ReviewID", "ReviewID", reviewAnswer.ReviewID);
            ViewBag.ReviewQuestionOptionID = new SelectList(db.ReviewQuestionOptions, "ReviewQuestionOptionID", "Title", reviewAnswer.ReviewQuestionOptionID);
            return View(reviewAnswer);
        }

        // GET: /ReviewAnswer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewAnswer reviewAnswer = db.ReviewAnswers.Find(id);
            if (reviewAnswer == null)
            {
                return HttpNotFound();
            }
            return View(reviewAnswer);
        }

        // POST: /ReviewAnswer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReviewAnswer reviewAnswer = db.ReviewAnswers.Find(id);
            db.ReviewAnswers.Remove(reviewAnswer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
