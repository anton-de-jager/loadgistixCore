using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace loadgistix.Models
{
    public partial class TimesheetItem
    {
        public Guid Id { get; set; }
        public Guid TimesheetId { get; set; }
        public DateTime TaskDate { get; set; }
        public string Description { get; set; }
        public decimal HoursRegular { get; set; }
        public decimal HoursOvertime { get; set; }

        public virtual Timesheet Timesheet { get; set; }
    }
}
