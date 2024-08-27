using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PDMasterDetail.Data;
using PDMasterDetail.Models;

namespace PDMasterDetail.Pages.Default
{
    public class CreateModel : PageModel
    {
        private readonly PDMasterDetail.Data.PDMasterDetailContext _context;

        public CreateModel(PDMasterDetail.Data.PDMasterDetailContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Resources Resources { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Resources == null || Resources == null)
            {
                return Page();
            }

            _context.Resources.Add(Resources);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
