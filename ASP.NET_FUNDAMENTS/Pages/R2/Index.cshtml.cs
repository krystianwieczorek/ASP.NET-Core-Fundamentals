using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OddToFood.Data;
using OdeToFood.Core;

namespace ASP.NET_FUNDAMENTS.Pages.R2
{
    public class IndexModel : PageModel
    {
        private readonly OddToFood.Data.OdeToFoodDbContext _context;

        public IndexModel(OddToFood.Data.OdeToFoodDbContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; }

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurants.ToListAsync();
        }
    }
}
