using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace loadgistix.Models
{
    public partial class Bid
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid LoadId { get; set; }
        public Guid VehicleId { get; set; }
        public Guid DriverId { get; set; }
        public double Price { get; set; }
        public DateTime DateOut { get; set; }
        public DateTime DateIn { get; set; }
        public Guid StatusId { get; set; }
        public double? ReviewLoad { get; set; }
        public double? ReviewLoadCount { get; set; }
        public double? ReviewDriver { get; set; }
        public double? ReviewDriverCount { get; set; }

        public virtual Driver Driver { get; set; }
        public virtual Load Load { get; set; }
        public virtual Status Status { get; set; }
        public virtual User User { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
