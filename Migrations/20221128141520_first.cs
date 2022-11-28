using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerTransaction",
                columns: table => new
                {
                    CustomerTransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Money = table.Column<double>(type: "float", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTransaction", x => x.CustomerTransactionId);
                    table.ForeignKey(
                        name: "FK_CustomerTransaction_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerEmail", "CustomerName", "CustomerPassword" },
                values: new object[] { 1, "alperen9792@gmail.com", "testUser", "testPassword" });

            migrationBuilder.InsertData(
                table: "CustomerTransaction",
                columns: new[] { "CustomerTransactionId", "CustomerId", "Money", "TransactionDate", "TransactionNumber" },
                values: new object[,]
                {
                    { new Guid("96dac919-3141-4ca8-afdc-4e33e89f5aec"), 1, -25.0, new DateTime(2022, 11, 28, 17, 15, 20, 585, DateTimeKind.Local).AddTicks(1247), 10001 },
                    { new Guid("e3bd21ee-de46-4bf1-ab99-39ca20cea4d8"), 1, 100.0, new DateTime(2022, 11, 28, 17, 15, 20, 585, DateTimeKind.Local).AddTicks(1201), 10000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTransaction_CustomerId",
                table: "CustomerTransaction",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerTransaction");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
