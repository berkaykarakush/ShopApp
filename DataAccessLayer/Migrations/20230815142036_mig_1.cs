using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<double>(type: "float", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConversationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    OrderState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SalesCount = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsHome = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartItemId = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<double>(type: "float", nullable: false),
                    CartId = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<double>(type: "float", nullable: false),
                    OrderId = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    CategoryId = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<double>(type: "float", nullable: false),
                    Id = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.CategoryId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "Url" },
                values: new object[,]
                {
                    { 1.0, "category 1", "category-1" },
                    { 2.0, "category 2", "category-2" },
                    { 3.0, "category 3", "category-3" },
                    { 4.0, "category 4", "category-4" },
                    { 5.0, "category 5", "category-5" },
                    { 6.0, "category 6", "category-6" },
                    { 7.0, "category 7", "category-7" },
                    { 8.0, "category 8", "category-8" },
                    { 9.0, "category 9", "category-9" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CreatedDate", "Description", "ImageUrl", "IsApproved", "IsHome", "Name", "Price", "Quantity", "SalesCount", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 1.0, "2023/08/15 17:20:36", "urun aciklamasi 1", "1.jpg", true, false, "urun 1", 10.0, 1, 0, "2023/08/15 17:20:36", "urun-1" },
                    { 2.0, "2023/08/15 17:20:36", "urun aciklamasi 2", "1.jpg", true, false, "urun 2", 10.0, 2, 0, "2023/08/15 17:20:36", "urun-2" },
                    { 3.0, "2023/08/15 17:20:36", "urun aciklamasi 3", "1.jpg", true, false, "urun 3", 10.0, 3, 0, "2023/08/15 17:20:36", "urun-3" },
                    { 4.0, "2023/08/15 17:20:36", "urun aciklamasi 4", "1.jpg", true, false, "urun 4", 10.0, 4, 0, "2023/08/15 17:20:36", "urun-4" },
                    { 5.0, "2023/08/15 17:20:36", "urun aciklamasi 5", "1.jpg", true, false, "urun 5", 10.0, 5, 0, "2023/08/15 17:20:36", "urun-5" },
                    { 6.0, "2023/08/15 17:20:36", "urun aciklamasi 6", "1.jpg", true, false, "urun 6", 10.0, 6, 0, "2023/08/15 17:20:36", "urun-6" },
                    { 7.0, "2023/08/15 17:20:36", "urun aciklamasi 7", "1.jpg", true, false, "urun 7", 10.0, 7, 0, "2023/08/15 17:20:36", "urun-7" },
                    { 8.0, "2023/08/15 17:20:36", "urun aciklamasi 8", "1.jpg", true, false, "urun 8", 10.0, 8, 0, "2023/08/15 17:20:36", "urun-8" },
                    { 9.0, "2023/08/15 17:20:36", "urun aciklamasi 9", "1.jpg", true, false, "urun 9", 10.0, 9, 0, "2023/08/15 17:20:36", "urun-9" },
                    { 10.0, "2023/08/15 17:20:36", "urun aciklamasi 10", "1.jpg", true, false, "urun 10", 10.0, 10, 0, "2023/08/15 17:20:36", "urun-10" },
                    { 11.0, "2023/08/15 17:20:36", "urun aciklamasi 11", "1.jpg", true, false, "urun 11", 10.0, 11, 0, "2023/08/15 17:20:36", "urun-11" },
                    { 12.0, "2023/08/15 17:20:36", "urun aciklamasi 12", "1.jpg", true, false, "urun 12", 10.0, 12, 0, "2023/08/15 17:20:36", "urun-12" },
                    { 13.0, "2023/08/15 17:20:36", "urun aciklamasi 13", "1.jpg", true, false, "urun 13", 10.0, 13, 0, "2023/08/15 17:20:36", "urun-13" },
                    { 14.0, "2023/08/15 17:20:36", "urun aciklamasi 14", "1.jpg", true, false, "urun 14", 10.0, 14, 0, "2023/08/15 17:20:36", "urun-14" },
                    { 15.0, "2023/08/15 17:20:36", "urun aciklamasi 15", "1.jpg", true, false, "urun 15", 10.0, 15, 0, "2023/08/15 17:20:36", "urun-15" },
                    { 16.0, "2023/08/15 17:20:36", "urun aciklamasi 16", "1.jpg", true, false, "urun 16", 10.0, 16, 0, "2023/08/15 17:20:36", "urun-16" },
                    { 17.0, "2023/08/15 17:20:36", "urun aciklamasi 17", "1.jpg", true, false, "urun 17", 10.0, 17, 0, "2023/08/15 17:20:36", "urun-17" },
                    { 18.0, "2023/08/15 17:20:36", "urun aciklamasi 18", "1.jpg", true, false, "urun 18", 10.0, 18, 0, "2023/08/15 17:20:36", "urun-18" },
                    { 19.0, "2023/08/15 17:20:36", "urun aciklamasi 19", "1.jpg", true, false, "urun 19", 10.0, 19, 0, "2023/08/15 17:20:36", "urun-19" },
                    { 20.0, "2023/08/15 17:20:36", "urun aciklamasi 20", "1.jpg", true, false, "urun 20", 10.0, 20, 0, "2023/08/15 17:20:36", "urun-20" },
                    { 21.0, "2023/08/15 17:20:36", "urun aciklamasi 21", "1.jpg", true, false, "urun 21", 10.0, 21, 0, "2023/08/15 17:20:36", "urun-21" },
                    { 22.0, "2023/08/15 17:20:36", "urun aciklamasi 22", "1.jpg", true, false, "urun 22", 10.0, 22, 0, "2023/08/15 17:20:36", "urun-22" },
                    { 23.0, "2023/08/15 17:20:36", "urun aciklamasi 23", "1.jpg", true, false, "urun 23", 10.0, 23, 0, "2023/08/15 17:20:36", "urun-23" },
                    { 24.0, "2023/08/15 17:20:36", "urun aciklamasi 24", "1.jpg", true, false, "urun 24", 10.0, 24, 0, "2023/08/15 17:20:36", "urun-24" },
                    { 25.0, "2023/08/15 17:20:36", "urun aciklamasi 25", "1.jpg", true, false, "urun 25", 10.0, 25, 0, "2023/08/15 17:20:36", "urun-25" },
                    { 26.0, "2023/08/15 17:20:36", "urun aciklamasi 26", "1.jpg", true, false, "urun 26", 10.0, 26, 0, "2023/08/15 17:20:36", "urun-26" },
                    { 27.0, "2023/08/15 17:20:36", "urun aciklamasi 27", "1.jpg", true, false, "urun 27", 10.0, 27, 0, "2023/08/15 17:20:36", "urun-27" },
                    { 28.0, "2023/08/15 17:20:36", "urun aciklamasi 28", "1.jpg", true, false, "urun 28", 10.0, 28, 0, "2023/08/15 17:20:36", "urun-28" },
                    { 29.0, "2023/08/15 17:20:36", "urun aciklamasi 29", "1.jpg", true, false, "urun 29", 10.0, 29, 0, "2023/08/15 17:20:36", "urun-29" },
                    { 30.0, "2023/08/15 17:20:36", "urun aciklamasi 30", "1.jpg", true, false, "urun 30", 10.0, 30, 0, "2023/08/15 17:20:36", "urun-30" },
                    { 31.0, "2023/08/15 17:20:36", "urun aciklamasi 31", "1.jpg", true, false, "urun 31", 10.0, 31, 0, "2023/08/15 17:20:36", "urun-31" },
                    { 32.0, "2023/08/15 17:20:36", "urun aciklamasi 32", "1.jpg", true, false, "urun 32", 10.0, 32, 0, "2023/08/15 17:20:36", "urun-32" },
                    { 33.0, "2023/08/15 17:20:36", "urun aciklamasi 33", "1.jpg", true, false, "urun 33", 10.0, 33, 0, "2023/08/15 17:20:36", "urun-33" },
                    { 34.0, "2023/08/15 17:20:36", "urun aciklamasi 34", "1.jpg", true, false, "urun 34", 10.0, 34, 0, "2023/08/15 17:20:36", "urun-34" },
                    { 35.0, "2023/08/15 17:20:36", "urun aciklamasi 35", "1.jpg", true, false, "urun 35", 10.0, 35, 0, "2023/08/15 17:20:36", "urun-35" },
                    { 36.0, "2023/08/15 17:20:36", "urun aciklamasi 36", "1.jpg", true, false, "urun 36", 10.0, 36, 0, "2023/08/15 17:20:36", "urun-36" },
                    { 37.0, "2023/08/15 17:20:36", "urun aciklamasi 37", "1.jpg", true, false, "urun 37", 10.0, 37, 0, "2023/08/15 17:20:36", "urun-37" },
                    { 38.0, "2023/08/15 17:20:36", "urun aciklamasi 38", "1.jpg", true, false, "urun 38", 10.0, 38, 0, "2023/08/15 17:20:36", "urun-38" },
                    { 39.0, "2023/08/15 17:20:36", "urun aciklamasi 39", "1.jpg", true, false, "urun 39", 10.0, 39, 0, "2023/08/15 17:20:36", "urun-39" },
                    { 40.0, "2023/08/15 17:20:36", "urun aciklamasi 40", "1.jpg", true, false, "urun 40", 10.0, 40, 0, "2023/08/15 17:20:36", "urun-40" },
                    { 41.0, "2023/08/15 17:20:36", "urun aciklamasi 41", "1.jpg", true, false, "urun 41", 10.0, 41, 0, "2023/08/15 17:20:36", "urun-41" },
                    { 42.0, "2023/08/15 17:20:36", "urun aciklamasi 42", "1.jpg", true, false, "urun 42", 10.0, 42, 0, "2023/08/15 17:20:36", "urun-42" },
                    { 43.0, "2023/08/15 17:20:36", "urun aciklamasi 43", "1.jpg", true, false, "urun 43", 10.0, 43, 0, "2023/08/15 17:20:36", "urun-43" },
                    { 44.0, "2023/08/15 17:20:36", "urun aciklamasi 44", "1.jpg", true, false, "urun 44", 10.0, 44, 0, "2023/08/15 17:20:36", "urun-44" },
                    { 45.0, "2023/08/15 17:20:36", "urun aciklamasi 45", "1.jpg", true, false, "urun 45", 10.0, 45, 0, "2023/08/15 17:20:36", "urun-45" },
                    { 46.0, "2023/08/15 17:20:36", "urun aciklamasi 46", "1.jpg", true, false, "urun 46", 10.0, 46, 0, "2023/08/15 17:20:36", "urun-46" },
                    { 47.0, "2023/08/15 17:20:36", "urun aciklamasi 47", "1.jpg", true, false, "urun 47", 10.0, 47, 0, "2023/08/15 17:20:36", "urun-47" },
                    { 48.0, "2023/08/15 17:20:36", "urun aciklamasi 48", "1.jpg", true, false, "urun 48", 10.0, 48, 0, "2023/08/15 17:20:36", "urun-48" },
                    { 49.0, "2023/08/15 17:20:36", "urun aciklamasi 49", "1.jpg", true, false, "urun 49", 10.0, 49, 0, "2023/08/15 17:20:36", "urun-49" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "ProductId", "Id" },
                values: new object[,]
                {
                    { 1.0, 1.0, 0.074962908062155442 },
                    { 2.0, 2.0, 0.053908470734938763 },
                    { 3.0, 3.0, 0.50657643527102592 },
                    { 4.0, 4.0, 0.10249034288847125 },
                    { 5.0, 5.0, 0.24261805974186945 },
                    { 6.0, 6.0, 0.40044998854791214 },
                    { 7.0, 7.0, 0.59959590546627461 },
                    { 8.0, 8.0, 0.28030444441775559 },
                    { 9.0, 9.0, 0.84461017102497216 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ProductId",
                table: "ProductCategories",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
