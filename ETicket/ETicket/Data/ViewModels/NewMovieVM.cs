using ETicket.Data;
using ETicket.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket.Models
{
    // this if not for storing data so no need of PK
    public class NewMovieVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price required")]
        public double Price { get; set; }

        [Required(ErrorMessage = "URL required")]
        public string ImageURL { get; set; }

        [Required(ErrorMessage = "Sdate required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Edate required")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Category required")]
        public MovieCategory MovieCategory { get; set; }

        // Relationship
        [Required(ErrorMessage = "Actor required")]
        public List<int> ActorIds { get; set; }

        [Required(ErrorMessage = "Cinema required")]
        public int CinemaId { get; set; }

        [Required(ErrorMessage = "Producer required")]
        public int ProducerId { get; set; }
    }
}
