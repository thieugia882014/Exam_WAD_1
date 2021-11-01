using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Exam_WAD_1.Models;

namespace Exam_WAD_1.Controllers
{
    public class ExamSubjectsController : Controller
    {
        private SystemDbContext db = new SystemDbContext();

        public ActionResult Index()
        {
            return View(db.ExamSubjects.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamSubject examSubject = db.ExamSubjects.Find(id);
            if (examSubject == null)
            {
                return HttpNotFound();
            }
            return View(examSubject);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] ExamSubject examSubject)
        {
            if (ModelState.IsValid)
            {
                db.ExamSubjects.Add(examSubject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(examSubject);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamSubject examSubject = db.ExamSubjects.Find(id);
            if (examSubject == null)
            {
                return HttpNotFound();
            }
            return View(examSubject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] ExamSubject examSubject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examSubject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(examSubject);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamSubject examSubject = db.ExamSubjects.Find(id);
            if (examSubject == null)
            {
                return HttpNotFound();
            }
            return View(examSubject);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExamSubject examSubject = db.ExamSubjects.Find(id);
            db.ExamSubjects.Remove(examSubject);
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
