using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PeterGardinerAssignment5.Models;

namespace PeterGardinerAssignment5.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IProductRepository repository;
        public NavigationMenuViewComponent(IProductRepository r)
        {
            repository = r;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            return View(repository.Projects.Select(x => x.Category).Distinct().OrderBy(x => x));
        }
    }
}
