using ETicket.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket.Models
{
    public class Cinema : IEntityBase
    {
        //public int CinemaId { get; set; }
        public int Id { get; set; }

        [Required(ErrorMessage = "Logo Required")]
        public string Logo { get; set; }

        [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description Required")]
        public string Description { get; set; }

        // Relationship
        public List<Movie> Movies { get; set; }
    }
}
