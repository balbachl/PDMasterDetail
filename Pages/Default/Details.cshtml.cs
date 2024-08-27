using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PDMasterDetail.Data;
using PDMasterDetail.Models;

namespace PDMasterDetail.Pages.Default
{
    public class DetailsModel : PageModel
    {
        private readonly PDMasterDetail.Data.PDMasterDetailContext _context;

        public DetailsModel(PDMasterDetail.Data.PDMasterDetailContext context)
        {
            _context = context;
        }

      public Resources Resources { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Resources == null)
            {
                return NotFound();
            }

            var resources = await _context.Resources.FirstOrDefaultAsync(m => m.ID == id);
            if (resources == null)
            {
                return NotFound();
            }
            else 
            {
                Resources = resources;
            }
            return Page();
        }
    }
}
