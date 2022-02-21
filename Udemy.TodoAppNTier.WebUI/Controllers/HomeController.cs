using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Udemy.TodoAppNtier.Dtos.WorkDto;
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

        public IActionResult Create()
        {
            return View(new WorkCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkCreateDto Dto)
        {
            if (ModelState.IsValid)
            {
                await _workServices.Create(Dto);
                return RedirectToAction("Index");
            }            
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            var dto = await _workServices.GetById(id);
            return View(new WorkUpdateDto
            {
                Id = dto.Id,
                Definition = dto.Definition,
                IsCompleted = dto.IsCompleted
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(WorkUpdateDto dto)
        {
            if (ModelState.IsValid)
            {
                await _workServices.Update(dto);
                return RedirectToAction("Index");
            }
            return View(dto);

        }

        public async Task<IActionResult> Remove(int id)
        {
            await _workServices.Remove(id);
            return RedirectToAction("Index");
        }


    }
}
