using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace loadgistix.Models
{
    public partial class VwVehicle
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserDescription { get; set; }
        public Guid VehicleCategoryId { get; set; }
        public string VehicleCategoryDescription { get; set; }
        public Guid VehicleTypeId { get; set; }
        public string VehicleTypeDescription { get; set; }
        public string Description { get; set; }
        public string RegistrationNumber { get; set; }
        public double MaxLoadWeight { get; set; }
        public double? MaxLoadHeight { get; set; }
        public double? MaxLoadWidth { get; set; }
        public double? MaxLoadLength { get; set; }
        public double? MaxLoadVolume { get; set; }
        public double? AvailableCapacity { get; set; }
        public DateTime? AvailableFrom { get; set; }
        public DateTime? AvailableTo { get; set; }
        public string OriginatingAddressLabel { get; set; }
        public double OriginatingAddressLat { get; set; }
        public double OriginatingAddressLon { get; set; }
        public string DestinationAddressLabel { get; set; }
        public double? DestinationAddressLat { get; set; }
        public double? DestinationAddressLon { get; set; }
        public string Avatar { get; set; }
        public Guid StatusId { get; set; }
        public string StatusDescription { get; set; }
    }
}
