using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace loadgistix.Models
{
    public partial class VwLoad
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserDescription { get; set; }
        public Guid LoadCategoryId { get; set; }
        public string LoadCategoryDescription { get; set; }
        public Guid LoadTypeId { get; set; }
        public string LoadTypeDescription { get; set; }
        public bool LoadTypeLiquid { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public double Price { get; set; }
        public string OriginatingAddressLabel { get; set; }
        public double OriginatingAddressLat { get; set; }
        public double OriginatingAddressLon { get; set; }
        public string DestinationAddressLabel { get; set; }
        public double DestinationAddressLat { get; set; }
        public double DestinationAddressLon { get; set; }
        public int? ItemCount { get; set; }
        public double? Weight { get; set; }
        public double? Length { get; set; }
        public double? Width { get; set; }
        public double? Height { get; set; }
        public double? Volume { get; set; }
        public decimal TotalValue { get; set; }
        public DateTime DateOut { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime DateBidEnd { get; set; }
        public Guid NotificationId { get; set; }
        public string NotificationDescription { get; set; }
        public string Avatar { get; set; }
        public double? Review { get; set; }
        public double? ReviewCount { get; set; }
        public int? BidCount { get; set; }
        public Guid? UserIdAccepted { get; set; }
        public Guid? UserIdLoaded { get; set; }
        public Guid? UserIdLoadedConfirmed { get; set; }
        public Guid? UserIdDelivered { get; set; }
        public Guid? UserIdDeliveredConfirmed { get; set; }
        public Guid StatusId { get; set; }
        public string StatusDescription { get; set; }
    }
}
