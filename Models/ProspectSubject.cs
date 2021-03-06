using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace loadgistix.Models
{
    public partial class ProspectSubject
    {
        public Guid Id { get; set; }
        public Guid ProspectId { get; set; }
        public string Description { get; set; }
        public string Level { get; set; }
        public string Result { get; set; }

        public virtual Prospect Prospect { get; set; }
    }
}
