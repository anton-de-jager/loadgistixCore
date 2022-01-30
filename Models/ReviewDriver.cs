using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace loadgistix.Models
{
    public partial class ReviewDriver
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid LoadId { get; set; }
        public int? RatingPunctuality { get; set; }
        public int? RatingVehicleDescription { get; set; }
        public int? RatingCare { get; set; }
        public int? RatingCondition { get; set; }
        public int? RatingAttitude { get; set; }
        public string Note { get; set; }
        public DateTime Timestamp { get; set; }

        public virtual Load Load { get; set; }
        public virtual User User { get; set; }
    }
}
