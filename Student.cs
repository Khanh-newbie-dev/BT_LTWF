using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity_Framework_Core
{
    public class Student
    {
        [Key]
        public int Id { get; set; } // Khóa chính (Primary Key)

        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty; // Cột NVARCHAR(100), NOT NULL

        public double Grade { get; set; }

        // Khóa ngoại (Foreign Key)
        public int FacultyId { get; set; }

        // Navigation Property trỏ về Faculty
        [ForeignKey(nameof(FacultyId))]
        public virtual Faculty? Faculty { get; set; }
    }
}
