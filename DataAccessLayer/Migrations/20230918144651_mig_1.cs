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
                    IsHome = table.Column<bool>(type: "bit", nullable: false),
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
                    { 111111111.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6487), "Brand 0", null, "brand-0" },
                    { 111111112.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6509), "Brand 1", null, "brand-1" },
                    { 111111113.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6520), "Brand 2", null, "brand-2" },
                    { 111111114.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6531), "Brand 3", null, "brand-3" },
                    { 111111115.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6545), "Brand 4", null, "brand-4" },
                    { 111111116.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6557), "Brand 5", null, "brand-5" },
                    { 111111117.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6568), "Brand 6", null, "brand-6" },
                    { 111111118.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6579), "Brand 7", null, "brand-7" },
                    { 111111119.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6593), "Brand 8", null, "brand-8" },
                    { 111111120.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6606), "Brand 9", null, "brand-9" },
                    { 111111121.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6617), "Brand 10", null, "brand-10" },
                    { 111111122.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6628), "Brand 11", null, "brand-11" },
                    { 111111123.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6642), "Brand 12", null, "brand-12" },
                    { 111111124.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6653), "Brand 13", null, "brand-13" },
                    { 111111125.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6664), "Brand 14", null, "brand-14" },
                    { 111111126.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6675), "Brand 15", null, "brand-15" },
                    { 111111127.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6742), "Brand 16", null, "brand-16" },
                    { 111111128.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6755), "Brand 17", null, "brand-17" },
                    { 111111129.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6766), "Brand 18", null, "brand-18" },
                    { 111111130.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6776), "Brand 19", null, "brand-19" },
                    { 111111131.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6793), "Brand 20", null, "brand-20" },
                    { 111111132.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6804), "Brand 21", null, "brand-21" },
                    { 111111133.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6815), "Brand 22", null, "brand-22" },
                    { 111111134.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6826), "Brand 23", null, "brand-23" },
                    { 111111135.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6840), "Brand 24", null, "brand-24" },
                    { 111111136.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7050), "Brand 25", null, "brand-25" },
                    { 111111137.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7064), "Brand 26", null, "brand-26" },
                    { 111111138.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7078), "Brand 27", null, "brand-27" },
                    { 111111139.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7095), "Brand 28", null, "brand-28" },
                    { 111111140.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7108), "Brand 29", null, "brand-29" },
                    { 111111141.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7121), "Brand 30", null, "brand-30" },
                    { 111111142.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7135), "Brand 31", null, "brand-31" },
                    { 111111143.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7151), "Brand 32", null, "brand-32" },
                    { 111111144.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7221), "Brand 33", null, "brand-33" },
                    { 111111145.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7235), "Brand 34", null, "brand-34" },
                    { 111111146.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7248), "Brand 35", null, "brand-35" },
                    { 111111147.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7264), "Brand 36", null, "brand-36" },
                    { 111111148.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7277), "Brand 37", null, "brand-37" },
                    { 111111149.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7291), "Brand 38", null, "brand-38" },
                    { 111111150.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7304), "Brand 39", null, "brand-39" },
                    { 111111151.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7320), "Brand 40", null, "brand-40" },
                    { 111111152.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7333), "Brand 41", null, "brand-41" },
                    { 111111153.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7346), "Brand 42", null, "brand-42" },
                    { 111111154.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7359), "Brand 43", null, "brand-43" },
                    { 111111155.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7375), "Brand 44", null, "brand-44" },
                    { 111111156.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7388), "Brand 45", null, "brand-45" },
                    { 111111157.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7401), "Brand 46", null, "brand-46" },
                    { 111111158.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7414), "Brand 47", null, "brand-47" },
                    { 111111159.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7431), "Brand 48", null, "brand-48" },
                    { 111111160.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7444), "Brand 49", null, "brand-49" }
                });

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "CampaignId", "CampaignImage", "Code", "CreatedDate", "Description", "IsHome", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 111111111.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(875), "Description: 111111111", true, "Campaign 111111111", null },
                    { 111111112.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(897), "Description: 111111112", true, "Campaign 111111112", null },
                    { 111111113.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(964), "Description: 111111113", true, "Campaign 111111113", null },
                    { 111111114.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(985), "Description: 111111114", true, "Campaign 111111114", null },
                    { 111111115.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1002), "Description: 111111115", true, "Campaign 111111115", null },
                    { 111111116.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1017), "Description: 111111116", true, "Campaign 111111116", null },
                    { 111111117.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1032), "Description: 111111117", true, "Campaign 111111117", null },
                    { 111111118.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1045), "Description: 111111118", true, "Campaign 111111118", null },
                    { 111111119.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1061), "Description: 111111119", true, "Campaign 111111119", null },
                    { 111111120.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1079), "Description: 111111120", true, "Campaign 111111120", null },
                    { 111111121.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1093), "Description: 111111121", true, "Campaign 111111121", null },
                    { 111111122.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1106), "Description: 111111122", true, "Campaign 111111122", null },
                    { 111111123.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1123), "Description: 111111123", true, "Campaign 111111123", null },
                    { 111111124.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1137), "Description: 111111124", true, "Campaign 111111124", null },
                    { 111111125.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1151), "Description: 111111125", true, "Campaign 111111125", null },
                    { 111111126.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1165), "Description: 111111126", true, "Campaign 111111126", null },
                    { 111111127.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1183), "Description: 111111127", true, "Campaign 111111127", null },
                    { 111111128.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1259), "Description: 111111128", true, "Campaign 111111128", null },
                    { 111111129.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1279), "Description: 111111129", true, "Campaign 111111129", null },
                    { 111111130.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1292), "Description: 111111130", true, "Campaign 111111130", null },
                    { 111111131.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1308), "Description: 111111131", true, "Campaign 111111131", null },
                    { 111111132.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1326), "Description: 111111132", true, "Campaign 111111132", null },
                    { 111111133.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1339), "Description: 111111133", true, "Campaign 111111133", null },
                    { 111111134.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1352), "Description: 111111134", true, "Campaign 111111134", null },
                    { 111111135.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1368), "Description: 111111135", true, "Campaign 111111135", null },
                    { 111111136.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1383), "Description: 111111136", true, "Campaign 111111136", null },
                    { 111111137.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1396), "Description: 111111137", true, "Campaign 111111137", null },
                    { 111111138.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1410), "Description: 111111138", true, "Campaign 111111138", null },
                    { 111111139.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1426), "Description: 111111139", true, "Campaign 111111139", null },
                    { 111111140.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1440), "Description: 111111140", true, "Campaign 111111140", null },
                    { 111111141.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1453), "Description: 111111141", true, "Campaign 111111141", null },
                    { 111111142.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1466), "Description: 111111142", true, "Campaign 111111142", null },
                    { 111111143.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1488), "Description: 111111143", true, "Campaign 111111143", null },
                    { 111111144.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1639), "Description: 111111144", true, "Campaign 111111144", null },
                    { 111111145.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1665), "Description: 111111145", true, "Campaign 111111145", null },
                    { 111111146.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1688), "Description: 111111146", true, "Campaign 111111146", null },
                    { 111111147.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1716), "Description: 111111147", true, "Campaign 111111147", null },
                    { 111111148.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1737), "Description: 111111148", true, "Campaign 111111148", null },
                    { 111111149.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1763), "Description: 111111149", true, "Campaign 111111149", null },
                    { 111111150.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1787), "Description: 111111150", true, "Campaign 111111150", null },
                    { 111111151.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1812), "Description: 111111151", true, "Campaign 111111151", null },
                    { 111111152.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1839), "Description: 111111152", true, "Campaign 111111152", null },
                    { 111111153.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1861), "Description: 111111153", true, "Campaign 111111153", null },
                    { 111111154.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1885), "Description: 111111154", true, "Campaign 111111154", null },
                    { 111111155.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1913), "Description: 111111155", true, "Campaign 111111155", null },
                    { 111111156.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1935), "Description: 111111156", true, "Campaign 111111156", null },
                    { 111111157.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1956), "Description: 111111157", true, "Campaign 111111157", null },
                    { 111111158.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(1977), "Description: 111111158", true, "Campaign 111111158", null },
                    { 111111159.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(2187), "Description: 111111159", true, "Campaign 111111159", null },
                    { 111111160.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(2236), "Description: 111111160", true, "Campaign 111111160", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CreatedDate", "Name", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 111111111.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(4785), "Woman", null, "woman" },
                    { 111111112.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(4807), "Man", null, "man" },
                    { 111111113.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(4809), "Mom & Child", null, "mom-child" },
                    { 111111114.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(4811), "Home & Furniture", null, "home-furniture" },
                    { 111111115.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(4815), "Supermarket", null, "supermarket" },
                    { 111111116.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(4816), "Cosmetics", null, "cosmetics" },
                    { 111111117.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(4819), "Shoe & Bag", null, "shoe-bag" },
                    { 111111118.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(4821), "Electronics", null, "electronics" },
                    { 111111119.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(4824), "Sport & Outdoor", null, "sport-outdoor" },
                    { 111111120.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(4826), "Book & Instrument", null, "book-instrument" },
                    { 111111121.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(4954), "category 0", null, "category-0" },
                    { 111111122.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(4968), "category 1", null, "category-1" },
                    { 111111123.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(4981), "category 2", null, "category-2" },
                    { 111111124.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(4990), "category 3", null, "category-3" },
                    { 111111125.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5000), "category 4", null, "category-4" },
                    { 111111126.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5010), "category 5", null, "category-5" },
                    { 111111127.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5022), "category 6", null, "category-6" },
                    { 111111128.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5079), "category 7", null, "category-7" },
                    { 111111129.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5090), "category 8", null, "category-8" },
                    { 111111130.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5099), "category 9", null, "category-9" },
                    { 111111131.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5111), "category 10", null, "category-10" },
                    { 111111132.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5121), "category 11", null, "category-11" },
                    { 111111133.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5130), "category 12", null, "category-12" },
                    { 111111134.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5140), "category 13", null, "category-13" },
                    { 111111135.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5152), "category 14", null, "category-14" },
                    { 111111136.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5161), "category 15", null, "category-15" },
                    { 111111137.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5171), "category 16", null, "category-16" },
                    { 111111138.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5181), "category 17", null, "category-17" },
                    { 111111139.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5192), "category 18", null, "category-18" },
                    { 111111140.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5202), "category 19", null, "category-19" },
                    { 111111141.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5211), "category 20", null, "category-20" },
                    { 111111142.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5221), "category 21", null, "category-21" },
                    { 111111143.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5233), "category 22", null, "category-22" },
                    { 111111144.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5288), "category 23", null, "category-23" },
                    { 111111145.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5298), "category 24", null, "category-24" },
                    { 111111146.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5308), "category 25", null, "category-25" },
                    { 111111147.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5320), "category 26", null, "category-26" },
                    { 111111148.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5329), "category 27", null, "category-27" },
                    { 111111149.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5339), "category 28", null, "category-28" },
                    { 111111150.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5348), "category 29", null, "category-29" },
                    { 111111151.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5360), "category 30", null, "category-30" },
                    { 111111152.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5369), "category 31", null, "category-31" },
                    { 111111153.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5379), "category 32", null, "category-32" },
                    { 111111154.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5388), "category 33", null, "category-33" },
                    { 111111155.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5400), "category 34", null, "category-34" },
                    { 111111156.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5409), "category 35", null, "category-35" },
                    { 111111157.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5419), "category 36", null, "category-36" },
                    { 111111158.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5428), "category 37", null, "category-37" },
                    { 111111159.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5440), "category 38", null, "category-38" },
                    { 111111160.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5449), "category 39", null, "category-39" }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreId", "CommentCount", "CreatedDate", "IsApproved", "SellerEmail", "SellerFirstName", "SellerId", "SellerLastName", "SellerPhone", "StarCount", "StoreImage", "StoreName", "StoreRate", "StoreUrl", "UpdatedDate" },
                values: new object[,]
                {
                    { 111111111.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9843), false, null, null, null, null, null, 1m, "1.jpg", "store 0", 1m, "store-0", null },
                    { 111111112.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9864), false, null, null, null, null, null, 1m, "1.jpg", "store 1", 1m, "store-1", null },
                    { 111111113.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9879), false, null, null, null, null, null, 1m, "1.jpg", "store 2", 1m, "store-2", null },
                    { 111111114.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9892), false, null, null, null, null, null, 1m, "1.jpg", "store 3", 1m, "store-3", null },
                    { 111111115.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9903), false, null, null, null, null, null, 1m, "1.jpg", "store 4", 1m, "store-4", null },
                    { 111111116.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9916), false, null, null, null, null, null, 1m, "1.jpg", "store 5", 1m, "store-5", null },
                    { 111111117.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9931), false, null, null, null, null, null, 1m, "1.jpg", "store 6", 1m, "store-6", null },
                    { 111111118.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9943), false, null, null, null, null, null, 1m, "1.jpg", "store 7", 1m, "store-7", null },
                    { 111111119.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9956), false, null, null, null, null, null, 1m, "1.jpg", "store 8", 1m, "store-8", null },
                    { 111111120.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9969), false, null, null, null, null, null, 1m, "1.jpg", "store 9", 1m, "store-9", null },
                    { 111111121.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9984), false, null, null, null, null, null, 1m, "1.jpg", "store 10", 1m, "store-10", null },
                    { 111111122.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9996), false, null, null, null, null, null, 1m, "1.jpg", "store 11", 1m, "store-11", null },
                    { 111111123.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(60), false, null, null, null, null, null, 1m, "1.jpg", "store 12", 1m, "store-12", null },
                    { 111111124.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(74), false, null, null, null, null, null, 1m, "1.jpg", "store 13", 1m, "store-13", null },
                    { 111111125.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(88), false, null, null, null, null, null, 1m, "1.jpg", "store 14", 1m, "store-14", null },
                    { 111111126.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(101), false, null, null, null, null, null, 1m, "1.jpg", "store 15", 1m, "store-15", null },
                    { 111111127.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(112), false, null, null, null, null, null, 1m, "1.jpg", "store 16", 1m, "store-16", null },
                    { 111111128.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(125), false, null, null, null, null, null, 1m, "1.jpg", "store 17", 1m, "store-17", null },
                    { 111111129.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(140), false, null, null, null, null, null, 1m, "1.jpg", "store 18", 1m, "store-18", null },
                    { 111111130.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(153), false, null, null, null, null, null, 1m, "1.jpg", "store 19", 1m, "store-19", null },
                    { 111111131.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(164), false, null, null, null, null, null, 1m, "1.jpg", "store 20", 1m, "store-20", null },
                    { 111111132.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(176), false, null, null, null, null, null, 1m, "1.jpg", "store 21", 1m, "store-21", null },
                    { 111111133.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(191), false, null, null, null, null, null, 1m, "1.jpg", "store 22", 1m, "store-22", null },
                    { 111111134.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(203), false, null, null, null, null, null, 1m, "1.jpg", "store 23", 1m, "store-23", null },
                    { 111111135.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(215), false, null, null, null, null, null, 1m, "1.jpg", "store 24", 1m, "store-24", null },
                    { 111111136.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(272), false, null, null, null, null, null, 1m, "1.jpg", "store 25", 1m, "store-25", null },
                    { 111111137.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(290), false, null, null, null, null, null, 1m, "1.jpg", "store 26", 1m, "store-26", null },
                    { 111111138.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(303), false, null, null, null, null, null, 1m, "1.jpg", "store 27", 1m, "store-27", null },
                    { 111111139.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(317), false, null, null, null, null, null, 1m, "1.jpg", "store 28", 1m, "store-28", null },
                    { 111111140.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(329), false, null, null, null, null, null, 1m, "1.jpg", "store 29", 1m, "store-29", null },
                    { 111111141.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(344), false, null, null, null, null, null, 1m, "1.jpg", "store 30", 1m, "store-30", null },
                    { 111111142.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(356), false, null, null, null, null, null, 1m, "1.jpg", "store 31", 1m, "store-31", null },
                    { 111111143.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(368), false, null, null, null, null, null, 1m, "1.jpg", "store 32", 1m, "store-32", null },
                    { 111111144.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(381), false, null, null, null, null, null, 1m, "1.jpg", "store 33", 1m, "store-33", null },
                    { 111111145.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(395), false, null, null, null, null, null, 1m, "1.jpg", "store 34", 1m, "store-34", null },
                    { 111111146.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(408), false, null, null, null, null, null, 1m, "1.jpg", "store 35", 1m, "store-35", null },
                    { 111111147.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(419), false, null, null, null, null, null, 1m, "1.jpg", "store 36", 1m, "store-36", null },
                    { 111111148.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(431), false, null, null, null, null, null, 1m, "1.jpg", "store 37", 1m, "store-37", null },
                    { 111111149.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(496), false, null, null, null, null, null, 1m, "1.jpg", "store 38", 1m, "store-38", null },
                    { 111111150.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(510), false, null, null, null, null, null, 1m, "1.jpg", "store 39", 1m, "store-39", null },
                    { 111111151.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(522), false, null, null, null, null, null, 1m, "1.jpg", "store 40", 1m, "store-40", null },
                    { 111111152.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(534), false, null, null, null, null, null, 1m, "1.jpg", "store 41", 1m, "store-41", null },
                    { 111111153.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(549), false, null, null, null, null, null, 1m, "1.jpg", "store 42", 1m, "store-42", null },
                    { 111111154.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(563), false, null, null, null, null, null, 1m, "1.jpg", "store 43", 1m, "store-43", null },
                    { 111111155.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(575), false, null, null, null, null, null, 1m, "1.jpg", "store 44", 1m, "store-44", null },
                    { 111111156.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(587), false, null, null, null, null, null, 1m, "1.jpg", "store 45", 1m, "store-45", null },
                    { 111111157.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(801), false, null, null, null, null, null, 1m, "1.jpg", "store 46", 1m, "store-46", null },
                    { 111111158.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(817), false, null, null, null, null, null, 1m, "1.jpg", "store 47", 1m, "store-47", null },
                    { 111111159.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(832), false, null, null, null, null, null, 1m, "1.jpg", "store 48", 1m, "store-48", null },
                    { 111111160.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(846), false, null, null, null, null, null, 1m, "1.jpg", "store 49", 1m, "store-49", null }
                });

            migrationBuilder.InsertData(
                table: "Categories2",
                columns: new[] { "Category2Id", "CategoryId", "CreatedDate", "Name", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 111111111.0, 111111111.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5541), "category2 0", null, "category2-0" },
                    { 111111112.0, 111111112.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5563), "category2 1", null, "category2-1" },
                    { 111111113.0, 111111113.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5576), "category2 2", null, "category2-2" },
                    { 111111114.0, 111111114.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5586), "category2 3", null, "category2-3" },
                    { 111111115.0, 111111115.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5596), "category2 4", null, "category2-4" },
                    { 111111116.0, 111111116.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5606), "category2 5", null, "category2-5" },
                    { 111111117.0, 111111117.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5618), "category2 6", null, "category2-6" },
                    { 111111118.0, 111111118.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5627), "category2 7", null, "category2-7" },
                    { 111111119.0, 111111119.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5637), "category2 8", null, "category2-8" },
                    { 111111120.0, 111111120.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5648), "category2 9", null, "category2-9" },
                    { 111111121.0, 111111121.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5660), "category2 10", null, "category2-10" },
                    { 111111122.0, 111111122.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5670), "category2 11", null, "category2-11" },
                    { 111111123.0, 111111123.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5679), "category2 12", null, "category2-12" },
                    { 111111124.0, 111111124.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5688), "category2 13", null, "category2-13" },
                    { 111111125.0, 111111125.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5700), "category2 14", null, "category2-14" },
                    { 111111126.0, 111111126.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5710), "category2 15", null, "category2-15" },
                    { 111111127.0, 111111127.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5760), "category2 16", null, "category2-16" },
                    { 111111128.0, 111111128.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5772), "category2 17", null, "category2-17" },
                    { 111111129.0, 111111129.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5980), "category2 18", null, "category2-18" },
                    { 111111130.0, 111111130.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(5993), "category2 19", null, "category2-19" },
                    { 111111131.0, 111111131.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6004), "category2 20", null, "category2-20" },
                    { 111111132.0, 111111132.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6016), "category2 21", null, "category2-21" },
                    { 111111133.0, 111111133.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6030), "category2 22", null, "category2-22" },
                    { 111111134.0, 111111134.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6042), "category2 23", null, "category2-23" },
                    { 111111135.0, 111111135.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6053), "category2 24", null, "category2-24" },
                    { 111111136.0, 111111136.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6064), "category2 25", null, "category2-25" },
                    { 111111137.0, 111111137.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6078), "category2 26", null, "category2-26" },
                    { 111111138.0, 111111138.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6090), "category2 27", null, "category2-27" },
                    { 111111139.0, 111111139.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6102), "category2 28", null, "category2-28" },
                    { 111111140.0, 111111140.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6113), "category2 29", null, "category2-29" },
                    { 111111141.0, 111111141.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6126), "category2 30", null, "category2-30" },
                    { 111111142.0, 111111142.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6138), "category2 31", null, "category2-31" },
                    { 111111143.0, 111111143.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6149), "category2 32", null, "category2-32" },
                    { 111111144.0, 111111144.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6217), "category2 33", null, "category2-33" },
                    { 111111145.0, 111111145.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6232), "category2 34", null, "category2-34" },
                    { 111111146.0, 111111146.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6243), "category2 35", null, "category2-35" },
                    { 111111147.0, 111111147.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6255), "category2 36", null, "category2-36" },
                    { 111111148.0, 111111148.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6266), "category2 37", null, "category2-37" },
                    { 111111149.0, 111111149.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6280), "category2 38", null, "category2-38" },
                    { 111111150.0, 111111150.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6292), "category2 39", null, "category2-39" },
                    { 111111151.0, 111111151.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6304), "category2 40", null, "category2-40" },
                    { 111111152.0, 111111152.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6315), "category2 41", null, "category2-41" },
                    { 111111153.0, 111111153.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6329), "category2 42", null, "category2-42" },
                    { 111111154.0, 111111154.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6341), "category2 43", null, "category2-43" },
                    { 111111155.0, 111111155.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6352), "category2 44", null, "category2-44" },
                    { 111111156.0, 111111156.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6364), "category2 45", null, "category2-45" },
                    { 111111157.0, 111111157.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6378), "category2 46", null, "category2-46" },
                    { 111111158.0, 111111158.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6390), "category2 47", null, "category2-47" },
                    { 111111159.0, 111111159.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6452), "category2 48", null, "category2-48" },
                    { 111111160.0, 111111160.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(6465), "category2 49", null, "category2-49" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "BrandId", "Category2Id", "CategoryId", "CommentCount", "CreatedDate", "Description", "IsApproved", "IsHome", "Name", "Price", "ProductImage", "ProductRate", "Quantity", "SalesCount", "StarCount", "StoreId", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 111111111.0, 111111111.0, 111111111.0, 111111111.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7683), "urun aciklamasi 0", true, true, "urun 0", 10m, "1.jpg", 1m, 0, 0, 1, 111111111.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7684), "urun-0" },
                    { 111111112.0, 111111112.0, 111111112.0, 111111112.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7725), "urun aciklamasi 1", true, true, "urun 1", 10m, "1.jpg", 1m, 1, 1, 1, 111111112.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7726), "urun-1" },
                    { 111111113.0, 111111113.0, 111111113.0, 111111113.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7745), "urun aciklamasi 2", true, true, "urun 2", 10m, "1.jpg", 1m, 2, 2, 1, 111111113.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7746), "urun-2" },
                    { 111111114.0, 111111114.0, 111111114.0, 111111114.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7760), "urun aciklamasi 3", true, true, "urun 3", 10m, "1.jpg", 1m, 3, 3, 1, 111111114.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7760), "urun-3" },
                    { 111111115.0, 111111115.0, 111111115.0, 111111115.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7775), "urun aciklamasi 4", true, true, "urun 4", 10m, "1.jpg", 1m, 4, 4, 1, 111111115.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7775), "urun-4" },
                    { 111111116.0, 111111116.0, 111111116.0, 111111116.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7790), "urun aciklamasi 5", true, true, "urun 5", 10m, "1.jpg", 1m, 5, 5, 1, 111111116.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7791), "urun-5" },
                    { 111111117.0, 111111117.0, 111111117.0, 111111117.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7808), "urun aciklamasi 6", true, true, "urun 6", 10m, "1.jpg", 1m, 6, 6, 1, 111111117.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7809), "urun-6" },
                    { 111111118.0, 111111118.0, 111111118.0, 111111118.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7823), "urun aciklamasi 7", true, true, "urun 7", 10m, "1.jpg", 1m, 7, 7, 1, 111111118.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7823), "urun-7" },
                    { 111111119.0, 111111119.0, 111111119.0, 111111119.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7837), "urun aciklamasi 8", true, true, "urun 8", 10m, "1.jpg", 1m, 8, 8, 1, 111111119.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7838), "urun-8" },
                    { 111111120.0, 111111120.0, 111111120.0, 111111120.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7853), "urun aciklamasi 9", true, true, "urun 9", 10m, "1.jpg", 1m, 9, 9, 1, 111111120.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7854), "urun-9" },
                    { 111111121.0, 111111121.0, 111111121.0, 111111121.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7871), "urun aciklamasi 10", true, true, "urun 10", 10m, "1.jpg", 1m, 10, 10, 1, 111111121.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(7872), "urun-10" },
                    { 111111122.0, 111111122.0, 111111122.0, 111111122.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8062), "urun aciklamasi 11", true, true, "urun 11", 10m, "1.jpg", 1m, 11, 11, 1, 111111122.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8062), "urun-11" },
                    { 111111123.0, 111111123.0, 111111123.0, 111111123.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8079), "urun aciklamasi 12", true, true, "urun 12", 10m, "1.jpg", 1m, 12, 12, 1, 111111123.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8079), "urun-12" },
                    { 111111124.0, 111111124.0, 111111124.0, 111111124.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8093), "urun aciklamasi 13", true, true, "urun 13", 10m, "1.jpg", 1m, 13, 13, 1, 111111124.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8094), "urun-13" },
                    { 111111125.0, 111111125.0, 111111125.0, 111111125.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8112), "urun aciklamasi 14", true, true, "urun 14", 10m, "1.jpg", 1m, 14, 14, 1, 111111125.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8112), "urun-14" },
                    { 111111126.0, 111111126.0, 111111126.0, 111111126.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8126), "urun aciklamasi 15", true, true, "urun 15", 10m, "1.jpg", 1m, 15, 15, 1, 111111126.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8127), "urun-15" },
                    { 111111127.0, 111111127.0, 111111127.0, 111111127.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8140), "urun aciklamasi 16", true, true, "urun 16", 10m, "1.jpg", 1m, 16, 16, 1, 111111127.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8141), "urun-16" },
                    { 111111128.0, 111111128.0, 111111128.0, 111111128.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8157), "urun aciklamasi 17", true, true, "urun 17", 10m, "1.jpg", 1m, 17, 17, 1, 111111128.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8157), "urun-17" },
                    { 111111129.0, 111111129.0, 111111129.0, 111111129.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8178), "urun aciklamasi 18", true, true, "urun 18", 10m, "1.jpg", 1m, 18, 18, 1, 111111129.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8178), "urun-18" },
                    { 111111130.0, 111111130.0, 111111130.0, 111111130.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8193), "urun aciklamasi 19", true, true, "urun 19", 10m, "1.jpg", 1m, 19, 19, 1, 111111130.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8193), "urun-19" },
                    { 111111131.0, 111111131.0, 111111131.0, 111111131.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8207), "urun aciklamasi 20", true, true, "urun 20", 10m, "1.jpg", 1m, 20, 20, 1, 111111131.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8208), "urun-20" },
                    { 111111132.0, 111111132.0, 111111132.0, 111111132.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8221), "urun aciklamasi 21", true, true, "urun 21", 10m, "1.jpg", 1m, 21, 21, 1, 111111132.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8222), "urun-21" },
                    { 111111133.0, 111111133.0, 111111133.0, 111111133.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8291), "urun aciklamasi 22", true, true, "urun 22", 10m, "1.jpg", 1m, 22, 22, 1, 111111133.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8292), "urun-22" },
                    { 111111134.0, 111111134.0, 111111134.0, 111111134.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8308), "urun aciklamasi 23", true, true, "urun 23", 10m, "1.jpg", 1m, 23, 23, 1, 111111134.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8308), "urun-23" },
                    { 111111135.0, 111111135.0, 111111135.0, 111111135.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8322), "urun aciklamasi 24", true, true, "urun 24", 10m, "1.jpg", 1m, 24, 24, 1, 111111135.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8323), "urun-24" },
                    { 111111136.0, 111111136.0, 111111136.0, 111111136.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8337), "urun aciklamasi 25", true, true, "urun 25", 10m, "1.jpg", 1m, 25, 25, 1, 111111136.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8338), "urun-25" },
                    { 111111137.0, 111111137.0, 111111137.0, 111111137.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8355), "urun aciklamasi 26", true, true, "urun 26", 10m, "1.jpg", 1m, 26, 26, 1, 111111137.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8356), "urun-26" },
                    { 111111138.0, 111111138.0, 111111138.0, 111111138.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8370), "urun aciklamasi 27", true, true, "urun 27", 10m, "1.jpg", 1m, 27, 27, 1, 111111138.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8370), "urun-27" },
                    { 111111139.0, 111111139.0, 111111139.0, 111111139.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8384), "urun aciklamasi 28", true, true, "urun 28", 10m, "1.jpg", 1m, 28, 28, 1, 111111139.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8384), "urun-28" },
                    { 111111140.0, 111111140.0, 111111140.0, 111111140.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8399), "urun aciklamasi 29", true, true, "urun 29", 10m, "1.jpg", 1m, 29, 29, 1, 111111140.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8399), "urun-29" },
                    { 111111141.0, 111111141.0, 111111141.0, 111111141.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8416), "urun aciklamasi 30", true, true, "urun 30", 10m, "1.jpg", 1m, 30, 30, 1, 111111141.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8417), "urun-30" },
                    { 111111142.0, 111111142.0, 111111142.0, 111111142.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8432), "urun aciklamasi 31", true, true, "urun 31", 10m, "1.jpg", 1m, 31, 31, 1, 111111142.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8432), "urun-31" },
                    { 111111143.0, 111111143.0, 111111143.0, 111111143.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8447), "urun aciklamasi 32", true, true, "urun 32", 10m, "1.jpg", 1m, 32, 32, 1, 111111143.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8447), "urun-32" },
                    { 111111144.0, 111111144.0, 111111144.0, 111111144.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8505), "urun aciklamasi 33", true, true, "urun 33", 10m, "1.jpg", 1m, 33, 33, 1, 111111144.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8506), "urun-33" },
                    { 111111145.0, 111111145.0, 111111145.0, 111111145.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8523), "urun aciklamasi 34", true, true, "urun 34", 10m, "1.jpg", 1m, 34, 34, 1, 111111145.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8524), "urun-34" },
                    { 111111146.0, 111111146.0, 111111146.0, 111111146.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8538), "urun aciklamasi 35", true, true, "urun 35", 10m, "1.jpg", 1m, 35, 35, 1, 111111146.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8734), "urun-35" },
                    { 111111147.0, 111111147.0, 111111147.0, 111111147.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8757), "urun aciklamasi 36", true, true, "urun 36", 10m, "1.jpg", 1m, 36, 36, 1, 111111147.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8758), "urun-36" },
                    { 111111148.0, 111111148.0, 111111148.0, 111111148.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8774), "urun aciklamasi 37", true, true, "urun 37", 10m, "1.jpg", 1m, 37, 37, 1, 111111148.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8775), "urun-37" },
                    { 111111149.0, 111111149.0, 111111149.0, 111111149.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8795), "urun aciklamasi 38", true, true, "urun 38", 10m, "1.jpg", 1m, 38, 38, 1, 111111149.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8796), "urun-38" },
                    { 111111150.0, 111111150.0, 111111150.0, 111111150.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8813), "urun aciklamasi 39", true, true, "urun 39", 10m, "1.jpg", 1m, 39, 39, 1, 111111150.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8813), "urun-39" },
                    { 111111151.0, 111111151.0, 111111151.0, 111111151.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8830), "urun aciklamasi 40", true, true, "urun 40", 10m, "1.jpg", 1m, 40, 40, 1, 111111151.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8831), "urun-40" },
                    { 111111152.0, 111111152.0, 111111152.0, 111111152.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8847), "urun aciklamasi 41", true, true, "urun 41", 10m, "1.jpg", 1m, 41, 41, 1, 111111152.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8848), "urun-41" },
                    { 111111153.0, 111111153.0, 111111153.0, 111111153.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8867), "urun aciklamasi 42", true, true, "urun 42", 10m, "1.jpg", 1m, 42, 42, 1, 111111153.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8868), "urun-42" },
                    { 111111154.0, 111111154.0, 111111154.0, 111111154.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8884), "urun aciklamasi 43", true, true, "urun 43", 10m, "1.jpg", 1m, 43, 43, 1, 111111154.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8885), "urun-43" },
                    { 111111155.0, 111111155.0, 111111155.0, 111111155.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8954), "urun aciklamasi 44", true, true, "urun 44", 10m, "1.jpg", 1m, 44, 44, 1, 111111155.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8955), "urun-44" },
                    { 111111156.0, 111111156.0, 111111156.0, 111111156.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8972), "urun aciklamasi 45", true, true, "urun 45", 10m, "1.jpg", 1m, 45, 45, 1, 111111156.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8973), "urun-45" },
                    { 111111157.0, 111111157.0, 111111157.0, 111111157.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8993), "urun aciklamasi 46", true, true, "urun 46", 10m, "1.jpg", 1m, 46, 46, 1, 111111157.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(8994), "urun-46" },
                    { 111111158.0, 111111158.0, 111111158.0, 111111158.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9011), "urun aciklamasi 47", true, true, "urun 47", 10m, "1.jpg", 1m, 47, 47, 1, 111111158.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9011), "urun-47" },
                    { 111111159.0, 111111159.0, 111111159.0, 111111159.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9028), "urun aciklamasi 48", true, true, "urun 48", 10m, "1.jpg", 1m, 48, 48, 1, 111111159.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9029), "urun-48" },
                    { 111111160.0, 111111160.0, 111111160.0, 111111160.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9045), "urun aciklamasi 49", true, true, "urun 49", 10m, "1.jpg", 1m, 49, 49, 1, 111111160.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9046), "urun-49" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "CommentRate", "CreatedDate", "Description", "ProductId", "SellerAnswer", "StoreId", "UpdatedDate", "UserFirstname", "UserId", "UserLastname" },
                values: new object[,]
                {
                    { 111111111.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(2315), "description - 0", 111111111.0, "seller answer - 0", 111111111.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111112.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(2421), "description - 1", 111111112.0, "seller answer - 1", 111111112.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111113.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(2498), "description - 2", 111111113.0, "seller answer - 2", 111111113.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111114.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(2536), "description - 3", 111111114.0, "seller answer - 3", 111111114.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111115.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(2554), "description - 4", 111111115.0, "seller answer - 4", 111111115.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111116.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(2576), "description - 5", 111111116.0, "seller answer - 5", 111111116.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111117.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(2595), "description - 6", 111111117.0, "seller answer - 6", 111111117.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111118.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(2611), "description - 7", 111111118.0, "seller answer - 7", 111111118.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111119.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(2626), "description - 8", 111111119.0, "seller answer - 8", 111111119.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111120.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(2644), "description - 9", 111111120.0, "seller answer - 9", 111111120.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111121.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(2666), "description - 10", 111111121.0, "seller answer - 10", 111111121.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111122.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(2684), "description - 11", 111111122.0, "seller answer - 11", 111111122.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111123.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(2764), "description - 12", 111111123.0, "seller answer - 12", 111111123.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111124.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(2785), "description - 13", 111111124.0, "seller answer - 13", 111111124.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111125.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(2805), "description - 14", 111111125.0, "seller answer - 14", 111111125.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111126.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(2821), "description - 15", 111111126.0, "seller answer - 15", 111111126.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111127.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(2836), "description - 16", 111111127.0, "seller answer - 16", 111111127.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111128.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(2852), "description - 17", 111111128.0, "seller answer - 17", 111111128.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111129.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(2869), "description - 18", 111111129.0, "seller answer - 18", 111111129.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111130.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(2884), "description - 19", 111111130.0, "seller answer - 19", 111111130.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111131.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(2901), "description - 20", 111111131.0, "seller answer - 20", 111111131.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111132.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(2914), "description - 21", 111111132.0, "seller answer - 21", 111111132.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111133.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(2930), "description - 22", 111111133.0, "seller answer - 22", 111111133.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111134.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(2944), "description - 23", 111111134.0, "seller answer - 23", 111111134.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111135.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(2957), "description - 24", 111111135.0, "seller answer - 24", 111111135.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111136.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(2971), "description - 25", 111111136.0, "seller answer - 25", 111111136.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111137.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(2988), "description - 26", 111111137.0, "seller answer - 26", 111111137.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111138.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(3072), "description - 27", 111111138.0, "seller answer - 27", 111111138.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111139.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(3099), "description - 28", 111111139.0, "seller answer - 28", 111111139.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111140.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(3123), "description - 29", 111111140.0, "seller answer - 29", 111111140.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111141.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(3151), "description - 30", 111111141.0, "seller answer - 30", 111111141.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111142.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(3177), "description - 31", 111111142.0, "seller answer - 31", 111111142.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111143.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(3203), "description - 32", 111111143.0, "seller answer - 32", 111111143.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111144.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(3296), "description - 33", 111111144.0, "seller answer - 33", 111111144.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111145.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(3332), "description - 34", 111111145.0, "seller answer - 34", 111111145.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111146.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(3358), "description - 35", 111111146.0, "seller answer - 35", 111111146.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111147.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(3382), "description - 36", 111111147.0, "seller answer - 36", 111111147.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111148.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(3405), "description - 37", 111111148.0, "seller answer - 37", 111111148.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111149.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(3432), "description - 38", 111111149.0, "seller answer - 38", 111111149.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111150.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(3455), "description - 39", 111111150.0, "seller answer - 39", 111111150.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111151.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(3483), "description - 40", 111111151.0, "seller answer - 40", 111111151.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111152.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(3760), "description - 41", 111111152.0, "seller answer - 41", 111111152.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111153.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(3806), "description - 42", 111111153.0, "seller answer - 42", 111111153.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111154.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(3826), "description - 43", 111111154.0, "seller answer - 43", 111111154.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111155.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(4049), "description - 44", 111111155.0, "seller answer - 44", 111111155.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111156.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(4121), "description - 45", 111111156.0, "seller answer - 45", 111111156.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111157.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(4204), "description - 46", 111111157.0, "seller answer - 46", 111111157.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111158.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(4231), "description - 47", 111111158.0, "seller answer - 47", 111111158.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111159.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(4250), "description - 48", 111111159.0, "seller answer - 48", 111111159.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111160.0, 1, new DateTime(2023, 9, 18, 17, 46, 50, 914, DateTimeKind.Local).AddTicks(4265), "description - 49", 111111160.0, "seller answer - 49", 111111160.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" }
                });

            migrationBuilder.InsertData(
                table: "ImageUrls",
                columns: new[] { "ImageUrlId", "CreatedDate", "ProductId", "StoreId", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 111111111.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9071), 111111111.0, 111111111.0, null, "1.jpg" },
                    { 111111112.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9090), 111111112.0, 111111112.0, null, "1.jpg" },
                    { 111111113.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9101), 111111113.0, 111111113.0, null, "1.jpg" },
                    { 111111114.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9111), 111111114.0, 111111114.0, null, "1.jpg" },
                    { 111111115.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9124), 111111115.0, 111111115.0, null, "1.jpg" },
                    { 111111116.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9135), 111111116.0, 111111116.0, null, "1.jpg" },
                    { 111111117.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9145), 111111117.0, 111111117.0, null, "1.jpg" },
                    { 111111118.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9154), 111111118.0, 111111118.0, null, "1.jpg" },
                    { 111111119.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9167), 111111119.0, 111111119.0, null, "1.jpg" },
                    { 111111120.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9381), 111111120.0, 111111120.0, null, "1.jpg" },
                    { 111111121.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9390), 111111121.0, 111111121.0, null, "1.jpg" },
                    { 111111122.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9398), 111111122.0, 111111122.0, null, "1.jpg" },
                    { 111111123.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9410), 111111123.0, 111111123.0, null, "1.jpg" },
                    { 111111124.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9419), 111111124.0, 111111124.0, null, "1.jpg" },
                    { 111111125.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9428), 111111125.0, 111111125.0, null, "1.jpg" },
                    { 111111126.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9436), 111111126.0, 111111126.0, null, "1.jpg" },
                    { 111111127.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9447), 111111127.0, 111111127.0, null, "1.jpg" },
                    { 111111128.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9457), 111111128.0, 111111128.0, null, "1.jpg" },
                    { 111111129.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9465), 111111129.0, 111111129.0, null, "1.jpg" },
                    { 111111130.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9474), 111111130.0, 111111130.0, null, "1.jpg" },
                    { 111111131.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9485), 111111131.0, 111111131.0, null, "1.jpg" },
                    { 111111132.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9494), 111111132.0, 111111132.0, null, "1.jpg" },
                    { 111111133.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9502), 111111133.0, 111111133.0, null, "1.jpg" },
                    { 111111134.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9510), 111111134.0, 111111134.0, null, "1.jpg" },
                    { 111111135.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9522), 111111135.0, 111111135.0, null, "1.jpg" },
                    { 111111136.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9530), 111111136.0, 111111136.0, null, "1.jpg" },
                    { 111111137.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9538), 111111137.0, 111111137.0, null, "1.jpg" },
                    { 111111138.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9546), 111111138.0, 111111138.0, null, "1.jpg" },
                    { 111111139.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9598), 111111139.0, 111111139.0, null, "1.jpg" },
                    { 111111140.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9608), 111111140.0, 111111140.0, null, "1.jpg" },
                    { 111111141.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9616), 111111141.0, 111111141.0, null, "1.jpg" },
                    { 111111142.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9624), 111111142.0, 111111142.0, null, "1.jpg" },
                    { 111111143.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9635), 111111143.0, 111111143.0, null, "1.jpg" },
                    { 111111144.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9645), 111111144.0, 111111144.0, null, "1.jpg" },
                    { 111111145.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9653), 111111145.0, 111111145.0, null, "1.jpg" },
                    { 111111146.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9661), 111111146.0, 111111146.0, null, "1.jpg" },
                    { 111111147.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9672), 111111147.0, 111111147.0, null, "1.jpg" },
                    { 111111148.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9680), 111111148.0, 111111148.0, null, "1.jpg" },
                    { 111111149.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9688), 111111149.0, 111111149.0, null, "1.jpg" },
                    { 111111150.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9696), 111111150.0, 111111150.0, null, "1.jpg" },
                    { 111111151.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9707), 111111151.0, 111111151.0, null, "1.jpg" },
                    { 111111152.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9716), 111111152.0, 111111152.0, null, "1.jpg" },
                    { 111111153.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9724), 111111153.0, 111111153.0, null, "1.jpg" },
                    { 111111154.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9732), 111111154.0, 111111154.0, null, "1.jpg" },
                    { 111111155.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9743), 111111155.0, 111111155.0, null, "1.jpg" },
                    { 111111156.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9752), 111111156.0, 111111156.0, null, "1.jpg" },
                    { 111111157.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9760), 111111157.0, 111111157.0, null, "1.jpg" },
                    { 111111158.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9810), 111111158.0, 111111158.0, null, "1.jpg" },
                    { 111111159.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9822), 111111159.0, 111111159.0, null, "1.jpg" },
                    { 111111160.0, new DateTime(2023, 9, 18, 17, 46, 50, 913, DateTimeKind.Local).AddTicks(9830), 111111160.0, 111111160.0, null, "1.jpg" }
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
