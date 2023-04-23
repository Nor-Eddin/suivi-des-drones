using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace suivi_des_drones.Core.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitWithIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HealthStatus",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Login = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Login);
                });

            migrationBuilder.CreateTable(
                name: "Drone",
                columns: table => new
                {
                    Matricule = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    healthStatusId = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drone", x => x.Matricule);
                    table.ForeignKey(
                        name: "FK_Drone_HealthStatus_healthStatusId",
                        column: x => x.healthStatusId,
                        principalTable: "HealthStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drone_healthStatusId",
                table: "Drone",
                column: "healthStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drone");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "HealthStatus");
        }
    }
}
