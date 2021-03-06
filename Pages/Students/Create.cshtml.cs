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
using Microsoft.AspNetCore.Authorization;

namespace DB_College_Management.Pages.Students
{
    [Authorize]
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

            var student = new DB_College_Management.Data.Entity.Student()
            {
                Name = Input.Name, 
                PRN = Input.PRN, 
                Email = Input.Email, 
                MobileNo = Input.MobileNo, 
                Address = Input.Address, 
                BirthDay = Input.BirthDate, 
                Year = Input.Year, 
                Age = age
            };

            _context.Students.Add(student);

            await _context.SaveChangesAsync();

            return RedirectToPage("/Students/Index");
        }

        public int CalculateAge(DateTime birthDay)
        {
            var currentYear = DateTime.Now.Year;

            var age = currentYear - birthDay.Year;

            return age;
        }
    }
}
