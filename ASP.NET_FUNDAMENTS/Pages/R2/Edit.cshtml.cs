﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OddToFood.Data;
using OdeToFood.Core;

namespace ASP.NET_FUNDAMENTS.Pages.R2
{
    public class EditModel : PageModel
    {
        private readonly OddToFood.Data.OdeToFoodDbContext _context;
        private readonly IHtmlHelper htmlHelper;

        public IEnumerable<SelectListItem> Cousines { get; set; }

        public EditModel(OddToFood.Data.OdeToFoodDbContext context, IHtmlHelper htmlHelper)
        {
            _context = context;
            this.htmlHelper = htmlHelper;
        }

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            Cousines = htmlHelper.GetEnumSelectList<CuisineType>();

            if (id == null)
            {
                return NotFound();
            }

            Restaurant = await _context.Restaurants.FirstOrDefaultAsync(m => m.Id == id);

            if (Restaurant == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Restaurant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(Restaurant.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RestaurantExists(int id)
        {
            return _context.Restaurants.Any(e => e.Id == id);
        }
    }
}
