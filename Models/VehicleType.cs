using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace loadgistix.Models
{
    public partial class VehicleType
    {
        public VehicleType()
        {
            Vehicle = new HashSet<Vehicle>();
        }

        public Guid Id { get; set; }
        public Guid VehicleCategoryId { get; set; }
        public string Description { get; set; }
        public bool Liquid { get; set; }
        public Guid StatusId { get; set; }

        public virtual Status Status { get; set; }
        public virtual VehicleCategory VehicleCategory { get; set; }
        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
