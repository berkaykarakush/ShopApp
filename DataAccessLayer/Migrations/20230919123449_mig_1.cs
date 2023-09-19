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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    CampaignImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TermsAndConditions = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreId = table.Column<double>(type: "float", nullable: false),
                    PaymentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConversationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    OrderState = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    StoreRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CommentCount = table.Column<int>(type: "int", nullable: false),
                    StarCount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    CategoryId = table.Column<double>(type: "float", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                name: "OrderStore",
                columns: table => new
                {
                    OrdersOrderId = table.Column<double>(type: "float", nullable: false),
                    StoresStoreId = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStore", x => new { x.OrdersOrderId, x.StoresStoreId });
                    table.ForeignKey(
                        name: "FK_OrderStore_Orders_OrdersOrderId",
                        column: x => x.OrdersOrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderStore_Stores_StoresStoreId",
                        column: x => x.StoresStoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    StoreId = table.Column<double>(type: "float", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<double>(type: "float", nullable: false),
                    CartId = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserFirstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserLastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentRate = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<double>(type: "float", nullable: false),
                    SellerAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<double>(type: "float", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    ProductId = table.Column<double>(type: "float", nullable: true),
                    StoreId = table.Column<double>(type: "float", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderId = table.Column<double>(type: "float", nullable: true),
                    ProductId = table.Column<double>(type: "float", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    { 111111111.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(843), "Brand 0", null, "brand-0" },
                    { 111111112.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(858), "Brand 1", null, "brand-1" },
                    { 111111113.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(869), "Brand 2", null, "brand-2" },
                    { 111111114.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(880), "Brand 3", null, "brand-3" },
                    { 111111115.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(931), "Brand 4", null, "brand-4" },
                    { 111111116.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(946), "Brand 5", null, "brand-5" },
                    { 111111117.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(957), "Brand 6", null, "brand-6" },
                    { 111111118.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(967), "Brand 7", null, "brand-7" },
                    { 111111119.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(980), "Brand 8", null, "brand-8" },
                    { 111111120.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(992), "Brand 9", null, "brand-9" },
                    { 111111121.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1003), "Brand 10", null, "brand-10" },
                    { 111111122.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1013), "Brand 11", null, "brand-11" },
                    { 111111123.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1026), "Brand 12", null, "brand-12" },
                    { 111111124.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1037), "Brand 13", null, "brand-13" },
                    { 111111125.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1047), "Brand 14", null, "brand-14" },
                    { 111111126.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1057), "Brand 15", null, "brand-15" },
                    { 111111127.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1070), "Brand 16", null, "brand-16" },
                    { 111111128.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1082), "Brand 17", null, "brand-17" },
                    { 111111129.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1093), "Brand 18", null, "brand-18" },
                    { 111111130.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1103), "Brand 19", null, "brand-19" },
                    { 111111131.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1116), "Brand 20", null, "brand-20" },
                    { 111111132.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1164), "Brand 21", null, "brand-21" },
                    { 111111133.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1176), "Brand 22", null, "brand-22" },
                    { 111111134.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1187), "Brand 23", null, "brand-23" },
                    { 111111135.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1200), "Brand 24", null, "brand-24" },
                    { 111111136.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1210), "Brand 25", null, "brand-25" },
                    { 111111137.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1221), "Brand 26", null, "brand-26" },
                    { 111111138.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1231), "Brand 27", null, "brand-27" },
                    { 111111139.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1244), "Brand 28", null, "brand-28" },
                    { 111111140.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1255), "Brand 29", null, "brand-29" },
                    { 111111141.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1265), "Brand 30", null, "brand-30" },
                    { 111111142.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1276), "Brand 31", null, "brand-31" },
                    { 111111143.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1288), "Brand 32", null, "brand-32" },
                    { 111111144.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1301), "Brand 33", null, "brand-33" },
                    { 111111145.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1311), "Brand 34", null, "brand-34" },
                    { 111111146.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1322), "Brand 35", null, "brand-35" },
                    { 111111147.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1334), "Brand 36", null, "brand-36" },
                    { 111111148.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1345), "Brand 37", null, "brand-37" },
                    { 111111149.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1396), "Brand 38", null, "brand-38" },
                    { 111111150.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1408), "Brand 39", null, "brand-39" },
                    { 111111151.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1421), "Brand 40", null, "brand-40" },
                    { 111111152.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1432), "Brand 41", null, "brand-41" },
                    { 111111153.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1443), "Brand 42", null, "brand-42" },
                    { 111111154.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1453), "Brand 43", null, "brand-43" },
                    { 111111155.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1466), "Brand 44", null, "brand-44" },
                    { 111111156.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1477), "Brand 45", null, "brand-45" },
                    { 111111157.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1487), "Brand 46", null, "brand-46" },
                    { 111111158.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1498), "Brand 47", null, "brand-47" },
                    { 111111159.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1511), "Brand 48", null, "brand-48" },
                    { 111111160.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1522), "Brand 49", null, "brand-49" }
                });

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "CampaignId", "CampaignImage", "Code", "CreatedDate", "Description", "IsApproved", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 111111111.0, "1.jpg", "campaign-code-111111111", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3954), "Description: 111111111", false, "Campaign 111111111", null },
                    { 111111112.0, "1.jpg", "campaign-code-111111112", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3968), "Description: 111111112", false, "Campaign 111111112", null },
                    { 111111113.0, "1.jpg", "campaign-code-111111113", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3980), "Description: 111111113", false, "Campaign 111111113", null },
                    { 111111114.0, "1.jpg", "campaign-code-111111114", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3991), "Description: 111111114", false, "Campaign 111111114", null },
                    { 111111115.0, "1.jpg", "campaign-code-111111115", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4005), "Description: 111111115", false, "Campaign 111111115", null },
                    { 111111116.0, "1.jpg", "campaign-code-111111116", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4018), "Description: 111111116", false, "Campaign 111111116", null },
                    { 111111117.0, "1.jpg", "campaign-code-111111117", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4030), "Description: 111111117", false, "Campaign 111111117", null },
                    { 111111118.0, "1.jpg", "campaign-code-111111118", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4081), "Description: 111111118", false, "Campaign 111111118", null },
                    { 111111119.0, "1.jpg", "campaign-code-111111119", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4096), "Description: 111111119", false, "Campaign 111111119", null },
                    { 111111120.0, "1.jpg", "campaign-code-111111120", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4109), "Description: 111111120", false, "Campaign 111111120", null },
                    { 111111121.0, "1.jpg", "campaign-code-111111121", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4121), "Description: 111111121", false, "Campaign 111111121", null },
                    { 111111122.0, "1.jpg", "campaign-code-111111122", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4132), "Description: 111111122", false, "Campaign 111111122", null },
                    { 111111123.0, "1.jpg", "campaign-code-111111123", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4146), "Description: 111111123", false, "Campaign 111111123", null },
                    { 111111124.0, "1.jpg", "campaign-code-111111124", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4157), "Description: 111111124", false, "Campaign 111111124", null },
                    { 111111125.0, "1.jpg", "campaign-code-111111125", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4169), "Description: 111111125", false, "Campaign 111111125", null },
                    { 111111126.0, "1.jpg", "campaign-code-111111126", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4181), "Description: 111111126", false, "Campaign 111111126", null },
                    { 111111127.0, "1.jpg", "campaign-code-111111127", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4195), "Description: 111111127", false, "Campaign 111111127", null },
                    { 111111128.0, "1.jpg", "campaign-code-111111128", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4207), "Description: 111111128", false, "Campaign 111111128", null },
                    { 111111129.0, "1.jpg", "campaign-code-111111129", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4219), "Description: 111111129", false, "Campaign 111111129", null },
                    { 111111130.0, "1.jpg", "campaign-code-111111130", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4230), "Description: 111111130", false, "Campaign 111111130", null },
                    { 111111131.0, "1.jpg", "campaign-code-111111131", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4284), "Description: 111111131", false, "Campaign 111111131", null },
                    { 111111132.0, "1.jpg", "campaign-code-111111132", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4296), "Description: 111111132", false, "Campaign 111111132", null },
                    { 111111133.0, "1.jpg", "campaign-code-111111133", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4308), "Description: 111111133", false, "Campaign 111111133", null },
                    { 111111134.0, "1.jpg", "campaign-code-111111134", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4319), "Description: 111111134", false, "Campaign 111111134", null },
                    { 111111135.0, "1.jpg", "campaign-code-111111135", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4333), "Description: 111111135", false, "Campaign 111111135", null },
                    { 111111136.0, "1.jpg", "campaign-code-111111136", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4345), "Description: 111111136", false, "Campaign 111111136", null },
                    { 111111137.0, "1.jpg", "campaign-code-111111137", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4356), "Description: 111111137", false, "Campaign 111111137", null },
                    { 111111138.0, "1.jpg", "campaign-code-111111138", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4368), "Description: 111111138", false, "Campaign 111111138", null },
                    { 111111139.0, "1.jpg", "campaign-code-111111139", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4381), "Description: 111111139", false, "Campaign 111111139", null },
                    { 111111140.0, "1.jpg", "campaign-code-111111140", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4393), "Description: 111111140", false, "Campaign 111111140", null },
                    { 111111141.0, "1.jpg", "campaign-code-111111141", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4405), "Description: 111111141", false, "Campaign 111111141", null },
                    { 111111142.0, "1.jpg", "campaign-code-111111142", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4416), "Description: 111111142", false, "Campaign 111111142", null },
                    { 111111143.0, "1.jpg", "campaign-code-111111143", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4430), "Description: 111111143", false, "Campaign 111111143", null },
                    { 111111144.0, "1.jpg", "campaign-code-111111144", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4483), "Description: 111111144", false, "Campaign 111111144", null },
                    { 111111145.0, "1.jpg", "campaign-code-111111145", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4495), "Description: 111111145", false, "Campaign 111111145", null },
                    { 111111146.0, "1.jpg", "campaign-code-111111146", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4506), "Description: 111111146", false, "Campaign 111111146", null },
                    { 111111147.0, "1.jpg", "campaign-code-111111147", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4520), "Description: 111111147", false, "Campaign 111111147", null },
                    { 111111148.0, "1.jpg", "campaign-code-111111148", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4532), "Description: 111111148", false, "Campaign 111111148", null },
                    { 111111149.0, "1.jpg", "campaign-code-111111149", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4544), "Description: 111111149", false, "Campaign 111111149", null },
                    { 111111150.0, "1.jpg", "campaign-code-111111150", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4556), "Description: 111111150", false, "Campaign 111111150", null },
                    { 111111151.0, "1.jpg", "campaign-code-111111151", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4569), "Description: 111111151", false, "Campaign 111111151", null },
                    { 111111152.0, "1.jpg", "campaign-code-111111152", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4581), "Description: 111111152", false, "Campaign 111111152", null },
                    { 111111153.0, "1.jpg", "campaign-code-111111153", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4592), "Description: 111111153", false, "Campaign 111111153", null },
                    { 111111154.0, "1.jpg", "campaign-code-111111154", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4604), "Description: 111111154", false, "Campaign 111111154", null },
                    { 111111155.0, "1.jpg", "campaign-code-111111155", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4617), "Description: 111111155", false, "Campaign 111111155", null },
                    { 111111156.0, "1.jpg", "campaign-code-111111156", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4629), "Description: 111111156", false, "Campaign 111111156", null },
                    { 111111157.0, "1.jpg", "campaign-code-111111157", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4678), "Description: 111111157", false, "Campaign 111111157", null },
                    { 111111158.0, "1.jpg", "campaign-code-111111158", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4692), "Description: 111111158", false, "Campaign 111111158", null },
                    { 111111159.0, "1.jpg", "campaign-code-111111159", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4707), "Description: 111111159", false, "Campaign 111111159", null },
                    { 111111160.0, "1.jpg", "campaign-code-111111160", new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4719), "Description: 111111160", false, "Campaign 111111160", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CreatedDate", "Name", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 111111111.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9386), "Woman", null, "woman" },
                    { 111111112.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9400), "Man", null, "man" },
                    { 111111113.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9402), "Mom & Child", null, "mom-child" },
                    { 111111114.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9404), "Home & Furniture", null, "home-furniture" },
                    { 111111115.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9408), "Supermarket", null, "supermarket" },
                    { 111111116.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9410), "Cosmetics", null, "cosmetics" },
                    { 111111117.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9411), "Shoe & Bag", null, "shoe-bag" },
                    { 111111118.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9413), "Electronics", null, "electronics" },
                    { 111111119.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9417), "Sport & Outdoor", null, "sport-outdoor" },
                    { 111111120.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9418), "Book & Instrument", null, "book-instrument" },
                    { 111111121.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9509), "category 0", null, "category-0" },
                    { 111111122.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9525), "category 1", null, "category-1" },
                    { 111111123.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9539), "category 2", null, "category-2" },
                    { 111111124.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9550), "category 3", null, "category-3" },
                    { 111111125.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9561), "category 4", null, "category-4" },
                    { 111111126.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9573), "category 5", null, "category-5" },
                    { 111111127.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9586), "category 6", null, "category-6" },
                    { 111111128.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9599), "category 7", null, "category-7" },
                    { 111111129.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9611), "category 8", null, "category-8" },
                    { 111111130.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9622), "category 9", null, "category-9" },
                    { 111111131.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9636), "category 10", null, "category-10" },
                    { 111111132.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9648), "category 11", null, "category-11" },
                    { 111111133.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9659), "category 12", null, "category-12" },
                    { 111111134.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9733), "category 13", null, "category-13" },
                    { 111111135.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9748), "category 14", null, "category-14" },
                    { 111111136.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9759), "category 15", null, "category-15" },
                    { 111111137.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9771), "category 16", null, "category-16" },
                    { 111111138.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9782), "category 17", null, "category-17" },
                    { 111111139.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9795), "category 18", null, "category-18" },
                    { 111111140.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9806), "category 19", null, "category-19" },
                    { 111111141.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9817), "category 20", null, "category-20" },
                    { 111111142.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9828), "category 21", null, "category-21" },
                    { 111111143.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9842), "category 22", null, "category-22" },
                    { 111111144.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9854), "category 23", null, "category-23" },
                    { 111111145.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9865), "category 24", null, "category-24" },
                    { 111111146.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9876), "category 25", null, "category-25" },
                    { 111111147.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9890), "category 26", null, "category-26" },
                    { 111111148.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9901), "category 27", null, "category-27" },
                    { 111111149.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9911), "category 28", null, "category-28" },
                    { 111111150.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9963), "category 29", null, "category-29" },
                    { 111111151.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9977), "category 30", null, "category-30" },
                    { 111111152.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9989), "category 31", null, "category-31" },
                    { 111111153.0, new DateTime(2023, 9, 19, 15, 34, 48, 861, DateTimeKind.Local).AddTicks(9999), "category 32", null, "category-32" },
                    { 111111154.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(11), "category 33", null, "category-33" },
                    { 111111155.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(24), "category 34", null, "category-34" },
                    { 111111156.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(35), "category 35", null, "category-35" },
                    { 111111157.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(46), "category 36", null, "category-36" },
                    { 111111158.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(57), "category 37", null, "category-37" },
                    { 111111159.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(71), "category 38", null, "category-38" },
                    { 111111160.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(82), "category 39", null, "category-39" }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreId", "CommentCount", "CreatedDate", "IsApproved", "SellerEmail", "SellerFirstName", "SellerId", "SellerLastName", "SellerPhone", "StarCount", "StoreImage", "StoreName", "StoreRate", "StoreUrl", "UpdatedDate" },
                values: new object[,]
                {
                    { 111111111.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3117), false, null, null, null, null, null, 1m, "1.jpg", "store 0", 1m, "store-0", null },
                    { 111111112.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3135), false, null, null, null, null, null, 1m, "1.jpg", "store 1", 1m, "store-1", null },
                    { 111111113.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3150), false, null, null, null, null, null, 1m, "1.jpg", "store 2", 1m, "store-2", null },
                    { 111111114.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3211), false, null, null, null, null, null, 1m, "1.jpg", "store 3", 1m, "store-3", null },
                    { 111111115.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3224), false, null, null, null, null, null, 1m, "1.jpg", "store 4", 1m, "store-4", null },
                    { 111111116.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3237), false, null, null, null, null, null, 1m, "1.jpg", "store 5", 1m, "store-5", null },
                    { 111111117.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3252), false, null, null, null, null, null, 1m, "1.jpg", "store 6", 1m, "store-6", null },
                    { 111111118.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3263), false, null, null, null, null, null, 1m, "1.jpg", "store 7", 1m, "store-7", null },
                    { 111111119.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3275), false, null, null, null, null, null, 1m, "1.jpg", "store 8", 1m, "store-8", null },
                    { 111111120.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3288), false, null, null, null, null, null, 1m, "1.jpg", "store 9", 1m, "store-9", null },
                    { 111111121.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3302), false, null, null, null, null, null, 1m, "1.jpg", "store 10", 1m, "store-10", null },
                    { 111111122.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3314), false, null, null, null, null, null, 1m, "1.jpg", "store 11", 1m, "store-11", null },
                    { 111111123.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3325), false, null, null, null, null, null, 1m, "1.jpg", "store 12", 1m, "store-12", null },
                    { 111111124.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3337), false, null, null, null, null, null, 1m, "1.jpg", "store 13", 1m, "store-13", null },
                    { 111111125.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3351), false, null, null, null, null, null, 1m, "1.jpg", "store 14", 1m, "store-14", null },
                    { 111111126.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3363), false, null, null, null, null, null, 1m, "1.jpg", "store 15", 1m, "store-15", null },
                    { 111111127.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3435), false, null, null, null, null, null, 1m, "1.jpg", "store 16", 1m, "store-16", null },
                    { 111111128.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3452), false, null, null, null, null, null, 1m, "1.jpg", "store 17", 1m, "store-17", null },
                    { 111111129.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3467), false, null, null, null, null, null, 1m, "1.jpg", "store 18", 1m, "store-18", null },
                    { 111111130.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3479), false, null, null, null, null, null, 1m, "1.jpg", "store 19", 1m, "store-19", null },
                    { 111111131.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3491), false, null, null, null, null, null, 1m, "1.jpg", "store 20", 1m, "store-20", null },
                    { 111111132.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3503), false, null, null, null, null, null, 1m, "1.jpg", "store 21", 1m, "store-21", null },
                    { 111111133.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3517), false, null, null, null, null, null, 1m, "1.jpg", "store 22", 1m, "store-22", null },
                    { 111111134.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3529), false, null, null, null, null, null, 1m, "1.jpg", "store 23", 1m, "store-23", null },
                    { 111111135.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3541), false, null, null, null, null, null, 1m, "1.jpg", "store 24", 1m, "store-24", null },
                    { 111111136.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3552), false, null, null, null, null, null, 1m, "1.jpg", "store 25", 1m, "store-25", null },
                    { 111111137.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3567), false, null, null, null, null, null, 1m, "1.jpg", "store 26", 1m, "store-26", null },
                    { 111111138.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3579), false, null, null, null, null, null, 1m, "1.jpg", "store 27", 1m, "store-27", null },
                    { 111111139.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3591), false, null, null, null, null, null, 1m, "1.jpg", "store 28", 1m, "store-28", null },
                    { 111111140.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3602), false, null, null, null, null, null, 1m, "1.jpg", "store 29", 1m, "store-29", null },
                    { 111111141.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3657), false, null, null, null, null, null, 1m, "1.jpg", "store 30", 1m, "store-30", null },
                    { 111111142.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3670), false, null, null, null, null, null, 1m, "1.jpg", "store 31", 1m, "store-31", null },
                    { 111111143.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3682), false, null, null, null, null, null, 1m, "1.jpg", "store 32", 1m, "store-32", null },
                    { 111111144.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3695), false, null, null, null, null, null, 1m, "1.jpg", "store 33", 1m, "store-33", null },
                    { 111111145.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3709), false, null, null, null, null, null, 1m, "1.jpg", "store 34", 1m, "store-34", null },
                    { 111111146.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3720), false, null, null, null, null, null, 1m, "1.jpg", "store 35", 1m, "store-35", null },
                    { 111111147.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3732), false, null, null, null, null, null, 1m, "1.jpg", "store 36", 1m, "store-36", null },
                    { 111111148.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3744), false, null, null, null, null, null, 1m, "1.jpg", "store 37", 1m, "store-37", null },
                    { 111111149.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3758), false, null, null, null, null, null, 1m, "1.jpg", "store 38", 1m, "store-38", null },
                    { 111111150.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3769), false, null, null, null, null, null, 1m, "1.jpg", "store 39", 1m, "store-39", null },
                    { 111111151.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3781), false, null, null, null, null, null, 1m, "1.jpg", "store 40", 1m, "store-40", null },
                    { 111111152.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3793), false, null, null, null, null, null, 1m, "1.jpg", "store 41", 1m, "store-41", null },
                    { 111111153.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3806), false, null, null, null, null, null, 1m, "1.jpg", "store 42", 1m, "store-42", null },
                    { 111111154.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3858), false, null, null, null, null, null, 1m, "1.jpg", "store 43", 1m, "store-43", null },
                    { 111111155.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3872), false, null, null, null, null, null, 1m, "1.jpg", "store 44", 1m, "store-44", null },
                    { 111111156.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3883), false, null, null, null, null, null, 1m, "1.jpg", "store 45", 1m, "store-45", null },
                    { 111111157.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3898), false, null, null, null, null, null, 1m, "1.jpg", "store 46", 1m, "store-46", null },
                    { 111111158.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3909), false, null, null, null, null, null, 1m, "1.jpg", "store 47", 1m, "store-47", null },
                    { 111111159.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3921), false, null, null, null, null, null, 1m, "1.jpg", "store 48", 1m, "store-48", null },
                    { 111111160.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3933), false, null, null, null, null, null, 1m, "1.jpg", "store 49", 1m, "store-49", null }
                });

            migrationBuilder.InsertData(
                table: "Categories2",
                columns: new[] { "Category2Id", "CategoryId", "CreatedDate", "Name", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 111111111.0, 111111111.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(100), "category2 0", null, "category2-0" },
                    { 111111112.0, 111111112.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(119), "category2 1", null, "category2-1" },
                    { 111111113.0, 111111113.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(133), "category2 2", null, "category2-2" },
                    { 111111114.0, 111111114.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(146), "category2 3", null, "category2-3" },
                    { 111111115.0, 111111115.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(157), "category2 4", null, "category2-4" },
                    { 111111116.0, 111111116.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(169), "category2 5", null, "category2-5" },
                    { 111111117.0, 111111117.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(222), "category2 6", null, "category2-6" },
                    { 111111118.0, 111111118.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(234), "category2 7", null, "category2-7" },
                    { 111111119.0, 111111119.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(246), "category2 8", null, "category2-8" },
                    { 111111120.0, 111111120.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(258), "category2 9", null, "category2-9" },
                    { 111111121.0, 111111121.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(271), "category2 10", null, "category2-10" },
                    { 111111122.0, 111111122.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(283), "category2 11", null, "category2-11" },
                    { 111111123.0, 111111123.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(295), "category2 12", null, "category2-12" },
                    { 111111124.0, 111111124.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(306), "category2 13", null, "category2-13" },
                    { 111111125.0, 111111125.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(320), "category2 14", null, "category2-14" },
                    { 111111126.0, 111111126.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(332), "category2 15", null, "category2-15" },
                    { 111111127.0, 111111127.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(343), "category2 16", null, "category2-16" },
                    { 111111128.0, 111111128.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(355), "category2 17", null, "category2-17" },
                    { 111111129.0, 111111129.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(369), "category2 18", null, "category2-18" },
                    { 111111130.0, 111111130.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(381), "category2 19", null, "category2-19" },
                    { 111111131.0, 111111131.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(392), "category2 20", null, "category2-20" },
                    { 111111132.0, 111111132.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(403), "category2 21", null, "category2-21" },
                    { 111111133.0, 111111133.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(461), "category2 22", null, "category2-22" },
                    { 111111134.0, 111111134.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(473), "category2 23", null, "category2-23" },
                    { 111111135.0, 111111135.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(484), "category2 24", null, "category2-24" },
                    { 111111136.0, 111111136.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(495), "category2 25", null, "category2-25" },
                    { 111111137.0, 111111137.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(509), "category2 26", null, "category2-26" },
                    { 111111138.0, 111111138.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(521), "category2 27", null, "category2-27" },
                    { 111111139.0, 111111139.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(532), "category2 28", null, "category2-28" },
                    { 111111140.0, 111111140.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(543), "category2 29", null, "category2-29" },
                    { 111111141.0, 111111141.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(557), "category2 30", null, "category2-30" },
                    { 111111142.0, 111111142.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(569), "category2 31", null, "category2-31" },
                    { 111111143.0, 111111143.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(580), "category2 32", null, "category2-32" },
                    { 111111144.0, 111111144.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(593), "category2 33", null, "category2-33" },
                    { 111111145.0, 111111145.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(607), "category2 34", null, "category2-34" },
                    { 111111146.0, 111111146.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(619), "category2 35", null, "category2-35" },
                    { 111111147.0, 111111147.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(630), "category2 36", null, "category2-36" },
                    { 111111148.0, 111111148.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(679), "category2 37", null, "category2-37" },
                    { 111111149.0, 111111149.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(694), "category2 38", null, "category2-38" },
                    { 111111150.0, 111111150.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(707), "category2 39", null, "category2-39" },
                    { 111111151.0, 111111151.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(718), "category2 40", null, "category2-40" },
                    { 111111152.0, 111111152.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(730), "category2 41", null, "category2-41" },
                    { 111111153.0, 111111153.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(744), "category2 42", null, "category2-42" },
                    { 111111154.0, 111111154.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(756), "category2 43", null, "category2-43" },
                    { 111111155.0, 111111155.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(767), "category2 44", null, "category2-44" },
                    { 111111156.0, 111111156.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(778), "category2 45", null, "category2-45" },
                    { 111111157.0, 111111157.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(792), "category2 46", null, "category2-46" },
                    { 111111158.0, 111111158.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(804), "category2 47", null, "category2-47" },
                    { 111111159.0, 111111159.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(815), "category2 48", null, "category2-48" },
                    { 111111160.0, 111111160.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(826), "category2 49", null, "category2-49" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "BrandId", "Category2Id", "CategoryId", "CommentCount", "CreatedDate", "Description", "IsApproved", "IsHome", "Name", "Price", "ProductImage", "ProductRate", "Quantity", "SalesCount", "StarCount", "StoreId", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 111111111.0, 111111111.0, 111111111.0, 111111111.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1547), "urun aciklamasi 0", true, true, "urun 0", 10m, "1.jpg", 1m, 0, 0, 1, 111111111.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1548), "urun-0" },
                    { 111111112.0, 111111112.0, 111111112.0, 111111112.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1571), "urun aciklamasi 1", true, true, "urun 1", 10m, "1.jpg", 1m, 1, 1, 1, 111111112.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1571), "urun-1" },
                    { 111111113.0, 111111113.0, 111111113.0, 111111113.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1588), "urun aciklamasi 2", true, true, "urun 2", 10m, "1.jpg", 1m, 2, 2, 1, 111111113.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1588), "urun-2" },
                    { 111111114.0, 111111114.0, 111111114.0, 111111114.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1603), "urun aciklamasi 3", true, true, "urun 3", 10m, "1.jpg", 1m, 3, 3, 1, 111111114.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1603), "urun-3" },
                    { 111111115.0, 111111115.0, 111111115.0, 111111115.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1672), "urun aciklamasi 4", true, true, "urun 4", 10m, "1.jpg", 1m, 4, 4, 1, 111111115.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1672), "urun-4" },
                    { 111111116.0, 111111116.0, 111111116.0, 111111116.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1688), "urun aciklamasi 5", true, true, "urun 5", 10m, "1.jpg", 1m, 5, 5, 1, 111111116.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1689), "urun-5" },
                    { 111111117.0, 111111117.0, 111111117.0, 111111117.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1705), "urun aciklamasi 6", true, true, "urun 6", 10m, "1.jpg", 1m, 6, 6, 1, 111111117.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1706), "urun-6" },
                    { 111111118.0, 111111118.0, 111111118.0, 111111118.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1720), "urun aciklamasi 7", true, true, "urun 7", 10m, "1.jpg", 1m, 7, 7, 1, 111111118.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1720), "urun-7" },
                    { 111111119.0, 111111119.0, 111111119.0, 111111119.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1734), "urun aciklamasi 8", true, true, "urun 8", 10m, "1.jpg", 1m, 8, 8, 1, 111111119.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1734), "urun-8" },
                    { 111111120.0, 111111120.0, 111111120.0, 111111120.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1749), "urun aciklamasi 9", true, true, "urun 9", 10m, "1.jpg", 1m, 9, 9, 1, 111111120.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1749), "urun-9" },
                    { 111111121.0, 111111121.0, 111111121.0, 111111121.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1766), "urun aciklamasi 10", true, true, "urun 10", 10m, "1.jpg", 1m, 10, 10, 1, 111111121.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1766), "urun-10" },
                    { 111111122.0, 111111122.0, 111111122.0, 111111122.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1780), "urun aciklamasi 11", true, true, "urun 11", 10m, "1.jpg", 1m, 11, 11, 1, 111111122.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1780), "urun-11" },
                    { 111111123.0, 111111123.0, 111111123.0, 111111123.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1794), "urun aciklamasi 12", true, true, "urun 12", 10m, "1.jpg", 1m, 12, 12, 1, 111111123.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1795), "urun-12" },
                    { 111111124.0, 111111124.0, 111111124.0, 111111124.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1808), "urun aciklamasi 13", true, true, "urun 13", 10m, "1.jpg", 1m, 13, 13, 1, 111111124.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1808), "urun-13" },
                    { 111111125.0, 111111125.0, 111111125.0, 111111125.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1824), "urun aciklamasi 14", true, true, "urun 14", 10m, "1.jpg", 1m, 14, 14, 1, 111111125.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1825), "urun-14" },
                    { 111111126.0, 111111126.0, 111111126.0, 111111126.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1897), "urun aciklamasi 15", true, true, "urun 15", 10m, "1.jpg", 1m, 15, 15, 1, 111111126.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1898), "urun-15" },
                    { 111111127.0, 111111127.0, 111111127.0, 111111127.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1912), "urun aciklamasi 16", true, true, "urun 16", 10m, "1.jpg", 1m, 16, 16, 1, 111111127.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1913), "urun-16" },
                    { 111111128.0, 111111128.0, 111111128.0, 111111128.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1927), "urun aciklamasi 17", true, true, "urun 17", 10m, "1.jpg", 1m, 17, 17, 1, 111111128.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1928), "urun-17" },
                    { 111111129.0, 111111129.0, 111111129.0, 111111129.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1944), "urun aciklamasi 18", true, true, "urun 18", 10m, "1.jpg", 1m, 18, 18, 1, 111111129.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1944), "urun-18" },
                    { 111111130.0, 111111130.0, 111111130.0, 111111130.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1958), "urun aciklamasi 19", true, true, "urun 19", 10m, "1.jpg", 1m, 19, 19, 1, 111111130.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1958), "urun-19" },
                    { 111111131.0, 111111131.0, 111111131.0, 111111131.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1972), "urun aciklamasi 20", true, true, "urun 20", 10m, "1.jpg", 1m, 20, 20, 1, 111111131.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1972), "urun-20" },
                    { 111111132.0, 111111132.0, 111111132.0, 111111132.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1986), "urun aciklamasi 21", true, true, "urun 21", 10m, "1.jpg", 1m, 21, 21, 1, 111111132.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(1987), "urun-21" },
                    { 111111133.0, 111111133.0, 111111133.0, 111111133.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2002), "urun aciklamasi 22", true, true, "urun 22", 10m, "1.jpg", 1m, 22, 22, 1, 111111133.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2003), "urun-22" },
                    { 111111134.0, 111111134.0, 111111134.0, 111111134.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2017), "urun aciklamasi 23", true, true, "urun 23", 10m, "1.jpg", 1m, 23, 23, 1, 111111134.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2017), "urun-23" },
                    { 111111135.0, 111111135.0, 111111135.0, 111111135.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2030), "urun aciklamasi 24", true, true, "urun 24", 10m, "1.jpg", 1m, 24, 24, 1, 111111135.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2031), "urun-24" },
                    { 111111136.0, 111111136.0, 111111136.0, 111111136.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2044), "urun aciklamasi 25", true, true, "urun 25", 10m, "1.jpg", 1m, 25, 25, 1, 111111136.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2045), "urun-25" },
                    { 111111137.0, 111111137.0, 111111137.0, 111111137.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2102), "urun aciklamasi 26", true, true, "urun 26", 10m, "1.jpg", 1m, 26, 26, 1, 111111137.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2102), "urun-26" },
                    { 111111138.0, 111111138.0, 111111138.0, 111111138.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2117), "urun aciklamasi 27", true, true, "urun 27", 10m, "1.jpg", 1m, 27, 27, 1, 111111138.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2117), "urun-27" },
                    { 111111139.0, 111111139.0, 111111139.0, 111111139.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2131), "urun aciklamasi 28", true, true, "urun 28", 10m, "1.jpg", 1m, 28, 28, 1, 111111139.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2132), "urun-28" },
                    { 111111140.0, 111111140.0, 111111140.0, 111111140.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2145), "urun aciklamasi 29", true, true, "urun 29", 10m, "1.jpg", 1m, 29, 29, 1, 111111140.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2146), "urun-29" },
                    { 111111141.0, 111111141.0, 111111141.0, 111111141.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2161), "urun aciklamasi 30", true, true, "urun 30", 10m, "1.jpg", 1m, 30, 30, 1, 111111141.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2162), "urun-30" },
                    { 111111142.0, 111111142.0, 111111142.0, 111111142.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2176), "urun aciklamasi 31", true, true, "urun 31", 10m, "1.jpg", 1m, 31, 31, 1, 111111142.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2176), "urun-31" },
                    { 111111143.0, 111111143.0, 111111143.0, 111111143.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2189), "urun aciklamasi 32", true, true, "urun 32", 10m, "1.jpg", 1m, 32, 32, 1, 111111143.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2190), "urun-32" },
                    { 111111144.0, 111111144.0, 111111144.0, 111111144.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2204), "urun aciklamasi 33", true, true, "urun 33", 10m, "1.jpg", 1m, 33, 33, 1, 111111144.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2205), "urun-33" },
                    { 111111145.0, 111111145.0, 111111145.0, 111111145.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2221), "urun aciklamasi 34", true, true, "urun 34", 10m, "1.jpg", 1m, 34, 34, 1, 111111145.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2221), "urun-34" },
                    { 111111146.0, 111111146.0, 111111146.0, 111111146.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2235), "urun aciklamasi 35", true, true, "urun 35", 10m, "1.jpg", 1m, 35, 35, 1, 111111146.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2236), "urun-35" },
                    { 111111147.0, 111111147.0, 111111147.0, 111111147.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2298), "urun aciklamasi 36", true, true, "urun 36", 10m, "1.jpg", 1m, 36, 36, 1, 111111147.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2298), "urun-36" },
                    { 111111148.0, 111111148.0, 111111148.0, 111111148.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2315), "urun aciklamasi 37", true, true, "urun 37", 10m, "1.jpg", 1m, 37, 37, 1, 111111148.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2316), "urun-37" },
                    { 111111149.0, 111111149.0, 111111149.0, 111111149.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2332), "urun aciklamasi 38", true, true, "urun 38", 10m, "1.jpg", 1m, 38, 38, 1, 111111149.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2332), "urun-38" },
                    { 111111150.0, 111111150.0, 111111150.0, 111111150.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2347), "urun aciklamasi 39", true, true, "urun 39", 10m, "1.jpg", 1m, 39, 39, 1, 111111150.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2347), "urun-39" },
                    { 111111151.0, 111111151.0, 111111151.0, 111111151.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2360), "urun aciklamasi 40", true, true, "urun 40", 10m, "1.jpg", 1m, 40, 40, 1, 111111151.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2361), "urun-40" },
                    { 111111152.0, 111111152.0, 111111152.0, 111111152.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2374), "urun aciklamasi 41", true, true, "urun 41", 10m, "1.jpg", 1m, 41, 41, 1, 111111152.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2374), "urun-41" },
                    { 111111153.0, 111111153.0, 111111153.0, 111111153.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2390), "urun aciklamasi 42", true, true, "urun 42", 10m, "1.jpg", 1m, 42, 42, 1, 111111153.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2391), "urun-42" },
                    { 111111154.0, 111111154.0, 111111154.0, 111111154.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2404), "urun aciklamasi 43", true, true, "urun 43", 10m, "1.jpg", 1m, 43, 43, 1, 111111154.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2405), "urun-43" },
                    { 111111155.0, 111111155.0, 111111155.0, 111111155.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2418), "urun aciklamasi 44", true, true, "urun 44", 10m, "1.jpg", 1m, 44, 44, 1, 111111155.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2419), "urun-44" },
                    { 111111156.0, 111111156.0, 111111156.0, 111111156.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2432), "urun aciklamasi 45", true, true, "urun 45", 10m, "1.jpg", 1m, 45, 45, 1, 111111156.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2433), "urun-45" },
                    { 111111157.0, 111111157.0, 111111157.0, 111111157.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2448), "urun aciklamasi 46", true, true, "urun 46", 10m, "1.jpg", 1m, 46, 46, 1, 111111157.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2449), "urun-46" },
                    { 111111158.0, 111111158.0, 111111158.0, 111111158.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2463), "urun aciklamasi 47", true, true, "urun 47", 10m, "1.jpg", 1m, 47, 47, 1, 111111158.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2463), "urun-47" },
                    { 111111159.0, 111111159.0, 111111159.0, 111111159.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2530), "urun aciklamasi 48", true, true, "urun 48", 10m, "1.jpg", 1m, 48, 48, 1, 111111159.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2530), "urun-48" },
                    { 111111160.0, 111111160.0, 111111160.0, 111111160.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2544), "urun aciklamasi 49", true, true, "urun 49", 10m, "1.jpg", 1m, 49, 49, 1, 111111160.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2545), "urun-49" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "CommentRate", "CreatedDate", "Description", "ProductId", "SellerAnswer", "StoreId", "UpdatedDate", "UserFirstname", "UserId", "UserLastname" },
                values: new object[,]
                {
                    { 111111111.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4733), "description - 0", 111111111.0, "seller answer - 0", 111111111.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111112.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4751), "description - 1", 111111112.0, "seller answer - 1", 111111112.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111113.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4765), "description - 2", 111111113.0, "seller answer - 2", 111111113.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111114.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4777), "description - 3", 111111114.0, "seller answer - 3", 111111114.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111115.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4788), "description - 4", 111111115.0, "seller answer - 4", 111111115.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111116.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4802), "description - 5", 111111116.0, "seller answer - 5", 111111116.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111117.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4816), "description - 6", 111111117.0, "seller answer - 6", 111111117.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111118.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4827), "description - 7", 111111118.0, "seller answer - 7", 111111118.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111119.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4838), "description - 8", 111111119.0, "seller answer - 8", 111111119.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111120.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4850), "description - 9", 111111120.0, "seller answer - 9", 111111120.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111121.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4864), "description - 10", 111111121.0, "seller answer - 10", 111111121.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111122.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4914), "description - 11", 111111122.0, "seller answer - 11", 111111122.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111123.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4926), "description - 12", 111111123.0, "seller answer - 12", 111111123.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111124.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4937), "description - 13", 111111124.0, "seller answer - 13", 111111124.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111125.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4951), "description - 14", 111111125.0, "seller answer - 14", 111111125.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111126.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4962), "description - 15", 111111126.0, "seller answer - 15", 111111126.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111127.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4973), "description - 16", 111111127.0, "seller answer - 16", 111111127.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111128.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4985), "description - 17", 111111128.0, "seller answer - 17", 111111128.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111129.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(4999), "description - 18", 111111129.0, "seller answer - 18", 111111129.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111130.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(5010), "description - 19", 111111130.0, "seller answer - 19", 111111130.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111131.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(5021), "description - 20", 111111131.0, "seller answer - 20", 111111131.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111132.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(5032), "description - 21", 111111132.0, "seller answer - 21", 111111132.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111133.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(5045), "description - 22", 111111133.0, "seller answer - 22", 111111133.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111134.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(5057), "description - 23", 111111134.0, "seller answer - 23", 111111134.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111135.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(5068), "description - 24", 111111135.0, "seller answer - 24", 111111135.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111136.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(5129), "description - 25", 111111136.0, "seller answer - 25", 111111136.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111137.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(5145), "description - 26", 111111137.0, "seller answer - 26", 111111137.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111138.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(5157), "description - 27", 111111138.0, "seller answer - 27", 111111138.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111139.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(5168), "description - 28", 111111139.0, "seller answer - 28", 111111139.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111140.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(5180), "description - 29", 111111140.0, "seller answer - 29", 111111140.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111141.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(5193), "description - 30", 111111141.0, "seller answer - 30", 111111141.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111142.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(5204), "description - 31", 111111142.0, "seller answer - 31", 111111142.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111143.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(5216), "description - 32", 111111143.0, "seller answer - 32", 111111143.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111144.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(5228), "description - 33", 111111144.0, "seller answer - 33", 111111144.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111145.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(5242), "description - 34", 111111145.0, "seller answer - 34", 111111145.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111146.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(5254), "description - 35", 111111146.0, "seller answer - 35", 111111146.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111147.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(5265), "description - 36", 111111147.0, "seller answer - 36", 111111147.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111148.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(5276), "description - 37", 111111148.0, "seller answer - 37", 111111148.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111149.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(5291), "description - 38", 111111149.0, "seller answer - 38", 111111149.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111150.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(5381), "description - 39", 111111150.0, "seller answer - 39", 111111150.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111151.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(5396), "description - 40", 111111151.0, "seller answer - 40", 111111151.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111152.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(5408), "description - 41", 111111152.0, "seller answer - 41", 111111152.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111153.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(5422), "description - 42", 111111153.0, "seller answer - 42", 111111153.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111154.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(5434), "description - 43", 111111154.0, "seller answer - 43", 111111154.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111155.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(5445), "description - 44", 111111155.0, "seller answer - 44", 111111155.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111156.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(5456), "description - 45", 111111156.0, "seller answer - 45", 111111156.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111157.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(5470), "description - 46", 111111157.0, "seller answer - 46", 111111157.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111158.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(5481), "description - 47", 111111158.0, "seller answer - 47", 111111158.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111159.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(5492), "description - 48", 111111159.0, "seller answer - 48", 111111159.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111160.0, 1, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(5504), "description - 49", 111111160.0, "seller answer - 49", 111111160.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" }
                });

            migrationBuilder.InsertData(
                table: "ImageUrls",
                columns: new[] { "ImageUrlId", "CreatedDate", "ProductId", "StoreId", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 111111111.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2561), 111111111.0, 111111111.0, null, "1.jpg" },
                    { 111111112.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2575), 111111112.0, 111111112.0, null, "1.jpg" },
                    { 111111113.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2584), 111111113.0, 111111113.0, null, "1.jpg" },
                    { 111111114.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2592), 111111114.0, 111111114.0, null, "1.jpg" },
                    { 111111115.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2603), 111111115.0, 111111115.0, null, "1.jpg" },
                    { 111111116.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2613), 111111116.0, 111111116.0, null, "1.jpg" },
                    { 111111117.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2621), 111111117.0, 111111117.0, null, "1.jpg" },
                    { 111111118.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2630), 111111118.0, 111111118.0, null, "1.jpg" },
                    { 111111119.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2640), 111111119.0, 111111119.0, null, "1.jpg" },
                    { 111111120.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2650), 111111120.0, 111111120.0, null, "1.jpg" },
                    { 111111121.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2658), 111111121.0, 111111121.0, null, "1.jpg" },
                    { 111111122.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2667), 111111122.0, 111111122.0, null, "1.jpg" },
                    { 111111123.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2677), 111111123.0, 111111123.0, null, "1.jpg" },
                    { 111111124.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2686), 111111124.0, 111111124.0, null, "1.jpg" },
                    { 111111125.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2694), 111111125.0, 111111125.0, null, "1.jpg" },
                    { 111111126.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2702), 111111126.0, 111111126.0, null, "1.jpg" },
                    { 111111127.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2750), 111111127.0, 111111127.0, null, "1.jpg" },
                    { 111111128.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2760), 111111128.0, 111111128.0, null, "1.jpg" },
                    { 111111129.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2769), 111111129.0, 111111129.0, null, "1.jpg" },
                    { 111111130.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2777), 111111130.0, 111111130.0, null, "1.jpg" },
                    { 111111131.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2787), 111111131.0, 111111131.0, null, "1.jpg" },
                    { 111111132.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2796), 111111132.0, 111111132.0, null, "1.jpg" },
                    { 111111133.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2804), 111111133.0, 111111133.0, null, "1.jpg" },
                    { 111111134.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2812), 111111134.0, 111111134.0, null, "1.jpg" },
                    { 111111135.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2822), 111111135.0, 111111135.0, null, "1.jpg" },
                    { 111111136.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2831), 111111136.0, 111111136.0, null, "1.jpg" },
                    { 111111137.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2839), 111111137.0, 111111137.0, null, "1.jpg" },
                    { 111111138.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2847), 111111138.0, 111111138.0, null, "1.jpg" },
                    { 111111139.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2858), 111111139.0, 111111139.0, null, "1.jpg" },
                    { 111111140.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2866), 111111140.0, 111111140.0, null, "1.jpg" },
                    { 111111141.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2874), 111111141.0, 111111141.0, null, "1.jpg" },
                    { 111111142.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2883), 111111142.0, 111111142.0, null, "1.jpg" },
                    { 111111143.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2893), 111111143.0, 111111143.0, null, "1.jpg" },
                    { 111111144.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2903), 111111144.0, 111111144.0, null, "1.jpg" },
                    { 111111145.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2969), 111111145.0, 111111145.0, null, "1.jpg" },
                    { 111111146.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2979), 111111146.0, 111111146.0, null, "1.jpg" },
                    { 111111147.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2990), 111111147.0, 111111147.0, null, "1.jpg" },
                    { 111111148.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(2998), 111111148.0, 111111148.0, null, "1.jpg" },
                    { 111111149.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3006), 111111149.0, 111111149.0, null, "1.jpg" },
                    { 111111150.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3015), 111111150.0, 111111150.0, null, "1.jpg" },
                    { 111111151.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3025), 111111151.0, 111111151.0, null, "1.jpg" },
                    { 111111152.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3034), 111111152.0, 111111152.0, null, "1.jpg" },
                    { 111111153.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3042), 111111153.0, 111111153.0, null, "1.jpg" },
                    { 111111154.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3050), 111111154.0, 111111154.0, null, "1.jpg" },
                    { 111111155.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3060), 111111155.0, 111111155.0, null, "1.jpg" },
                    { 111111156.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3069), 111111156.0, 111111156.0, null, "1.jpg" },
                    { 111111157.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3077), 111111157.0, 111111157.0, null, "1.jpg" },
                    { 111111158.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3085), 111111158.0, 111111158.0, null, "1.jpg" },
                    { 111111159.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3095), 111111159.0, 111111159.0, null, "1.jpg" },
                    { 111111160.0, new DateTime(2023, 9, 19, 15, 34, 48, 862, DateTimeKind.Local).AddTicks(3104), 111111160.0, 111111160.0, null, "1.jpg" }
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
                name: "IX_OrderStore_StoresStoreId",
                table: "OrderStore",
                column: "StoresStoreId");

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
                name: "OrderStore");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

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
