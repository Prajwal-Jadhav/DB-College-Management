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
using Microsoft.AspNetCore.Authorization;

namespace DB_College_Management.Pages.Students
{
    [Authorize]
    public class DeleteModel: PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnPostAsync(string prn)
        {
            var student = await _context.Students.Where(s => s.PRN == prn).FirstOrDefaultAsync();

            if (student == null)
                return NotFound();

            _context.Students.Remove(student);

            await _context.SaveChangesAsync();

            return RedirectToPage("/Students/Index");
        } 
    }
}