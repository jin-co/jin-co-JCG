using ETicket.Data;
using ETicket.Data.Services;
using ETicket.Data.Static;
using ETicket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket.Controllers
{
    [Authorize(Roles = UserRoles.Admin)] // adding a role restriction
    public class CinemasController : Controller
    {
        //private readonly AppDbContext context;

        //public CinemasController(AppDbContext context)
        //{
        //    this.context = context;
        //}

        private readonly ICinemasService service;

        public CinemasController(ICinemasService service)
        {
            this.service = service;
        }

        [AllowAnonymous] // this overrides '[Authorize]' and allow access to this action
        public async Task<IActionResult> Index()
        {
            var cinemas = await service.GetAllAsync();
            return View(cinemas);
        }

        //Get: cinemas/details/1
        [AllowAnonymous] // this overrides '[Authorize]' and allow access to this action
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails= await service.GetByIdAsync(id);
            if (cinemaDetails == null)
            {
                return View("NotFound");
            }
            return View(cinemaDetails);
        }

        //Get: cinemas/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo, Name, Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }

            await service.AddAsync(cinema);
            return RedirectToAction("Index");
        }

        //Get: cinemas/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetails= await service.GetByIdAsync(id);
            if (cinemaDetails== null)
            {
                return View("NotFound");
            }
            return View(cinemaDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id, Logo, Name, Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }

            if (id == cinema.Id)
            {
                await service.UpdateAsync(id, cinema);
                return RedirectToAction("Index");
            }
            return View(cinema);
        }

        //Get: cinemas/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetails= await service.GetByIdAsync(id);
            if (cinemaDetails== null)
            {
                return View("NotFound");
            }
            return View(cinemaDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinemaDetails= await service.GetByIdAsync(id);
            if (cinemaDetails== null)
            {
                return View("NotFound");
            }

            await service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
