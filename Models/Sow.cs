using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace loadgistix.Models
{
    public partial class Sow
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid ProspectId { get; set; }
        public string DocumentNumberClient { get; set; }
        public string DocumentNumberProspect { get; set; }
        public string Role { get; set; }
        public decimal HourlyRateClient { get; set; }
        public decimal HourlyRateProspect { get; set; }
        public string Location { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public DateTime DateContractClient { get; set; }
        public DateTime DateContractProspect { get; set; }

        public virtual Client Client { get; set; }
        public virtual Prospect Prospect { get; set; }
    }
}
