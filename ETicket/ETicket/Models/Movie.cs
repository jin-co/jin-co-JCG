using ETicket.Data;
using ETicket.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket.Models
{
    public class Movie : IEntityBase
    {
        //public int MovieId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }

        // Relationship
        public List<ActorMovie> ActorMovies { get; set; }

        // Cinema
        [ForeignKey("CinemaId")]
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }
        
        // Producer
        [ForeignKey("ProducerId")]
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
    }
}
