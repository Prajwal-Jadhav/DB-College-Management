using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DB_College_Management.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace DB_College_Management.Pages.Students
{
    [Authorize]
    public class EditModel: PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public DB_College_Management.Data.Entity.Student Input { get; set; }

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(string prn)
        {
            Input = await _context.Students.Where(s => s.PRN == prn).FirstOrDefaultAsync();

            if (Input == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string prn)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            int age = CalculateAge(Input.BirthDay);

            var student = await _context.Students.Where(s => s.PRN == prn).FirstOrDefaultAsync();

            student.PRN = Input.PRN;
            student.Name = Input.Name;
            student.BirthDay = Input.BirthDay;
            student.Email = Input.Email;
            student.Year = Input.Year;
            student.MobileNo = Input.MobileNo;
            student.Address = Input.Address;
            student.Age = age;
            
            await _context.SaveChangesAsync();

            return RedirectToPage("/Students/Details", new { prn = prn });
        }

        public int CalculateAge(DateTime birthDay)
        {
            var currentYear = DateTime.Now.Year;

            var age = currentYear - birthDay.Year;

            return age;
        }
    }
}