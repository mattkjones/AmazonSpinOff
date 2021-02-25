using AmazonSpinOff.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AmazonSpinOff.Models.ViewModels;

namespace AmazonSpinOff.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //Set Repository
        private IAmazonRepository _repository;

        //Set integer for how many items we want to display per page
        public int PageSize = 5;

        public HomeController(ILogger<HomeController> logger, IAmazonRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(int page = 1)
        {
            //Pass paging info into the Index view
            return View(
                new BookListViewModel
                {
                    Books = _repository.Books
                        .OrderBy(p => p.BookId)
                        .Skip((page - 1) * PageSize)
                        .Take(PageSize)
                    ,
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalNumItems = _repository.Books.Count()
                    }
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
