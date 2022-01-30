using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace loadgistix.Models
{
    public partial class VwDirectory
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid DirectoryCategoryId { get; set; }
        public string DirectoryCategoryDescription { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public double AddressLat { get; set; }
        public double AddressLon { get; set; }
        public string AddressLabel { get; set; }
        public string Avatar { get; set; }
        public Guid StatusId { get; set; }
        public string StatusDescription { get; set; }
    }
}
