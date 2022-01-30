using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace loadgistix.Models
{
    public partial class Advert
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateExpiry { get; set; }
        public Guid AdvertPackageId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Link { get; set; }
        public string Content { get; set; }
        public Guid StatusId { get; set; }
        public string Avatar { get; set; }

        public virtual AdvertPackage AdvertPackage { get; set; }
        public virtual Status Status { get; set; }
        public virtual User User { get; set; }
    }
}
