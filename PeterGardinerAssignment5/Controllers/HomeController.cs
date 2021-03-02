using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PeterGardinerAssignment5.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PeterGardinerAssignment5.Models;
using PeterGardinerAssignment5.Models.ViewModels;

namespace PeterGardinerAssignment5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IProductRepository _repository;

        public int PageSize = 5;

        public HomeController(ILogger<HomeController> logger, IProductRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(string category, int page=1)
        {
            return View(new ProductListViewModel
            {
                //return correct page and make them the right size with linq
                Products = _repository.Projects.Where(p => category == null || p.Category == category).OrderBy(p => p.BookId).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalNumItems = category == null ? _repository.Projects.Count() :
                        _repository.Projects.Where(x => x.Category == category).Count()
                },
                CurrentCategory = category
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
