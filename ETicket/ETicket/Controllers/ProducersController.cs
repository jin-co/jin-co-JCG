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
    public class ProducersController : Controller
    {
        //private readonly AppDbContext context;

        //public ProducersController(AppDbContext context)
        //{
        //    this.context = context;
        //}

        private readonly IProducersService service;

        public ProducersController(IProducersService service)
        {
            this.service = service;
        }

        // getting data asynchronously
        [AllowAnonymous] // this overrides '[Authorize]' and allow access to this action
        public async Task<IActionResult> Index()
        {
            var producers = await service.GetAllAsync();
            return View(producers);
        }

        //Get: producers/details/1
        [AllowAnonymous] // this overrides '[Authorize]' and allow access to this action
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await service.GetByIdAsync(id);
            if (producerDetails == null)
            {
                return View("NotFound");
            }
            return View(producerDetails);
        }

        //Get: Producers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL, FullName, Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }

            await service.AddAsync(producer);
            return RedirectToAction("Index");
        }

        //Get: Producers/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await service.GetByIdAsync(id);
            if (producerDetails == null)
            {
                return View("NotFound");
            }
            return View(producerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, 
            [Bind("Id, ProfilePictureURL, FullName, Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }

            if (id == producer.Id)
            {
                await service.UpdateAsync(id, producer);
                return RedirectToAction("Index");
            }
            return View(producer);
        }

                //Get: Producers/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await service.GetByIdAsync(id);
            if (producerDetails == null)
            {
                return View("NotFound");
            }
            return View(producerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetails = await service.GetByIdAsync(id);
            if (producerDetails == null)
            {
                return View("NotFound");
            }

            await service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
