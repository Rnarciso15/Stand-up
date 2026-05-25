using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StandUp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Top5Enhancements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateOnly = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateTimeSlot = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EmployeeNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    EmployeeName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClientName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    VehicleBrand = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    VehicleModel = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    VehicleLicensePlate = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    ClientPhone = table.Column<string>(type: "TEXT", maxLength: 40, nullable: true),
                    SmsConsentGranted = table.Column<bool>(type: "INTEGER", nullable: false),
                    SmsConsentTimestampUtc = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserRole = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Action = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    EntityName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    BeforeJson = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: true),
                    AfterJson = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: true),
                    TimestampUtc = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    Data = table.Column<byte[]>(type: "BLOB", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AppointmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    Type = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Attempts = table.Column<int>(type: "INTEGER", nullable: false),
                    ProviderMessageId = table.Column<string>(type: "TEXT", maxLength: 120, nullable: true),
                    ErrorMessage = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    ConsentGranted = table.Column<bool>(type: "INTEGER", nullable: false),
                    ConsentTimestampUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProposalDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SaleTransactionId = table.Column<int>(type: "INTEGER", nullable: false),
                    FileName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    ValidUntilUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PdfBytes = table.Column<byte[]>(type: "BLOB", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProposalDocuments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientNif = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    VehicleLicensePlate = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: false),
                    ClientName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleTransactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VehicleLicensePlate = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Data = table.Column<byte[]>(type: "BLOB", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LicensePlate = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Kilometers = table.Column<int>(type: "INTEGER", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Brand = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Fuel = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    Color = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    GearboxType = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Doors = table.Column<int>(type: "INTEGER", nullable: true),
                    Traction = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    IsSold = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsMotorcycle = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Role",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DateTimeSlot_ClientId",
                table: "Appointments",
                columns: new[] { "DateTimeSlot", "ClientId" });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DateTimeSlot_EmployeeNumber",
                table: "Appointments",
                columns: new[] { "DateTimeSlot", "EmployeeNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DateTimeSlot_VehicleLicensePlate",
                table: "Appointments",
                columns: new[] { "DateTimeSlot", "VehicleLicensePlate" });

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_TimestampUtc",
                table: "AuditLogs",
                column: "TimestampUtc");

            migrationBuilder.CreateIndex(
                name: "IX_ClientImages_ClientId",
                table: "ClientImages",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationLogs_AppointmentId",
                table: "NotificationLogs",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationLogs_CreatedAtUtc",
                table: "NotificationLogs",
                column: "CreatedAtUtc");

            migrationBuilder.CreateIndex(
                name: "IX_ProposalDocuments_SaleTransactionId",
                table: "ProposalDocuments",
                column: "SaleTransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleTransactions_VehicleLicensePlate",
                table: "SaleTransactions",
                column: "VehicleLicensePlate");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleImages_VehicleLicensePlate",
                table: "VehicleImages",
                column: "VehicleLicensePlate");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_LicensePlate",
                table: "Vehicles",
                column: "LicensePlate",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "ClientImages");

            migrationBuilder.DropTable(
                name: "NotificationLogs");

            migrationBuilder.DropTable(
                name: "ProposalDocuments");

            migrationBuilder.DropTable(
                name: "SaleTransactions");

            migrationBuilder.DropTable(
                name: "VehicleImages");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");
        }
    }
}
