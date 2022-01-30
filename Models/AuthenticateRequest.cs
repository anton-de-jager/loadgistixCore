﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace loadgistix.Models
{
    public partial class AuthenticateRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
