using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaTecnicaCrud.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaCrud.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

    }
}
