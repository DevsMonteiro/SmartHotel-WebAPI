using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartHotel.Data.Migrations
{
    public partial class ModifyEntryGuest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guest_Pendency_PendencyId",
                table: "Guest");

            migrationBuilder.AlterColumn<Guid>(
                name: "PendencyId",
                table: "Guest",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Guest_Pendency_PendencyId",
                table: "Guest",
                column: "PendencyId",
                principalTable: "Pendency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guest_Pendency_PendencyId",
                table: "Guest");

            migrationBuilder.AlterColumn<Guid>(
                name: "PendencyId",
                table: "Guest",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Guest_Pendency_PendencyId",
                table: "Guest",
                column: "PendencyId",
                principalTable: "Pendency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
