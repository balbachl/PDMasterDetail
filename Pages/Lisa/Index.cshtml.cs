using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PDMasterDetail.Data;
using PDMasterDetail.Models;

namespace PDMasterDetail.Pages.Lisa
{
    public class IndexModel : PageModel
    {
        private readonly PDMasterDetail.Data.PDMasterDetailContext _context;

        public IndexModel(PDMasterDetail.Data.PDMasterDetailContext context)
        {
            _context = context;
        }

        public IList<Resources> Resources { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public string TitleSort { get; set; }
        public string TypeSort { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "TitleDesc" : "";
            TypeSort = sortOrder == "TypeAsc" ? "TypeDesc" : "TypeAsc";

            var resources = from r in _context.Resources
                         select r;
            if (!string.IsNullOrEmpty(SearchString))
            {
                resources = resources.Where(r => r.Title.Contains(SearchString));
            }
            switch (sortOrder)
            {
                case "TitleDesc":
                    resources = resources.OrderByDescending(r => r.Title);
                    break;
                case "TypeDesc":
                    resources = resources.OrderByDescending(r => r.Type);
                    break;
                case "TypeAsc":
                    resources = resources.OrderBy(r => r.Type);
                    break;
                default:
                    resources = resources.OrderBy(r => r.Title);
                    break;
            }

            Resources = await resources.ToListAsync();
        }
    }
}
