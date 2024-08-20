using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crud_Carros.Migrations
{
    /// <inheritdoc />
    public partial class dffdwe56 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ddd",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ddd",
                table: "Clients");
        }
    }
}
