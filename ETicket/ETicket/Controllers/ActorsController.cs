using ETicket.Data;
using ETicket.Data.Services;
using ETicket.Data.Static;
using ETicket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket.Controllers
{
    //[Authorize] // without a argument, only checks if a user is logged in or not
    [Authorize(Roles = UserRoles.Admin)] // adding a role restriction
    public class ActorsController : Controller
    {
        //* Directly accessing DB
        //private readonly AppDbContext context;

        //public ActorsController(AppDbContext context)
        //{
        //    this.context = context;
        //}

        //public IActionResult Index()
        //{
        //    var data = context.Actors.ToList();
        //    return View(data);
        //}

        //* Using Services to access DB
        private readonly IActorsService service;

        public ActorsController(IActorsService service)
        {
            this.service = service;
        }

        [AllowAnonymous] // this overrides '[Authorize]' and allow access to this action
        public async Task<IActionResult> Index()
        {
            var data = await service.GetAllAsync();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [Bind("FullName, ProfilePictureURL, Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await service.AddAsync(actor);

            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous] // this overrides '[Authorize]' and allow access to this action
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await service.GetByIdAsync(id);

            if(actorDetails == null)
            {
                return View("NotFound");
            }

            return View(actorDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await service.GetByIdAsync(id);

            if (actorDetails == null)
            {
                return View("NotFound");
            }

            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,
            [Bind("ActorId, FullName, ProfilePictureURL, Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await service.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await service.GetByIdAsync(id);

            if (actorDetails == null)
            {
                return View("NotFound");
            }
            return View(actorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await service.GetByIdAsync(id);
            if (actorDetails == null)
            {
                return View("NotFound");
            }

            await service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
