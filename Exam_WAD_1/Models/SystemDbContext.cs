using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Exam_WAD_1.Models
{
    public class SystemDbContext : DbContext
    {
        public SystemDbContext() : base("Exam") { }

        public DbSet<ExamSubject> ExamSubjects { get; set; }

        public DbSet<ClassRoom> ClassRooms { get; set; }

        public DbSet<Faculty> Faculties { get; set; }

        public DbSet<Exam> Exams { get; set; }

    }
}