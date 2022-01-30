using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace loadgistix.Models
{
    public partial class Driver
    {
        public Driver()
        {
            Bid = new HashSet<Bid>();
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string IdNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid LicenceTypeId { get; set; }
        public DateTime LicenceExpiryDate { get; set; }
        public DateTime? TokenExpiry { get; set; }
        public string AccessToken { get; set; }
        public Guid? StatusId { get; set; }
        public string Avatar { get; set; }

        public virtual LicenceType LicenceType { get; set; }
        public virtual Status Status { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Bid> Bid { get; set; }
    }
}
