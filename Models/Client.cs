using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace loadgistix.Models
{
    public partial class Client
    {
        public Client()
        {
            ClientNote = new HashSet<ClientNote>();
            Invoice = new HashSet<Invoice>();
            Prospect = new HashSet<Prospect>();
            Sow = new HashSet<Sow>();
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public string DescriptionShort { get; set; }
        public string RegistrationNumber { get; set; }
        public string VatNumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string AddressCity { get; set; }
        public string AddressProvince { get; set; }
        public string AddressCountry { get; set; }
        public string AddressCode { get; set; }
        public string Contact { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public int DateBillingId { get; set; }
        public Guid StatusId { get; set; }

        public virtual DateBilling DateBilling { get; set; }
        public virtual Status Status { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ClientNote> ClientNote { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
        public virtual ICollection<Prospect> Prospect { get; set; }
        public virtual ICollection<Sow> Sow { get; set; }
    }
}
