using ETicket.Data.Base;
using ETicket.Data.ViewModels;
using ETicket.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext context;
        public MoviesService(AppDbContext context) : base(context) 
        {
            this.context = context;
        }

        public async Task AddNewMovieAsync(NewMovieVM data)
        {
            var newMovie = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                CinemaId = data.CinemaId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                MovieCategory = data.MovieCategory,
                ProducerId = data.ProducerId
            };
            await context.Movies.AddAsync(newMovie);
            await context.SaveChangesAsync();

            // Add Movie Actor
            foreach (var i in data.ActorIds)
            {
                var newActorMovie = new ActorMovie()
                {
                    MovieId = newMovie.Id,
                    ActorId = i
                };
                await context.ActorMovies.AddAsync(newActorMovie);
            }
            await context.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.ActorMovies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);
            return await movieDetails;
                
        }

        public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues()
        {
            //var response = new NewMovieDropdownsVM();
            //response.Actors = await context.Actors.OrderBy(n => n.FullName).ToListAsync();
            //response.Cinemas = await context.Cinemas.OrderBy(n => n.Name).ToListAsync();
            //response.Producers = await context.Producers.OrderBy(n => n.FullName).ToListAsync();

            //return response;

            var response = new NewMovieDropdownsVM()
            {
                Actors = await context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Producers = await context.Producers.OrderBy(n => n.FullName).ToListAsync()
            };
            return response;
        }

        public async Task UpdateMovieAsync(NewMovieVM data)
        {
            var dbMovie = await context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbMovie != null)
            {
                dbMovie.Name = data.Name;
                dbMovie.Description = data.Description;
                dbMovie.Price = data.Price;
                dbMovie.ImageURL = data.ImageURL;
                dbMovie.CinemaId = data.CinemaId;
                dbMovie.StartDate = data.StartDate;
                dbMovie.EndDate = data.EndDate;
                dbMovie.MovieCategory = data.MovieCategory;
                dbMovie.ProducerId = data.ProducerId;
                await context.SaveChangesAsync();
            }

            //Remove existing actors
            var existingActorsDb = context.ActorMovies
                .Where(n => n.MovieId == data.Id).ToList();
            context.ActorMovies.RemoveRange(existingActorsDb);
            await context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new ActorMovie()
                {
                    MovieId = data.Id,
                    ActorId = actorId
                };
                await context.ActorMovies.AddAsync(newActorMovie);
            }
            await context.SaveChangesAsync();
        }
    }
}
