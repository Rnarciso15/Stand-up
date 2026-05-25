using Microsoft.EntityFrameworkCore;
using StandUp.Domain.Entities;

namespace StandUp.Infrastructure.Persistence;

public sealed class StandUpDbContext : DbContext
{
    public StandUpDbContext(DbContextOptions<StandUpDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Vehicle> Vehicles => Set<Vehicle>();
    public DbSet<Appointment> Appointments => Set<Appointment>();
    public DbSet<SaleTransaction> SaleTransactions => Set<SaleTransaction>();
    public DbSet<ClientImage> ClientImages => Set<ClientImage>();
    public DbSet<VehicleImage> VehicleImages => Set<VehicleImage>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
    public DbSet<NotificationLog> NotificationLogs => Set<NotificationLog>();
    public DbSet<NotificationOutboxItem> NotificationOutboxItems => Set<NotificationOutboxItem>();
    public DbSet<ProposalDocument> ProposalDocuments => Set<ProposalDocument>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");
            entity.HasKey(x => x.Id);
            entity.HasIndex(x => x.EmployeeNumber).IsUnique();
            entity.Property(x => x.Name).HasMaxLength(200).IsRequired();
            entity.Property(x => x.PasswordHash).HasMaxLength(100).IsRequired();
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("Clients");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Name).HasMaxLength(200).IsRequired();
            entity.Property(x => x.Gender).HasMaxLength(50);
            entity.Property(x => x.Email).HasMaxLength(200);
            entity.Property(x => x.Phone).HasMaxLength(50);
            entity.Property(x => x.Nib).HasMaxLength(50);
            entity.Property(x => x.Nif).HasMaxLength(50);
            entity.Property(x => x.Address).HasMaxLength(300);
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.ToTable("Vehicles");
            entity.HasKey(x => x.Id);
            entity.HasIndex(x => x.LicensePlate).IsUnique();
            entity.HasIndex(x => new { x.IsSold, x.Price });
            entity.HasIndex(x => new { x.IsSold, x.Kilometers });
            entity.HasIndex(x => new { x.Brand, x.Model });
            entity.Property(x => x.LicensePlate).HasMaxLength(20).IsRequired();
            entity.Property(x => x.Brand).HasMaxLength(100).IsRequired();
            entity.Property(x => x.Model).HasMaxLength(100).IsRequired();
            entity.Property(x => x.Fuel).HasMaxLength(50);
            entity.Property(x => x.Color).HasMaxLength(50);
            entity.Property(x => x.GearboxType).HasMaxLength(50);
            entity.Property(x => x.Traction).HasMaxLength(50);
            entity.Property(x => x.Description).HasMaxLength(1000);
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.ToTable("Appointments");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.EmployeeName).HasMaxLength(200).IsRequired();
            entity.Property(x => x.ClientName).HasMaxLength(200).IsRequired();
            entity.Property(x => x.VehicleBrand).HasMaxLength(100).IsRequired();
            entity.Property(x => x.VehicleModel).HasMaxLength(100).IsRequired();
            entity.Property(x => x.VehicleLicensePlate).HasMaxLength(20).IsRequired();
            entity.Property(x => x.ClientPhone).HasMaxLength(40);
            entity.HasIndex(x => new { x.DateTimeSlot, x.EmployeeNumber });
            entity.HasIndex(x => new { x.DateTimeSlot, x.ClientId });
            entity.HasIndex(x => new { x.DateTimeSlot, x.VehicleLicensePlate });
        });

        modelBuilder.Entity<SaleTransaction>(entity =>
        {
            entity.ToTable("SaleTransactions");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.ClientNif).HasMaxLength(50).IsRequired();
            entity.Property(x => x.VehicleLicensePlate).HasMaxLength(20).IsRequired();
            entity.Property(x => x.ClientName).HasMaxLength(200).IsRequired();
            entity.HasIndex(x => x.VehicleLicensePlate);
            entity.HasIndex(x => x.TransactionDate);
        });

        modelBuilder.Entity<ClientImage>(entity =>
        {
            entity.ToTable("ClientImages");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Data).IsRequired();
            entity.HasIndex(x => x.ClientId);
        });

        modelBuilder.Entity<VehicleImage>(entity =>
        {
            entity.ToTable("VehicleImages");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.VehicleLicensePlate).HasMaxLength(20).IsRequired();
            entity.Property(x => x.Data).IsRequired();
            entity.HasIndex(x => x.VehicleLicensePlate);
        });

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.ToTable("AuditLogs");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.UserRole).HasMaxLength(50).IsRequired();
            entity.Property(x => x.Action).HasMaxLength(100).IsRequired();
            entity.Property(x => x.EntityName).HasMaxLength(100).IsRequired();
            entity.Property(x => x.BeforeJson).HasMaxLength(4000);
            entity.Property(x => x.AfterJson).HasMaxLength(4000);
            entity.HasIndex(x => x.TimestampUtc);
        });

        modelBuilder.Entity<NotificationLog>(entity =>
        {
            entity.ToTable("NotificationLogs");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.PhoneNumber).HasMaxLength(40).IsRequired();
            entity.Property(x => x.Type).HasMaxLength(50).IsRequired();
            entity.Property(x => x.Status).HasMaxLength(50).IsRequired();
            entity.Property(x => x.ProviderMessageId).HasMaxLength(120);
            entity.Property(x => x.ErrorMessage).HasMaxLength(500);
            entity.HasIndex(x => x.AppointmentId);
            entity.HasIndex(x => x.CreatedAtUtc);
        });

        modelBuilder.Entity<NotificationOutboxItem>(entity =>
        {
            entity.ToTable("NotificationOutboxItems");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Type).HasMaxLength(50).IsRequired();
            entity.Property(x => x.Prefix).HasMaxLength(200).IsRequired();
            entity.Property(x => x.Status).HasMaxLength(30).IsRequired();
            entity.Property(x => x.LastError).HasMaxLength(500);
            entity.HasIndex(x => new { x.Status, x.NextAttemptUtc });
        });

        modelBuilder.Entity<ProposalDocument>(entity =>
        {
            entity.ToTable("ProposalDocuments");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.FileName).HasMaxLength(200).IsRequired();
            entity.Property(x => x.TemplateVersion).HasMaxLength(20).IsRequired();
            entity.Property(x => x.PdfBytes).IsRequired();
            entity.HasIndex(x => x.SaleTransactionId);
        });

        // Default user: 1000 / "teste"
        modelBuilder.Entity<User>().HasData(new User
        {
            Id = 1,
            EmployeeNumber = 1000,
            Name = "Administrador",
            PasswordHash = "2E6F9B0D5885B6010F9167787445617F553A735F",
            IsActive = true,
            IsAdmin = true,
            Role = UserRole.Admin
        });
    }
}
