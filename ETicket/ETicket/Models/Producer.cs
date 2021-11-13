using ETicket.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket.Models
{
    public class Producer : IEntityBase
    {        
        //public int ProducerId { get; set; }
        public int Id { get; set; }

        [DisplayName("ProFile Picture")]
        [Required(ErrorMessage = "Picture Required")]
        public string ProfilePictureURL { get; set; }

        [DisplayName("Full Name")]
        [Required(ErrorMessage = "Full name Required")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Bio Required")]
        public string Bio { get; set; }

        // Relationship
        public List<Movie> Movies { get; set; }
    }
}
