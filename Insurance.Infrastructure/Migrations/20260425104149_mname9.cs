using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insurance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mname9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customer_Addresses_Customer_Id",
                table: "Customer_Addresses");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Addresses_Customer_Id",
                table: "Customer_Addresses",
                column: "Customer_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customer_Addresses_Customer_Id",
                table: "Customer_Addresses");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Addresses_Customer_Id",
                table: "Customer_Addresses",
                column: "Customer_Id",
                unique: true);
        }
    }
}
