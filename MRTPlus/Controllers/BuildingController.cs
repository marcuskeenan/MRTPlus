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
    public class BuildingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Building/
        public ActionResult Index()
        {
            var buildings = db.Buildings.Include(b => b.BuildingStatus).Include(b => b.BuildingType).Include(b => b.BuildingUsage);
            return View(buildings.ToList());
        }

        // GET: /Building/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Building building = db.Buildings.Find(id);
            if (building == null)
            {
                return HttpNotFound();
            }
            return View(building);
        }

        // GET: /Building/Create
        public ActionResult Create()
        {
            ViewBag.BuildingStatusID = new SelectList(db.BuildingStatuses, "BuildingStatusID", "Title");
            ViewBag.BuildingTypeID = new SelectList(db.BuildingTypes, "BuildingTypeID", "Title");
            ViewBag.BuildingUsageID = new SelectList(db.BuildingUsages, "BuildingUsageID", "Title");
            return View();
        }

        // POST: /Building/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="BuildingID,Name,Number,PropertyNumber,Size,BuildingTypeID,BuildingUsageID,BuildingStatusID")] Building building)
        {
            if (ModelState.IsValid)
            {
                db.Buildings.Add(building);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BuildingStatusID = new SelectList(db.BuildingStatuses, "BuildingStatusID", "Title", building.BuildingStatusID);
            ViewBag.BuildingTypeID = new SelectList(db.BuildingTypes, "BuildingTypeID", "Title", building.BuildingTypeID);
            ViewBag.BuildingUsageID = new SelectList(db.BuildingUsages, "BuildingUsageID", "Title", building.BuildingUsageID);
            return View(building);
        }

        // GET: /Building/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Building building = db.Buildings.Find(id);
            if (building == null)
            {
                return HttpNotFound();
            }
            ViewBag.BuildingStatusID = new SelectList(db.BuildingStatuses, "BuildingStatusID", "Title", building.BuildingStatusID);
            ViewBag.BuildingTypeID = new SelectList(db.BuildingTypes, "BuildingTypeID", "Title", building.BuildingTypeID);
            ViewBag.BuildingUsageID = new SelectList(db.BuildingUsages, "BuildingUsageID", "Title", building.BuildingUsageID);
            return View(building);
        }

        // POST: /Building/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="BuildingID,Name,Number,PropertyNumber,Size,BuildingTypeID,BuildingUsageID,BuildingStatusID")] Building building)
        {
            if (ModelState.IsValid)
            {
                db.Entry(building).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BuildingStatusID = new SelectList(db.BuildingStatuses, "BuildingStatusID", "Title", building.BuildingStatusID);
            ViewBag.BuildingTypeID = new SelectList(db.BuildingTypes, "BuildingTypeID", "Title", building.BuildingTypeID);
            ViewBag.BuildingUsageID = new SelectList(db.BuildingUsages, "BuildingUsageID", "Title", building.BuildingUsageID);
            return View(building);
        }

        // GET: /Building/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Building building = db.Buildings.Find(id);
            if (building == null)
            {
                return HttpNotFound();
            }
            return View(building);
        }

        // POST: /Building/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Building building = db.Buildings.Find(id);
            db.Buildings.Remove(building);
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
