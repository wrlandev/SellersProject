using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellersProject.Migrations
{
    /// <inheritdoc />
    public partial class exec01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartmentModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SellerModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaseSalary = table.Column<double>(type: "float", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellerModel_DepartmentModel_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "DepartmentModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesRecordModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesRecordModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesRecordModel_SellerModel_SellerId",
                        column: x => x.SellerId,
                        principalTable: "SellerModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesRecordModel_SellerId",
                table: "SalesRecordModel",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_SellerModel_DepartmentId",
                table: "SellerModel",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesRecordModel");

            migrationBuilder.DropTable(
                name: "SellerModel");

            migrationBuilder.DropTable(
                name: "DepartmentModel");
        }
    }
}
