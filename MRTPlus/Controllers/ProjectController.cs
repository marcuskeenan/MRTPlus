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
using System.Data.Entity.Infrastructure;

namespace MRTPlus.Controllers
{
    public class ProjectController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Project/
        public ActionResult Index()
        {
            var projects = db.Projects.Include(p => p.ActivityType)
                .Include(p => p.BandRType)
                .Include(p => p.Building)
                .Include(p => p.CampusStrategy)
                .Include(p => p.Division)
                .Include(p => p.FundingType)
                .Include(p => p.IFISectionType)
                .Include(p => p.LOBCategory)
                .Include(p => p.NeedType)
                .Include(p => p.StatusType);
            return View(projects.ToList());
        }

        // GET: /Project/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Include(s => s.Files).SingleOrDefault(s => s.ProjectID == id);

            
            List<File> imagelist = new List<File>();

            imagelist = (from p in db.Files
                        where p.ProjectID == id
                        select p).ToList();

            ViewData["ImageList"] = imagelist;
           
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: /Project/Create
        public ActionResult Create()
        {
            ViewBag.ActivityTypeID = new SelectList(db.ActivityTypes, "ActivityTypeID", "Title");
            ViewBag.BandRTypeID = new SelectList(db.BandRTypes, "BandRTypeID", "Title");
            ViewBag.BuildingID = new SelectList(db.Buildings, "BuildingID", "Name");
            ViewBag.CampusStrategyID = new SelectList(db.CampusStrategies, "CampusStrategyID", "Title");
            ViewBag.DivisionID = new SelectList(db.Divisions, "DivisionID", "Title");
            ViewBag.FundingTypeID = new SelectList(db.FundingTypes, "FundingTypeID", "Title");
            ViewBag.IFISectionTypeID = new SelectList(db.IFISectionTypes, "IFISectionTypeID", "Title");
            ViewBag.LOBCategoryID = new SelectList(db.LOBCategories, "LOBCategoryID", "Title");
            ViewBag.NeedTypeID = new SelectList(db.NeedTypes, "NeedTypeID", "Title");
            ViewBag.StatusTypeID = new SelectList(db.StatusTypes, "StatusTypeID", "Title");
            return View();
        }

        // POST: /Project/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectID,Title,TEC,DivisionID,BuildingID,SMEID,Description,Justification,ActivityTypeID,FundingTypeID,Cost,NeedTypeID,BandRTypeID,IFISectionTypeID,DM,StatusTypeID,CampusStrategyID,LOBCategoryID,LOBRating,ShovelReady,EnrollmentDate,FY")] Project project, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var image = new File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileGUID = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(upload.FileName),
                        FileType = FileType.Image,
                        ContentType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        image.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    project.Files = new List<File> { image };
                }

                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = project.ProjectID });
            }

            ViewBag.ActivityTypeID = new SelectList(db.ActivityTypes, "ActivityTypeID", "Title", project.ActivityTypeID);
            ViewBag.BandRTypeID = new SelectList(db.BandRTypes, "BandRTypeID", "Title", project.BandRTypeID);
            ViewBag.BuildingID = new SelectList(db.Buildings, "BuildingID", "Name", project.BuildingID);
            ViewBag.CampusStrategyID = new SelectList(db.CampusStrategies, "CampusStrategyID", "Title", project.CampusStrategyID);
            ViewBag.DivisionID = new SelectList(db.Divisions, "DivisionID", "Title", project.DivisionID);
            ViewBag.FundingTypeID = new SelectList(db.FundingTypes, "FundingTypeID", "Title", project.FundingTypeID);
            ViewBag.IFISectionTypeID = new SelectList(db.IFISectionTypes, "IFISectionTypeID", "Title", project.IFISectionTypeID);
            ViewBag.LOBCategoryID = new SelectList(db.LOBCategories, "LOBCategoryID", "Title", project.LOBCategoryID);
            ViewBag.NeedTypeID = new SelectList(db.NeedTypes, "NeedTypeID", "Title", project.NeedTypeID);
            ViewBag.StatusTypeID = new SelectList(db.StatusTypes, "StatusTypeID", "Title", project.StatusTypeID);
            return View(project);
        }

        // GET: /Project/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Project project = db.Projects.Find(id);
            Project project = db.Projects.Include(s => s.Files).SingleOrDefault(s => s.ProjectID == id);

            if (project == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActivityTypeID = new SelectList(db.ActivityTypes, "ActivityTypeID", "Title", project.ActivityTypeID);
            ViewBag.BandRTypeID = new SelectList(db.BandRTypes, "BandRTypeID", "Title", project.BandRTypeID);
            ViewBag.BuildingID = new SelectList(db.Buildings, "BuildingID", "Name", project.BuildingID);
            ViewBag.CampusStrategyID = new SelectList(db.CampusStrategies, "CampusStrategyID", "Title", project.CampusStrategyID);
            ViewBag.DivisionID = new SelectList(db.Divisions, "DivisionID", "Title", project.DivisionID);
            ViewBag.FundingTypeID = new SelectList(db.FundingTypes, "FundingTypeID", "Title", project.FundingTypeID);
            ViewBag.IFISectionTypeID = new SelectList(db.IFISectionTypes, "IFISectionTypeID", "Title", project.IFISectionTypeID);
            ViewBag.LOBCategoryID = new SelectList(db.LOBCategories, "LOBCategoryID", "Title", project.LOBCategoryID);
            ViewBag.NeedTypeID = new SelectList(db.NeedTypes, "NeedTypeID", "Title", project.NeedTypeID);
            ViewBag.StatusTypeID = new SelectList(db.StatusTypes, "StatusTypeID", "Title", project.StatusTypeID);
            return View(project);
        }

        // POST: /Project/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id, HttpPostedFileBase upload)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var projectToUpdate = db.Projects.Find(id);
            if (TryUpdateModel(projectToUpdate, ""))
            {
                try
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        
                        //Uncomment below if only on file should exist
                        //if (projectToUpdate.Files.Any(f => f.FileType == FileType.Image))
                        //{
                          //  db.Files.Remove(projectToUpdate.Files.First(f => f.FileType == FileType.Image));
                        //}
                        var image = new File
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            FileGUID = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(upload.FileName),
                            FileType = FileType.Image,
                            ContentType = upload.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            image.Content = reader.ReadBytes(upload.ContentLength);
                        }
                        projectToUpdate.Files = new List<File> { image };
                    }


                    db.Entry(projectToUpdate).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            /*
            ViewBag.ActivityTypeID = new SelectList(db.ActivityTypes, "ActivityTypeID", "Title", project.ActivityTypeID);
            ViewBag.BandRTypeID = new SelectList(db.BandRTypes, "BandRTypeID", "Title", project.BandRTypeID);
            ViewBag.BuildingID = new SelectList(db.Buildings, "BuildingID", "Name", project.BuildingID);
            ViewBag.CampusStrategyID = new SelectList(db.CampusStrategies, "CampusStrategyID", "Title", project.CampusStrategyID);
            ViewBag.DivisionID = new SelectList(db.Divisions, "DivisionID", "Title", project.DivisionID);
            ViewBag.FundingTypeID = new SelectList(db.FundingTypes, "FundingTypeID", "Title", project.FundingTypeID);
            ViewBag.IFISectionTypeID = new SelectList(db.IFISectionTypes, "IFISectionTypeID", "Title", project.IFISectionTypeID);
            ViewBag.LOBCategoryID = new SelectList(db.LOBCategories, "LOBCategoryID", "Title", project.LOBCategoryID);
            ViewBag.NeedTypeID = new SelectList(db.NeedTypes, "NeedTypeID", "Title", project.NeedTypeID);
            ViewBag.StatusTypeID = new SelectList(db.StatusTypes, "StatusTypeID", "Title", project.StatusTypeID);*/
            return View(projectToUpdate);
        }

        // GET: /Project/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: /Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
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
