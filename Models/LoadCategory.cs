using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace loadgistix.Models
{
    public partial class LoadCategory
    {
        public LoadCategory()
        {
            LoadType = new HashSet<LoadType>();
        }

        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid StatusId { get; set; }

        public virtual Status Status { get; set; }
        public virtual ICollection<LoadType> LoadType { get; set; }
    }
}
