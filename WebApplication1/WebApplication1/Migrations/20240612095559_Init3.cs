using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2024, 6, 12, 11, 55, 58, 812, DateTimeKind.Local).AddTicks(2095), new DateTime(2024, 7, 12, 11, 55, 58, 812, DateTimeKind.Local).AddTicks(2140) });

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 2,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2024, 6, 12, 11, 55, 58, 812, DateTimeKind.Local).AddTicks(2146), new DateTime(2024, 7, 12, 11, 55, 58, 812, DateTimeKind.Local).AddTicks(2147) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2024, 6, 12, 11, 47, 50, 737, DateTimeKind.Local).AddTicks(663), new DateTime(2024, 7, 12, 11, 47, 50, 737, DateTimeKind.Local).AddTicks(702) });

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 2,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2024, 6, 12, 11, 47, 50, 737, DateTimeKind.Local).AddTicks(708), new DateTime(2024, 7, 12, 11, 47, 50, 737, DateTimeKind.Local).AddTicks(710) });
        }
    }
}
