using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace loadgistix.Models
{
    public partial class loadgistixContext : DbContext
    {
        public loadgistixContext(DbContextOptions<loadgistixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Advert> Advert { get; set; }
        public virtual DbSet<AdvertLog> AdvertLog { get; set; }
        public virtual DbSet<AdvertPackage> AdvertPackage { get; set; }
        public virtual DbSet<AuditActions> AuditActions { get; set; }
        public virtual DbSet<Bid> Bid { get; set; }
        public virtual DbSet<BidAudit> BidAudit { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<ClientNote> ClientNote { get; set; }
        public virtual DbSet<DateBilling> DateBilling { get; set; }
        public virtual DbSet<Directory> Directory { get; set; }
        public virtual DbSet<DirectoryCategory> DirectoryCategory { get; set; }
        public virtual DbSet<Driver> Driver { get; set; }
        public virtual DbSet<DriverAudit> DriverAudit { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceItem> InvoiceItem { get; set; }
        public virtual DbSet<LicenceType> LicenceType { get; set; }
        public virtual DbSet<Load> Load { get; set; }
        public virtual DbSet<LoadAudit> LoadAudit { get; set; }
        public virtual DbSet<LoadCategory> LoadCategory { get; set; }
        public virtual DbSet<LoadType> LoadType { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<Prospect> Prospect { get; set; }
        public virtual DbSet<ProspectEmployment> ProspectEmployment { get; set; }
        public virtual DbSet<ProspectEmploymentDuty> ProspectEmploymentDuty { get; set; }
        public virtual DbSet<ProspectEmploymentTechnology> ProspectEmploymentTechnology { get; set; }
        public virtual DbSet<ProspectLanguage> ProspectLanguage { get; set; }
        public virtual DbSet<ProspectSubject> ProspectSubject { get; set; }
        public virtual DbSet<ProspectTertiary> ProspectTertiary { get; set; }
        public virtual DbSet<ReviewDriver> ReviewDriver { get; set; }
        public virtual DbSet<ReviewLoad> ReviewLoad { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Sow> Sow { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<TemplateEmail> TemplateEmail { get; set; }
        public virtual DbSet<Timesheet> Timesheet { get; set; }
        public virtual DbSet<TimesheetItem> TimesheetItem { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserAudit> UserAudit { get; set; }
        public virtual DbSet<UserPermission> UserPermission { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<VehicleAudit> VehicleAudit { get; set; }
        public virtual DbSet<VehicleCategory> VehicleCategory { get; set; }
        public virtual DbSet<VehicleType> VehicleType { get; set; }
        public virtual DbSet<VwAdvert> VwAdvert { get; set; }
        public virtual DbSet<VwBid> VwBid { get; set; }
        public virtual DbSet<VwDirectory> VwDirectory { get; set; }
        public virtual DbSet<VwDirectoryCategory> VwDirectoryCategory { get; set; }
        public virtual DbSet<VwDistance> VwDistance { get; set; }
        public virtual DbSet<VwDriver> VwDriver { get; set; }
        public virtual DbSet<VwLoad> VwLoad { get; set; }
        public virtual DbSet<VwLoadType> VwLoadType { get; set; }
        public virtual DbSet<VwMessage> VwMessage { get; set; }
        public virtual DbSet<VwUser> VwUser { get; set; }
        public virtual DbSet<VwVehicle> VwVehicle { get; set; }
        public virtual DbSet<VwVehicleType> VwVehicleType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "madproducts");

            modelBuilder.Entity<Advert>(entity =>
            {
                entity.ToTable("advert", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AdvertPackageId).HasColumnName("advertPackageId");

                entity.Property(e => e.Avatar)
                    .HasColumnName("avatar")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DateExpiry)
                    .HasColumnName("dateExpiry")
                    .HasColumnType("datetime");

                entity.Property(e => e.Link)
                    .HasColumnName("link")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.SubTitle)
                    .IsRequired()
                    .HasColumnName("subTitle")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.AdvertPackage)
                    .WithMany(p => p.Advert)
                    .HasForeignKey(d => d.AdvertPackageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_advert_advertPackage");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Advert)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_advert_status");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Advert)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_advert_user");
            });

            modelBuilder.Entity<AdvertLog>(entity =>
            {
                entity.ToTable("advertLog", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AdvertCount).HasColumnName("advertCount");

                entity.Property(e => e.AdvertDate)
                    .HasColumnName("advertDate")
                    .HasColumnType("date");

                entity.Property(e => e.AdvertId).HasColumnName("advertId");
            });

            modelBuilder.Entity<AdvertPackage>(entity =>
            {
                entity.ToTable("advertPackage", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AuditActions>(entity =>
            {
                entity.ToTable("auditActions", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Bid>(entity =>
            {
                entity.ToTable("bid", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateIn)
                    .HasColumnName("dateIn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateOut)
                    .HasColumnName("dateOut")
                    .HasColumnType("datetime");

                entity.Property(e => e.DriverId).HasColumnName("driverId");

                entity.Property(e => e.LoadId).HasColumnName("loadId");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ReviewDriver)
                    .HasColumnName("reviewDriver")
                    .HasComputedColumnSql("([dbo].[fn_reviewDriver]([userId]))");

                entity.Property(e => e.ReviewDriverCount)
                    .HasColumnName("reviewDriverCount")
                    .HasComputedColumnSql("([dbo].[fn_reviewDriverCount]([userId]))");

                entity.Property(e => e.ReviewLoad)
                    .HasColumnName("reviewLoad")
                    .HasComputedColumnSql("([dbo].[fn_reviewLoad]([userId]))");

                entity.Property(e => e.ReviewLoadCount)
                    .HasColumnName("reviewLoadCount")
                    .HasComputedColumnSql("([dbo].[fn_reviewLoadCount]([userId]))");

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.VehicleId).HasColumnName("vehicleId");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Bid)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_bid_driver");

                entity.HasOne(d => d.Load)
                    .WithMany(p => p.Bid)
                    .HasForeignKey(d => d.LoadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_bid_load");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Bid)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_bid_status");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bid)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_bid_user");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Bid)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_bid_vehicle");
            });

            modelBuilder.Entity<BidAudit>(entity =>
            {
                entity.ToTable("bidAudit", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Action).HasColumnName("action");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnName("data")
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.User).HasColumnName("user");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasColumnName("address1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasColumnName("address2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressCity)
                    .IsRequired()
                    .HasColumnName("addressCity")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressCode)
                    .IsRequired()
                    .HasColumnName("addressCode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressCountry)
                    .IsRequired()
                    .HasColumnName("addressCountry")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressProvince)
                    .HasColumnName("addressProvince")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasColumnName("contact")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactEmail)
                    .IsRequired()
                    .HasColumnName("contactEmail")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPhone)
                    .IsRequired()
                    .HasColumnName("contactPhone")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateBillingId).HasColumnName("dateBillingId");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DescriptionShort)
                    .IsRequired()
                    .HasColumnName("descriptionShort")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationNumber)
                    .IsRequired()
                    .HasColumnName("registrationNumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId)
                    .HasColumnName("statusId")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.VatNumber)
                    .IsRequired()
                    .HasColumnName("vatNumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.DateBilling)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.DateBillingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_client_dateBilling");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_client_status");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_client_user");
            });

            modelBuilder.Entity<ClientNote>(entity =>
            {
                entity.ToTable("clientNote", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ClientId).HasColumnName("clientId");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientNote)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_clientNote_client");
            });

            modelBuilder.Entity<DateBilling>(entity =>
            {
                entity.ToTable("dateBilling", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DayNumber)
                    .IsRequired()
                    .HasColumnName("dayNumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Directory>(entity =>
            {
                entity.ToTable("directory", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AddressLabel)
                    .IsRequired()
                    .HasColumnName("addressLabel")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLat).HasColumnName("addressLat");

                entity.Property(e => e.AddressLon).HasColumnName("addressLon");

                entity.Property(e => e.Avatar)
                    .HasColumnName("avatar")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("companyName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DirectoryCategoryId).HasColumnName("directoryCategoryId");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Facebook)
                    .HasColumnName("facebook")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Instagram)
                    .HasColumnName("instagram")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LinkedIn)
                    .HasColumnName("linkedIn")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.Twitter)
                    .HasColumnName("twitter")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Website)
                    .HasColumnName("website")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.DirectoryCategory)
                    .WithMany(p => p.Directory)
                    .HasForeignKey(d => d.DirectoryCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_directory_directoryCategory");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Directory)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_directory_status");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Directory)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_directory_user");
            });

            modelBuilder.Entity<DirectoryCategory>(entity =>
            {
                entity.ToTable("directoryCategory", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.ToTable("driver", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccessToken)
                    .HasColumnName("accessToken")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Avatar)
                    .HasColumnName("avatar")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("dateOfBirth")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdNumber)
                    .IsRequired()
                    .HasColumnName("idNumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LicenceExpiryDate)
                    .HasColumnName("licenceExpiryDate")
                    .HasColumnType("date");

                entity.Property(e => e.LicenceTypeId).HasColumnName("licenceTypeId");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.TokenExpiry)
                    .HasColumnName("tokenExpiry")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.LicenceType)
                    .WithMany(p => p.Driver)
                    .HasForeignKey(d => d.LicenceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_driver_licenceType");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Driver)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_driver_status");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Driver)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_driver_user");
            });

            modelBuilder.Entity<DriverAudit>(entity =>
            {
                entity.ToTable("driverAudit", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Action).HasColumnName("action");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnName("data")
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.User).HasColumnName("user");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("invoice", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ClientId).HasColumnName("clientId");

                entity.Property(e => e.DueDate)
                    .HasColumnName("dueDate")
                    .HasColumnType("date");

                entity.Property(e => e.InvoiceDate)
                    .HasColumnName("invoiceDate")
                    .HasColumnType("date");

                entity.Property(e => e.InvoiceNumber)
                    .IsRequired()
                    .HasColumnName("invoiceNumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PoNumber)
                    .HasColumnName("poNumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_invoice_client");
            });

            modelBuilder.Entity<InvoiceItem>(entity =>
            {
                entity.ToTable("invoiceItem", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.InvoiceId).HasColumnName("invoiceId");

                entity.Property(e => e.TimesheetId).HasColumnName("timesheetId");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoiceItem)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_invoiceItem_invoice");

                entity.HasOne(d => d.Timesheet)
                    .WithMany(p => p.InvoiceItem)
                    .HasForeignKey(d => d.TimesheetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_invoiceItem_timesheet");
            });

            modelBuilder.Entity<LicenceType>(entity =>
            {
                entity.ToTable("licenceType", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Load>(entity =>
            {
                entity.ToTable("load", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Avatar)
                    .HasColumnName("avatar")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.DateBidEnd)
                    .HasColumnName("dateBidEnd")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateIn)
                    .HasColumnName("dateIn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateOut)
                    .HasColumnName("dateOut")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DestinationAddressLabel)
                    .IsRequired()
                    .HasColumnName("destinationAddressLabel")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DestinationAddressLat).HasColumnName("destinationAddressLat");

                entity.Property(e => e.DestinationAddressLon).HasColumnName("destinationAddressLon");

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.ItemCount).HasColumnName("itemCount");

                entity.Property(e => e.Length).HasColumnName("length");

                entity.Property(e => e.LoadTypeId).HasColumnName("loadTypeId");

                entity.Property(e => e.Note)
                    .IsRequired()
                    .HasColumnName("note")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NotificationId).HasColumnName("notificationId");

                entity.Property(e => e.OriginatingAddressLabel)
                    .IsRequired()
                    .HasColumnName("originatingAddressLabel")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.OriginatingAddressLat).HasColumnName("originatingAddressLat");

                entity.Property(e => e.OriginatingAddressLon).HasColumnName("originatingAddressLon");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.TotalValue)
                    .HasColumnName("totalValue")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.UserIdAccepted).HasColumnName("userIdAccepted");

                entity.Property(e => e.UserIdDelivered).HasColumnName("userIdDelivered");

                entity.Property(e => e.UserIdDeliveredConfirmed).HasColumnName("userIdDeliveredConfirmed");

                entity.Property(e => e.UserIdLoaded).HasColumnName("userIdLoaded");

                entity.Property(e => e.UserIdLoadedConfirmed).HasColumnName("userIdLoadedConfirmed");

                entity.Property(e => e.Volume).HasColumnName("volume");

                entity.Property(e => e.Weight).HasColumnName("weight");

                entity.Property(e => e.Width).HasColumnName("width");

                entity.HasOne(d => d.LoadType)
                    .WithMany(p => p.Load)
                    .HasForeignKey(d => d.LoadTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_load_loadType");

                entity.HasOne(d => d.Notification)
                    .WithMany(p => p.Load)
                    .HasForeignKey(d => d.NotificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_load_notification");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Load)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_load_status");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LoadUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_load_user");

                entity.HasOne(d => d.UserIdAcceptedNavigation)
                    .WithMany(p => p.LoadUserIdAcceptedNavigation)
                    .HasForeignKey(d => d.UserIdAccepted)
                    .HasConstraintName("FK_load_user1");

                entity.HasOne(d => d.UserIdDeliveredNavigation)
                    .WithMany(p => p.LoadUserIdDeliveredNavigation)
                    .HasForeignKey(d => d.UserIdDelivered)
                    .HasConstraintName("FK_load_user4");

                entity.HasOne(d => d.UserIdLoadedNavigation)
                    .WithMany(p => p.LoadUserIdLoadedNavigation)
                    .HasForeignKey(d => d.UserIdLoaded)
                    .HasConstraintName("FK_load_user2");

                entity.HasOne(d => d.UserIdLoadedConfirmedNavigation)
                    .WithMany(p => p.LoadUserIdLoadedConfirmedNavigation)
                    .HasForeignKey(d => d.UserIdLoadedConfirmed)
                    .HasConstraintName("FK_load_user3");
            });

            modelBuilder.Entity<LoadAudit>(entity =>
            {
                entity.ToTable("loadAudit", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Action).HasColumnName("action");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnName("data")
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.User).HasColumnName("user");
            });

            modelBuilder.Entity<LoadCategory>(entity =>
            {
                entity.ToTable("loadCategory", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.LoadCategory)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_loadCategory_status");
            });

            modelBuilder.Entity<LoadType>(entity =>
            {
                entity.ToTable("loadType", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Liquid).HasColumnName("liquid");

                entity.Property(e => e.LoadCategoryId).HasColumnName("loadCategoryId");

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.HasOne(d => d.LoadCategory)
                    .WithMany(p => p.LoadType)
                    .HasForeignKey(d => d.LoadCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_loadType_loadCategory");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.LoadType)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_loadType_status");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("message", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Link)
                    .HasColumnName("link")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Read).HasColumnName("read");

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.Timestamp)
                    .HasColumnName("timestamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserIdFrom).HasColumnName("userIdFrom");

                entity.Property(e => e.UserIdTo).HasColumnName("userIdTo");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_message_status");

                entity.HasOne(d => d.UserIdFromNavigation)
                    .WithMany(p => p.MessageUserIdFromNavigation)
                    .HasForeignKey(d => d.UserIdFrom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_message_user");

                entity.HasOne(d => d.UserIdToNavigation)
                    .WithMany(p => p.MessageUserIdToNavigation)
                    .HasForeignKey(d => d.UserIdTo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_message_user1");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("notification", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("permission", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Prospect>(entity =>
            {
                entity.ToTable("prospect", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Address1)
                    .HasColumnName("address1")
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasColumnName("address2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressCity)
                    .IsRequired()
                    .HasColumnName("addressCity")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressCode)
                    .IsRequired()
                    .HasColumnName("addressCode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressCountry)
                    .IsRequired()
                    .HasColumnName("addressCountry")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressProvince)
                    .IsRequired()
                    .HasColumnName("addressProvince")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Availability)
                    .HasColumnName("availability")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientId).HasColumnName("clientId");

                entity.Property(e => e.EducationHighestGrade)
                    .HasColumnName("educationHighestGrade")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EducationSchool)
                    .HasColumnName("educationSchool")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EducationYearCompleted).HasColumnName("educationYearCompleted");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Equity)
                    .HasColumnName("equity")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdNumber)
                    .IsRequired()
                    .HasColumnName("idNumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nationality)
                    .HasColumnName("nationality")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Transport)
                    .HasColumnName("transport")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Prospect)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_prospect_client");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Prospect)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_prospect_user");
            });

            modelBuilder.Entity<ProspectEmployment>(entity =>
            {
                entity.ToTable("prospectEmployment", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateEnd)
                    .HasColumnName("dateEnd")
                    .HasColumnType("date");

                entity.Property(e => e.DateStart)
                    .HasColumnName("dateStart")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasColumnName("position")
                    .IsUnicode(false);

                entity.Property(e => e.ProspectId).HasColumnName("prospectId");

                entity.Property(e => e.ReasonForLeaving)
                    .IsRequired()
                    .HasColumnName("reasonForLeaving")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Prospect)
                    .WithMany(p => p.ProspectEmployment)
                    .HasForeignKey(d => d.ProspectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_prospectEmployment_prospect");
            });

            modelBuilder.Entity<ProspectEmploymentDuty>(entity =>
            {
                entity.ToTable("prospectEmploymentDuty", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .IsUnicode(false);

                entity.Property(e => e.ProspectEmploymentId).HasColumnName("prospectEmploymentId");

                entity.HasOne(d => d.ProspectEmployment)
                    .WithMany(p => p.ProspectEmploymentDuty)
                    .HasForeignKey(d => d.ProspectEmploymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_prospectEmploymentDuty_prospectEmployment");
            });

            modelBuilder.Entity<ProspectEmploymentTechnology>(entity =>
            {
                entity.ToTable("prospectEmploymentTechnology", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ProspectEmploymentId).HasColumnName("prospectEmploymentId");

                entity.HasOne(d => d.ProspectEmployment)
                    .WithMany(p => p.ProspectEmploymentTechnology)
                    .HasForeignKey(d => d.ProspectEmploymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_prospectEmploymentTechnology_prospectEmployment");
            });

            modelBuilder.Entity<ProspectLanguage>(entity =>
            {
                entity.ToTable("prospectLanguage", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProspectId).HasColumnName("prospectId");

                entity.HasOne(d => d.Prospect)
                    .WithMany(p => p.ProspectLanguage)
                    .HasForeignKey(d => d.ProspectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_prospectLanguage_prospect");
            });

            modelBuilder.Entity<ProspectSubject>(entity =>
            {
                entity.ToTable("prospectSubject", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasColumnName("level")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProspectId).HasColumnName("prospectId");

                entity.Property(e => e.Result)
                    .IsRequired()
                    .HasColumnName("result")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.Prospect)
                    .WithMany(p => p.ProspectSubject)
                    .HasForeignKey(d => d.ProspectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_prospectSubject_prospect");
            });

            modelBuilder.Entity<ProspectTertiary>(entity =>
            {
                entity.ToTable("prospectTertiary", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Course)
                    .HasColumnName("course")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ProspectId).HasColumnName("prospectId");

                entity.Property(e => e.YearCompleted).HasColumnName("yearCompleted");

                entity.HasOne(d => d.Prospect)
                    .WithMany(p => p.ProspectTertiary)
                    .HasForeignKey(d => d.ProspectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_prospectTertiary_prospect");
            });

            modelBuilder.Entity<ReviewDriver>(entity =>
            {
                entity.ToTable("reviewDriver", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.LoadId).HasColumnName("loadId");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RatingAttitude).HasColumnName("ratingAttitude");

                entity.Property(e => e.RatingCare).HasColumnName("ratingCare");

                entity.Property(e => e.RatingCondition).HasColumnName("ratingCondition");

                entity.Property(e => e.RatingPunctuality).HasColumnName("ratingPunctuality");

                entity.Property(e => e.RatingVehicleDescription).HasColumnName("ratingVehicleDescription");

                entity.Property(e => e.Timestamp)
                    .HasColumnName("timestamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Load)
                    .WithMany(p => p.ReviewDriver)
                    .HasForeignKey(d => d.LoadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reviewDriver_load");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ReviewDriver)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reviewDriver_user");
            });

            modelBuilder.Entity<ReviewLoad>(entity =>
            {
                entity.ToTable("reviewLoad", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.LoadId).HasColumnName("loadId");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RatingAttitude).HasColumnName("ratingAttitude");

                entity.Property(e => e.RatingCare).HasColumnName("ratingCare");

                entity.Property(e => e.RatingLoadDescription).HasColumnName("ratingLoadDescription");

                entity.Property(e => e.RatingPayment).HasColumnName("ratingPayment");

                entity.Property(e => e.RatingPunctuality).HasColumnName("ratingPunctuality");

                entity.Property(e => e.Timestamp)
                    .HasColumnName("timestamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Load)
                    .WithMany(p => p.ReviewLoad)
                    .HasForeignKey(d => d.LoadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reviewLoad_load");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ReviewLoad)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reviewLoad_user");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sow>(entity =>
            {
                entity.ToTable("sow", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ClientId).HasColumnName("clientId");

                entity.Property(e => e.DateContractClient)
                    .HasColumnName("dateContractClient")
                    .HasColumnType("date");

                entity.Property(e => e.DateContractProspect)
                    .HasColumnName("dateContractProspect")
                    .HasColumnType("date");

                entity.Property(e => e.DateEnd)
                    .HasColumnName("dateEnd")
                    .HasColumnType("date");

                entity.Property(e => e.DateStart)
                    .HasColumnName("dateStart")
                    .HasColumnType("date");

                entity.Property(e => e.DocumentNumberClient)
                    .IsRequired()
                    .HasColumnName("documentNumberClient")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentNumberProspect)
                    .IsRequired()
                    .HasColumnName("documentNumberProspect")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HourlyRateClient)
                    .HasColumnName("hourlyRateClient")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.HourlyRateProspect)
                    .HasColumnName("hourlyRateProspect")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnName("location")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ProspectId).HasColumnName("prospectId");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnName("role")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Sow)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sow_client");

                entity.HasOne(d => d.Prospect)
                    .WithMany(p => p.Sow)
                    .HasForeignKey(d => d.ProspectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sow_prospect");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Table)
                    .IsRequired()
                    .HasColumnName("table")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TemplateEmail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("templateEmail", "dbo");

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<Timesheet>(entity =>
            {
                entity.ToTable("timesheet", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ProspectId).HasColumnName("prospectId");

                entity.Property(e => e.TimesheetDate)
                    .HasColumnName("timesheetDate")
                    .HasColumnType("date");

                entity.HasOne(d => d.Prospect)
                    .WithMany(p => p.Timesheet)
                    .HasForeignKey(d => d.ProspectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_timesheet_prospect");
            });

            modelBuilder.Entity<TimesheetItem>(entity =>
            {
                entity.ToTable("timesheetItem", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HoursOvertime)
                    .HasColumnName("hoursOvertime")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.HoursRegular)
                    .HasColumnName("hoursRegular")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TaskDate)
                    .HasColumnName("taskDate")
                    .HasColumnType("date");

                entity.Property(e => e.TimesheetId).HasColumnName("timesheetId");

                entity.HasOne(d => d.Timesheet)
                    .WithMany(p => p.TimesheetItem)
                    .HasForeignKey(d => d.TimesheetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_timesheetItem_timesheet");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccessToken)
                    .HasColumnName("accessToken")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Avatar)
                    .HasColumnName("avatar")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasColumnName("company")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(14)
                    .IsFixedLength();

                entity.Property(e => e.Reset).HasColumnName("reset");

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.TokenExpiry)
                    .HasColumnName("tokenExpiry")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_status");
            });

            modelBuilder.Entity<UserAudit>(entity =>
            {
                entity.ToTable("userAudit", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Action).HasColumnName("action");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnName("data")
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.User).HasColumnName("user");
            });

            modelBuilder.Entity<UserPermission>(entity =>
            {
                entity.ToTable("userPermission", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.PermissionId).HasColumnName("permissionId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.UserPermission)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_userPermission_permission");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPermission)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_userPermission_user");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("vehicle", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AvailableCapacity).HasColumnName("availableCapacity");

                entity.Property(e => e.AvailableFrom)
                    .HasColumnName("availableFrom")
                    .HasColumnType("datetime");

                entity.Property(e => e.AvailableTo)
                    .HasColumnName("availableTo")
                    .HasColumnType("datetime");

                entity.Property(e => e.Avatar)
                    .HasColumnName("avatar")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DestinationAddressLabel)
                    .HasColumnName("destinationAddressLabel")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DestinationAddressLat).HasColumnName("destinationAddressLat");

                entity.Property(e => e.DestinationAddressLon).HasColumnName("destinationAddressLon");

                entity.Property(e => e.MaxLoadHeight).HasColumnName("maxLoadHeight");

                entity.Property(e => e.MaxLoadLength).HasColumnName("maxLoadLength");

                entity.Property(e => e.MaxLoadVolume).HasColumnName("maxLoadVolume");

                entity.Property(e => e.MaxLoadWeight).HasColumnName("maxLoadWeight");

                entity.Property(e => e.MaxLoadWidth).HasColumnName("maxLoadWidth");

                entity.Property(e => e.OriginatingAddressLabel)
                    .IsRequired()
                    .HasColumnName("originatingAddressLabel")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.OriginatingAddressLat).HasColumnName("originatingAddressLat");

                entity.Property(e => e.OriginatingAddressLon).HasColumnName("originatingAddressLon");

                entity.Property(e => e.RegistrationNumber)
                    .IsRequired()
                    .HasColumnName("registrationNumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.VehicleTypeId).HasColumnName("vehicleTypeId");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_vehicle_status");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_vehicle_user");

                entity.HasOne(d => d.VehicleType)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.VehicleTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_vehicle_vehicleType");
            });

            modelBuilder.Entity<VehicleAudit>(entity =>
            {
                entity.ToTable("vehicleAudit", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Action).HasColumnName("action");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnName("data")
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.User).HasColumnName("user");
            });

            modelBuilder.Entity<VehicleCategory>(entity =>
            {
                entity.ToTable("vehicleCategory", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.VehicleCategory)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_vehicleCategory_status");
            });

            modelBuilder.Entity<VehicleType>(entity =>
            {
                entity.ToTable("vehicleType", "dbo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Liquid).HasColumnName("liquid");

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.VehicleCategoryId).HasColumnName("vehicleCategoryId");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.VehicleType)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_vehicleType_status");

                entity.HasOne(d => d.VehicleCategory)
                    .WithMany(p => p.VehicleType)
                    .HasForeignKey(d => d.VehicleCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_vehicleType_vehicleCategory");
            });

            modelBuilder.Entity<VwAdvert>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_advert", "dbo");

                entity.Property(e => e.AdvertPackageDescription)
                    .IsRequired()
                    .HasColumnName("advertPackageDescription")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AdvertPackageId).HasColumnName("advertPackageId");

                entity.Property(e => e.Avatar)
                    .HasColumnName("avatar")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DateExpiry)
                    .HasColumnName("dateExpiry")
                    .HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Link)
                    .HasColumnName("link")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.StatusDescription)
                    .IsRequired()
                    .HasColumnName("statusDescription")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.SubTitle)
                    .IsRequired()
                    .HasColumnName("subTitle")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            modelBuilder.Entity<VwBid>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_bid", "dbo");

                entity.Property(e => e.DateIn)
                    .HasColumnName("dateIn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateOut)
                    .HasColumnName("dateOut")
                    .HasColumnType("datetime");

                entity.Property(e => e.DriverDescription)
                    .IsRequired()
                    .HasColumnName("driverDescription")
                    .HasMaxLength(101)
                    .IsUnicode(false);

                entity.Property(e => e.DriverId).HasColumnName("driverId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LoadAvatar)
                    .HasColumnName("loadAvatar")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.LoadDateBidEnd)
                    .HasColumnName("loadDateBidEnd")
                    .HasColumnType("datetime");

                entity.Property(e => e.LoadDateIn)
                    .HasColumnName("loadDateIn")
                    .HasColumnType("datetime");

                entity.Property(e => e.LoadDateOut)
                    .HasColumnName("loadDateOut")
                    .HasColumnType("datetime");

                entity.Property(e => e.LoadDescription)
                    .IsRequired()
                    .HasColumnName("loadDescription")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LoadDestinationAddressLabel)
                    .IsRequired()
                    .HasColumnName("loadDestinationAddressLabel")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LoadDestinationAddressLat).HasColumnName("loadDestinationAddressLat");

                entity.Property(e => e.LoadDestinationAddressLon).HasColumnName("loadDestinationAddressLon");

                entity.Property(e => e.LoadHeight).HasColumnName("loadHeight");

                entity.Property(e => e.LoadId).HasColumnName("loadId");

                entity.Property(e => e.LoadItemCount).HasColumnName("loadItemCount");

                entity.Property(e => e.LoadLength).HasColumnName("loadLength");

                entity.Property(e => e.LoadLoadTypeDescription)
                    .IsRequired()
                    .HasColumnName("loadLoadTypeDescription")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoadLoadTypeId).HasColumnName("loadLoadTypeId");

                entity.Property(e => e.LoadNote)
                    .IsRequired()
                    .HasColumnName("loadNote")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LoadOriginatingAddressLabel)
                    .IsRequired()
                    .HasColumnName("loadOriginatingAddressLabel")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LoadOriginatingAddressLat).HasColumnName("loadOriginatingAddressLat");

                entity.Property(e => e.LoadOriginatingAddressLon).HasColumnName("loadOriginatingAddressLon");

                entity.Property(e => e.LoadPrice).HasColumnName("loadPrice");

                entity.Property(e => e.LoadStatusDescription)
                    .IsRequired()
                    .HasColumnName("loadStatusDescription")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoadStatusId).HasColumnName("loadStatusId");

                entity.Property(e => e.LoadTotalValue)
                    .HasColumnName("loadTotalValue")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.LoadUserId).HasColumnName("loadUserId");

                entity.Property(e => e.LoadWeight).HasColumnName("loadWeight");

                entity.Property(e => e.LoadWidth).HasColumnName("loadWidth");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ReviewDriver).HasColumnName("reviewDriver");

                entity.Property(e => e.ReviewDriverCount).HasColumnName("reviewDriverCount");

                entity.Property(e => e.ReviewLoad).HasColumnName("reviewLoad");

                entity.Property(e => e.ReviewLoadCount).HasColumnName("reviewLoadCount");

                entity.Property(e => e.StatusDescription)
                    .IsRequired()
                    .HasColumnName("statusDescription")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.UserCompany)
                    .IsRequired()
                    .HasColumnName("userCompany")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserDescription)
                    .IsRequired()
                    .HasColumnName("userDescription")
                    .HasMaxLength(101)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.UserIdAccepted).HasColumnName("userIdAccepted");

                entity.Property(e => e.UserIdDelivered).HasColumnName("userIdDelivered");

                entity.Property(e => e.UserIdDeliveredConfirmed).HasColumnName("userIdDeliveredConfirmed");

                entity.Property(e => e.UserIdLoaded).HasColumnName("userIdLoaded");

                entity.Property(e => e.UserIdLoadedConfirmed).HasColumnName("userIdLoadedConfirmed");

                entity.Property(e => e.VehicleDescription)
                    .IsRequired()
                    .HasColumnName("vehicleDescription")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleId).HasColumnName("vehicleId");
            });

            modelBuilder.Entity<VwDirectory>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_directory", "dbo");

                entity.Property(e => e.AddressLabel)
                    .IsRequired()
                    .HasColumnName("addressLabel")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLat).HasColumnName("addressLat");

                entity.Property(e => e.AddressLon).HasColumnName("addressLon");

                entity.Property(e => e.Avatar)
                    .HasColumnName("avatar")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("companyName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DirectoryCategoryDescription)
                    .IsRequired()
                    .HasColumnName("directoryCategoryDescription")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DirectoryCategoryId).HasColumnName("directoryCategoryId");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Facebook)
                    .HasColumnName("facebook")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Instagram)
                    .HasColumnName("instagram")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusDescription)
                    .IsRequired()
                    .HasColumnName("statusDescription")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.Twitter)
                    .HasColumnName("twitter")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Website)
                    .HasColumnName("website")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwDirectoryCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_directoryCategory", "dbo");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DirectoryCount).HasColumnName("directoryCount");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<VwDistance>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_distance", "dbo");

                entity.Property(e => e.DestinationAddressLoad)
                    .IsRequired()
                    .HasColumnName("destinationAddressLoad")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DestinationAddressVehicle)
                    .HasColumnName("destinationAddressVehicle")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DestinationDestination).HasColumnName("destination_destination");

                entity.Property(e => e.DestinationOriginating).HasColumnName("destination_originating");

                entity.Property(e => e.LoadId).HasColumnName("loadId");

                entity.Property(e => e.OriginatingAddressLoad)
                    .IsRequired()
                    .HasColumnName("originatingAddressLoad")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.OriginatingAddressVehicle)
                    .IsRequired()
                    .HasColumnName("originatingAddressVehicle")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.OriginatingDestination).HasColumnName("originating_destination");

                entity.Property(e => e.OriginatingOriginating).HasColumnName("originating_originating");

                entity.Property(e => e.UserIdLoad).HasColumnName("userIdLoad");

                entity.Property(e => e.UserIdVehicle).HasColumnName("userIdVehicle");

                entity.Property(e => e.VehicleId).HasColumnName("vehicleId");
            });

            modelBuilder.Entity<VwDriver>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_driver", "dbo");

                entity.Property(e => e.Avatar)
                    .HasColumnName("avatar")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("dateOfBirth")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdNumber)
                    .IsRequired()
                    .HasColumnName("idNumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LicenceExpiryDate)
                    .HasColumnName("licenceExpiryDate")
                    .HasColumnType("date");

                entity.Property(e => e.LicenceTypeDescription)
                    .IsRequired()
                    .HasColumnName("licenceTypeDescription")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.LicenceTypeId).HasColumnName("licenceTypeId");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Review).HasColumnName("review");

                entity.Property(e => e.ReviewCount).HasColumnName("reviewCount");

                entity.Property(e => e.StatusDescription)
                    .IsRequired()
                    .HasColumnName("statusDescription")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.UserDescription)
                    .IsRequired()
                    .HasColumnName("userDescription")
                    .HasMaxLength(101)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            modelBuilder.Entity<VwLoad>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_load", "dbo");

                entity.Property(e => e.Avatar)
                    .HasColumnName("avatar")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.BidCount).HasColumnName("bidCount");

                entity.Property(e => e.DateBidEnd)
                    .HasColumnName("dateBidEnd")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateIn)
                    .HasColumnName("dateIn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateOut)
                    .HasColumnName("dateOut")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DestinationAddressLabel)
                    .IsRequired()
                    .HasColumnName("destinationAddressLabel")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DestinationAddressLat).HasColumnName("destinationAddressLat");

                entity.Property(e => e.DestinationAddressLon).HasColumnName("destinationAddressLon");

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ItemCount).HasColumnName("itemCount");

                entity.Property(e => e.Length).HasColumnName("length");

                entity.Property(e => e.LoadCategoryDescription)
                    .IsRequired()
                    .HasColumnName("loadCategoryDescription")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoadCategoryId).HasColumnName("loadCategoryId");

                entity.Property(e => e.LoadTypeDescription)
                    .IsRequired()
                    .HasColumnName("loadTypeDescription")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoadTypeId).HasColumnName("loadTypeId");

                entity.Property(e => e.LoadTypeLiquid).HasColumnName("loadTypeLiquid");

                entity.Property(e => e.Note)
                    .IsRequired()
                    .HasColumnName("note")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NotificationDescription)
                    .IsRequired()
                    .HasColumnName("notificationDescription")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NotificationId).HasColumnName("notificationId");

                entity.Property(e => e.OriginatingAddressLabel)
                    .IsRequired()
                    .HasColumnName("originatingAddressLabel")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.OriginatingAddressLat).HasColumnName("originatingAddressLat");

                entity.Property(e => e.OriginatingAddressLon).HasColumnName("originatingAddressLon");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Review).HasColumnName("review");

                entity.Property(e => e.ReviewCount).HasColumnName("reviewCount");

                entity.Property(e => e.StatusDescription)
                    .IsRequired()
                    .HasColumnName("statusDescription")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.TotalValue)
                    .HasColumnName("totalValue")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UserDescription)
                    .IsRequired()
                    .HasColumnName("userDescription")
                    .HasMaxLength(101)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.UserIdAccepted).HasColumnName("userIdAccepted");

                entity.Property(e => e.UserIdDelivered).HasColumnName("userIdDelivered");

                entity.Property(e => e.UserIdDeliveredConfirmed).HasColumnName("userIdDeliveredConfirmed");

                entity.Property(e => e.UserIdLoaded).HasColumnName("userIdLoaded");

                entity.Property(e => e.UserIdLoadedConfirmed).HasColumnName("userIdLoadedConfirmed");

                entity.Property(e => e.Volume).HasColumnName("volume");

                entity.Property(e => e.Weight).HasColumnName("weight");

                entity.Property(e => e.Width).HasColumnName("width");
            });

            modelBuilder.Entity<VwLoadType>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_loadType", "dbo");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Liquid).HasColumnName("liquid");

                entity.Property(e => e.LoadCategoryDescription)
                    .IsRequired()
                    .HasColumnName("loadCategoryDescription")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoadCategoryId).HasColumnName("loadCategoryId");

                entity.Property(e => e.StatusDescription)
                    .IsRequired()
                    .HasColumnName("statusDescription")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("statusId");
            });

            modelBuilder.Entity<VwMessage>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_message", "dbo");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Link)
                    .HasColumnName("link")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Read).HasColumnName("read");

                entity.Property(e => e.Timestamp)
                    .HasColumnName("timestamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserFrom)
                    .IsRequired()
                    .HasColumnName("userFrom")
                    .HasMaxLength(101)
                    .IsUnicode(false);

                entity.Property(e => e.UserIdFrom).HasColumnName("userIdFrom");

                entity.Property(e => e.UserIdTo).HasColumnName("userIdTo");

                entity.Property(e => e.UserTo)
                    .IsRequired()
                    .HasColumnName("userTo")
                    .HasMaxLength(101)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_user", "dbo");

                entity.Property(e => e.AccessToken)
                    .HasColumnName("accessToken")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Avatar)
                    .HasColumnName("avatar")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasColumnName("company")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(14);

                entity.Property(e => e.StatusDescription)
                    .IsRequired()
                    .HasColumnName("statusDescription")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.TokenExpiry)
                    .HasColumnName("tokenExpiry")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.UserType)
                    .IsRequired()
                    .HasColumnName("userType")
                    .HasMaxLength(6)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwVehicle>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_vehicle", "dbo");

                entity.Property(e => e.AvailableCapacity).HasColumnName("availableCapacity");

                entity.Property(e => e.AvailableFrom)
                    .HasColumnName("availableFrom")
                    .HasColumnType("datetime");

                entity.Property(e => e.AvailableTo)
                    .HasColumnName("availableTo")
                    .HasColumnType("datetime");

                entity.Property(e => e.Avatar)
                    .HasColumnName("avatar")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DestinationAddressLabel)
                    .HasColumnName("destinationAddressLabel")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DestinationAddressLat).HasColumnName("destinationAddressLat");

                entity.Property(e => e.DestinationAddressLon).HasColumnName("destinationAddressLon");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MaxLoadHeight).HasColumnName("maxLoadHeight");

                entity.Property(e => e.MaxLoadLength).HasColumnName("maxLoadLength");

                entity.Property(e => e.MaxLoadVolume).HasColumnName("maxLoadVolume");

                entity.Property(e => e.MaxLoadWeight).HasColumnName("maxLoadWeight");

                entity.Property(e => e.MaxLoadWidth).HasColumnName("maxLoadWidth");

                entity.Property(e => e.OriginatingAddressLabel)
                    .IsRequired()
                    .HasColumnName("originatingAddressLabel")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.OriginatingAddressLat).HasColumnName("originatingAddressLat");

                entity.Property(e => e.OriginatingAddressLon).HasColumnName("originatingAddressLon");

                entity.Property(e => e.RegistrationNumber)
                    .IsRequired()
                    .HasColumnName("registrationNumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusDescription)
                    .IsRequired()
                    .HasColumnName("statusDescription")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.UserDescription)
                    .IsRequired()
                    .HasColumnName("userDescription")
                    .HasMaxLength(101)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.VehicleCategoryDescription)
                    .IsRequired()
                    .HasColumnName("vehicleCategoryDescription")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleCategoryId).HasColumnName("vehicleCategoryId");

                entity.Property(e => e.VehicleTypeDescription)
                    .IsRequired()
                    .HasColumnName("vehicleTypeDescription")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleTypeId).HasColumnName("vehicleTypeId");
            });

            modelBuilder.Entity<VwVehicleType>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_vehicleType", "dbo");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Liquid).HasColumnName("liquid");

                entity.Property(e => e.StatusDescription)
                    .IsRequired()
                    .HasColumnName("statusDescription")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.VehicleCategoryDescription)
                    .IsRequired()
                    .HasColumnName("vehicleCategoryDescription")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleCategoryId).HasColumnName("vehicleCategoryId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
