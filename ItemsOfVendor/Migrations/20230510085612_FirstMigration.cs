using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItemsOfVendor.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    IId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ICode = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.IId);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    VId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VCode = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VContactNo = table.Column<decimal>(name: "VContact_No", type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.VId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Vendors");
        }
    }
}
