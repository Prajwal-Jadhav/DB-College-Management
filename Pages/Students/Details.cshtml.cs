using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DB_College_Management.Data;
using DB_College_Management.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace DB_College_Management.Pages.Student
{
    public class DetailsModel: PageModel
    {
        private readonly ApplicationDbContext _context;

        public DB_College_Management.Data.Entity.Student Student { get; set; }

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(string prn)
        {
            Student = await _context.Students.Where(s => s.PRN == prn).FirstOrDefaultAsync();

            if (Student == null)
                return NotFound($"Student with PRN {prn} does not exist.");

            return Page();
        }
    }
}