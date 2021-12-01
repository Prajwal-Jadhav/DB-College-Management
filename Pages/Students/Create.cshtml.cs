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

namespace DB_College_Management.Pages.Student
{
    public class CreateModel: PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public CreateBindingModel Input { get; set; }

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            int age = CalculateAge(Input.BirthDate);

            var student = new DB_College_Management.Data.Entity.Student(
                Input.Name, Input.PRN, Input.Email, Input.MobileNo, Input.Address, Input.BirthDate, Input.Year, age
            );

            _context.Students.Add(student);

            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }

        public int CalculateAge(DateTime birthDay)
        {
            var currentYear = DateTime.Now.Year;

            var age = currentYear - birthDay.Year;

            return age;
        }
    }
}
