using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductInventory.Api.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1L, "Description 1", "Product 1", 2m, 5 },
                    { 2L, "Description 2", "Product 2", 4m, 10 },
                    { 3L, "Description 3", "Product 3", 6m, 15 },
                    { 4L, "Description 4", "Product 4", 8m, 20 },
                    { 5L, "Description 5", "Product 5", 10m, 0 },
                    { 6L, "Description 6", "Product 6", 12m, 5 },
                    { 7L, "Description 7", "Product 7", 14m, 10 },
                    { 8L, "Description 8", "Product 8", 16m, 15 },
                    { 9L, "Description 9", "Product 9", 18m, 20 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
