using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace loadgistix.Models
{
    public partial class Prospect
    {
        public Prospect()
        {
            ProspectEmployment = new HashSet<ProspectEmployment>();
            ProspectLanguage = new HashSet<ProspectLanguage>();
            ProspectSubject = new HashSet<ProspectSubject>();
            ProspectTertiary = new HashSet<ProspectTertiary>();
            Sow = new HashSet<Sow>();
            Timesheet = new HashSet<Timesheet>();
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid? ClientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string AddressCity { get; set; }
        public string AddressProvince { get; set; }
        public string AddressCountry { get; set; }
        public string AddressCode { get; set; }
        public string Equity { get; set; }
        public string Nationality { get; set; }
        public string Transport { get; set; }
        public string Availability { get; set; }
        public string EducationSchool { get; set; }
        public string EducationHighestGrade { get; set; }
        public int? EducationYearCompleted { get; set; }
        public string Role { get; set; }

        public virtual Client Client { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ProspectEmployment> ProspectEmployment { get; set; }
        public virtual ICollection<ProspectLanguage> ProspectLanguage { get; set; }
        public virtual ICollection<ProspectSubject> ProspectSubject { get; set; }
        public virtual ICollection<ProspectTertiary> ProspectTertiary { get; set; }
        public virtual ICollection<Sow> Sow { get; set; }
        public virtual ICollection<Timesheet> Timesheet { get; set; }
    }
}
