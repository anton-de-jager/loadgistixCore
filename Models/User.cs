using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace loadgistix.Models
{
    public partial class User
    {
        public User()
        {
            Advert = new HashSet<Advert>();
            Bid = new HashSet<Bid>();
            Client = new HashSet<Client>();
            Directory = new HashSet<Directory>();
            Driver = new HashSet<Driver>();
            LoadUser = new HashSet<Load>();
            LoadUserIdAcceptedNavigation = new HashSet<Load>();
            LoadUserIdDeliveredNavigation = new HashSet<Load>();
            LoadUserIdLoadedConfirmedNavigation = new HashSet<Load>();
            LoadUserIdLoadedNavigation = new HashSet<Load>();
            MessageUserIdFromNavigation = new HashSet<Message>();
            MessageUserIdToNavigation = new HashSet<Message>();
            Prospect = new HashSet<Prospect>();
            ReviewDriver = new HashSet<ReviewDriver>();
            ReviewLoad = new HashSet<ReviewLoad>();
            UserPermission = new HashSet<UserPermission>();
            Vehicle = new HashSet<Vehicle>();
        }

        public Guid Id { get; set; }
        public string Company { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime? TokenExpiry { get; set; }
        public string AccessToken { get; set; }
        public Guid StatusId { get; set; }
        public string Avatar { get; set; }
        public Guid? Reset { get; set; }

        public virtual Status Status { get; set; }
        public virtual ICollection<Advert> Advert { get; set; }
        public virtual ICollection<Bid> Bid { get; set; }
        public virtual ICollection<Client> Client { get; set; }
        public virtual ICollection<Directory> Directory { get; set; }
        public virtual ICollection<Driver> Driver { get; set; }
        public virtual ICollection<Load> LoadUser { get; set; }
        public virtual ICollection<Load> LoadUserIdAcceptedNavigation { get; set; }
        public virtual ICollection<Load> LoadUserIdDeliveredNavigation { get; set; }
        public virtual ICollection<Load> LoadUserIdLoadedConfirmedNavigation { get; set; }
        public virtual ICollection<Load> LoadUserIdLoadedNavigation { get; set; }
        public virtual ICollection<Message> MessageUserIdFromNavigation { get; set; }
        public virtual ICollection<Message> MessageUserIdToNavigation { get; set; }
        public virtual ICollection<Prospect> Prospect { get; set; }
        public virtual ICollection<ReviewDriver> ReviewDriver { get; set; }
        public virtual ICollection<ReviewLoad> ReviewLoad { get; set; }
        public virtual ICollection<UserPermission> UserPermission { get; set; }
        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
