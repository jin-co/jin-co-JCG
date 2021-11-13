using ETicket.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket.Models
{
    public class Actor : IEntityBase
    {
        public int Id { get; set; }
        
        // before generic
        //public int ActorId { get; set; }
        
        [Display(Name = "Profile Picture")]  // this will be displayed title
        [Required(ErrorMessage = "Picture Required")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Name Required")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Bio Required")]
        public string Bio { get; set; }

        // Relationship
        public List<ActorMovie> ActorMovies { get; set; }
    }
}
