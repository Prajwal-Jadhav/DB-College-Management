using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DB_College_Management.Data.Entity
{
    public class Professor
    {
        [MaxLength(length: 20)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Qualification { get; set; }

        public long MobileNo { get; set; }

        public string Address { get; set; }

        [MaxLength(length: 50)]
        [EmailAddress]
        public string Email { get; set; }

        public Decimal Salary { get; set; }

        public List<Student> Students { get; set; }

        public List<Course> Courses { get; set; }

        public Department Department { get; set; }
    }
}