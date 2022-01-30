using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace loadgistix.Models
{
    public partial class Message
    {
        public Guid Id { get; set; }
        public Guid UserIdFrom { get; set; }
        public Guid UserIdTo { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public DateTime Timestamp { get; set; }
        public bool? Read { get; set; }
        public Guid? StatusId { get; set; }

        public virtual Status Status { get; set; }
        public virtual User UserIdFromNavigation { get; set; }
        public virtual User UserIdToNavigation { get; set; }
    }
}
