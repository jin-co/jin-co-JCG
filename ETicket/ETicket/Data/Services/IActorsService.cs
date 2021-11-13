using ETicket.Data.Base;
using ETicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket.Data.Services
{
    /* It is possible to get data and manipulate data in the Controllers
     * but it is better practice to use Services
     * make an interface -> implement
     */

    public interface IActorsService : IEntityBaseRepository<Actor>
    {
        // before generic
        //Task<IEnumerable<Actor>> GetAllAsync();
        //Task<Actor> GetByIdAsync(int id);
        //Task AddAsync(Actor actor);
        //Task<Actor> UpdateAsync(int id, Actor actor);
        //Task DeleteAsync(int id);
    }
}
