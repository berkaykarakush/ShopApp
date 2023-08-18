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
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "ImageUrls",
                columns: table => new
                {
                    Id = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<double>(type: "float", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageUrls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageUrls_Products_ProductId",
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
                    { 111111112.0, "category 1", "category-1" },
                    { 111111113.0, "category 2", "category-2" },
                    { 111111114.0, "category 3", "category-3" },
                    { 111111115.0, "category 4", "category-4" },
                    { 111111116.0, "category 5", "category-5" },
                    { 111111117.0, "category 6", "category-6" },
                    { 111111118.0, "category 7", "category-7" },
                    { 111111119.0, "category 8", "category-8" },
                    { 111111120.0, "category 9", "category-9" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CreatedDate", "Description", "IsApproved", "IsHome", "Name", "Price", "ProductImage", "Quantity", "SalesCount", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 111111112.0, "2023/08/17 16:50:59", "urun aciklamasi 1", true, false, "urun 1", 10.0, "1.jpg", 1, 1, "2023/08/17 16:50:59", "urun-1" },
                    { 111111113.0, "2023/08/17 16:50:59", "urun aciklamasi 2", true, false, "urun 2", 10.0, "1.jpg", 2, 2, "2023/08/17 16:50:59", "urun-2" },
                    { 111111114.0, "2023/08/17 16:50:59", "urun aciklamasi 3", true, false, "urun 3", 10.0, "1.jpg", 3, 3, "2023/08/17 16:50:59", "urun-3" },
                    { 111111115.0, "2023/08/17 16:50:59", "urun aciklamasi 4", true, false, "urun 4", 10.0, "1.jpg", 4, 4, "2023/08/17 16:50:59", "urun-4" },
                    { 111111116.0, "2023/08/17 16:50:59", "urun aciklamasi 5", true, false, "urun 5", 10.0, "1.jpg", 5, 5, "2023/08/17 16:50:59", "urun-5" },
                    { 111111117.0, "2023/08/17 16:50:59", "urun aciklamasi 6", true, false, "urun 6", 10.0, "1.jpg", 6, 6, "2023/08/17 16:50:59", "urun-6" },
                    { 111111118.0, "2023/08/17 16:50:59", "urun aciklamasi 7", true, false, "urun 7", 10.0, "1.jpg", 7, 7, "2023/08/17 16:50:59", "urun-7" },
                    { 111111119.0, "2023/08/17 16:50:59", "urun aciklamasi 8", true, false, "urun 8", 10.0, "1.jpg", 8, 8, "2023/08/17 16:50:59", "urun-8" },
                    { 111111120.0, "2023/08/17 16:50:59", "urun aciklamasi 9", true, false, "urun 9", 10.0, "1.jpg", 9, 9, "2023/08/17 16:50:59", "urun-9" },
                    { 111111121.0, "2023/08/17 16:50:59", "urun aciklamasi 10", true, false, "urun 10", 10.0, "1.jpg", 10, 10, "2023/08/17 16:50:59", "urun-10" },
                    { 111111122.0, "2023/08/17 16:50:59", "urun aciklamasi 11", true, false, "urun 11", 10.0, "1.jpg", 11, 11, "2023/08/17 16:50:59", "urun-11" },
                    { 111111123.0, "2023/08/17 16:50:59", "urun aciklamasi 12", true, false, "urun 12", 10.0, "1.jpg", 12, 12, "2023/08/17 16:50:59", "urun-12" },
                    { 111111124.0, "2023/08/17 16:50:59", "urun aciklamasi 13", true, false, "urun 13", 10.0, "1.jpg", 13, 13, "2023/08/17 16:50:59", "urun-13" },
                    { 111111125.0, "2023/08/17 16:50:59", "urun aciklamasi 14", true, false, "urun 14", 10.0, "1.jpg", 14, 14, "2023/08/17 16:50:59", "urun-14" },
                    { 111111126.0, "2023/08/17 16:50:59", "urun aciklamasi 15", true, false, "urun 15", 10.0, "1.jpg", 15, 15, "2023/08/17 16:50:59", "urun-15" },
                    { 111111127.0, "2023/08/17 16:50:59", "urun aciklamasi 16", true, false, "urun 16", 10.0, "1.jpg", 16, 16, "2023/08/17 16:50:59", "urun-16" },
                    { 111111128.0, "2023/08/17 16:50:59", "urun aciklamasi 17", true, false, "urun 17", 10.0, "1.jpg", 17, 17, "2023/08/17 16:50:59", "urun-17" },
                    { 111111129.0, "2023/08/17 16:50:59", "urun aciklamasi 18", true, false, "urun 18", 10.0, "1.jpg", 18, 18, "2023/08/17 16:50:59", "urun-18" },
                    { 111111130.0, "2023/08/17 16:50:59", "urun aciklamasi 19", true, false, "urun 19", 10.0, "1.jpg", 19, 19, "2023/08/17 16:50:59", "urun-19" },
                    { 111111131.0, "2023/08/17 16:50:59", "urun aciklamasi 20", true, false, "urun 20", 10.0, "1.jpg", 20, 20, "2023/08/17 16:50:59", "urun-20" },
                    { 111111132.0, "2023/08/17 16:50:59", "urun aciklamasi 21", true, false, "urun 21", 10.0, "1.jpg", 21, 21, "2023/08/17 16:50:59", "urun-21" },
                    { 111111133.0, "2023/08/17 16:50:59", "urun aciklamasi 22", true, false, "urun 22", 10.0, "1.jpg", 22, 22, "2023/08/17 16:50:59", "urun-22" },
                    { 111111134.0, "2023/08/17 16:50:59", "urun aciklamasi 23", true, false, "urun 23", 10.0, "1.jpg", 23, 23, "2023/08/17 16:50:59", "urun-23" },
                    { 111111135.0, "2023/08/17 16:50:59", "urun aciklamasi 24", true, false, "urun 24", 10.0, "1.jpg", 24, 24, "2023/08/17 16:50:59", "urun-24" },
                    { 111111136.0, "2023/08/17 16:50:59", "urun aciklamasi 25", true, false, "urun 25", 10.0, "1.jpg", 25, 25, "2023/08/17 16:50:59", "urun-25" },
                    { 111111137.0, "2023/08/17 16:50:59", "urun aciklamasi 26", true, false, "urun 26", 10.0, "1.jpg", 26, 26, "2023/08/17 16:50:59", "urun-26" },
                    { 111111138.0, "2023/08/17 16:50:59", "urun aciklamasi 27", true, false, "urun 27", 10.0, "1.jpg", 27, 27, "2023/08/17 16:50:59", "urun-27" },
                    { 111111139.0, "2023/08/17 16:50:59", "urun aciklamasi 28", true, false, "urun 28", 10.0, "1.jpg", 28, 28, "2023/08/17 16:50:59", "urun-28" },
                    { 111111140.0, "2023/08/17 16:50:59", "urun aciklamasi 29", true, false, "urun 29", 10.0, "1.jpg", 29, 29, "2023/08/17 16:50:59", "urun-29" },
                    { 111111141.0, "2023/08/17 16:50:59", "urun aciklamasi 30", true, false, "urun 30", 10.0, "1.jpg", 30, 30, "2023/08/17 16:50:59", "urun-30" },
                    { 111111142.0, "2023/08/17 16:50:59", "urun aciklamasi 31", true, false, "urun 31", 10.0, "1.jpg", 31, 31, "2023/08/17 16:50:59", "urun-31" },
                    { 111111143.0, "2023/08/17 16:50:59", "urun aciklamasi 32", true, false, "urun 32", 10.0, "1.jpg", 32, 32, "2023/08/17 16:50:59", "urun-32" },
                    { 111111144.0, "2023/08/17 16:50:59", "urun aciklamasi 33", true, false, "urun 33", 10.0, "1.jpg", 33, 33, "2023/08/17 16:50:59", "urun-33" },
                    { 111111145.0, "2023/08/17 16:50:59", "urun aciklamasi 34", true, false, "urun 34", 10.0, "1.jpg", 34, 34, "2023/08/17 16:50:59", "urun-34" },
                    { 111111146.0, "2023/08/17 16:50:59", "urun aciklamasi 35", true, false, "urun 35", 10.0, "1.jpg", 35, 35, "2023/08/17 16:50:59", "urun-35" },
                    { 111111147.0, "2023/08/17 16:50:59", "urun aciklamasi 36", true, false, "urun 36", 10.0, "1.jpg", 36, 36, "2023/08/17 16:50:59", "urun-36" },
                    { 111111148.0, "2023/08/17 16:50:59", "urun aciklamasi 37", true, false, "urun 37", 10.0, "1.jpg", 37, 37, "2023/08/17 16:50:59", "urun-37" },
                    { 111111149.0, "2023/08/17 16:50:59", "urun aciklamasi 38", true, false, "urun 38", 10.0, "1.jpg", 38, 38, "2023/08/17 16:50:59", "urun-38" },
                    { 111111150.0, "2023/08/17 16:50:59", "urun aciklamasi 39", true, false, "urun 39", 10.0, "1.jpg", 39, 39, "2023/08/17 16:50:59", "urun-39" },
                    { 111111151.0, "2023/08/17 16:50:59", "urun aciklamasi 40", true, false, "urun 40", 10.0, "1.jpg", 40, 40, "2023/08/17 16:50:59", "urun-40" },
                    { 111111152.0, "2023/08/17 16:50:59", "urun aciklamasi 41", true, false, "urun 41", 10.0, "1.jpg", 41, 41, "2023/08/17 16:50:59", "urun-41" },
                    { 111111153.0, "2023/08/17 16:50:59", "urun aciklamasi 42", true, false, "urun 42", 10.0, "1.jpg", 42, 42, "2023/08/17 16:50:59", "urun-42" },
                    { 111111154.0, "2023/08/17 16:50:59", "urun aciklamasi 43", true, false, "urun 43", 10.0, "1.jpg", 43, 43, "2023/08/17 16:50:59", "urun-43" },
                    { 111111155.0, "2023/08/17 16:50:59", "urun aciklamasi 44", true, false, "urun 44", 10.0, "1.jpg", 44, 44, "2023/08/17 16:50:59", "urun-44" },
                    { 111111156.0, "2023/08/17 16:50:59", "urun aciklamasi 45", true, false, "urun 45", 10.0, "1.jpg", 45, 45, "2023/08/17 16:50:59", "urun-45" },
                    { 111111157.0, "2023/08/17 16:50:59", "urun aciklamasi 46", true, false, "urun 46", 10.0, "1.jpg", 46, 46, "2023/08/17 16:50:59", "urun-46" },
                    { 111111158.0, "2023/08/17 16:50:59", "urun aciklamasi 47", true, false, "urun 47", 10.0, "1.jpg", 47, 47, "2023/08/17 16:50:59", "urun-47" },
                    { 111111159.0, "2023/08/17 16:50:59", "urun aciklamasi 48", true, false, "urun 48", 10.0, "1.jpg", 48, 48, "2023/08/17 16:50:59", "urun-48" },
                    { 111111160.0, "2023/08/17 16:50:59", "urun aciklamasi 49", true, false, "urun 49", 10.0, "1.jpg", 49, 49, "2023/08/17 16:50:59", "urun-49" }
                });

            migrationBuilder.InsertData(
                table: "ImageUrls",
                columns: new[] { "Id", "ProductId", "Url" },
                values: new object[,]
                {
                    { 111111112.0, 111111112.0, "1.jpg" },
                    { 111111113.0, 111111113.0, "1.jpg" },
                    { 111111114.0, 111111114.0, "1.jpg" },
                    { 111111115.0, 111111115.0, "1.jpg" },
                    { 111111116.0, 111111116.0, "1.jpg" },
                    { 111111117.0, 111111117.0, "1.jpg" },
                    { 111111118.0, 111111118.0, "1.jpg" },
                    { 111111119.0, 111111119.0, "1.jpg" },
                    { 111111120.0, 111111120.0, "1.jpg" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "ProductId", "Id" },
                values: new object[,]
                {
                    { 111111112.0, 111111112.0, 116557806.0 },
                    { 111111113.0, 111111113.0, 752698525.0 },
                    { 111111114.0, 111111114.0, 685307395.0 },
                    { 111111115.0, 111111115.0, 563304109.0 },
                    { 111111116.0, 111111116.0, 722072845.0 },
                    { 111111117.0, 111111117.0, 880317711.0 },
                    { 111111118.0, 111111118.0, 365620929.0 },
                    { 111111119.0, 111111119.0, 390540500.0 },
                    { 111111120.0, 111111120.0, 946048035.0 }
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
                name: "IX_ImageUrls_ProductId",
                table: "ImageUrls",
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
                name: "ImageUrls");

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
