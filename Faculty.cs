using System;
using System.Collections.Generic;
using System.Text;

namespace Entity_Framework_Core
{
    public class Faculty
    {
        public int Id { get; set; } // Primary Key (Identity)
        public required string FacultyName { get; set; } // NVARCHAR, NOT NULL

        // Navigation Property: 1 Khoa có nhiều Sinh viên
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
