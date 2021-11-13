using ETicket.Data;
using ETicket.Data.Services;
using ETicket.Data.Static;
using ETicket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket.Controllers
{
    [Authorize(Roles = UserRoles.Admin)] // adding a role restriction
    public class MoviesController : Controller
    {
        //private readonly AppDbContext context;

        //public MoviesController(AppDbContext context)
        //{
        //    this.context = context;
        //}

        private readonly IMoviesService service;

        public MoviesController(IMoviesService service)
        {
            this.service = service;
        }

        [AllowAnonymous] // this overrides '[Authorize]' and allow access to this action
        public async Task<IActionResult> Index()
        {
            //var moives = await context.Movies
            //    .Include(n => n.Cinema)
            //    .OrderBy(m => m.Name)
            //    .ToListAsync();
            //return View(moives);

            var moives = await service.GetAllAsync(n => n.Cinema);
            return View(moives);
        }

        //Get: Movies/Details/1
        [AllowAnonymous] // this overrides '[Authorize]' and allow access to this action
        public async Task<IActionResult> Details(int id)
        {
            var movieDetail = await service.GetMovieByIdAsync(id);
            return View(movieDetail);
        }

        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await service.GetNewMovieDropdownsValues();
            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await service.GetNewMovieDropdownsValues();
                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
                return View(movie);
            }

            await service.AddNewMovieAsync(movie);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await service.GetMovieByIdAsync(id);
            if (movieDetails == null)
            {
                return View("NotFound");
            }
            var response = new NewMovieVM()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                ImageURL = movieDetails.ImageURL,
                MovieCategory = movieDetails.MovieCategory,
                CinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId,
                ActorIds = movieDetails.ActorMovies.Select(n => n.ActorId).ToList()
            };

            var movieDropdownsData = await service.GetNewMovieDropdownsValues();
            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if (id != movie.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await service.GetNewMovieDropdownsValues();

                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

                return View(movie);
            }

            await service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous] // this overrides '[Authorize]' and allow access to this action
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await service.GetAllAsync(n => n.Cinema);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allMovies
                    .Where(n => n.Name.Contains(searchString) || 
                    n.Description.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", allMovies);
        }
    }
}
