using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace loadgistix.Models
{
    public partial class VwBid
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserCompany { get; set; }
        public string UserDescription { get; set; }
        public Guid LoadId { get; set; }
        public Guid LoadUserId { get; set; }
        public Guid LoadLoadTypeId { get; set; }
        public string LoadLoadTypeDescription { get; set; }
        public string LoadDescription { get; set; }
        public string LoadNote { get; set; }
        public double LoadPrice { get; set; }
        public string LoadOriginatingAddressLabel { get; set; }
        public double LoadOriginatingAddressLat { get; set; }
        public double LoadOriginatingAddressLon { get; set; }
        public string LoadDestinationAddressLabel { get; set; }
        public double LoadDestinationAddressLat { get; set; }
        public double LoadDestinationAddressLon { get; set; }
        public int? LoadItemCount { get; set; }
        public double? LoadWeight { get; set; }
        public double? LoadLength { get; set; }
        public double? LoadWidth { get; set; }
        public double? LoadHeight { get; set; }
        public decimal LoadTotalValue { get; set; }
        public DateTime LoadDateOut { get; set; }
        public DateTime LoadDateIn { get; set; }
        public DateTime LoadDateBidEnd { get; set; }
        public string LoadAvatar { get; set; }
        public Guid LoadStatusId { get; set; }
        public string LoadStatusDescription { get; set; }
        public Guid? UserIdAccepted { get; set; }
        public Guid? UserIdLoaded { get; set; }
        public Guid? UserIdLoadedConfirmed { get; set; }
        public Guid? UserIdDelivered { get; set; }
        public Guid? UserIdDeliveredConfirmed { get; set; }
        public Guid VehicleId { get; set; }
        public string VehicleDescription { get; set; }
        public Guid DriverId { get; set; }
        public string DriverDescription { get; set; }
        public double Price { get; set; }
        public DateTime DateOut { get; set; }
        public DateTime DateIn { get; set; }
        public Guid StatusId { get; set; }
        public string StatusDescription { get; set; }
        public double? ReviewLoad { get; set; }
        public double? ReviewLoadCount { get; set; }
        public double? ReviewDriver { get; set; }
        public double? ReviewDriverCount { get; set; }
    }
}
