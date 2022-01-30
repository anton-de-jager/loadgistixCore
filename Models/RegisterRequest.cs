using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace loadgistix.Models
{
    public class RegisterRequest
    {
        [Required]
        public string Company { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Avatar { get; set; }
        public bool? Vehicles { get; set; }
        [Required]
        public bool? Loads { get; set; }
        [Required]
        public bool? Adverts { get; set; }
        [Required]
        public bool? Directory { get; set; }
    }
}
