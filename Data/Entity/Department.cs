using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DB_College_Management.Data.Entity
{
    public class Department
    {
        [Key]
        public string Name { get; set; }

        public List<Professor> Professors { get; set; }

        public List<Student> Students { get; set; }

        public List<Course> Courses { get; set; }
    }
}