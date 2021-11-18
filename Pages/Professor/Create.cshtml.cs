using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DB_College_Management.Model.Professor;
using DB_College_Management.Data;
using DB_College_Management.Data.Entity;

namespace DB_College_Management.Pages.Professor
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Data.Entity.Professor Input { get; set; }

        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Professors.Add(Input);

            await _context.SaveChangesAsync();

            return LocalRedirect("/Index");
        }
    }
}
