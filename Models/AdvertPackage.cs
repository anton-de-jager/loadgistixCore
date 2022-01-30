using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace loadgistix.Models
{
    public partial class AdvertPackage
    {
        public AdvertPackage()
        {
            Advert = new HashSet<Advert>();
        }

        public Guid Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Advert> Advert { get; set; }
    }
}
