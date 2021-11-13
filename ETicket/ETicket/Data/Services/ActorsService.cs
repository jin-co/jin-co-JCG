using ETicket.Data.Base;
using ETicket.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
        public ActorsService(AppDbContext context) : base(context) { }     
        // before using generic

        // To work with DB I first need to inject it inside constructor
        // And add service config in Startup file
        //private readonly AppDbContext context;

        //public ActorsService(AppDbContext context)
        //{
        //    this.context = context;
        //}

        //public async Task AddAsync(Actor actor)
        //{
        //    await context.Actors.AddAsync(actor);
        //    await context.SaveChangesAsync();
        //}

        //public async Task<Actor> UpdateAsync(int id, Actor actor)
        //{
        //    context.Update(actor);
        //    await context.SaveChangesAsync();
        //    return actor;
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    var result = await context.Actors.FirstOrDefaultAsync(n => n.ActorId == id);
        //    context.Actors.Remove(result);
        //    await context.SaveChangesAsync();
        //}

        //public async Task<IEnumerable<Actor>> GetAllAsync()
        //{
        //    var result = await context.Actors.ToListAsync();
        //    return result;
        //}

        //public async Task<Actor> GetByIdAsync(int id)
        //{
        //    var result = await context.Actors.FirstOrDefaultAsync(n => n.ActorId == id);
        //    return result;
        //}
    }
}
