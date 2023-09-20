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
                    DiscountPercentage = table.Column<int>(type: "int", nullable: false),
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
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    { 111111111.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7958), "Brand 0", null, "brand-0" },
                    { 111111112.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7973), "Brand 1", null, "brand-1" },
                    { 111111113.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7984), "Brand 2", null, "brand-2" },
                    { 111111114.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8042), "Brand 3", null, "brand-3" },
                    { 111111115.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8058), "Brand 4", null, "brand-4" },
                    { 111111116.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8070), "Brand 5", null, "brand-5" },
                    { 111111117.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8081), "Brand 6", null, "brand-6" },
                    { 111111118.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8091), "Brand 7", null, "brand-7" },
                    { 111111119.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8104), "Brand 8", null, "brand-8" },
                    { 111111120.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8116), "Brand 9", null, "brand-9" },
                    { 111111121.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8127), "Brand 10", null, "brand-10" },
                    { 111111122.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8137), "Brand 11", null, "brand-11" },
                    { 111111123.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8150), "Brand 12", null, "brand-12" },
                    { 111111124.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8160), "Brand 13", null, "brand-13" },
                    { 111111125.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8171), "Brand 14", null, "brand-14" },
                    { 111111126.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8181), "Brand 15", null, "brand-15" },
                    { 111111127.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8194), "Brand 16", null, "brand-16" },
                    { 111111128.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8206), "Brand 17", null, "brand-17" },
                    { 111111129.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8216), "Brand 18", null, "brand-18" },
                    { 111111130.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8226), "Brand 19", null, "brand-19" },
                    { 111111131.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8285), "Brand 20", null, "brand-20" },
                    { 111111132.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8298), "Brand 21", null, "brand-21" },
                    { 111111133.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8309), "Brand 22", null, "brand-22" },
                    { 111111134.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8320), "Brand 23", null, "brand-23" },
                    { 111111135.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8333), "Brand 24", null, "brand-24" },
                    { 111111136.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8343), "Brand 25", null, "brand-25" },
                    { 111111137.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8353), "Brand 26", null, "brand-26" },
                    { 111111138.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8364), "Brand 27", null, "brand-27" },
                    { 111111139.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8377), "Brand 28", null, "brand-28" },
                    { 111111140.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8387), "Brand 29", null, "brand-29" },
                    { 111111141.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8397), "Brand 30", null, "brand-30" },
                    { 111111142.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8407), "Brand 31", null, "brand-31" },
                    { 111111143.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8420), "Brand 32", null, "brand-32" },
                    { 111111144.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8432), "Brand 33", null, "brand-33" },
                    { 111111145.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8442), "Brand 34", null, "brand-34" },
                    { 111111146.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8452), "Brand 35", null, "brand-35" },
                    { 111111147.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8466), "Brand 36", null, "brand-36" },
                    { 111111148.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8521), "Brand 37", null, "brand-37" },
                    { 111111149.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8533), "Brand 38", null, "brand-38" },
                    { 111111150.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8544), "Brand 39", null, "brand-39" },
                    { 111111151.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8557), "Brand 40", null, "brand-40" },
                    { 111111152.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8567), "Brand 41", null, "brand-41" },
                    { 111111153.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8578), "Brand 42", null, "brand-42" },
                    { 111111154.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8588), "Brand 43", null, "brand-43" },
                    { 111111155.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8601), "Brand 44", null, "brand-44" },
                    { 111111156.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8612), "Brand 45", null, "brand-45" },
                    { 111111157.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8622), "Brand 46", null, "brand-46" },
                    { 111111158.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8633), "Brand 47", null, "brand-47" },
                    { 111111159.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8646), "Brand 48", null, "brand-48" },
                    { 111111160.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8656), "Brand 49", null, "brand-49" }
                });

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "CampaignId", "CampaignImage", "Code", "CreatedDate", "Description", "DiscountPercentage", "IsApproved", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 111111111.0, "1.jpg", "campaign-code-111111111", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1092), "Description: 111111111", 1, false, "Campaign 111111111", null },
                    { 111111112.0, "1.jpg", "campaign-code-111111112", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1110), "Description: 111111112", 2, false, "Campaign 111111112", null },
                    { 111111113.0, "1.jpg", "campaign-code-111111113", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1122), "Description: 111111113", 3, false, "Campaign 111111113", null },
                    { 111111114.0, "1.jpg", "campaign-code-111111114", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1134), "Description: 111111114", 4, false, "Campaign 111111114", null },
                    { 111111115.0, "1.jpg", "campaign-code-111111115", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1149), "Description: 111111115", 5, false, "Campaign 111111115", null },
                    { 111111116.0, "1.jpg", "campaign-code-111111116", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1162), "Description: 111111116", 6, false, "Campaign 111111116", null },
                    { 111111117.0, "1.jpg", "campaign-code-111111117", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1233), "Description: 111111117", 7, false, "Campaign 111111117", null },
                    { 111111118.0, "1.jpg", "campaign-code-111111118", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1248), "Description: 111111118", 8, false, "Campaign 111111118", null },
                    { 111111119.0, "1.jpg", "campaign-code-111111119", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1263), "Description: 111111119", 9, false, "Campaign 111111119", null },
                    { 111111120.0, "1.jpg", "campaign-code-111111120", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1277), "Description: 111111120", 10, false, "Campaign 111111120", null },
                    { 111111121.0, "1.jpg", "campaign-code-111111121", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1289), "Description: 111111121", 11, false, "Campaign 111111121", null },
                    { 111111122.0, "1.jpg", "campaign-code-111111122", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1301), "Description: 111111122", 12, false, "Campaign 111111122", null },
                    { 111111123.0, "1.jpg", "campaign-code-111111123", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1315), "Description: 111111123", 13, false, "Campaign 111111123", null },
                    { 111111124.0, "1.jpg", "campaign-code-111111124", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1327), "Description: 111111124", 14, false, "Campaign 111111124", null },
                    { 111111125.0, "1.jpg", "campaign-code-111111125", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1339), "Description: 111111125", 15, false, "Campaign 111111125", null },
                    { 111111126.0, "1.jpg", "campaign-code-111111126", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1350), "Description: 111111126", 16, false, "Campaign 111111126", null },
                    { 111111127.0, "1.jpg", "campaign-code-111111127", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1365), "Description: 111111127", 17, false, "Campaign 111111127", null },
                    { 111111128.0, "1.jpg", "campaign-code-111111128", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1378), "Description: 111111128", 18, false, "Campaign 111111128", null },
                    { 111111129.0, "1.jpg", "campaign-code-111111129", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1390), "Description: 111111129", 19, false, "Campaign 111111129", null },
                    { 111111130.0, "1.jpg", "campaign-code-111111130", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1446), "Description: 111111130", 20, false, "Campaign 111111130", null },
                    { 111111131.0, "1.jpg", "campaign-code-111111131", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1462), "Description: 111111131", 21, false, "Campaign 111111131", null },
                    { 111111132.0, "1.jpg", "campaign-code-111111132", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1474), "Description: 111111132", 22, false, "Campaign 111111132", null },
                    { 111111133.0, "1.jpg", "campaign-code-111111133", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1487), "Description: 111111133", 23, false, "Campaign 111111133", null },
                    { 111111134.0, "1.jpg", "campaign-code-111111134", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1499), "Description: 111111134", 24, false, "Campaign 111111134", null },
                    { 111111135.0, "1.jpg", "campaign-code-111111135", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1513), "Description: 111111135", 25, false, "Campaign 111111135", null },
                    { 111111136.0, "1.jpg", "campaign-code-111111136", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1525), "Description: 111111136", 26, false, "Campaign 111111136", null },
                    { 111111137.0, "1.jpg", "campaign-code-111111137", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1537), "Description: 111111137", 27, false, "Campaign 111111137", null },
                    { 111111138.0, "1.jpg", "campaign-code-111111138", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1549), "Description: 111111138", 28, false, "Campaign 111111138", null },
                    { 111111139.0, "1.jpg", "campaign-code-111111139", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1564), "Description: 111111139", 29, false, "Campaign 111111139", null },
                    { 111111140.0, "1.jpg", "campaign-code-111111140", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1576), "Description: 111111140", 30, false, "Campaign 111111140", null },
                    { 111111141.0, "1.jpg", "campaign-code-111111141", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1588), "Description: 111111141", 31, false, "Campaign 111111141", null },
                    { 111111142.0, "1.jpg", "campaign-code-111111142", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1599), "Description: 111111142", 32, false, "Campaign 111111142", null },
                    { 111111143.0, "1.jpg", "campaign-code-111111143", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1614), "Description: 111111143", 33, false, "Campaign 111111143", null },
                    { 111111144.0, "1.jpg", "campaign-code-111111144", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1674), "Description: 111111144", 34, false, "Campaign 111111144", null },
                    { 111111145.0, "1.jpg", "campaign-code-111111145", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1686), "Description: 111111145", 35, false, "Campaign 111111145", null },
                    { 111111146.0, "1.jpg", "campaign-code-111111146", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1698), "Description: 111111146", 36, false, "Campaign 111111146", null },
                    { 111111147.0, "1.jpg", "campaign-code-111111147", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1713), "Description: 111111147", 37, false, "Campaign 111111147", null },
                    { 111111148.0, "1.jpg", "campaign-code-111111148", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1725), "Description: 111111148", 38, false, "Campaign 111111148", null },
                    { 111111149.0, "1.jpg", "campaign-code-111111149", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1737), "Description: 111111149", 39, false, "Campaign 111111149", null },
                    { 111111150.0, "1.jpg", "campaign-code-111111150", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1749), "Description: 111111150", 40, false, "Campaign 111111150", null },
                    { 111111151.0, "1.jpg", "campaign-code-111111151", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1764), "Description: 111111151", 41, false, "Campaign 111111151", null },
                    { 111111152.0, "1.jpg", "campaign-code-111111152", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1776), "Description: 111111152", 42, false, "Campaign 111111152", null },
                    { 111111153.0, "1.jpg", "campaign-code-111111153", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1788), "Description: 111111153", 43, false, "Campaign 111111153", null },
                    { 111111154.0, "1.jpg", "campaign-code-111111154", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1800), "Description: 111111154", 44, false, "Campaign 111111154", null },
                    { 111111155.0, "1.jpg", "campaign-code-111111155", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1815), "Description: 111111155", 45, false, "Campaign 111111155", null },
                    { 111111156.0, "1.jpg", "campaign-code-111111156", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1827), "Description: 111111156", 46, false, "Campaign 111111156", null },
                    { 111111157.0, "1.jpg", "campaign-code-111111157", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1883), "Description: 111111157", 47, false, "Campaign 111111157", null },
                    { 111111158.0, "1.jpg", "campaign-code-111111158", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1896), "Description: 111111158", 48, false, "Campaign 111111158", null },
                    { 111111159.0, "1.jpg", "campaign-code-111111159", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1911), "Description: 111111159", 49, false, "Campaign 111111159", null },
                    { 111111160.0, "1.jpg", "campaign-code-111111160", new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1923), "Description: 111111160", 50, false, "Campaign 111111160", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CreatedDate", "Name", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 111111111.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6014), "Woman", null, "woman" },
                    { 111111112.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6031), "Man", null, "man" },
                    { 111111113.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6034), "Mom & Child", null, "mom-child" },
                    { 111111114.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6036), "Home & Furniture", null, "home-furniture" },
                    { 111111115.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6042), "Supermarket", null, "supermarket" },
                    { 111111116.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6045), "Cosmetics", null, "cosmetics" },
                    { 111111117.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6048), "Shoe & Bag", null, "shoe-bag" },
                    { 111111118.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6051), "Electronics", null, "electronics" },
                    { 111111119.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6056), "Sport & Outdoor", null, "sport-outdoor" },
                    { 111111120.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6058), "Book & Instrument", null, "book-instrument" },
                    { 111111121.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6179), "category 0", null, "category-0" },
                    { 111111122.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6334), "category 1", null, "category-1" },
                    { 111111123.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6351), "category 2", null, "category-2" },
                    { 111111124.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6364), "category 3", null, "category-3" },
                    { 111111125.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6376), "category 4", null, "category-4" },
                    { 111111126.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6388), "category 5", null, "category-5" },
                    { 111111127.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6403), "category 6", null, "category-6" },
                    { 111111128.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6417), "category 7", null, "category-7" },
                    { 111111129.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6429), "category 8", null, "category-8" },
                    { 111111130.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6441), "category 9", null, "category-9" },
                    { 111111131.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6456), "category 10", null, "category-10" },
                    { 111111132.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6468), "category 11", null, "category-11" },
                    { 111111133.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6531), "category 12", null, "category-12" },
                    { 111111134.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6544), "category 13", null, "category-13" },
                    { 111111135.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6701), "category 14", null, "category-14" },
                    { 111111136.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6713), "category 15", null, "category-15" },
                    { 111111137.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6725), "category 16", null, "category-16" },
                    { 111111138.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6736), "category 17", null, "category-17" },
                    { 111111139.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6751), "category 18", null, "category-18" },
                    { 111111140.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6762), "category 19", null, "category-19" },
                    { 111111141.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6774), "category 20", null, "category-20" },
                    { 111111142.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6785), "category 21", null, "category-21" },
                    { 111111143.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6799), "category 22", null, "category-22" },
                    { 111111144.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6813), "category 23", null, "category-23" },
                    { 111111145.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6824), "category 24", null, "category-24" },
                    { 111111146.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6836), "category 25", null, "category-25" },
                    { 111111147.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6850), "category 26", null, "category-26" },
                    { 111111148.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6862), "category 27", null, "category-27" },
                    { 111111149.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6921), "category 28", null, "category-28" },
                    { 111111150.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6934), "category 29", null, "category-29" },
                    { 111111151.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6949), "category 30", null, "category-30" },
                    { 111111152.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6960), "category 31", null, "category-31" },
                    { 111111153.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6971), "category 32", null, "category-32" },
                    { 111111154.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6982), "category 33", null, "category-33" },
                    { 111111155.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(6996), "category 34", null, "category-34" },
                    { 111111156.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7007), "category 35", null, "category-35" },
                    { 111111157.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7019), "category 36", null, "category-36" },
                    { 111111158.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7030), "category 37", null, "category-37" },
                    { 111111159.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7044), "category 38", null, "category-38" },
                    { 111111160.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7055), "category 39", null, "category-39" }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreId", "CommentCount", "CreatedDate", "IsApproved", "SellerEmail", "SellerFirstName", "SellerId", "SellerLastName", "SellerPhone", "StarCount", "StoreImage", "StoreName", "StoreRate", "StoreUrl", "UpdatedDate" },
                values: new object[,]
                {
                    { 111111111.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(266), false, null, null, null, null, null, 1m, "1.jpg", "store 0", 1m, "store-0", null },
                    { 111111112.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(282), false, null, null, null, null, null, 1m, "1.jpg", "store 1", 1m, "store-1", null },
                    { 111111113.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(341), false, null, null, null, null, null, 1m, "1.jpg", "store 2", 1m, "store-2", null },
                    { 111111114.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(355), false, null, null, null, null, null, 1m, "1.jpg", "store 3", 1m, "store-3", null },
                    { 111111115.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(366), false, null, null, null, null, null, 1m, "1.jpg", "store 4", 1m, "store-4", null },
                    { 111111116.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(380), false, null, null, null, null, null, 1m, "1.jpg", "store 5", 1m, "store-5", null },
                    { 111111117.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(394), false, null, null, null, null, null, 1m, "1.jpg", "store 6", 1m, "store-6", null },
                    { 111111118.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(406), false, null, null, null, null, null, 1m, "1.jpg", "store 7", 1m, "store-7", null },
                    { 111111119.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(417), false, null, null, null, null, null, 1m, "1.jpg", "store 8", 1m, "store-8", null },
                    { 111111120.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(430), false, null, null, null, null, null, 1m, "1.jpg", "store 9", 1m, "store-9", null },
                    { 111111121.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(445), false, null, null, null, null, null, 1m, "1.jpg", "store 10", 1m, "store-10", null },
                    { 111111122.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(457), false, null, null, null, null, null, 1m, "1.jpg", "store 11", 1m, "store-11", null },
                    { 111111123.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(468), false, null, null, null, null, null, 1m, "1.jpg", "store 12", 1m, "store-12", null },
                    { 111111124.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(479), false, null, null, null, null, null, 1m, "1.jpg", "store 13", 1m, "store-13", null },
                    { 111111125.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(493), false, null, null, null, null, null, 1m, "1.jpg", "store 14", 1m, "store-14", null },
                    { 111111126.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(505), false, null, null, null, null, null, 1m, "1.jpg", "store 15", 1m, "store-15", null },
                    { 111111127.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(563), false, null, null, null, null, null, 1m, "1.jpg", "store 16", 1m, "store-16", null },
                    { 111111128.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(577), false, null, null, null, null, null, 1m, "1.jpg", "store 17", 1m, "store-17", null },
                    { 111111129.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(591), false, null, null, null, null, null, 1m, "1.jpg", "store 18", 1m, "store-18", null },
                    { 111111130.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(603), false, null, null, null, null, null, 1m, "1.jpg", "store 19", 1m, "store-19", null },
                    { 111111131.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(614), false, null, null, null, null, null, 1m, "1.jpg", "store 20", 1m, "store-20", null },
                    { 111111132.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(625), false, null, null, null, null, null, 1m, "1.jpg", "store 21", 1m, "store-21", null },
                    { 111111133.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(639), false, null, null, null, null, null, 1m, "1.jpg", "store 22", 1m, "store-22", null },
                    { 111111134.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(651), false, null, null, null, null, null, 1m, "1.jpg", "store 23", 1m, "store-23", null },
                    { 111111135.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(663), false, null, null, null, null, null, 1m, "1.jpg", "store 24", 1m, "store-24", null },
                    { 111111136.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(674), false, null, null, null, null, null, 1m, "1.jpg", "store 25", 1m, "store-25", null },
                    { 111111137.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(688), false, null, null, null, null, null, 1m, "1.jpg", "store 26", 1m, "store-26", null },
                    { 111111138.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(699), false, null, null, null, null, null, 1m, "1.jpg", "store 27", 1m, "store-27", null },
                    { 111111139.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(711), false, null, null, null, null, null, 1m, "1.jpg", "store 28", 1m, "store-28", null },
                    { 111111140.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(767), false, null, null, null, null, null, 1m, "1.jpg", "store 29", 1m, "store-29", null },
                    { 111111141.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(784), false, null, null, null, null, null, 1m, "1.jpg", "store 30", 1m, "store-30", null },
                    { 111111142.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(796), false, null, null, null, null, null, 1m, "1.jpg", "store 31", 1m, "store-31", null },
                    { 111111143.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(807), false, null, null, null, null, null, 1m, "1.jpg", "store 32", 1m, "store-32", null },
                    { 111111144.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(820), false, null, null, null, null, null, 1m, "1.jpg", "store 33", 1m, "store-33", null },
                    { 111111145.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(835), false, null, null, null, null, null, 1m, "1.jpg", "store 34", 1m, "store-34", null },
                    { 111111146.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(846), false, null, null, null, null, null, 1m, "1.jpg", "store 35", 1m, "store-35", null },
                    { 111111147.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(858), false, null, null, null, null, null, 1m, "1.jpg", "store 36", 1m, "store-36", null },
                    { 111111148.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(870), false, null, null, null, null, null, 1m, "1.jpg", "store 37", 1m, "store-37", null },
                    { 111111149.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(884), false, null, null, null, null, null, 1m, "1.jpg", "store 38", 1m, "store-38", null },
                    { 111111150.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(896), false, null, null, null, null, null, 1m, "1.jpg", "store 39", 1m, "store-39", null },
                    { 111111151.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(907), false, null, null, null, null, null, 1m, "1.jpg", "store 40", 1m, "store-40", null },
                    { 111111152.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(919), false, null, null, null, null, null, 1m, "1.jpg", "store 41", 1m, "store-41", null },
                    { 111111153.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(980), false, null, null, null, null, null, 1m, "1.jpg", "store 42", 1m, "store-42", null },
                    { 111111154.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(993), false, null, null, null, null, null, 1m, "1.jpg", "store 43", 1m, "store-43", null },
                    { 111111155.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1005), false, null, null, null, null, null, 1m, "1.jpg", "store 44", 1m, "store-44", null },
                    { 111111156.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1017), false, null, null, null, null, null, 1m, "1.jpg", "store 45", 1m, "store-45", null },
                    { 111111157.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1031), false, null, null, null, null, null, 1m, "1.jpg", "store 46", 1m, "store-46", null },
                    { 111111158.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1043), false, null, null, null, null, null, 1m, "1.jpg", "store 47", 1m, "store-47", null },
                    { 111111159.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1054), false, null, null, null, null, null, 1m, "1.jpg", "store 48", 1m, "store-48", null },
                    { 111111160.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1065), false, null, null, null, null, null, 1m, "1.jpg", "store 49", 1m, "store-49", null }
                });

            migrationBuilder.InsertData(
                table: "Categories2",
                columns: new[] { "Category2Id", "CategoryId", "CreatedDate", "Name", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 111111111.0, 111111111.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7076), "category2 0", null, "category2-0" },
                    { 111111112.0, 111111112.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7096), "category2 1", null, "category2-1" },
                    { 111111113.0, 111111113.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7111), "category2 2", null, "category2-2" },
                    { 111111114.0, 111111114.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7122), "category2 3", null, "category2-3" },
                    { 111111115.0, 111111115.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7133), "category2 4", null, "category2-4" },
                    { 111111116.0, 111111116.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7231), "category2 5", null, "category2-5" },
                    { 111111117.0, 111111117.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7248), "category2 6", null, "category2-6" },
                    { 111111118.0, 111111118.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7260), "category2 7", null, "category2-7" },
                    { 111111119.0, 111111119.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7271), "category2 8", null, "category2-8" },
                    { 111111120.0, 111111120.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7284), "category2 9", null, "category2-9" },
                    { 111111121.0, 111111121.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7298), "category2 10", null, "category2-10" },
                    { 111111122.0, 111111122.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7310), "category2 11", null, "category2-11" },
                    { 111111123.0, 111111123.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7321), "category2 12", null, "category2-12" },
                    { 111111124.0, 111111124.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7332), "category2 13", null, "category2-13" },
                    { 111111125.0, 111111125.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7346), "category2 14", null, "category2-14" },
                    { 111111126.0, 111111126.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7357), "category2 15", null, "category2-15" },
                    { 111111127.0, 111111127.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7368), "category2 16", null, "category2-16" },
                    { 111111128.0, 111111128.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7381), "category2 17", null, "category2-17" },
                    { 111111129.0, 111111129.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7395), "category2 18", null, "category2-18" },
                    { 111111130.0, 111111130.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7406), "category2 19", null, "category2-19" },
                    { 111111131.0, 111111131.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7417), "category2 20", null, "category2-20" },
                    { 111111132.0, 111111132.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7547), "category2 21", null, "category2-21" },
                    { 111111133.0, 111111133.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7564), "category2 22", null, "category2-22" },
                    { 111111134.0, 111111134.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7575), "category2 23", null, "category2-23" },
                    { 111111135.0, 111111135.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7586), "category2 24", null, "category2-24" },
                    { 111111136.0, 111111136.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7597), "category2 25", null, "category2-25" },
                    { 111111137.0, 111111137.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7611), "category2 26", null, "category2-26" },
                    { 111111138.0, 111111138.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7623), "category2 27", null, "category2-27" },
                    { 111111139.0, 111111139.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7634), "category2 28", null, "category2-28" },
                    { 111111140.0, 111111140.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7645), "category2 29", null, "category2-29" },
                    { 111111141.0, 111111141.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7660), "category2 30", null, "category2-30" },
                    { 111111142.0, 111111142.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7671), "category2 31", null, "category2-31" },
                    { 111111143.0, 111111143.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7683), "category2 32", null, "category2-32" },
                    { 111111144.0, 111111144.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7696), "category2 33", null, "category2-33" },
                    { 111111145.0, 111111145.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7710), "category2 34", null, "category2-34" },
                    { 111111146.0, 111111146.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7722), "category2 35", null, "category2-35" },
                    { 111111147.0, 111111147.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7781), "category2 36", null, "category2-36" },
                    { 111111148.0, 111111148.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7796), "category2 37", null, "category2-37" },
                    { 111111149.0, 111111149.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7811), "category2 38", null, "category2-38" },
                    { 111111150.0, 111111150.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7822), "category2 39", null, "category2-39" },
                    { 111111151.0, 111111151.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7833), "category2 40", null, "category2-40" },
                    { 111111152.0, 111111152.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7844), "category2 41", null, "category2-41" },
                    { 111111153.0, 111111153.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7858), "category2 42", null, "category2-42" },
                    { 111111154.0, 111111154.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7869), "category2 43", null, "category2-43" },
                    { 111111155.0, 111111155.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7880), "category2 44", null, "category2-44" },
                    { 111111156.0, 111111156.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7891), "category2 45", null, "category2-45" },
                    { 111111157.0, 111111157.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7905), "category2 46", null, "category2-46" },
                    { 111111158.0, 111111158.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7916), "category2 47", null, "category2-47" },
                    { 111111159.0, 111111159.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7927), "category2 48", null, "category2-48" },
                    { 111111160.0, 111111160.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(7938), "category2 49", null, "category2-49" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "BrandId", "Category2Id", "CategoryId", "CommentCount", "CreatedDate", "Description", "IsApproved", "IsHome", "Name", "Price", "ProductImage", "ProductRate", "Quantity", "SalesCount", "StarCount", "StoreId", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 111111111.0, 111111111.0, 111111111.0, 111111111.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8684), "urun aciklamasi 0", true, true, "urun 0", 10m, "1.jpg", 1m, 0, 0, 1, 111111111.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8685), "urun-0" },
                    { 111111112.0, 111111112.0, 111111112.0, 111111112.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8709), "urun aciklamasi 1", true, true, "urun 1", 10m, "1.jpg", 1m, 1, 1, 1, 111111112.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8710), "urun-1" },
                    { 111111113.0, 111111113.0, 111111113.0, 111111113.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8728), "urun aciklamasi 2", true, true, "urun 2", 10m, "1.jpg", 1m, 2, 2, 1, 111111113.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8728), "urun-2" },
                    { 111111114.0, 111111114.0, 111111114.0, 111111114.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8786), "urun aciklamasi 3", true, true, "urun 3", 10m, "1.jpg", 1m, 3, 3, 1, 111111114.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8787), "urun-3" },
                    { 111111115.0, 111111115.0, 111111115.0, 111111115.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8803), "urun aciklamasi 4", true, true, "urun 4", 10m, "1.jpg", 1m, 4, 4, 1, 111111115.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8804), "urun-4" },
                    { 111111116.0, 111111116.0, 111111116.0, 111111116.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8819), "urun aciklamasi 5", true, true, "urun 5", 10m, "1.jpg", 1m, 5, 5, 1, 111111116.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8820), "urun-5" },
                    { 111111117.0, 111111117.0, 111111117.0, 111111117.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8837), "urun aciklamasi 6", true, true, "urun 6", 10m, "1.jpg", 1m, 6, 6, 1, 111111117.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8837), "urun-6" },
                    { 111111118.0, 111111118.0, 111111118.0, 111111118.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8851), "urun aciklamasi 7", true, true, "urun 7", 10m, "1.jpg", 1m, 7, 7, 1, 111111118.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8851), "urun-7" },
                    { 111111119.0, 111111119.0, 111111119.0, 111111119.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8865), "urun aciklamasi 8", true, true, "urun 8", 10m, "1.jpg", 1m, 8, 8, 1, 111111119.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8865), "urun-8" },
                    { 111111120.0, 111111120.0, 111111120.0, 111111120.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8880), "urun aciklamasi 9", true, true, "urun 9", 10m, "1.jpg", 1m, 9, 9, 1, 111111120.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8881), "urun-9" },
                    { 111111121.0, 111111121.0, 111111121.0, 111111121.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8897), "urun aciklamasi 10", true, true, "urun 10", 10m, "1.jpg", 1m, 10, 10, 1, 111111121.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8898), "urun-10" },
                    { 111111122.0, 111111122.0, 111111122.0, 111111122.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8911), "urun aciklamasi 11", true, true, "urun 11", 10m, "1.jpg", 1m, 11, 11, 1, 111111122.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8912), "urun-11" },
                    { 111111123.0, 111111123.0, 111111123.0, 111111123.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8925), "urun aciklamasi 12", true, true, "urun 12", 10m, "1.jpg", 1m, 12, 12, 1, 111111123.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8926), "urun-12" },
                    { 111111124.0, 111111124.0, 111111124.0, 111111124.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8939), "urun aciklamasi 13", true, true, "urun 13", 10m, "1.jpg", 1m, 13, 13, 1, 111111124.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(8940), "urun-13" },
                    { 111111125.0, 111111125.0, 111111125.0, 111111125.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9007), "urun aciklamasi 14", true, true, "urun 14", 10m, "1.jpg", 1m, 14, 14, 1, 111111125.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9008), "urun-14" },
                    { 111111126.0, 111111126.0, 111111126.0, 111111126.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9024), "urun aciklamasi 15", true, true, "urun 15", 10m, "1.jpg", 1m, 15, 15, 1, 111111126.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9025), "urun-15" },
                    { 111111127.0, 111111127.0, 111111127.0, 111111127.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9038), "urun aciklamasi 16", true, true, "urun 16", 10m, "1.jpg", 1m, 16, 16, 1, 111111127.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9039), "urun-16" },
                    { 111111128.0, 111111128.0, 111111128.0, 111111128.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9054), "urun aciklamasi 17", true, true, "urun 17", 10m, "1.jpg", 1m, 17, 17, 1, 111111128.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9055), "urun-17" },
                    { 111111129.0, 111111129.0, 111111129.0, 111111129.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9071), "urun aciklamasi 18", true, true, "urun 18", 10m, "1.jpg", 1m, 18, 18, 1, 111111129.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9072), "urun-18" },
                    { 111111130.0, 111111130.0, 111111130.0, 111111130.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9085), "urun aciklamasi 19", true, true, "urun 19", 10m, "1.jpg", 1m, 19, 19, 1, 111111130.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9086), "urun-19" },
                    { 111111131.0, 111111131.0, 111111131.0, 111111131.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9099), "urun aciklamasi 20", true, true, "urun 20", 10m, "1.jpg", 1m, 20, 20, 1, 111111131.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9100), "urun-20" },
                    { 111111132.0, 111111132.0, 111111132.0, 111111132.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9113), "urun aciklamasi 21", true, true, "urun 21", 10m, "1.jpg", 1m, 21, 21, 1, 111111132.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9114), "urun-21" },
                    { 111111133.0, 111111133.0, 111111133.0, 111111133.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9130), "urun aciklamasi 22", true, true, "urun 22", 10m, "1.jpg", 1m, 22, 22, 1, 111111133.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9131), "urun-22" },
                    { 111111134.0, 111111134.0, 111111134.0, 111111134.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9145), "urun aciklamasi 23", true, true, "urun 23", 10m, "1.jpg", 1m, 23, 23, 1, 111111134.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9145), "urun-23" },
                    { 111111135.0, 111111135.0, 111111135.0, 111111135.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9159), "urun aciklamasi 24", true, true, "urun 24", 10m, "1.jpg", 1m, 24, 24, 1, 111111135.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9159), "urun-24" },
                    { 111111136.0, 111111136.0, 111111136.0, 111111136.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9225), "urun aciklamasi 25", true, true, "urun 25", 10m, "1.jpg", 1m, 25, 25, 1, 111111136.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9226), "urun-25" },
                    { 111111137.0, 111111137.0, 111111137.0, 111111137.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9244), "urun aciklamasi 26", true, true, "urun 26", 10m, "1.jpg", 1m, 26, 26, 1, 111111137.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9245), "urun-26" },
                    { 111111138.0, 111111138.0, 111111138.0, 111111138.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9258), "urun aciklamasi 27", true, true, "urun 27", 10m, "1.jpg", 1m, 27, 27, 1, 111111138.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9259), "urun-27" },
                    { 111111139.0, 111111139.0, 111111139.0, 111111139.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9272), "urun aciklamasi 28", true, true, "urun 28", 10m, "1.jpg", 1m, 28, 28, 1, 111111139.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9273), "urun-28" },
                    { 111111140.0, 111111140.0, 111111140.0, 111111140.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9286), "urun aciklamasi 29", true, true, "urun 29", 10m, "1.jpg", 1m, 29, 29, 1, 111111140.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9287), "urun-29" },
                    { 111111141.0, 111111141.0, 111111141.0, 111111141.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9303), "urun aciklamasi 30", true, true, "urun 30", 10m, "1.jpg", 1m, 30, 30, 1, 111111141.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9303), "urun-30" },
                    { 111111142.0, 111111142.0, 111111142.0, 111111142.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9317), "urun aciklamasi 31", true, true, "urun 31", 10m, "1.jpg", 1m, 31, 31, 1, 111111142.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9317), "urun-31" },
                    { 111111143.0, 111111143.0, 111111143.0, 111111143.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9331), "urun aciklamasi 32", true, true, "urun 32", 10m, "1.jpg", 1m, 32, 32, 1, 111111143.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9331), "urun-32" },
                    { 111111144.0, 111111144.0, 111111144.0, 111111144.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9347), "urun aciklamasi 33", true, true, "urun 33", 10m, "1.jpg", 1m, 33, 33, 1, 111111144.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9347), "urun-33" },
                    { 111111145.0, 111111145.0, 111111145.0, 111111145.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9363), "urun aciklamasi 34", true, true, "urun 34", 10m, "1.jpg", 1m, 34, 34, 1, 111111145.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9364), "urun-34" },
                    { 111111146.0, 111111146.0, 111111146.0, 111111146.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9378), "urun aciklamasi 35", true, true, "urun 35", 10m, "1.jpg", 1m, 35, 35, 1, 111111146.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9378), "urun-35" },
                    { 111111147.0, 111111147.0, 111111147.0, 111111147.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9453), "urun aciklamasi 36", true, true, "urun 36", 10m, "1.jpg", 1m, 36, 36, 1, 111111147.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9453), "urun-36" },
                    { 111111148.0, 111111148.0, 111111148.0, 111111148.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9469), "urun aciklamasi 37", true, true, "urun 37", 10m, "1.jpg", 1m, 37, 37, 1, 111111148.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9470), "urun-37" },
                    { 111111149.0, 111111149.0, 111111149.0, 111111149.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9487), "urun aciklamasi 38", true, true, "urun 38", 10m, "1.jpg", 1m, 38, 38, 1, 111111149.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9487), "urun-38" },
                    { 111111150.0, 111111150.0, 111111150.0, 111111150.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9501), "urun aciklamasi 39", true, true, "urun 39", 10m, "1.jpg", 1m, 39, 39, 1, 111111150.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9502), "urun-39" },
                    { 111111151.0, 111111151.0, 111111151.0, 111111151.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9515), "urun aciklamasi 40", true, true, "urun 40", 10m, "1.jpg", 1m, 40, 40, 1, 111111151.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9515), "urun-40" },
                    { 111111152.0, 111111152.0, 111111152.0, 111111152.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9529), "urun aciklamasi 41", true, true, "urun 41", 10m, "1.jpg", 1m, 41, 41, 1, 111111152.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9529), "urun-41" },
                    { 111111153.0, 111111153.0, 111111153.0, 111111153.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9546), "urun aciklamasi 42", true, true, "urun 42", 10m, "1.jpg", 1m, 42, 42, 1, 111111153.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9546), "urun-42" },
                    { 111111154.0, 111111154.0, 111111154.0, 111111154.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9560), "urun aciklamasi 43", true, true, "urun 43", 10m, "1.jpg", 1m, 43, 43, 1, 111111154.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9560), "urun-43" },
                    { 111111155.0, 111111155.0, 111111155.0, 111111155.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9573), "urun aciklamasi 44", true, true, "urun 44", 10m, "1.jpg", 1m, 44, 44, 1, 111111155.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9574), "urun-44" },
                    { 111111156.0, 111111156.0, 111111156.0, 111111156.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9588), "urun aciklamasi 45", true, true, "urun 45", 10m, "1.jpg", 1m, 45, 45, 1, 111111156.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9588), "urun-45" },
                    { 111111157.0, 111111157.0, 111111157.0, 111111157.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9604), "urun aciklamasi 46", true, true, "urun 46", 10m, "1.jpg", 1m, 46, 46, 1, 111111157.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9605), "urun-46" },
                    { 111111158.0, 111111158.0, 111111158.0, 111111158.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9665), "urun aciklamasi 47", true, true, "urun 47", 10m, "1.jpg", 1m, 47, 47, 1, 111111158.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9665), "urun-47" },
                    { 111111159.0, 111111159.0, 111111159.0, 111111159.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9680), "urun aciklamasi 48", true, true, "urun 48", 10m, "1.jpg", 1m, 48, 48, 1, 111111159.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9681), "urun-48" },
                    { 111111160.0, 111111160.0, 111111160.0, 111111160.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9694), "urun aciklamasi 49", true, true, "urun 49", 10m, "1.jpg", 1m, 49, 49, 1, 111111160.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9695), "urun-49" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "CommentRate", "CreatedDate", "Description", "ProductId", "SellerAnswer", "StoreId", "UpdatedDate", "UserFirstname", "UserId", "UserLastname" },
                values: new object[,]
                {
                    { 111111111.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1941), "description - 0", 111111111.0, "seller answer - 0", 111111111.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111112.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1960), "description - 1", 111111112.0, "seller answer - 1", 111111112.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111113.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1975), "description - 2", 111111113.0, "seller answer - 2", 111111113.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111114.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1987), "description - 3", 111111114.0, "seller answer - 3", 111111114.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111115.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1998), "description - 4", 111111115.0, "seller answer - 4", 111111115.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111116.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2011), "description - 5", 111111116.0, "seller answer - 5", 111111116.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111117.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2025), "description - 6", 111111117.0, "seller answer - 6", 111111117.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111118.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2037), "description - 7", 111111118.0, "seller answer - 7", 111111118.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111119.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2049), "description - 8", 111111119.0, "seller answer - 8", 111111119.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111120.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2062), "description - 9", 111111120.0, "seller answer - 9", 111111120.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111121.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2122), "description - 10", 111111121.0, "seller answer - 10", 111111121.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111122.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2137), "description - 11", 111111122.0, "seller answer - 11", 111111122.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111123.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2149), "description - 12", 111111123.0, "seller answer - 12", 111111123.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111124.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2161), "description - 13", 111111124.0, "seller answer - 13", 111111124.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111125.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2176), "description - 14", 111111125.0, "seller answer - 14", 111111125.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111126.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2188), "description - 15", 111111126.0, "seller answer - 15", 111111126.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111127.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2199), "description - 16", 111111127.0, "seller answer - 16", 111111127.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111128.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2213), "description - 17", 111111128.0, "seller answer - 17", 111111128.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111129.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2227), "description - 18", 111111129.0, "seller answer - 18", 111111129.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111130.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2239), "description - 19", 111111130.0, "seller answer - 19", 111111130.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111131.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2250), "description - 20", 111111131.0, "seller answer - 20", 111111131.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111132.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2262), "description - 21", 111111132.0, "seller answer - 21", 111111132.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111133.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2276), "description - 22", 111111133.0, "seller answer - 22", 111111133.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111134.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2288), "description - 23", 111111134.0, "seller answer - 23", 111111134.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111135.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2299), "description - 24", 111111135.0, "seller answer - 24", 111111135.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111136.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2359), "description - 25", 111111136.0, "seller answer - 25", 111111136.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111137.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2374), "description - 26", 111111137.0, "seller answer - 26", 111111137.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111138.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2386), "description - 27", 111111138.0, "seller answer - 27", 111111138.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111139.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2397), "description - 28", 111111139.0, "seller answer - 28", 111111139.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111140.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2409), "description - 29", 111111140.0, "seller answer - 29", 111111140.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111141.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2423), "description - 30", 111111141.0, "seller answer - 30", 111111141.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111142.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2434), "description - 31", 111111142.0, "seller answer - 31", 111111142.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111143.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2446), "description - 32", 111111143.0, "seller answer - 32", 111111143.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111144.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2459), "description - 33", 111111144.0, "seller answer - 33", 111111144.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111145.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2474), "description - 34", 111111145.0, "seller answer - 34", 111111145.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111146.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2485), "description - 35", 111111146.0, "seller answer - 35", 111111146.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111147.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2496), "description - 36", 111111147.0, "seller answer - 36", 111111147.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111148.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2508), "description - 37", 111111148.0, "seller answer - 37", 111111148.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111149.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2522), "description - 38", 111111149.0, "seller answer - 38", 111111149.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111150.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2584), "description - 39", 111111150.0, "seller answer - 39", 111111150.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111151.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2596), "description - 40", 111111151.0, "seller answer - 40", 111111151.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111152.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2608), "description - 41", 111111152.0, "seller answer - 41", 111111152.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111153.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2622), "description - 42", 111111153.0, "seller answer - 42", 111111153.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111154.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2634), "description - 43", 111111154.0, "seller answer - 43", 111111154.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111155.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2645), "description - 44", 111111155.0, "seller answer - 44", 111111155.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111156.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2657), "description - 45", 111111156.0, "seller answer - 45", 111111156.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111157.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2671), "description - 46", 111111157.0, "seller answer - 46", 111111157.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111158.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2683), "description - 47", 111111158.0, "seller answer - 47", 111111158.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111159.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2694), "description - 48", 111111159.0, "seller answer - 48", 111111159.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111160.0, 1, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(2705), "description - 49", 111111160.0, "seller answer - 49", 111111160.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" }
                });

            migrationBuilder.InsertData(
                table: "ImageUrls",
                columns: new[] { "ImageUrlId", "CreatedDate", "ProductId", "StoreId", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 111111111.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9712), 111111111.0, 111111111.0, null, "1.jpg" },
                    { 111111112.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9726), 111111112.0, 111111112.0, null, "1.jpg" },
                    { 111111113.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9735), 111111113.0, 111111113.0, null, "1.jpg" },
                    { 111111114.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9744), 111111114.0, 111111114.0, null, "1.jpg" },
                    { 111111115.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9755), 111111115.0, 111111115.0, null, "1.jpg" },
                    { 111111116.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9765), 111111116.0, 111111116.0, null, "1.jpg" },
                    { 111111117.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9773), 111111117.0, 111111117.0, null, "1.jpg" },
                    { 111111118.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9782), 111111118.0, 111111118.0, null, "1.jpg" },
                    { 111111119.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9793), 111111119.0, 111111119.0, null, "1.jpg" },
                    { 111111120.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9802), 111111120.0, 111111120.0, null, "1.jpg" },
                    { 111111121.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9810), 111111121.0, 111111121.0, null, "1.jpg" },
                    { 111111122.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9819), 111111122.0, 111111122.0, null, "1.jpg" },
                    { 111111123.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9830), 111111123.0, 111111123.0, null, "1.jpg" },
                    { 111111124.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9838), 111111124.0, 111111124.0, null, "1.jpg" },
                    { 111111125.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9846), 111111125.0, 111111125.0, null, "1.jpg" },
                    { 111111126.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9901), 111111126.0, 111111126.0, null, "1.jpg" },
                    { 111111127.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9913), 111111127.0, 111111127.0, null, "1.jpg" },
                    { 111111128.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9923), 111111128.0, 111111128.0, null, "1.jpg" },
                    { 111111129.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9931), 111111129.0, 111111129.0, null, "1.jpg" },
                    { 111111130.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9939), 111111130.0, 111111130.0, null, "1.jpg" },
                    { 111111131.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9950), 111111131.0, 111111131.0, null, "1.jpg" },
                    { 111111132.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9958), 111111132.0, 111111132.0, null, "1.jpg" },
                    { 111111133.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9966), 111111133.0, 111111133.0, null, "1.jpg" },
                    { 111111134.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9974), 111111134.0, 111111134.0, null, "1.jpg" },
                    { 111111135.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9985), 111111135.0, 111111135.0, null, "1.jpg" },
                    { 111111136.0, new DateTime(2023, 9, 20, 17, 31, 20, 701, DateTimeKind.Local).AddTicks(9993), 111111136.0, 111111136.0, null, "1.jpg" },
                    { 111111137.0, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(1), 111111137.0, 111111137.0, null, "1.jpg" },
                    { 111111138.0, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(9), 111111138.0, 111111138.0, null, "1.jpg" },
                    { 111111139.0, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(20), 111111139.0, 111111139.0, null, "1.jpg" },
                    { 111111140.0, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(28), 111111140.0, 111111140.0, null, "1.jpg" },
                    { 111111141.0, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(36), 111111141.0, 111111141.0, null, "1.jpg" },
                    { 111111142.0, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(44), 111111142.0, 111111142.0, null, "1.jpg" },
                    { 111111143.0, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(55), 111111143.0, 111111143.0, null, "1.jpg" },
                    { 111111144.0, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(109), 111111144.0, 111111144.0, null, "1.jpg" },
                    { 111111145.0, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(119), 111111145.0, 111111145.0, null, "1.jpg" },
                    { 111111146.0, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(127), 111111146.0, 111111146.0, null, "1.jpg" },
                    { 111111147.0, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(138), 111111147.0, 111111147.0, null, "1.jpg" },
                    { 111111148.0, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(146), 111111148.0, 111111148.0, null, "1.jpg" },
                    { 111111149.0, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(154), 111111149.0, 111111149.0, null, "1.jpg" },
                    { 111111150.0, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(162), 111111150.0, 111111150.0, null, "1.jpg" },
                    { 111111151.0, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(173), 111111151.0, 111111151.0, null, "1.jpg" },
                    { 111111152.0, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(181), 111111152.0, 111111152.0, null, "1.jpg" },
                    { 111111153.0, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(189), 111111153.0, 111111153.0, null, "1.jpg" },
                    { 111111154.0, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(198), 111111154.0, 111111154.0, null, "1.jpg" },
                    { 111111155.0, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(209), 111111155.0, 111111155.0, null, "1.jpg" },
                    { 111111156.0, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(217), 111111156.0, 111111156.0, null, "1.jpg" },
                    { 111111157.0, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(225), 111111157.0, 111111157.0, null, "1.jpg" },
                    { 111111158.0, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(233), 111111158.0, 111111158.0, null, "1.jpg" },
                    { 111111159.0, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(244), 111111159.0, 111111159.0, null, "1.jpg" },
                    { 111111160.0, new DateTime(2023, 9, 20, 17, 31, 20, 702, DateTimeKind.Local).AddTicks(252), 111111160.0, 111111160.0, null, "1.jpg" }
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
