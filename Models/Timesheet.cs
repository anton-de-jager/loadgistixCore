using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace loadgistix.Models
{
    public partial class Timesheet
    {
        public Timesheet()
        {
            InvoiceItem = new HashSet<InvoiceItem>();
            TimesheetItem = new HashSet<TimesheetItem>();
        }

        public Guid Id { get; set; }
        public Guid ProspectId { get; set; }
        public DateTime TimesheetDate { get; set; }

        public virtual Prospect Prospect { get; set; }
        public virtual ICollection<InvoiceItem> InvoiceItem { get; set; }
        public virtual ICollection<TimesheetItem> TimesheetItem { get; set; }
    }
}
