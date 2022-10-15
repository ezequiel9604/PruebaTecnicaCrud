using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaTecnicaCrud.Models;
using PruebaTecnicaCrud.Repositories;
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
        private readonly IClientRepository _clientRepository;

        public ClientController(ILogger<ClientController> logger,
            IClientRepository clientRepository)
        {
            _logger = logger;
            _clientRepository = clientRepository;
        }

        public async Task<IActionResult> Index()
        {

            var dtos = await _clientRepository.GetAllAsync();

            return View(dtos);
        }

        public IActionResult Add()
        {
            return View();
        }

    }
}
