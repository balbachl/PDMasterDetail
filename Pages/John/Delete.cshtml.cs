using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PDMasterDetail.Data;
using PDMasterDetail.Models;

namespace PDMasterDetail.Pages.John
{
    public class DeleteModel : PageModel
    {
        private readonly PDMasterDetail.Data.PDMasterDetailContext _context;

        public DeleteModel(PDMasterDetail.Data.PDMasterDetailContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Resources Resources { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Resources = await _context.Resources.FirstOrDefaultAsync(m => m.ID == id);

            if (Resources == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Resources = await _context.Resources.FindAsync(id);

            if (Resources != null)
            {
                _context.Resources.Remove(Resources);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
