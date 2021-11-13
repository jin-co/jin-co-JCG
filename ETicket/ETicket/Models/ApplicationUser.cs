﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket.Models
{
    public class ApplicationUser : IdentityUser
    {
        [DisplayName("Full name")]
        public string FullName { get; set; }

    }
}
