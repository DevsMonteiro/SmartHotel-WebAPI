using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartHotel.Data.Migrations
{
    public partial class TableChangeGuesAndPendency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guest_Pendency_PendencyId",
                table: "Guest");

            migrationBuilder.DropIndex(
                name: "IX_Guest_PendencyId",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Pendency");

            migrationBuilder.DropColumn(
                name: "PendencyId",
                table: "Guest");

            migrationBuilder.AddColumn<Guid>(
                name: "GuestId",
                table: "Pendency",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Pendency_GuestId",
                table: "Pendency",
                column: "GuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pendency_Guest_GuestId",
                table: "Pendency",
                column: "GuestId",
                principalTable: "Guest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pendency_Guest_GuestId",
                table: "Pendency");

            migrationBuilder.DropIndex(
                name: "IX_Pendency_GuestId",
                table: "Pendency");

            migrationBuilder.DropColumn(
                name: "GuestId",
                table: "Pendency");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Pendency",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "PendencyId",
                table: "Guest",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guest_PendencyId",
                table: "Guest",
                column: "PendencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guest_Pendency_PendencyId",
                table: "Guest",
                column: "PendencyId",
                principalTable: "Pendency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
