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
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    CampaignId = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHome = table.Column<bool>(type: "bit", nullable: false),
                    CampaignImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.CampaignId);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Stores",
                columns: table => new
                {
                    StoreId = table.Column<double>(type: "float", nullable: false),
                    StoreName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoreUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoreImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellerFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellerLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellerPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.StoreId);
                });

            migrationBuilder.CreateTable(
                name: "Categories2",
                columns: table => new
                {
                    Category2Id = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories2", x => x.Category2Id);
                    table.ForeignKey(
                        name: "FK_Categories2_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "getdate()"),
                    UpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SalesCount = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsHome = table.Column<bool>(type: "bit", nullable: false),
                    ProductRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CommentCount = table.Column<int>(type: "int", nullable: false),
                    StarCount = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<double>(type: "float", nullable: true),
                    CategoryId = table.Column<double>(type: "float", nullable: true),
                    Category2Id = table.Column<double>(type: "float", nullable: true),
                    StoreId = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories2_Category2Id",
                        column: x => x.Category2Id,
                        principalTable: "Categories2",
                        principalColumn: "Category2Id");
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartItemId = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<double>(type: "float", nullable: false),
                    CartId = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<double>(type: "float", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserFirstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserLastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentRate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageUrls",
                columns: table => new
                {
                    ImageUrlId = table.Column<double>(type: "float", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<double>(type: "float", nullable: true),
                    StoreId = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageUrls", x => x.ImageUrlId);
                    table.ForeignKey(
                        name: "FK_ImageUrls_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageUrls_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId");
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<double>(type: "float", nullable: false),
                    OrderId = table.Column<double>(type: "float", nullable: true),
                    ProductId = table.Column<double>(type: "float", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                        principalColumn: "ProductId");
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandId", "CreatedDate", "Name", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 111111111.0, null, "Brand 0", null, "brand-0" },
                    { 111111112.0, null, "Brand 1", null, "brand-1" },
                    { 111111113.0, null, "Brand 2", null, "brand-2" },
                    { 111111114.0, null, "Brand 3", null, "brand-3" },
                    { 111111115.0, null, "Brand 4", null, "brand-4" },
                    { 111111116.0, null, "Brand 5", null, "brand-5" },
                    { 111111117.0, null, "Brand 6", null, "brand-6" },
                    { 111111118.0, null, "Brand 7", null, "brand-7" },
                    { 111111119.0, null, "Brand 8", null, "brand-8" },
                    { 111111120.0, null, "Brand 9", null, "brand-9" },
                    { 111111121.0, null, "Brand 10", null, "brand-10" },
                    { 111111122.0, null, "Brand 11", null, "brand-11" },
                    { 111111123.0, null, "Brand 12", null, "brand-12" },
                    { 111111124.0, null, "Brand 13", null, "brand-13" },
                    { 111111125.0, null, "Brand 14", null, "brand-14" },
                    { 111111126.0, null, "Brand 15", null, "brand-15" },
                    { 111111127.0, null, "Brand 16", null, "brand-16" },
                    { 111111128.0, null, "Brand 17", null, "brand-17" },
                    { 111111129.0, null, "Brand 18", null, "brand-18" },
                    { 111111130.0, null, "Brand 19", null, "brand-19" },
                    { 111111131.0, null, "Brand 20", null, "brand-20" },
                    { 111111132.0, null, "Brand 21", null, "brand-21" },
                    { 111111133.0, null, "Brand 22", null, "brand-22" },
                    { 111111134.0, null, "Brand 23", null, "brand-23" },
                    { 111111135.0, null, "Brand 24", null, "brand-24" },
                    { 111111136.0, null, "Brand 25", null, "brand-25" },
                    { 111111137.0, null, "Brand 26", null, "brand-26" },
                    { 111111138.0, null, "Brand 27", null, "brand-27" },
                    { 111111139.0, null, "Brand 28", null, "brand-28" },
                    { 111111140.0, null, "Brand 29", null, "brand-29" },
                    { 111111141.0, null, "Brand 30", null, "brand-30" },
                    { 111111142.0, null, "Brand 31", null, "brand-31" },
                    { 111111143.0, null, "Brand 32", null, "brand-32" },
                    { 111111144.0, null, "Brand 33", null, "brand-33" },
                    { 111111145.0, null, "Brand 34", null, "brand-34" },
                    { 111111146.0, null, "Brand 35", null, "brand-35" },
                    { 111111147.0, null, "Brand 36", null, "brand-36" },
                    { 111111148.0, null, "Brand 37", null, "brand-37" },
                    { 111111149.0, null, "Brand 38", null, "brand-38" },
                    { 111111150.0, null, "Brand 39", null, "brand-39" },
                    { 111111151.0, null, "Brand 40", null, "brand-40" },
                    { 111111152.0, null, "Brand 41", null, "brand-41" },
                    { 111111153.0, null, "Brand 42", null, "brand-42" },
                    { 111111154.0, null, "Brand 43", null, "brand-43" },
                    { 111111155.0, null, "Brand 44", null, "brand-44" },
                    { 111111156.0, null, "Brand 45", null, "brand-45" },
                    { 111111157.0, null, "Brand 46", null, "brand-46" },
                    { 111111158.0, null, "Brand 47", null, "brand-47" },
                    { 111111159.0, null, "Brand 48", null, "brand-48" },
                    { 111111160.0, null, "Brand 49", null, "brand-49" }
                });

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "CampaignId", "CampaignImage", "Code", "CreatedDate", "Description", "IsHome", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 111111111.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111111", true, "Campaign 111111111", null },
                    { 111111112.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111112", true, "Campaign 111111112", null },
                    { 111111113.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111113", true, "Campaign 111111113", null },
                    { 111111114.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111114", true, "Campaign 111111114", null },
                    { 111111115.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111115", true, "Campaign 111111115", null },
                    { 111111116.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111116", true, "Campaign 111111116", null },
                    { 111111117.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111117", true, "Campaign 111111117", null },
                    { 111111118.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111118", true, "Campaign 111111118", null },
                    { 111111119.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111119", true, "Campaign 111111119", null },
                    { 111111120.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111120", true, "Campaign 111111120", null },
                    { 111111121.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111121", true, "Campaign 111111121", null },
                    { 111111122.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111122", true, "Campaign 111111122", null },
                    { 111111123.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111123", true, "Campaign 111111123", null },
                    { 111111124.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111124", true, "Campaign 111111124", null },
                    { 111111125.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111125", true, "Campaign 111111125", null },
                    { 111111126.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111126", true, "Campaign 111111126", null },
                    { 111111127.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111127", true, "Campaign 111111127", null },
                    { 111111128.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111128", true, "Campaign 111111128", null },
                    { 111111129.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111129", true, "Campaign 111111129", null },
                    { 111111130.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111130", true, "Campaign 111111130", null },
                    { 111111131.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111131", true, "Campaign 111111131", null },
                    { 111111132.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111132", true, "Campaign 111111132", null },
                    { 111111133.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111133", true, "Campaign 111111133", null },
                    { 111111134.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111134", true, "Campaign 111111134", null },
                    { 111111135.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111135", true, "Campaign 111111135", null },
                    { 111111136.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111136", true, "Campaign 111111136", null },
                    { 111111137.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111137", true, "Campaign 111111137", null },
                    { 111111138.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111138", true, "Campaign 111111138", null },
                    { 111111139.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111139", true, "Campaign 111111139", null },
                    { 111111140.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111140", true, "Campaign 111111140", null },
                    { 111111141.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111141", true, "Campaign 111111141", null },
                    { 111111142.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111142", true, "Campaign 111111142", null },
                    { 111111143.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111143", true, "Campaign 111111143", null },
                    { 111111144.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111144", true, "Campaign 111111144", null },
                    { 111111145.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111145", true, "Campaign 111111145", null },
                    { 111111146.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111146", true, "Campaign 111111146", null },
                    { 111111147.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111147", true, "Campaign 111111147", null },
                    { 111111148.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111148", true, "Campaign 111111148", null },
                    { 111111149.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111149", true, "Campaign 111111149", null },
                    { 111111150.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111150", true, "Campaign 111111150", null },
                    { 111111151.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111151", true, "Campaign 111111151", null },
                    { 111111152.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111152", true, "Campaign 111111152", null },
                    { 111111153.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111153", true, "Campaign 111111153", null },
                    { 111111154.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111154", true, "Campaign 111111154", null },
                    { 111111155.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111155", true, "Campaign 111111155", null },
                    { 111111156.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111156", true, "Campaign 111111156", null },
                    { 111111157.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111157", true, "Campaign 111111157", null },
                    { 111111158.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111158", true, "Campaign 111111158", null },
                    { 111111159.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111159", true, "Campaign 111111159", null },
                    { 111111160.0, "1.jpg", "23sdasdasd", "2023/09/12 18:35:09", "Description: 111111160", true, "Campaign 111111160", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CreatedDate", "Name", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 111111111.0, null, "Woman", null, "woman" },
                    { 111111112.0, null, "Man", null, "man" },
                    { 111111113.0, null, "Mom & Child", null, "mom-child" },
                    { 111111114.0, null, "Home & Furniture", null, "home-furniture" },
                    { 111111115.0, null, "Supermarket", null, "supermarket" },
                    { 111111116.0, null, "Cosmetics", null, "cosmetics" },
                    { 111111117.0, null, "Shoe & Bag", null, "shoe-bag" },
                    { 111111118.0, null, "Electronics", null, "electronics" },
                    { 111111119.0, null, "Sport & Outdoor", null, "sport-outdoor" },
                    { 111111120.0, null, "Book & Instrument", null, "book-instrument" },
                    { 111111121.0, "2023/09/12 18:35:09", "category 0", null, "category-0" },
                    { 111111122.0, "2023/09/12 18:35:09", "category 1", null, "category-1" },
                    { 111111123.0, "2023/09/12 18:35:09", "category 2", null, "category-2" },
                    { 111111124.0, "2023/09/12 18:35:09", "category 3", null, "category-3" },
                    { 111111125.0, "2023/09/12 18:35:09", "category 4", null, "category-4" },
                    { 111111126.0, "2023/09/12 18:35:09", "category 5", null, "category-5" },
                    { 111111127.0, "2023/09/12 18:35:09", "category 6", null, "category-6" },
                    { 111111128.0, "2023/09/12 18:35:09", "category 7", null, "category-7" },
                    { 111111129.0, "2023/09/12 18:35:09", "category 8", null, "category-8" },
                    { 111111130.0, "2023/09/12 18:35:09", "category 9", null, "category-9" },
                    { 111111131.0, "2023/09/12 18:35:09", "category 10", null, "category-10" },
                    { 111111132.0, "2023/09/12 18:35:09", "category 11", null, "category-11" },
                    { 111111133.0, "2023/09/12 18:35:09", "category 12", null, "category-12" },
                    { 111111134.0, "2023/09/12 18:35:09", "category 13", null, "category-13" },
                    { 111111135.0, "2023/09/12 18:35:09", "category 14", null, "category-14" },
                    { 111111136.0, "2023/09/12 18:35:09", "category 15", null, "category-15" },
                    { 111111137.0, "2023/09/12 18:35:09", "category 16", null, "category-16" },
                    { 111111138.0, "2023/09/12 18:35:09", "category 17", null, "category-17" },
                    { 111111139.0, "2023/09/12 18:35:09", "category 18", null, "category-18" },
                    { 111111140.0, "2023/09/12 18:35:09", "category 19", null, "category-19" },
                    { 111111141.0, "2023/09/12 18:35:09", "category 20", null, "category-20" },
                    { 111111142.0, "2023/09/12 18:35:09", "category 21", null, "category-21" },
                    { 111111143.0, "2023/09/12 18:35:09", "category 22", null, "category-22" },
                    { 111111144.0, "2023/09/12 18:35:09", "category 23", null, "category-23" },
                    { 111111145.0, "2023/09/12 18:35:09", "category 24", null, "category-24" },
                    { 111111146.0, "2023/09/12 18:35:09", "category 25", null, "category-25" },
                    { 111111147.0, "2023/09/12 18:35:09", "category 26", null, "category-26" },
                    { 111111148.0, "2023/09/12 18:35:09", "category 27", null, "category-27" },
                    { 111111149.0, "2023/09/12 18:35:09", "category 28", null, "category-28" },
                    { 111111150.0, "2023/09/12 18:35:09", "category 29", null, "category-29" },
                    { 111111151.0, "2023/09/12 18:35:09", "category 30", null, "category-30" },
                    { 111111152.0, "2023/09/12 18:35:09", "category 31", null, "category-31" },
                    { 111111153.0, "2023/09/12 18:35:09", "category 32", null, "category-32" },
                    { 111111154.0, "2023/09/12 18:35:09", "category 33", null, "category-33" },
                    { 111111155.0, "2023/09/12 18:35:09", "category 34", null, "category-34" },
                    { 111111156.0, "2023/09/12 18:35:09", "category 35", null, "category-35" },
                    { 111111157.0, "2023/09/12 18:35:09", "category 36", null, "category-36" },
                    { 111111158.0, "2023/09/12 18:35:09", "category 37", null, "category-37" },
                    { 111111159.0, "2023/09/12 18:35:09", "category 38", null, "category-38" },
                    { 111111160.0, "2023/09/12 18:35:09", "category 39", null, "category-39" }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreId", "CreatedDate", "IsApproved", "SellerEmail", "SellerFirstName", "SellerId", "SellerLastName", "SellerPhone", "StoreImage", "StoreName", "StoreUrl", "UpdatedDate" },
                values: new object[,]
                {
                    { 111111111.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 0", "store-0", null },
                    { 111111112.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 1", "store-1", null },
                    { 111111113.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 2", "store-2", null },
                    { 111111114.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 3", "store-3", null },
                    { 111111115.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 4", "store-4", null },
                    { 111111116.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 5", "store-5", null },
                    { 111111117.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 6", "store-6", null },
                    { 111111118.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 7", "store-7", null },
                    { 111111119.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 8", "store-8", null },
                    { 111111120.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 9", "store-9", null },
                    { 111111121.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 10", "store-10", null },
                    { 111111122.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 11", "store-11", null },
                    { 111111123.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 12", "store-12", null },
                    { 111111124.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 13", "store-13", null },
                    { 111111125.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 14", "store-14", null },
                    { 111111126.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 15", "store-15", null },
                    { 111111127.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 16", "store-16", null },
                    { 111111128.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 17", "store-17", null },
                    { 111111129.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 18", "store-18", null },
                    { 111111130.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 19", "store-19", null },
                    { 111111131.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 20", "store-20", null },
                    { 111111132.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 21", "store-21", null },
                    { 111111133.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 22", "store-22", null },
                    { 111111134.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 23", "store-23", null },
                    { 111111135.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 24", "store-24", null },
                    { 111111136.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 25", "store-25", null },
                    { 111111137.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 26", "store-26", null },
                    { 111111138.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 27", "store-27", null },
                    { 111111139.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 28", "store-28", null },
                    { 111111140.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 29", "store-29", null },
                    { 111111141.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 30", "store-30", null },
                    { 111111142.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 31", "store-31", null },
                    { 111111143.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 32", "store-32", null },
                    { 111111144.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 33", "store-33", null },
                    { 111111145.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 34", "store-34", null },
                    { 111111146.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 35", "store-35", null },
                    { 111111147.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 36", "store-36", null },
                    { 111111148.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 37", "store-37", null },
                    { 111111149.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 38", "store-38", null },
                    { 111111150.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 39", "store-39", null },
                    { 111111151.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 40", "store-40", null },
                    { 111111152.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 41", "store-41", null },
                    { 111111153.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 42", "store-42", null },
                    { 111111154.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 43", "store-43", null },
                    { 111111155.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 44", "store-44", null },
                    { 111111156.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 45", "store-45", null },
                    { 111111157.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 46", "store-46", null },
                    { 111111158.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 47", "store-47", null },
                    { 111111159.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 48", "store-48", null },
                    { 111111160.0, "2023/09/12 18:35:09", false, null, null, null, null, null, "1.jpg", "store 49", "store-49", null }
                });

            migrationBuilder.InsertData(
                table: "Categories2",
                columns: new[] { "Category2Id", "CategoryId", "CreatedDate", "Name", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 111111111.0, 111111111.0, "2023/09/12 18:35:09", "category2 0", null, "category2-0" },
                    { 111111112.0, 111111112.0, "2023/09/12 18:35:09", "category2 1", null, "category2-1" },
                    { 111111113.0, 111111113.0, "2023/09/12 18:35:09", "category2 2", null, "category2-2" },
                    { 111111114.0, 111111114.0, "2023/09/12 18:35:09", "category2 3", null, "category2-3" },
                    { 111111115.0, 111111115.0, "2023/09/12 18:35:09", "category2 4", null, "category2-4" },
                    { 111111116.0, 111111116.0, "2023/09/12 18:35:09", "category2 5", null, "category2-5" },
                    { 111111117.0, 111111117.0, "2023/09/12 18:35:09", "category2 6", null, "category2-6" },
                    { 111111118.0, 111111118.0, "2023/09/12 18:35:09", "category2 7", null, "category2-7" },
                    { 111111119.0, 111111119.0, "2023/09/12 18:35:09", "category2 8", null, "category2-8" },
                    { 111111120.0, 111111120.0, "2023/09/12 18:35:09", "category2 9", null, "category2-9" },
                    { 111111121.0, 111111121.0, "2023/09/12 18:35:09", "category2 10", null, "category2-10" },
                    { 111111122.0, 111111122.0, "2023/09/12 18:35:09", "category2 11", null, "category2-11" },
                    { 111111123.0, 111111123.0, "2023/09/12 18:35:09", "category2 12", null, "category2-12" },
                    { 111111124.0, 111111124.0, "2023/09/12 18:35:09", "category2 13", null, "category2-13" },
                    { 111111125.0, 111111125.0, "2023/09/12 18:35:09", "category2 14", null, "category2-14" },
                    { 111111126.0, 111111126.0, "2023/09/12 18:35:09", "category2 15", null, "category2-15" },
                    { 111111127.0, 111111127.0, "2023/09/12 18:35:09", "category2 16", null, "category2-16" },
                    { 111111128.0, 111111128.0, "2023/09/12 18:35:09", "category2 17", null, "category2-17" },
                    { 111111129.0, 111111129.0, "2023/09/12 18:35:09", "category2 18", null, "category2-18" },
                    { 111111130.0, 111111130.0, "2023/09/12 18:35:09", "category2 19", null, "category2-19" },
                    { 111111131.0, 111111131.0, "2023/09/12 18:35:09", "category2 20", null, "category2-20" },
                    { 111111132.0, 111111132.0, "2023/09/12 18:35:09", "category2 21", null, "category2-21" },
                    { 111111133.0, 111111133.0, "2023/09/12 18:35:09", "category2 22", null, "category2-22" },
                    { 111111134.0, 111111134.0, "2023/09/12 18:35:09", "category2 23", null, "category2-23" },
                    { 111111135.0, 111111135.0, "2023/09/12 18:35:09", "category2 24", null, "category2-24" },
                    { 111111136.0, 111111136.0, "2023/09/12 18:35:09", "category2 25", null, "category2-25" },
                    { 111111137.0, 111111137.0, "2023/09/12 18:35:09", "category2 26", null, "category2-26" },
                    { 111111138.0, 111111138.0, "2023/09/12 18:35:09", "category2 27", null, "category2-27" },
                    { 111111139.0, 111111139.0, "2023/09/12 18:35:09", "category2 28", null, "category2-28" },
                    { 111111140.0, 111111140.0, "2023/09/12 18:35:09", "category2 29", null, "category2-29" },
                    { 111111141.0, 111111141.0, "2023/09/12 18:35:09", "category2 30", null, "category2-30" },
                    { 111111142.0, 111111142.0, "2023/09/12 18:35:09", "category2 31", null, "category2-31" },
                    { 111111143.0, 111111143.0, "2023/09/12 18:35:09", "category2 32", null, "category2-32" },
                    { 111111144.0, 111111144.0, "2023/09/12 18:35:09", "category2 33", null, "category2-33" },
                    { 111111145.0, 111111145.0, "2023/09/12 18:35:09", "category2 34", null, "category2-34" },
                    { 111111146.0, 111111146.0, "2023/09/12 18:35:09", "category2 35", null, "category2-35" },
                    { 111111147.0, 111111147.0, "2023/09/12 18:35:09", "category2 36", null, "category2-36" },
                    { 111111148.0, 111111148.0, "2023/09/12 18:35:09", "category2 37", null, "category2-37" },
                    { 111111149.0, 111111149.0, "2023/09/12 18:35:09", "category2 38", null, "category2-38" },
                    { 111111150.0, 111111150.0, "2023/09/12 18:35:09", "category2 39", null, "category2-39" },
                    { 111111151.0, 111111151.0, "2023/09/12 18:35:09", "category2 40", null, "category2-40" },
                    { 111111152.0, 111111152.0, "2023/09/12 18:35:09", "category2 41", null, "category2-41" },
                    { 111111153.0, 111111153.0, "2023/09/12 18:35:09", "category2 42", null, "category2-42" },
                    { 111111154.0, 111111154.0, "2023/09/12 18:35:09", "category2 43", null, "category2-43" },
                    { 111111155.0, 111111155.0, "2023/09/12 18:35:09", "category2 44", null, "category2-44" },
                    { 111111156.0, 111111156.0, "2023/09/12 18:35:09", "category2 45", null, "category2-45" },
                    { 111111157.0, 111111157.0, "2023/09/12 18:35:09", "category2 46", null, "category2-46" },
                    { 111111158.0, 111111158.0, "2023/09/12 18:35:09", "category2 47", null, "category2-47" },
                    { 111111159.0, 111111159.0, "2023/09/12 18:35:09", "category2 48", null, "category2-48" },
                    { 111111160.0, 111111160.0, "2023/09/12 18:35:09", "category2 49", null, "category2-49" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "BrandId", "Category2Id", "CategoryId", "CommentCount", "CreatedDate", "Description", "IsApproved", "IsHome", "Name", "Price", "ProductImage", "ProductRate", "Quantity", "SalesCount", "StarCount", "StoreId", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 111111111.0, 111111111.0, 111111111.0, 111111111.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 0", true, true, "urun 0", 10m, "1.jpg", 0m, 0, 0, 0, 111111111.0, "2023/09/12 18:35:09", "urun-0" },
                    { 111111112.0, 111111112.0, 111111112.0, 111111112.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 1", true, true, "urun 1", 10m, "1.jpg", 0m, 1, 1, 0, 111111112.0, "2023/09/12 18:35:09", "urun-1" },
                    { 111111113.0, 111111113.0, 111111113.0, 111111113.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 2", true, true, "urun 2", 10m, "1.jpg", 0m, 2, 2, 0, 111111113.0, "2023/09/12 18:35:09", "urun-2" },
                    { 111111114.0, 111111114.0, 111111114.0, 111111114.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 3", true, true, "urun 3", 10m, "1.jpg", 0m, 3, 3, 0, 111111114.0, "2023/09/12 18:35:09", "urun-3" },
                    { 111111115.0, 111111115.0, 111111115.0, 111111115.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 4", true, true, "urun 4", 10m, "1.jpg", 0m, 4, 4, 0, 111111115.0, "2023/09/12 18:35:09", "urun-4" },
                    { 111111116.0, 111111116.0, 111111116.0, 111111116.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 5", true, true, "urun 5", 10m, "1.jpg", 0m, 5, 5, 0, 111111116.0, "2023/09/12 18:35:09", "urun-5" },
                    { 111111117.0, 111111117.0, 111111117.0, 111111117.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 6", true, true, "urun 6", 10m, "1.jpg", 0m, 6, 6, 0, 111111117.0, "2023/09/12 18:35:09", "urun-6" },
                    { 111111118.0, 111111118.0, 111111118.0, 111111118.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 7", true, true, "urun 7", 10m, "1.jpg", 0m, 7, 7, 0, 111111118.0, "2023/09/12 18:35:09", "urun-7" },
                    { 111111119.0, 111111119.0, 111111119.0, 111111119.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 8", true, true, "urun 8", 10m, "1.jpg", 0m, 8, 8, 0, 111111119.0, "2023/09/12 18:35:09", "urun-8" },
                    { 111111120.0, 111111120.0, 111111120.0, 111111120.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 9", true, true, "urun 9", 10m, "1.jpg", 0m, 9, 9, 0, 111111120.0, "2023/09/12 18:35:09", "urun-9" },
                    { 111111121.0, 111111121.0, 111111121.0, 111111121.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 10", true, true, "urun 10", 10m, "1.jpg", 0m, 10, 10, 0, 111111121.0, "2023/09/12 18:35:09", "urun-10" },
                    { 111111122.0, 111111122.0, 111111122.0, 111111122.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 11", true, true, "urun 11", 10m, "1.jpg", 0m, 11, 11, 0, 111111122.0, "2023/09/12 18:35:09", "urun-11" },
                    { 111111123.0, 111111123.0, 111111123.0, 111111123.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 12", true, true, "urun 12", 10m, "1.jpg", 0m, 12, 12, 0, 111111123.0, "2023/09/12 18:35:09", "urun-12" },
                    { 111111124.0, 111111124.0, 111111124.0, 111111124.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 13", true, true, "urun 13", 10m, "1.jpg", 0m, 13, 13, 0, 111111124.0, "2023/09/12 18:35:09", "urun-13" },
                    { 111111125.0, 111111125.0, 111111125.0, 111111125.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 14", true, true, "urun 14", 10m, "1.jpg", 0m, 14, 14, 0, 111111125.0, "2023/09/12 18:35:09", "urun-14" },
                    { 111111126.0, 111111126.0, 111111126.0, 111111126.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 15", true, true, "urun 15", 10m, "1.jpg", 0m, 15, 15, 0, 111111126.0, "2023/09/12 18:35:09", "urun-15" },
                    { 111111127.0, 111111127.0, 111111127.0, 111111127.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 16", true, true, "urun 16", 10m, "1.jpg", 0m, 16, 16, 0, 111111127.0, "2023/09/12 18:35:09", "urun-16" },
                    { 111111128.0, 111111128.0, 111111128.0, 111111128.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 17", true, true, "urun 17", 10m, "1.jpg", 0m, 17, 17, 0, 111111128.0, "2023/09/12 18:35:09", "urun-17" },
                    { 111111129.0, 111111129.0, 111111129.0, 111111129.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 18", true, true, "urun 18", 10m, "1.jpg", 0m, 18, 18, 0, 111111129.0, "2023/09/12 18:35:09", "urun-18" },
                    { 111111130.0, 111111130.0, 111111130.0, 111111130.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 19", true, true, "urun 19", 10m, "1.jpg", 0m, 19, 19, 0, 111111130.0, "2023/09/12 18:35:09", "urun-19" },
                    { 111111131.0, 111111131.0, 111111131.0, 111111131.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 20", true, true, "urun 20", 10m, "1.jpg", 0m, 20, 20, 0, 111111131.0, "2023/09/12 18:35:09", "urun-20" },
                    { 111111132.0, 111111132.0, 111111132.0, 111111132.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 21", true, true, "urun 21", 10m, "1.jpg", 0m, 21, 21, 0, 111111132.0, "2023/09/12 18:35:09", "urun-21" },
                    { 111111133.0, 111111133.0, 111111133.0, 111111133.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 22", true, true, "urun 22", 10m, "1.jpg", 0m, 22, 22, 0, 111111133.0, "2023/09/12 18:35:09", "urun-22" },
                    { 111111134.0, 111111134.0, 111111134.0, 111111134.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 23", true, true, "urun 23", 10m, "1.jpg", 0m, 23, 23, 0, 111111134.0, "2023/09/12 18:35:09", "urun-23" },
                    { 111111135.0, 111111135.0, 111111135.0, 111111135.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 24", true, true, "urun 24", 10m, "1.jpg", 0m, 24, 24, 0, 111111135.0, "2023/09/12 18:35:09", "urun-24" },
                    { 111111136.0, 111111136.0, 111111136.0, 111111136.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 25", true, true, "urun 25", 10m, "1.jpg", 0m, 25, 25, 0, 111111136.0, "2023/09/12 18:35:09", "urun-25" },
                    { 111111137.0, 111111137.0, 111111137.0, 111111137.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 26", true, true, "urun 26", 10m, "1.jpg", 0m, 26, 26, 0, 111111137.0, "2023/09/12 18:35:09", "urun-26" },
                    { 111111138.0, 111111138.0, 111111138.0, 111111138.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 27", true, true, "urun 27", 10m, "1.jpg", 0m, 27, 27, 0, 111111138.0, "2023/09/12 18:35:09", "urun-27" },
                    { 111111139.0, 111111139.0, 111111139.0, 111111139.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 28", true, true, "urun 28", 10m, "1.jpg", 0m, 28, 28, 0, 111111139.0, "2023/09/12 18:35:09", "urun-28" },
                    { 111111140.0, 111111140.0, 111111140.0, 111111140.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 29", true, true, "urun 29", 10m, "1.jpg", 0m, 29, 29, 0, 111111140.0, "2023/09/12 18:35:09", "urun-29" },
                    { 111111141.0, 111111141.0, 111111141.0, 111111141.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 30", true, true, "urun 30", 10m, "1.jpg", 0m, 30, 30, 0, 111111141.0, "2023/09/12 18:35:09", "urun-30" },
                    { 111111142.0, 111111142.0, 111111142.0, 111111142.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 31", true, true, "urun 31", 10m, "1.jpg", 0m, 31, 31, 0, 111111142.0, "2023/09/12 18:35:09", "urun-31" },
                    { 111111143.0, 111111143.0, 111111143.0, 111111143.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 32", true, true, "urun 32", 10m, "1.jpg", 0m, 32, 32, 0, 111111143.0, "2023/09/12 18:35:09", "urun-32" },
                    { 111111144.0, 111111144.0, 111111144.0, 111111144.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 33", true, true, "urun 33", 10m, "1.jpg", 0m, 33, 33, 0, 111111144.0, "2023/09/12 18:35:09", "urun-33" },
                    { 111111145.0, 111111145.0, 111111145.0, 111111145.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 34", true, true, "urun 34", 10m, "1.jpg", 0m, 34, 34, 0, 111111145.0, "2023/09/12 18:35:09", "urun-34" },
                    { 111111146.0, 111111146.0, 111111146.0, 111111146.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 35", true, true, "urun 35", 10m, "1.jpg", 0m, 35, 35, 0, 111111146.0, "2023/09/12 18:35:09", "urun-35" },
                    { 111111147.0, 111111147.0, 111111147.0, 111111147.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 36", true, true, "urun 36", 10m, "1.jpg", 0m, 36, 36, 0, 111111147.0, "2023/09/12 18:35:09", "urun-36" },
                    { 111111148.0, 111111148.0, 111111148.0, 111111148.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 37", true, true, "urun 37", 10m, "1.jpg", 0m, 37, 37, 0, 111111148.0, "2023/09/12 18:35:09", "urun-37" },
                    { 111111149.0, 111111149.0, 111111149.0, 111111149.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 38", true, true, "urun 38", 10m, "1.jpg", 0m, 38, 38, 0, 111111149.0, "2023/09/12 18:35:09", "urun-38" },
                    { 111111150.0, 111111150.0, 111111150.0, 111111150.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 39", true, true, "urun 39", 10m, "1.jpg", 0m, 39, 39, 0, 111111150.0, "2023/09/12 18:35:09", "urun-39" },
                    { 111111151.0, 111111151.0, 111111151.0, 111111151.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 40", true, true, "urun 40", 10m, "1.jpg", 0m, 40, 40, 0, 111111151.0, "2023/09/12 18:35:09", "urun-40" },
                    { 111111152.0, 111111152.0, 111111152.0, 111111152.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 41", true, true, "urun 41", 10m, "1.jpg", 0m, 41, 41, 0, 111111152.0, "2023/09/12 18:35:09", "urun-41" },
                    { 111111153.0, 111111153.0, 111111153.0, 111111153.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 42", true, true, "urun 42", 10m, "1.jpg", 0m, 42, 42, 0, 111111153.0, "2023/09/12 18:35:09", "urun-42" },
                    { 111111154.0, 111111154.0, 111111154.0, 111111154.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 43", true, true, "urun 43", 10m, "1.jpg", 0m, 43, 43, 0, 111111154.0, "2023/09/12 18:35:09", "urun-43" },
                    { 111111155.0, 111111155.0, 111111155.0, 111111155.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 44", true, true, "urun 44", 10m, "1.jpg", 0m, 44, 44, 0, 111111155.0, "2023/09/12 18:35:09", "urun-44" },
                    { 111111156.0, 111111156.0, 111111156.0, 111111156.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 45", true, true, "urun 45", 10m, "1.jpg", 0m, 45, 45, 0, 111111156.0, "2023/09/12 18:35:09", "urun-45" },
                    { 111111157.0, 111111157.0, 111111157.0, 111111157.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 46", true, true, "urun 46", 10m, "1.jpg", 0m, 46, 46, 0, 111111157.0, "2023/09/12 18:35:09", "urun-46" },
                    { 111111158.0, 111111158.0, 111111158.0, 111111158.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 47", true, true, "urun 47", 10m, "1.jpg", 0m, 47, 47, 0, 111111158.0, "2023/09/12 18:35:09", "urun-47" },
                    { 111111159.0, 111111159.0, 111111159.0, 111111159.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 48", true, true, "urun 48", 10m, "1.jpg", 0m, 48, 48, 0, 111111159.0, "2023/09/12 18:35:09", "urun-48" },
                    { 111111160.0, 111111160.0, 111111160.0, 111111160.0, 1, "2023/09/12 18:35:09", "urun aciklamasi 49", true, true, "urun 49", 10m, "1.jpg", 0m, 49, 49, 0, 111111160.0, "2023/09/12 18:35:09", "urun-49" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "CommentRate", "CreatedDate", "Description", "ProductId", "UpdatedDate", "UserFirstname", "UserId", "UserLastname" },
                values: new object[,]
                {
                    { 111111111.0, 1, "2023/09/12 18:35:09", "description - 0", 111111111.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111112.0, 1, "2023/09/12 18:35:09", "description - 1", 111111112.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111113.0, 1, "2023/09/12 18:35:09", "description - 2", 111111113.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111114.0, 1, "2023/09/12 18:35:09", "description - 3", 111111114.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111115.0, 1, "2023/09/12 18:35:09", "description - 4", 111111115.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111116.0, 1, "2023/09/12 18:35:09", "description - 5", 111111116.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111117.0, 1, "2023/09/12 18:35:09", "description - 6", 111111117.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111118.0, 1, "2023/09/12 18:35:09", "description - 7", 111111118.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111119.0, 1, "2023/09/12 18:35:09", "description - 8", 111111119.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111120.0, 1, "2023/09/12 18:35:09", "description - 9", 111111120.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111121.0, 1, "2023/09/12 18:35:09", "description - 10", 111111121.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111122.0, 1, "2023/09/12 18:35:09", "description - 11", 111111122.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111123.0, 1, "2023/09/12 18:35:09", "description - 12", 111111123.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111124.0, 1, "2023/09/12 18:35:09", "description - 13", 111111124.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111125.0, 1, "2023/09/12 18:35:09", "description - 14", 111111125.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111126.0, 1, "2023/09/12 18:35:09", "description - 15", 111111126.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111127.0, 1, "2023/09/12 18:35:09", "description - 16", 111111127.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111128.0, 1, "2023/09/12 18:35:09", "description - 17", 111111128.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111129.0, 1, "2023/09/12 18:35:09", "description - 18", 111111129.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111130.0, 1, "2023/09/12 18:35:09", "description - 19", 111111130.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111131.0, 1, "2023/09/12 18:35:09", "description - 20", 111111131.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111132.0, 1, "2023/09/12 18:35:09", "description - 21", 111111132.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111133.0, 1, "2023/09/12 18:35:09", "description - 22", 111111133.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111134.0, 1, "2023/09/12 18:35:09", "description - 23", 111111134.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111135.0, 1, "2023/09/12 18:35:09", "description - 24", 111111135.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111136.0, 1, "2023/09/12 18:35:09", "description - 25", 111111136.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111137.0, 1, "2023/09/12 18:35:09", "description - 26", 111111137.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111138.0, 1, "2023/09/12 18:35:09", "description - 27", 111111138.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111139.0, 1, "2023/09/12 18:35:09", "description - 28", 111111139.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111140.0, 1, "2023/09/12 18:35:09", "description - 29", 111111140.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111141.0, 1, "2023/09/12 18:35:09", "description - 30", 111111141.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111142.0, 1, "2023/09/12 18:35:09", "description - 31", 111111142.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111143.0, 1, "2023/09/12 18:35:09", "description - 32", 111111143.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111144.0, 1, "2023/09/12 18:35:09", "description - 33", 111111144.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111145.0, 1, "2023/09/12 18:35:09", "description - 34", 111111145.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111146.0, 1, "2023/09/12 18:35:09", "description - 35", 111111146.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111147.0, 1, "2023/09/12 18:35:09", "description - 36", 111111147.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111148.0, 1, "2023/09/12 18:35:09", "description - 37", 111111148.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111149.0, 1, "2023/09/12 18:35:09", "description - 38", 111111149.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111150.0, 1, "2023/09/12 18:35:09", "description - 39", 111111150.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111151.0, 1, "2023/09/12 18:35:09", "description - 40", 111111151.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111152.0, 1, "2023/09/12 18:35:09", "description - 41", 111111152.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111153.0, 1, "2023/09/12 18:35:09", "description - 42", 111111153.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111154.0, 1, "2023/09/12 18:35:09", "description - 43", 111111154.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111155.0, 1, "2023/09/12 18:35:09", "description - 44", 111111155.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111156.0, 1, "2023/09/12 18:35:09", "description - 45", 111111156.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111157.0, 1, "2023/09/12 18:35:09", "description - 46", 111111157.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111158.0, 1, "2023/09/12 18:35:09", "description - 47", 111111158.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111159.0, 1, "2023/09/12 18:35:09", "description - 48", 111111159.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111160.0, 1, "2023/09/12 18:35:09", "description - 49", 111111160.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" }
                });

            migrationBuilder.InsertData(
                table: "ImageUrls",
                columns: new[] { "ImageUrlId", "CreatedDate", "ProductId", "StoreId", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 111111111.0, null, 111111111.0, 111111111.0, null, "1.jpg" },
                    { 111111112.0, null, 111111112.0, 111111112.0, null, "1.jpg" },
                    { 111111113.0, null, 111111113.0, 111111113.0, null, "1.jpg" },
                    { 111111114.0, null, 111111114.0, 111111114.0, null, "1.jpg" },
                    { 111111115.0, null, 111111115.0, 111111115.0, null, "1.jpg" },
                    { 111111116.0, null, 111111116.0, 111111116.0, null, "1.jpg" },
                    { 111111117.0, null, 111111117.0, 111111117.0, null, "1.jpg" },
                    { 111111118.0, null, 111111118.0, 111111118.0, null, "1.jpg" },
                    { 111111119.0, null, 111111119.0, 111111119.0, null, "1.jpg" },
                    { 111111120.0, null, 111111120.0, 111111120.0, null, "1.jpg" },
                    { 111111121.0, null, 111111121.0, 111111121.0, null, "1.jpg" },
                    { 111111122.0, null, 111111122.0, 111111122.0, null, "1.jpg" },
                    { 111111123.0, null, 111111123.0, 111111123.0, null, "1.jpg" },
                    { 111111124.0, null, 111111124.0, 111111124.0, null, "1.jpg" },
                    { 111111125.0, null, 111111125.0, 111111125.0, null, "1.jpg" },
                    { 111111126.0, null, 111111126.0, 111111126.0, null, "1.jpg" },
                    { 111111127.0, null, 111111127.0, 111111127.0, null, "1.jpg" },
                    { 111111128.0, null, 111111128.0, 111111128.0, null, "1.jpg" },
                    { 111111129.0, null, 111111129.0, 111111129.0, null, "1.jpg" },
                    { 111111130.0, null, 111111130.0, 111111130.0, null, "1.jpg" },
                    { 111111131.0, null, 111111131.0, 111111131.0, null, "1.jpg" },
                    { 111111132.0, null, 111111132.0, 111111132.0, null, "1.jpg" },
                    { 111111133.0, null, 111111133.0, 111111133.0, null, "1.jpg" },
                    { 111111134.0, null, 111111134.0, 111111134.0, null, "1.jpg" },
                    { 111111135.0, null, 111111135.0, 111111135.0, null, "1.jpg" },
                    { 111111136.0, null, 111111136.0, 111111136.0, null, "1.jpg" },
                    { 111111137.0, null, 111111137.0, 111111137.0, null, "1.jpg" },
                    { 111111138.0, null, 111111138.0, 111111138.0, null, "1.jpg" },
                    { 111111139.0, null, 111111139.0, 111111139.0, null, "1.jpg" },
                    { 111111140.0, null, 111111140.0, 111111140.0, null, "1.jpg" },
                    { 111111141.0, null, 111111141.0, 111111141.0, null, "1.jpg" },
                    { 111111142.0, null, 111111142.0, 111111142.0, null, "1.jpg" },
                    { 111111143.0, null, 111111143.0, 111111143.0, null, "1.jpg" },
                    { 111111144.0, null, 111111144.0, 111111144.0, null, "1.jpg" },
                    { 111111145.0, null, 111111145.0, 111111145.0, null, "1.jpg" },
                    { 111111146.0, null, 111111146.0, 111111146.0, null, "1.jpg" },
                    { 111111147.0, null, 111111147.0, 111111147.0, null, "1.jpg" },
                    { 111111148.0, null, 111111148.0, 111111148.0, null, "1.jpg" },
                    { 111111149.0, null, 111111149.0, 111111149.0, null, "1.jpg" },
                    { 111111150.0, null, 111111150.0, 111111150.0, null, "1.jpg" },
                    { 111111151.0, null, 111111151.0, 111111151.0, null, "1.jpg" },
                    { 111111152.0, null, 111111152.0, 111111152.0, null, "1.jpg" },
                    { 111111153.0, null, 111111153.0, 111111153.0, null, "1.jpg" },
                    { 111111154.0, null, 111111154.0, 111111154.0, null, "1.jpg" },
                    { 111111155.0, null, 111111155.0, 111111155.0, null, "1.jpg" },
                    { 111111156.0, null, 111111156.0, 111111156.0, null, "1.jpg" },
                    { 111111157.0, null, 111111157.0, 111111157.0, null, "1.jpg" },
                    { 111111158.0, null, 111111158.0, 111111158.0, null, "1.jpg" },
                    { 111111159.0, null, 111111159.0, 111111159.0, null, "1.jpg" },
                    { 111111160.0, null, 111111160.0, 111111160.0, null, "1.jpg" }
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
                name: "IX_Categories2_CategoryId",
                table: "Categories2",
                column: "CategoryId",
                unique: true,
                filter: "[CategoryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductId",
                table: "Comments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageUrls_ProductId",
                table: "ImageUrls",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageUrls_StoreId",
                table: "ImageUrls",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Category2Id",
                table: "Products",
                column: "Category2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StoreId",
                table: "Products",
                column: "StoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ImageUrls");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories2");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
