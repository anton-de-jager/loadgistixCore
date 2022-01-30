using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace loadgistix.Models
{
    public partial class Status
    {
        public Status()
        {
            Advert = new HashSet<Advert>();
            Bid = new HashSet<Bid>();
            Client = new HashSet<Client>();
            Directory = new HashSet<Directory>();
            Driver = new HashSet<Driver>();
            Load = new HashSet<Load>();
            LoadCategory = new HashSet<LoadCategory>();
            LoadType = new HashSet<LoadType>();
            Message = new HashSet<Message>();
            User = new HashSet<User>();
            Vehicle = new HashSet<Vehicle>();
            VehicleCategory = new HashSet<VehicleCategory>();
            VehicleType = new HashSet<VehicleType>();
        }

        public Guid Id { get; set; }
        public string Table { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Advert> Advert { get; set; }
        public virtual ICollection<Bid> Bid { get; set; }
        public virtual ICollection<Client> Client { get; set; }
        public virtual ICollection<Directory> Directory { get; set; }
        public virtual ICollection<Driver> Driver { get; set; }
        public virtual ICollection<Load> Load { get; set; }
        public virtual ICollection<LoadCategory> LoadCategory { get; set; }
        public virtual ICollection<LoadType> LoadType { get; set; }
        public virtual ICollection<Message> Message { get; set; }
        public virtual ICollection<User> User { get; set; }
        public virtual ICollection<Vehicle> Vehicle { get; set; }
        public virtual ICollection<VehicleCategory> VehicleCategory { get; set; }
        public virtual ICollection<VehicleType> VehicleType { get; set; }
    }
}
