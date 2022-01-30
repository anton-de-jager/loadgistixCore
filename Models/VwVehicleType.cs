using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace loadgistix.Models
{
    public partial class VwVehicleType
    {
        public Guid Id { get; set; }
        public Guid VehicleCategoryId { get; set; }
        public string VehicleCategoryDescription { get; set; }
        public string Description { get; set; }
        public bool Liquid { get; set; }
        public Guid StatusId { get; set; }
        public string StatusDescription { get; set; }
    }
}
