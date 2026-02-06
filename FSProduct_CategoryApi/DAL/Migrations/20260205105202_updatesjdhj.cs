using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSProduct_CategoryApi.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updatesjdhj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Product_Price_Positive",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_Product_Price_Positive",
                table: "Products",
                sql: "Price > 0");
        }
    }
}
