using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Udemy.TodoAppNTier.Business.Interfaces;
using Udemy.TodoAppNTier.WebUI.Models;

namespace Udemy.TodoAppNTier.WebUI.Controllers
{
    public class HomeController : Controller
    {

        private readonly IWorkServices _workServices;

        public HomeController(IWorkServices workServices)
        {
            _workServices = workServices;
        }

        public async Task<IActionResult> Index()
        {
            var worklist = await _workServices.GetAll();
            return View(worklist);
        }

        
    }
}
