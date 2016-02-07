using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MRTPlus.Models;

namespace MRTPlus.Controllers
{
    public class ReviewDataController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /ReviewData/
        public ActionResult Index()
        {
            var reviewdatas = db.ReviewDatas.Include(r => r.Review).Include(r => r.ReviewElement);
            return View(reviewdatas.ToList());
        }

        // GET: /ReviewData/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewData reviewData = db.ReviewDatas.Find(id);
            if (reviewData == null)
            {
                return HttpNotFound();
            }
            return View(reviewData);
        }

        // GET: /ReviewData/Create
        public ActionResult Create()
        {
            ViewBag.ReviewID = new SelectList(db.Reviews, "ReviewID", "ReviewID");
            ViewBag.ReviewElementID = new SelectList(db.ReviewElements, "ReviewElementID", "Title");
            return View();
        }

        // POST: /ReviewData/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ReviewDataID,ReviewID,ReviewElementID")] ReviewData reviewData)
        {
            if (ModelState.IsValid)
            {
                db.ReviewDatas.Add(reviewData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReviewID = new SelectList(db.Reviews, "ReviewID", "ReviewID", reviewData.ReviewID);
            ViewBag.ReviewElementID = new SelectList(db.ReviewElements, "ReviewElementID", "Title", reviewData.ReviewElementID);
            return View(reviewData);
        }

        // GET: /ReviewData/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewData reviewData = db.ReviewDatas.Find(id);
            if (reviewData == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReviewID = new SelectList(db.Reviews, "ReviewID", "ReviewID", reviewData.ReviewID);
            ViewBag.ReviewElementID = new SelectList(db.ReviewElements, "ReviewElementID", "Title", reviewData.ReviewElementID);
            return View(reviewData);
        }

        // POST: /ReviewData/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ReviewDataID,ReviewID,ReviewElementID")] ReviewData reviewData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reviewData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReviewID = new SelectList(db.Reviews, "ReviewID", "ReviewID", reviewData.ReviewID);
            ViewBag.ReviewElementID = new SelectList(db.ReviewElements, "ReviewElementID", "Title", reviewData.ReviewElementID);
            return View(reviewData);
        }

        // GET: /ReviewData/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewData reviewData = db.ReviewDatas.Find(id);
            if (reviewData == null)
            {
                return HttpNotFound();
            }
            return View(reviewData);
        }

        // POST: /ReviewData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReviewData reviewData = db.ReviewDatas.Find(id);
            db.ReviewDatas.Remove(reviewData);
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
