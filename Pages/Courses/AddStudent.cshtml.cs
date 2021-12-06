using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using DB_College_Management.Model.Student;
using DB_College_Management.Data;
using DB_College_Management.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace DB_College_Management.Pages.Courses
{
    [Authorize]
    public class AddStudentModel: PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public List<string> StudentIds { get; set; }

        public Course Course { get; set; }

        public List<DB_College_Management.Data.Entity.Student> AlreadyEnrolled { get; set; }

        public List<SelectListItem> ToBeEnrolled { get; set; }

        public AddStudentModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(string courseId)
        {
            Course = await _context.Courses.Include(c => c.Students)
                                        .Where(c => c.CourseId == courseId)
                                        .FirstOrDefaultAsync();

            AlreadyEnrolled = Course.Students;

            var students = await _context.Students.ToListAsync();
            ToBeEnrolled = students.Except(AlreadyEnrolled).Select(s => new SelectListItem(s.Name, s.PRN)).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string courseId)
        {
            Course = await _context.Courses.Include(c => c.Students)
                                        .Where(c => c.CourseId == courseId)
                                        .FirstOrDefaultAsync();

            var allStudents = await _context.Students.ToListAsync();

            var requiredStudents = allStudents.Where(s => StudentIds.Contains(s.PRN)).ToList();

            foreach (var student in requiredStudents)
            {
                if (!Course.Students.Contains(student) && (Course.Students.Count < Course.Strength))
                {
                    Course.Students.Add(student);
                }
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("/Courses/AddStudent", new { courseId = courseId });
        }


        public async Task<IActionResult> OnPostRemoveStudentAsync(string courseId, string prn)
        {
            var course = await _context.Courses.Include(c => c.Students).Where(c => c.CourseId == courseId).FirstOrDefaultAsync();
            course.Students.RemoveAll(s => s.PRN == prn);

            await _context.SaveChangesAsync();

            return RedirectToPage("/Courses/AddStudent", new { courseId = courseId });
        }

    }
}