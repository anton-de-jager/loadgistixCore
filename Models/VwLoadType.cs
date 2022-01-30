using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace loadgistix.Models
{
    public partial class VwLoadType
    {
        public Guid Id { get; set; }
        public Guid LoadCategoryId { get; set; }
        public string LoadCategoryDescription { get; set; }
        public string Description { get; set; }
        public bool Liquid { get; set; }
        public Guid StatusId { get; set; }
        public string StatusDescription { get; set; }
    }
}
