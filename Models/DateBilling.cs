using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace loadgistix.Models
{
    public partial class DateBilling
    {
        public DateBilling()
        {
            Client = new HashSet<Client>();
        }

        public int Id { get; set; }
        public string DayNumber { get; set; }

        public virtual ICollection<Client> Client { get; set; }
    }
}
