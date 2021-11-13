using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FixedAssetsAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActiveType",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    documentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    departmentId = table.Column<int>(type: "int", nullable: false),
                    personType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    admissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.id);
                    table.ForeignKey(
                        name: "FK_Employee_Department_departmentId",
                        column: x => x.departmentId,
                        principalTable: "Department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FixedAsset",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    departmentId = table.Column<int>(type: "int", nullable: false),
                    activeTypeId = table.Column<int>(type: "int", nullable: false),
                    admissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    purchaseValue = table.Column<double>(type: "float", nullable: false),
                    depreciationAccumulated = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixedAsset", x => x.id);
                    table.ForeignKey(
                        name: "FK_FixedAsset_ActiveType_activeTypeId",
                        column: x => x.activeTypeId,
                        principalTable: "ActiveType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FixedAsset_Department_departmentId",
                        column: x => x.departmentId,
                        principalTable: "Department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CalculusDepreciation",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    processYear = table.Column<int>(type: "int", nullable: false),
                    processMonth = table.Column<int>(type: "int", nullable: false),
                    fixedAssetId = table.Column<int>(type: "int", nullable: false),
                    processDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deprecciatedAmount = table.Column<double>(type: "float", nullable: false),
                    deprecciatedAcumulated = table.Column<double>(type: "float", nullable: false),
                    purchaseAccount = table.Column<int>(type: "int", nullable: false),
                    deprecciatedAccount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculusDepreciation", x => x.id);
                    table.ForeignKey(
                        name: "FK_CalculusDepreciation_FixedAsset_fixedAssetId",
                        column: x => x.fixedAssetId,
                        principalTable: "FixedAsset",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalculusDepreciation_fixedAssetId",
                table: "CalculusDepreciation",
                column: "fixedAssetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_departmentId",
                table: "Employee",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_FixedAsset_activeTypeId",
                table: "FixedAsset",
                column: "activeTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FixedAsset_departmentId",
                table: "FixedAsset",
                column: "departmentId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculusDepreciation");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "FixedAsset");

            migrationBuilder.DropTable(
                name: "ActiveType");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
