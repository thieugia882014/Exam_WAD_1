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
    public class ExamsController : Controller
    {
        private SystemDbContext db = new SystemDbContext();

        public ActionResult Index()
        {
            var exams = db.Exams.Include(e => e.ClassRoom).Include(e => e.ExamSubject).Include(e => e.Faculty);
            return View(exams.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        public ActionResult Create()
        {
            ViewBag.ClassRoomId = new SelectList(db.ClassRooms, "Id", "Name");
            ViewBag.ExamSubjectId = new SelectList(db.ExamSubjects, "Id", "Name");
            ViewBag.FacultyId = new SelectList(db.Faculties, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ExamSubjectId,StartTime,ExampleDate,Duration,ClassRoomId,FacultyId,Status")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Exams.Add(exam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassRoomId = new SelectList(db.ClassRooms, "Id", "Name", exam.ClassRoomId);
            ViewBag.ExamSubjectId = new SelectList(db.ExamSubjects, "Id", "Name", exam.ExamSubjectId);
            ViewBag.FacultyId = new SelectList(db.Faculties, "Id", "Name", exam.FacultyId);
            return View(exam);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassRoomId = new SelectList(db.ClassRooms, "Id", "Name", exam.ClassRoomId);
            ViewBag.ExamSubjectId = new SelectList(db.ExamSubjects, "Id", "Name", exam.ExamSubjectId);
            ViewBag.FacultyId = new SelectList(db.Faculties, "Id", "Name", exam.FacultyId);
            return View(exam);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ExamSubjectId,StartTime,ExampleDate,Duration,ClassRoomId,FacultyId,Status")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassRoomId = new SelectList(db.ClassRooms, "Id", "Name", exam.ClassRoomId);
            ViewBag.ExamSubjectId = new SelectList(db.ExamSubjects, "Id", "Name", exam.ExamSubjectId);
            ViewBag.FacultyId = new SelectList(db.Faculties, "Id", "Name", exam.FacultyId);
            return View(exam);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exam exam = db.Exams.Find(id);
            db.Exams.Remove(exam);
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
