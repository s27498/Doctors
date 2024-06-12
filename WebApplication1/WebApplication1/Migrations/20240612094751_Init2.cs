using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Doctor_IdPatient",
                table: "Prescription");

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

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_IdDoctor",
                table: "Prescription",
                column: "IdDoctor");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Doctor_IdDoctor",
                table: "Prescription",
                column: "IdDoctor",
                principalTable: "Doctor",
                principalColumn: "IdDoctor",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Doctor_IdDoctor",
                table: "Prescription");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_IdDoctor",
                table: "Prescription");

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2024, 6, 12, 11, 41, 1, 477, DateTimeKind.Local).AddTicks(3325), new DateTime(2024, 7, 12, 11, 41, 1, 477, DateTimeKind.Local).AddTicks(3374) });

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 2,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2024, 6, 12, 11, 41, 1, 477, DateTimeKind.Local).AddTicks(3379), new DateTime(2024, 7, 12, 11, 41, 1, 477, DateTimeKind.Local).AddTicks(3381) });

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Doctor_IdPatient",
                table: "Prescription",
                column: "IdPatient",
                principalTable: "Doctor",
                principalColumn: "IdDoctor",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
