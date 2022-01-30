using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace loadgistix.Models
{
    public partial class VehicleAudit
    {
        public Guid Id { get; set; }
        public Guid Action { get; set; }
        public DateTime Date { get; set; }
        public Guid User { get; set; }
        public string Data { get; set; }
    }
}
