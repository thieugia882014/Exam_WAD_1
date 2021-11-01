using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exam_WAD_1.Models
{
    public class ExamSubject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}