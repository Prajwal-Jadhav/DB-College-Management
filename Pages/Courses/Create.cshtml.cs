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


namespace DB_College_Management.Pages.Courses
{
    public class CreateModel: PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public Course Input { get; set; }

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGetAsync()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var course = new Course()
            {
                CourseId = Input.CourseId,
                Name = Input.Name,
                Semester = Input.Semester,
                Strength = Input.Strength
            };

            _context.Courses.Add(course);

            await _context.SaveChangesAsync();

            return RedirectToPage("/Courses/Index");
        }
    }
}