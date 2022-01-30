using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace loadgistix.Models
{
    public partial class ClientNote
    {
        public Guid Id { get; set; }
        public Guid? ClientId { get; set; }
        public string Note { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual Client Client { get; set; }
    }
}
