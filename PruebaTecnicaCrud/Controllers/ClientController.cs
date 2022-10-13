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
    public class ClientController : Controller
    {
        private readonly ILogger<ClientController> _logger;

        public ClientController(ILogger<ClientController> logger)
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
