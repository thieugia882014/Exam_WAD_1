using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exam_WAD_1.Models
{
    public class Exam
    {
        [Key]
        public int Id { get; set; }


        public int ExamSubjectId { get; set; }

        public virtual ExamSubject ExamSubject { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ExampleDate { get; set; }

        [Required]
        public int Duration { get; set; }

        public int ClassRoomId { get; set; }

        public virtual ClassRoom ClassRoom { get; set; }

        public int FacultyId { get; set; }

        public virtual Faculty Faculty { get; set; }

        public string Status { get; set; }

    }
}