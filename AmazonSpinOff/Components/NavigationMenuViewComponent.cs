using AmazonSpinOff.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonSpinOff.Components
{
    //Bring in the repository and declare it
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IAmazonRepository repository;

        public NavigationMenuViewComponent (IAmazonRepository r)
        {
            repository = r;
        }

        //Filter by category for NavMenu
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            return View(repository.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
