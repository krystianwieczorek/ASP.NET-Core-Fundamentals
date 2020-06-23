using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OddToFood.Data;
using OdeToFood.Core;

namespace ASP.NET_FUNDAMENTS.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData restauranttData;

        public Restaurant Restaurant { get; set; }

        public DeleteModel(IRestaurantData restauranttData)
        {
            this.restauranttData = restauranttData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restauranttData.GetById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int restaurantId)
        {
            var restaurant = restauranttData.Delete(restaurantId);
            restauranttData.Commit();

            if(restaurant == null)
            {
               return RedirectToPage("./NoFound");
            }

            TempData["Message"] = $"{restaurant.Name} deleted";
            return RedirectToPage("./List");
        }
    }
}