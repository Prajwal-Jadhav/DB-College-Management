

namespace DB_College_Management.Data.Entity
{
    public class Course
    {
        public string CourseId { get; set; }

        public string Name { get; set; }

        public int Semester { get; set; }

        public int Strength { get; set; }

        public Professor Professor { get; set; }
    }
}