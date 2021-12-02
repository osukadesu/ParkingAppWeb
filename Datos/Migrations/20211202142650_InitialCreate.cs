using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estacionamientos",
                columns: table => new
                {
                    IdEstacionamiento = table.Column<string>(type: "varchar(4)", nullable: false),
                    Tipo = table.Column<string>(type: "varchar(8)", nullable: true),
                    Estado = table.Column<string>(type: "varchar(13)", nullable: true),
                    NumeroCupo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estacionamientos", x => x.IdEstacionamiento);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Cedula = table.Column<string>(type: "varchar(13)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(25)", nullable: true),
                    Apellido = table.Column<string>(type: "varchar(25)", nullable: true),
                    Sexo = table.Column<string>(type: "varchar(10)", nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "varchar(40)", nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    IdCliente = table.Column<string>(type: "varchar(4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Cedula);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    IdVehiculo = table.Column<string>(type: "varchar(4)", nullable: false),
                    Cedula = table.Column<string>(type: "varchar(13)", nullable: true),
                    Tipo = table.Column<string>(type: "varchar(8)", nullable: true),
                    Color = table.Column<string>(type: "varchar(8)", nullable: true),
                    Marca = table.Column<string>(type: "varchar(8)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.IdVehiculo);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Personas_Cedula",
                        column: x => x.Cedula,
                        principalTable: "Personas",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    IdTicket = table.Column<string>(type: "varchar(4)", nullable: false),
                    Cedula = table.Column<string>(type: "varchar(13)", nullable: true),
                    IdVehiculo = table.Column<string>(type: "varchar(4)", nullable: true),
                    IdEstacionamiento = table.Column<string>(type: "varchar(4)", nullable: true),
                    FechaElaboracion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime", nullable: false),
                    Iva = table.Column<decimal>(type: "decimal", nullable: false),
                    Total = table.Column<decimal>(type: "decimal", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal", nullable: false),
                    Dias = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.IdTicket);
                    table.ForeignKey(
                        name: "FK_Tickets_Personas_Cedula",
                        column: x => x.Cedula,
                        principalTable: "Personas",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Estacionamientos_IdEstacionamiento",
                        column: x => x.IdEstacionamiento,
                        principalTable: "Estacionamientos",
                        principalColumn: "IdEstacionamiento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Vehiculos_IdVehiculo",
                        column: x => x.IdVehiculo,
                        principalTable: "Vehiculos",
                        principalColumn: "IdVehiculo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Cedula",
                table: "Tickets",
                column: "Cedula");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_IdEstacionamiento",
                table: "Tickets",
                column: "IdEstacionamiento");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_IdVehiculo",
                table: "Tickets",
                column: "IdVehiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_Cedula",
                table: "Vehiculos",
                column: "Cedula");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Estacionamientos");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
