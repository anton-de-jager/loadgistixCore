using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace loadgistix.Models
{
    public partial class ProspectEmployment
    {
        public ProspectEmployment()
        {
            ProspectEmploymentDuty = new HashSet<ProspectEmploymentDuty>();
            ProspectEmploymentTechnology = new HashSet<ProspectEmploymentTechnology>();
        }

        public Guid Id { get; set; }
        public Guid ProspectId { get; set; }
        public string Description { get; set; }
        public string Position { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string ReasonForLeaving { get; set; }

        public virtual Prospect Prospect { get; set; }
        public virtual ICollection<ProspectEmploymentDuty> ProspectEmploymentDuty { get; set; }
        public virtual ICollection<ProspectEmploymentTechnology> ProspectEmploymentTechnology { get; set; }
    }
}
