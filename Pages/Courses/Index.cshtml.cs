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

namespace DB_College_Management.Pages.Courses
{
    public class IndexModel: PageModel
    {
        private readonly ApplicationDbContext _context;

        public List<Course> Courses { get; set; }

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet()
        {
            Courses = await _context.Courses.OrderBy(c => c.CourseId).ToListAsync();

            return Page();
        }
    }

}