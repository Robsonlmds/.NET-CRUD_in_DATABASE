using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crud_Carros.Migrations
{
    /// <inheritdoc />
    public partial class Test156156561 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientOfStaffs",
                table: "ClientOfStaffs");

            migrationBuilder.AddColumn<Guid>(
                name: "Id_ClientOfStaff",
                table: "ClientOfStaffs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientOfStaffs",
                table: "ClientOfStaffs",
                column: "Id_ClientOfStaff");

            migrationBuilder.CreateIndex(
                name: "IX_ClientOfStaffs_ClientId",
                table: "ClientOfStaffs",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientOfStaffs",
                table: "ClientOfStaffs");

            migrationBuilder.DropIndex(
                name: "IX_ClientOfStaffs_ClientId",
                table: "ClientOfStaffs");

            migrationBuilder.DropColumn(
                name: "Id_ClientOfStaff",
                table: "ClientOfStaffs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientOfStaffs",
                table: "ClientOfStaffs",
                columns: new[] { "ClientId", "StaffId" });
        }
    }
}
