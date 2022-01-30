using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace loadgistix.Models
{
    public partial class LoadType
    {
        public LoadType()
        {
            Load = new HashSet<Load>();
        }

        public Guid Id { get; set; }
        public Guid LoadCategoryId { get; set; }
        public string Description { get; set; }
        public bool Liquid { get; set; }
        public Guid StatusId { get; set; }

        public virtual LoadCategory LoadCategory { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<Load> Load { get; set; }
    }
}
