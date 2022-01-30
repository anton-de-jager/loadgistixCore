using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace loadgistix.Models
{
    public partial class VwDistance
    {
        public Guid VehicleId { get; set; }
        public Guid UserIdVehicle { get; set; }
        public Guid LoadId { get; set; }
        public Guid UserIdLoad { get; set; }
        public string OriginatingAddressVehicle { get; set; }
        public string DestinationAddressVehicle { get; set; }
        public string OriginatingAddressLoad { get; set; }
        public string DestinationAddressLoad { get; set; }
        public double? OriginatingOriginating { get; set; }
        public double? OriginatingDestination { get; set; }
        public double? DestinationOriginating { get; set; }
        public double? DestinationDestination { get; set; }
    }
}
