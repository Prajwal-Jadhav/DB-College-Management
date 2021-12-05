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
    public class IndexModel: PageModel
    {
        private readonly ApplicationDbContext _context;

        public List<DB_College_Management.Data.Entity.Student> Students { get; set; }

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Students = await _context.Students.OrderBy(student => student.PRN).ToListAsync();

            return Page();
        }
    }
}