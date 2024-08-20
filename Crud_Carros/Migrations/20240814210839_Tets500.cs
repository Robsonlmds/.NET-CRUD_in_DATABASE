using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crud_Carros.Migrations
{
    /// <inheritdoc />
    public partial class Tets500 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id_Client = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name_Client = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contact = table.Column<int>(type: "int", nullable: false),
                    CPF = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id_Client);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    Id_Staff = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name_Staff = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Local_Staff = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postalcode = table.Column<int>(type: "int", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Id_Staff);
                });

            migrationBuilder.CreateTable(
                name: "ClientOfStaffs",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientOfStaffs", x => new { x.ClientId, x.StaffId });
                    table.ForeignKey(
                        name: "FK_ClientOfStaffs_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id_Client",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientOfStaffs_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "Id_Staff",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelsOfCar",
                columns: table => new
                {
                    Id_ModelOfCar = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name_ModelOfCar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelsOfCar", x => x.Id_ModelOfCar);
                    table.ForeignKey(
                        name: "FK_ModelsOfCar_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "Id_Staff",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id_Car = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Plate_Car = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_Owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year_Car = table.Column<int>(type: "int", nullable: false),
                    IPVA = table.Column<bool>(type: "bit", nullable: false),
                    ModelOfCarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id_Car);
                    table.ForeignKey(
                        name: "FK_Cars_ModelsOfCar_ModelOfCarId",
                        column: x => x.ModelOfCarId,
                        principalTable: "ModelsOfCar",
                        principalColumn: "Id_ModelOfCar",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ModelOfCarId",
                table: "Cars",
                column: "ModelOfCarId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientOfStaffs_StaffId",
                table: "ClientOfStaffs",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelsOfCar_StaffId",
                table: "ModelsOfCar",
                column: "StaffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "ClientOfStaffs");

            migrationBuilder.DropTable(
                name: "ModelsOfCar");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Staffs");
        }
    }
}
