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
                    { 111111111.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2680), "Brand 0", null, "brand-0" },
                    { 111111112.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2717), "Brand 1", null, "brand-1" },
                    { 111111113.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2747), "Brand 2", null, "brand-2" },
                    { 111111114.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2772), "Brand 3", null, "brand-3" },
                    { 111111115.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2797), "Brand 4", null, "brand-4" },
                    { 111111116.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2825), "Brand 5", null, "brand-5" },
                    { 111111117.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2856), "Brand 6", null, "brand-6" },
                    { 111111118.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2883), "Brand 7", null, "brand-7" },
                    { 111111119.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2910), "Brand 8", null, "brand-8" },
                    { 111111120.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2939), "Brand 9", null, "brand-9" },
                    { 111111121.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2969), "Brand 10", null, "brand-10" },
                    { 111111122.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2995), "Brand 11", null, "brand-11" },
                    { 111111123.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3020), "Brand 12", null, "brand-12" },
                    { 111111124.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3045), "Brand 13", null, "brand-13" },
                    { 111111125.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3083), "Brand 14", null, "brand-14" },
                    { 111111126.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3110), "Brand 15", null, "brand-15" },
                    { 111111127.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3136), "Brand 16", null, "brand-16" },
                    { 111111128.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3165), "Brand 17", null, "brand-17" },
                    { 111111129.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3193), "Brand 18", null, "brand-18" },
                    { 111111130.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3221), "Brand 19", null, "brand-19" },
                    { 111111131.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3249), "Brand 20", null, "brand-20" },
                    { 111111132.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3273), "Brand 21", null, "brand-21" },
                    { 111111133.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3302), "Brand 22", null, "brand-22" },
                    { 111111134.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3326), "Brand 23", null, "brand-23" },
                    { 111111135.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3350), "Brand 24", null, "brand-24" },
                    { 111111136.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3374), "Brand 25", null, "brand-25" },
                    { 111111137.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3402), "Brand 26", null, "brand-26" },
                    { 111111138.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3426), "Brand 27", null, "brand-27" },
                    { 111111139.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3450), "Brand 28", null, "brand-28" },
                    { 111111140.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3474), "Brand 29", null, "brand-29" },
                    { 111111141.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3502), "Brand 30", null, "brand-30" },
                    { 111111142.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3527), "Brand 31", null, "brand-31" },
                    { 111111143.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3565), "Brand 32", null, "brand-32" },
                    { 111111144.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3594), "Brand 33", null, "brand-33" },
                    { 111111145.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3622), "Brand 34", null, "brand-34" },
                    { 111111146.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3647), "Brand 35", null, "brand-35" },
                    { 111111147.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3671), "Brand 36", null, "brand-36" },
                    { 111111148.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3695), "Brand 37", null, "brand-37" },
                    { 111111149.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3725), "Brand 38", null, "brand-38" },
                    { 111111150.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3751), "Brand 39", null, "brand-39" },
                    { 111111151.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3776), "Brand 40", null, "brand-40" },
                    { 111111152.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3800), "Brand 41", null, "brand-41" },
                    { 111111153.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3829), "Brand 42", null, "brand-42" },
                    { 111111154.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3854), "Brand 43", null, "brand-43" },
                    { 111111155.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3879), "Brand 44", null, "brand-44" },
                    { 111111156.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3915), "Brand 45", null, "brand-45" },
                    { 111111157.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3945), "Brand 46", null, "brand-46" },
                    { 111111158.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3971), "Brand 47", null, "brand-47" },
                    { 111111159.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(3996), "Brand 48", null, "brand-48" },
                    { 111111160.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4030), "Brand 49", null, "brand-49" }
                });

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "CampaignId", "CampaignImage", "Code", "CreatedDate", "Description", "IsHome", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 111111111.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(8585), "Description: 111111111", true, "Campaign 111111111", null },
                    { 111111112.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(8621), "Description: 111111112", true, "Campaign 111111112", null },
                    { 111111113.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(8653), "Description: 111111113", true, "Campaign 111111113", null },
                    { 111111114.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(8680), "Description: 111111114", true, "Campaign 111111114", null },
                    { 111111115.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(8718), "Description: 111111115", true, "Campaign 111111115", null },
                    { 111111116.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(8752), "Description: 111111116", true, "Campaign 111111116", null },
                    { 111111117.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(8782), "Description: 111111117", true, "Campaign 111111117", null },
                    { 111111118.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(8807), "Description: 111111118", true, "Campaign 111111118", null },
                    { 111111119.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(8831), "Description: 111111119", true, "Campaign 111111119", null },
                    { 111111120.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(8864), "Description: 111111120", true, "Campaign 111111120", null },
                    { 111111121.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(8898), "Description: 111111121", true, "Campaign 111111121", null },
                    { 111111122.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(8925), "Description: 111111122", true, "Campaign 111111122", null },
                    { 111111123.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(8951), "Description: 111111123", true, "Campaign 111111123", null },
                    { 111111124.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(8976), "Description: 111111124", true, "Campaign 111111124", null },
                    { 111111125.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9007), "Description: 111111125", true, "Campaign 111111125", null },
                    { 111111126.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9035), "Description: 111111126", true, "Campaign 111111126", null },
                    { 111111127.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9062), "Description: 111111127", true, "Campaign 111111127", null },
                    { 111111128.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9093), "Description: 111111128", true, "Campaign 111111128", null },
                    { 111111129.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9124), "Description: 111111129", true, "Campaign 111111129", null },
                    { 111111130.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9159), "Description: 111111130", true, "Campaign 111111130", null },
                    { 111111131.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9186), "Description: 111111131", true, "Campaign 111111131", null },
                    { 111111132.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9212), "Description: 111111132", true, "Campaign 111111132", null },
                    { 111111133.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9244), "Description: 111111133", true, "Campaign 111111133", null },
                    { 111111134.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9270), "Description: 111111134", true, "Campaign 111111134", null },
                    { 111111135.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9297), "Description: 111111135", true, "Campaign 111111135", null },
                    { 111111136.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9324), "Description: 111111136", true, "Campaign 111111136", null },
                    { 111111137.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9356), "Description: 111111137", true, "Campaign 111111137", null },
                    { 111111138.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9383), "Description: 111111138", true, "Campaign 111111138", null },
                    { 111111139.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9409), "Description: 111111139", true, "Campaign 111111139", null },
                    { 111111140.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9435), "Description: 111111140", true, "Campaign 111111140", null },
                    { 111111141.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9468), "Description: 111111141", true, "Campaign 111111141", null },
                    { 111111142.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9496), "Description: 111111142", true, "Campaign 111111142", null },
                    { 111111143.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9522), "Description: 111111143", true, "Campaign 111111143", null },
                    { 111111144.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9552), "Description: 111111144", true, "Campaign 111111144", null },
                    { 111111145.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9595), "Description: 111111145", true, "Campaign 111111145", null },
                    { 111111146.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9624), "Description: 111111146", true, "Campaign 111111146", null },
                    { 111111147.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9650), "Description: 111111147", true, "Campaign 111111147", null },
                    { 111111148.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9677), "Description: 111111148", true, "Campaign 111111148", null },
                    { 111111149.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9709), "Description: 111111149", true, "Campaign 111111149", null },
                    { 111111150.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9735), "Description: 111111150", true, "Campaign 111111150", null },
                    { 111111151.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9761), "Description: 111111151", true, "Campaign 111111151", null },
                    { 111111152.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9788), "Description: 111111152", true, "Campaign 111111152", null },
                    { 111111153.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9821), "Description: 111111153", true, "Campaign 111111153", null },
                    { 111111154.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9848), "Description: 111111154", true, "Campaign 111111154", null },
                    { 111111155.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9873), "Description: 111111155", true, "Campaign 111111155", null },
                    { 111111156.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9904), "Description: 111111156", true, "Campaign 111111156", null },
                    { 111111157.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9937), "Description: 111111157", true, "Campaign 111111157", null },
                    { 111111158.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9964), "Description: 111111158", true, "Campaign 111111158", null },
                    { 111111159.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(9991), "Description: 111111159", true, "Campaign 111111159", null },
                    { 111111160.0, "1.jpg", "23sdasdasd", new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(34), "Description: 111111160", true, "Campaign 111111160", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CreatedDate", "Name", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 111111111.0, new DateTime(2023, 9, 18, 15, 35, 28, 452, DateTimeKind.Local).AddTicks(9832), "Woman", null, "woman" },
                    { 111111112.0, new DateTime(2023, 9, 18, 15, 35, 28, 452, DateTimeKind.Local).AddTicks(9853), "Man", null, "man" },
                    { 111111113.0, new DateTime(2023, 9, 18, 15, 35, 28, 452, DateTimeKind.Local).AddTicks(9871), "Mom & Child", null, "mom-child" },
                    { 111111114.0, new DateTime(2023, 9, 18, 15, 35, 28, 452, DateTimeKind.Local).AddTicks(9876), "Home & Furniture", null, "home-furniture" },
                    { 111111115.0, new DateTime(2023, 9, 18, 15, 35, 28, 452, DateTimeKind.Local).AddTicks(9880), "Supermarket", null, "supermarket" },
                    { 111111116.0, new DateTime(2023, 9, 18, 15, 35, 28, 452, DateTimeKind.Local).AddTicks(9884), "Cosmetics", null, "cosmetics" },
                    { 111111117.0, new DateTime(2023, 9, 18, 15, 35, 28, 452, DateTimeKind.Local).AddTicks(9893), "Shoe & Bag", null, "shoe-bag" },
                    { 111111118.0, new DateTime(2023, 9, 18, 15, 35, 28, 452, DateTimeKind.Local).AddTicks(9897), "Electronics", null, "electronics" },
                    { 111111119.0, new DateTime(2023, 9, 18, 15, 35, 28, 452, DateTimeKind.Local).AddTicks(9900), "Sport & Outdoor", null, "sport-outdoor" },
                    { 111111120.0, new DateTime(2023, 9, 18, 15, 35, 28, 452, DateTimeKind.Local).AddTicks(9904), "Book & Instrument", null, "book-instrument" },
                    { 111111121.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(147), "category 0", null, "category-0" },
                    { 111111122.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(183), "category 1", null, "category-1" },
                    { 111111123.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(208), "category 2", null, "category-2" },
                    { 111111124.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(233), "category 3", null, "category-3" },
                    { 111111125.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(264), "category 4", null, "category-4" },
                    { 111111126.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(292), "category 5", null, "category-5" },
                    { 111111127.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(331), "category 6", null, "category-6" },
                    { 111111128.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(360), "category 7", null, "category-7" },
                    { 111111129.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(389), "category 8", null, "category-8" },
                    { 111111130.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(415), "category 9", null, "category-9" },
                    { 111111131.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(441), "category 10", null, "category-10" },
                    { 111111132.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(467), "category 11", null, "category-11" },
                    { 111111133.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(494), "category 12", null, "category-12" },
                    { 111111134.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(520), "category 13", null, "category-13" },
                    { 111111135.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(544), "category 14", null, "category-14" },
                    { 111111136.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(568), "category 15", null, "category-15" },
                    { 111111137.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(598), "category 16", null, "category-16" },
                    { 111111138.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(624), "category 17", null, "category-17" },
                    { 111111139.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(646), "category 18", null, "category-18" },
                    { 111111140.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(671), "category 19", null, "category-19" },
                    { 111111141.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(700), "category 20", null, "category-20" },
                    { 111111142.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(728), "category 21", null, "category-21" },
                    { 111111143.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(754), "category 22", null, "category-22" },
                    { 111111144.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(793), "category 23", null, "category-23" },
                    { 111111145.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(825), "category 24", null, "category-24" },
                    { 111111146.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(850), "category 25", null, "category-25" },
                    { 111111147.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(876), "category 26", null, "category-26" },
                    { 111111148.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(901), "category 27", null, "category-27" },
                    { 111111149.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(931), "category 28", null, "category-28" },
                    { 111111150.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(958), "category 29", null, "category-29" },
                    { 111111151.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(985), "category 30", null, "category-30" },
                    { 111111152.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1014), "category 31", null, "category-31" },
                    { 111111153.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1043), "category 32", null, "category-32" },
                    { 111111154.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1068), "category 33", null, "category-33" },
                    { 111111155.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1093), "category 34", null, "category-34" },
                    { 111111156.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1117), "category 35", null, "category-35" },
                    { 111111157.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1146), "category 36", null, "category-36" },
                    { 111111158.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1172), "category 37", null, "category-37" },
                    { 111111159.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1196), "category 38", null, "category-38" },
                    { 111111160.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1230), "category 39", null, "category-39" }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreId", "CreatedDate", "IsApproved", "SellerEmail", "SellerFirstName", "SellerId", "SellerLastName", "SellerPhone", "StoreImage", "StoreName", "StoreUrl", "UpdatedDate" },
                values: new object[,]
                {
                    { 111111111.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6791), false, null, null, null, null, null, "1.jpg", "store 0", "store-0", null },
                    { 111111112.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6892), false, null, null, null, null, null, "1.jpg", "store 1", "store-1", null },
                    { 111111113.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6948), false, null, null, null, null, null, "1.jpg", "store 2", "store-2", null },
                    { 111111114.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(7001), false, null, null, null, null, null, "1.jpg", "store 3", "store-3", null },
                    { 111111115.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(7042), false, null, null, null, null, null, "1.jpg", "store 4", "store-4", null },
                    { 111111116.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(7097), false, null, null, null, null, null, "1.jpg", "store 5", "store-5", null },
                    { 111111117.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(7147), false, null, null, null, null, null, "1.jpg", "store 6", "store-6", null },
                    { 111111118.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(7191), false, null, null, null, null, null, "1.jpg", "store 7", "store-7", null },
                    { 111111119.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(7242), false, null, null, null, null, null, "1.jpg", "store 8", "store-8", null },
                    { 111111120.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(7340), false, null, null, null, null, null, "1.jpg", "store 9", "store-9", null },
                    { 111111121.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(7397), false, null, null, null, null, null, "1.jpg", "store 10", "store-10", null },
                    { 111111122.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(7439), false, null, null, null, null, null, "1.jpg", "store 11", "store-11", null },
                    { 111111123.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(7474), false, null, null, null, null, null, "1.jpg", "store 12", "store-12", null },
                    { 111111124.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(7501), false, null, null, null, null, null, "1.jpg", "store 13", "store-13", null },
                    { 111111125.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(7528), false, null, null, null, null, null, "1.jpg", "store 14", "store-14", null },
                    { 111111126.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(7556), false, null, null, null, null, null, "1.jpg", "store 15", "store-15", null },
                    { 111111127.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(7589), false, null, null, null, null, null, "1.jpg", "store 16", "store-16", null },
                    { 111111128.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(7624), false, null, null, null, null, null, "1.jpg", "store 17", "store-17", null },
                    { 111111129.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(7651), false, null, null, null, null, null, "1.jpg", "store 18", "store-18", null },
                    { 111111130.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(7678), false, null, null, null, null, null, "1.jpg", "store 19", "store-19", null },
                    { 111111131.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(7710), false, null, null, null, null, null, "1.jpg", "store 20", "store-20", null },
                    { 111111132.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(7737), false, null, null, null, null, null, "1.jpg", "store 21", "store-21", null },
                    { 111111133.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(7763), false, null, null, null, null, null, "1.jpg", "store 22", "store-22", null },
                    { 111111134.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(7790), false, null, null, null, null, null, "1.jpg", "store 23", "store-23", null },
                    { 111111135.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(7822), false, null, null, null, null, null, "1.jpg", "store 24", "store-24", null },
                    { 111111136.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(7856), false, null, null, null, null, null, "1.jpg", "store 25", "store-25", null },
                    { 111111137.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(7885), false, null, null, null, null, null, "1.jpg", "store 26", "store-26", null },
                    { 111111138.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(7910), false, null, null, null, null, null, "1.jpg", "store 27", "store-27", null },
                    { 111111139.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(7941), false, null, null, null, null, null, "1.jpg", "store 28", "store-28", null },
                    { 111111140.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(7968), false, null, null, null, null, null, "1.jpg", "store 29", "store-29", null },
                    { 111111141.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(7996), false, null, null, null, null, null, "1.jpg", "store 30", "store-30", null },
                    { 111111142.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(8024), false, null, null, null, null, null, "1.jpg", "store 31", "store-31", null },
                    { 111111143.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(8056), false, null, null, null, null, null, "1.jpg", "store 32", "store-32", null },
                    { 111111144.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(8088), false, null, null, null, null, null, "1.jpg", "store 33", "store-33", null },
                    { 111111145.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(8116), false, null, null, null, null, null, "1.jpg", "store 34", "store-34", null },
                    { 111111146.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(8143), false, null, null, null, null, null, "1.jpg", "store 35", "store-35", null },
                    { 111111147.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(8175), false, null, null, null, null, null, "1.jpg", "store 36", "store-36", null },
                    { 111111148.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(8200), false, null, null, null, null, null, "1.jpg", "store 37", "store-37", null },
                    { 111111149.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(8224), false, null, null, null, null, null, "1.jpg", "store 38", "store-38", null },
                    { 111111150.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(8260), false, null, null, null, null, null, "1.jpg", "store 39", "store-39", null },
                    { 111111151.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(8292), false, null, null, null, null, null, "1.jpg", "store 40", "store-40", null },
                    { 111111152.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(8317), false, null, null, null, null, null, "1.jpg", "store 41", "store-41", null },
                    { 111111153.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(8345), false, null, null, null, null, null, "1.jpg", "store 42", "store-42", null },
                    { 111111154.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(8373), false, null, null, null, null, null, "1.jpg", "store 43", "store-43", null },
                    { 111111155.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(8405), false, null, null, null, null, null, "1.jpg", "store 44", "store-44", null },
                    { 111111156.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(8433), false, null, null, null, null, null, "1.jpg", "store 45", "store-45", null },
                    { 111111157.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(8458), false, null, null, null, null, null, "1.jpg", "store 46", "store-46", null },
                    { 111111158.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(8486), false, null, null, null, null, null, "1.jpg", "store 47", "store-47", null },
                    { 111111159.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(8518), false, null, null, null, null, null, "1.jpg", "store 48", "store-48", null },
                    { 111111160.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(8544), false, null, null, null, null, null, "1.jpg", "store 49", "store-49", null }
                });

            migrationBuilder.InsertData(
                table: "Categories2",
                columns: new[] { "Category2Id", "CategoryId", "CreatedDate", "Name", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 111111111.0, 111111111.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1267), "category2 0", null, "category2-0" },
                    { 111111112.0, 111111112.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1303), "category2 1", null, "category2-1" },
                    { 111111113.0, 111111113.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1327), "category2 2", null, "category2-2" },
                    { 111111114.0, 111111114.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1350), "category2 3", null, "category2-3" },
                    { 111111115.0, 111111115.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1376), "category2 4", null, "category2-4" },
                    { 111111116.0, 111111116.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1402), "category2 5", null, "category2-5" },
                    { 111111117.0, 111111117.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1425), "category2 6", null, "category2-6" },
                    { 111111118.0, 111111118.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1448), "category2 7", null, "category2-7" },
                    { 111111119.0, 111111119.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1474), "category2 8", null, "category2-8" },
                    { 111111120.0, 111111120.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1500), "category2 9", null, "category2-9" },
                    { 111111121.0, 111111121.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1523), "category2 10", null, "category2-10" },
                    { 111111122.0, 111111122.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1550), "category2 11", null, "category2-11" },
                    { 111111123.0, 111111123.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1580), "category2 12", null, "category2-12" },
                    { 111111124.0, 111111124.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1606), "category2 13", null, "category2-13" },
                    { 111111125.0, 111111125.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1632), "category2 14", null, "category2-14" },
                    { 111111126.0, 111111126.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1667), "category2 15", null, "category2-15" },
                    { 111111127.0, 111111127.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1698), "category2 16", null, "category2-16" },
                    { 111111128.0, 111111128.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1729), "category2 17", null, "category2-17" },
                    { 111111129.0, 111111129.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1756), "category2 18", null, "category2-18" },
                    { 111111130.0, 111111130.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1781), "category2 19", null, "category2-19" },
                    { 111111131.0, 111111131.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1811), "category2 20", null, "category2-20" },
                    { 111111132.0, 111111132.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1837), "category2 21", null, "category2-21" },
                    { 111111133.0, 111111133.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1863), "category2 22", null, "category2-22" },
                    { 111111134.0, 111111134.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1893), "category2 23", null, "category2-23" },
                    { 111111135.0, 111111135.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1926), "category2 24", null, "category2-24" },
                    { 111111136.0, 111111136.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1953), "category2 25", null, "category2-25" },
                    { 111111137.0, 111111137.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(1980), "category2 26", null, "category2-26" },
                    { 111111138.0, 111111138.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2006), "category2 27", null, "category2-27" },
                    { 111111139.0, 111111139.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2036), "category2 28", null, "category2-28" },
                    { 111111140.0, 111111140.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2061), "category2 29", null, "category2-29" },
                    { 111111141.0, 111111141.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2088), "category2 30", null, "category2-30" },
                    { 111111142.0, 111111142.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2125), "category2 31", null, "category2-31" },
                    { 111111143.0, 111111143.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2157), "category2 32", null, "category2-32" },
                    { 111111144.0, 111111144.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2188), "category2 33", null, "category2-33" },
                    { 111111145.0, 111111145.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2215), "category2 34", null, "category2-34" },
                    { 111111146.0, 111111146.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2242), "category2 35", null, "category2-35" },
                    { 111111147.0, 111111147.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2273), "category2 36", null, "category2-36" },
                    { 111111148.0, 111111148.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2299), "category2 37", null, "category2-37" },
                    { 111111149.0, 111111149.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2325), "category2 38", null, "category2-38" },
                    { 111111150.0, 111111150.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2352), "category2 39", null, "category2-39" },
                    { 111111151.0, 111111151.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2382), "category2 40", null, "category2-40" },
                    { 111111152.0, 111111152.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2410), "category2 41", null, "category2-41" },
                    { 111111153.0, 111111153.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2438), "category2 42", null, "category2-42" },
                    { 111111154.0, 111111154.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2464), "category2 43", null, "category2-43" },
                    { 111111155.0, 111111155.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2496), "category2 44", null, "category2-44" },
                    { 111111156.0, 111111156.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2523), "category2 45", null, "category2-45" },
                    { 111111157.0, 111111157.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2551), "category2 46", null, "category2-46" },
                    { 111111158.0, 111111158.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2585), "category2 47", null, "category2-47" },
                    { 111111159.0, 111111159.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2618), "category2 48", null, "category2-48" },
                    { 111111160.0, 111111160.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(2645), "category2 49", null, "category2-49" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "BrandId", "Category2Id", "CategoryId", "CommentCount", "CreatedDate", "Description", "IsApproved", "IsHome", "Name", "Price", "ProductImage", "ProductRate", "Quantity", "SalesCount", "StarCount", "StoreId", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 111111111.0, 111111111.0, 111111111.0, 111111111.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4091), "urun aciklamasi 0", true, true, "urun 0", 10m, "1.jpg", 0m, 0, 0, 0, 111111111.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4094), "urun-0" },
                    { 111111112.0, 111111112.0, 111111112.0, 111111112.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4138), "urun aciklamasi 1", true, true, "urun 1", 10m, "1.jpg", 0m, 1, 1, 0, 111111112.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4139), "urun-1" },
                    { 111111113.0, 111111113.0, 111111113.0, 111111113.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4173), "urun aciklamasi 2", true, true, "urun 2", 10m, "1.jpg", 0m, 2, 2, 0, 111111113.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4174), "urun-2" },
                    { 111111114.0, 111111114.0, 111111114.0, 111111114.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4205), "urun aciklamasi 3", true, true, "urun 3", 10m, "1.jpg", 0m, 3, 3, 0, 111111114.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4206), "urun-3" },
                    { 111111115.0, 111111115.0, 111111115.0, 111111115.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4241), "urun aciklamasi 4", true, true, "urun 4", 10m, "1.jpg", 0m, 4, 4, 0, 111111115.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4242), "urun-4" },
                    { 111111116.0, 111111116.0, 111111116.0, 111111116.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4277), "urun aciklamasi 5", true, true, "urun 5", 10m, "1.jpg", 0m, 5, 5, 0, 111111116.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4278), "urun-5" },
                    { 111111117.0, 111111117.0, 111111117.0, 111111117.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4310), "urun aciklamasi 6", true, true, "urun 6", 10m, "1.jpg", 0m, 6, 6, 0, 111111117.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4311), "urun-6" },
                    { 111111118.0, 111111118.0, 111111118.0, 111111118.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4341), "urun aciklamasi 7", true, true, "urun 7", 10m, "1.jpg", 0m, 7, 7, 0, 111111118.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4343), "urun-7" },
                    { 111111119.0, 111111119.0, 111111119.0, 111111119.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4380), "urun aciklamasi 8", true, true, "urun 8", 10m, "1.jpg", 0m, 8, 8, 0, 111111119.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4381), "urun-8" },
                    { 111111120.0, 111111120.0, 111111120.0, 111111120.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4416), "urun aciklamasi 9", true, true, "urun 9", 10m, "1.jpg", 0m, 9, 9, 0, 111111120.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4417), "urun-9" },
                    { 111111121.0, 111111121.0, 111111121.0, 111111121.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4461), "urun aciklamasi 10", true, true, "urun 10", 10m, "1.jpg", 0m, 10, 10, 0, 111111121.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4462), "urun-10" },
                    { 111111122.0, 111111122.0, 111111122.0, 111111122.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4495), "urun aciklamasi 11", true, true, "urun 11", 10m, "1.jpg", 0m, 11, 11, 0, 111111122.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4496), "urun-11" },
                    { 111111123.0, 111111123.0, 111111123.0, 111111123.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4534), "urun aciklamasi 12", true, true, "urun 12", 10m, "1.jpg", 0m, 12, 12, 0, 111111123.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4535), "urun-12" },
                    { 111111124.0, 111111124.0, 111111124.0, 111111124.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4566), "urun aciklamasi 13", true, true, "urun 13", 10m, "1.jpg", 0m, 13, 13, 0, 111111124.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4568), "urun-13" },
                    { 111111125.0, 111111125.0, 111111125.0, 111111125.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4601), "urun aciklamasi 14", true, true, "urun 14", 10m, "1.jpg", 0m, 14, 14, 0, 111111125.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4602), "urun-14" },
                    { 111111126.0, 111111126.0, 111111126.0, 111111126.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4634), "urun aciklamasi 15", true, true, "urun 15", 10m, "1.jpg", 0m, 15, 15, 0, 111111126.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4636), "urun-15" },
                    { 111111127.0, 111111127.0, 111111127.0, 111111127.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4673), "urun aciklamasi 16", true, true, "urun 16", 10m, "1.jpg", 0m, 16, 16, 0, 111111127.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4674), "urun-16" },
                    { 111111128.0, 111111128.0, 111111128.0, 111111128.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4710), "urun aciklamasi 17", true, true, "urun 17", 10m, "1.jpg", 0m, 17, 17, 0, 111111128.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4711), "urun-17" },
                    { 111111129.0, 111111129.0, 111111129.0, 111111129.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4741), "urun aciklamasi 18", true, true, "urun 18", 10m, "1.jpg", 0m, 18, 18, 0, 111111129.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4742), "urun-18" },
                    { 111111130.0, 111111130.0, 111111130.0, 111111130.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4775), "urun aciklamasi 19", true, true, "urun 19", 10m, "1.jpg", 0m, 19, 19, 0, 111111130.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4776), "urun-19" },
                    { 111111131.0, 111111131.0, 111111131.0, 111111131.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4813), "urun aciklamasi 20", true, true, "urun 20", 10m, "1.jpg", 0m, 20, 20, 0, 111111131.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4814), "urun-20" },
                    { 111111132.0, 111111132.0, 111111132.0, 111111132.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4854), "urun aciklamasi 21", true, true, "urun 21", 10m, "1.jpg", 0m, 21, 21, 0, 111111132.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4855), "urun-21" },
                    { 111111133.0, 111111133.0, 111111133.0, 111111133.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4888), "urun aciklamasi 22", true, true, "urun 22", 10m, "1.jpg", 0m, 22, 22, 0, 111111133.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4889), "urun-22" },
                    { 111111134.0, 111111134.0, 111111134.0, 111111134.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4921), "urun aciklamasi 23", true, true, "urun 23", 10m, "1.jpg", 0m, 23, 23, 0, 111111134.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4922), "urun-23" },
                    { 111111135.0, 111111135.0, 111111135.0, 111111135.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4959), "urun aciklamasi 24", true, true, "urun 24", 10m, "1.jpg", 0m, 24, 24, 0, 111111135.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4961), "urun-24" },
                    { 111111136.0, 111111136.0, 111111136.0, 111111136.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4993), "urun aciklamasi 25", true, true, "urun 25", 10m, "1.jpg", 0m, 25, 25, 0, 111111136.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(4994), "urun-25" },
                    { 111111137.0, 111111137.0, 111111137.0, 111111137.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5025), "urun aciklamasi 26", true, true, "urun 26", 10m, "1.jpg", 0m, 26, 26, 0, 111111137.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5026), "urun-26" },
                    { 111111138.0, 111111138.0, 111111138.0, 111111138.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5056), "urun aciklamasi 27", true, true, "urun 27", 10m, "1.jpg", 0m, 27, 27, 0, 111111138.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5058), "urun-27" },
                    { 111111139.0, 111111139.0, 111111139.0, 111111139.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5094), "urun aciklamasi 28", true, true, "urun 28", 10m, "1.jpg", 0m, 28, 28, 0, 111111139.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5095), "urun-28" },
                    { 111111140.0, 111111140.0, 111111140.0, 111111140.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5128), "urun aciklamasi 29", true, true, "urun 29", 10m, "1.jpg", 0m, 29, 29, 0, 111111140.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5129), "urun-29" },
                    { 111111141.0, 111111141.0, 111111141.0, 111111141.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5161), "urun aciklamasi 30", true, true, "urun 30", 10m, "1.jpg", 0m, 30, 30, 0, 111111141.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5162), "urun-30" },
                    { 111111142.0, 111111142.0, 111111142.0, 111111142.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5194), "urun aciklamasi 31", true, true, "urun 31", 10m, "1.jpg", 0m, 31, 31, 0, 111111142.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5196), "urun-31" },
                    { 111111143.0, 111111143.0, 111111143.0, 111111143.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5241), "urun aciklamasi 32", true, true, "urun 32", 10m, "1.jpg", 0m, 32, 32, 0, 111111143.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5242), "urun-32" },
                    { 111111144.0, 111111144.0, 111111144.0, 111111144.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5278), "urun aciklamasi 33", true, true, "urun 33", 10m, "1.jpg", 0m, 33, 33, 0, 111111144.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5279), "urun-33" },
                    { 111111145.0, 111111145.0, 111111145.0, 111111145.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5311), "urun aciklamasi 34", true, true, "urun 34", 10m, "1.jpg", 0m, 34, 34, 0, 111111145.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5312), "urun-34" },
                    { 111111146.0, 111111146.0, 111111146.0, 111111146.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5343), "urun aciklamasi 35", true, true, "urun 35", 10m, "1.jpg", 0m, 35, 35, 0, 111111146.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5344), "urun-35" },
                    { 111111147.0, 111111147.0, 111111147.0, 111111147.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5381), "urun aciklamasi 36", true, true, "urun 36", 10m, "1.jpg", 0m, 36, 36, 0, 111111147.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5382), "urun-36" },
                    { 111111148.0, 111111148.0, 111111148.0, 111111148.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5414), "urun aciklamasi 37", true, true, "urun 37", 10m, "1.jpg", 0m, 37, 37, 0, 111111148.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5415), "urun-37" },
                    { 111111149.0, 111111149.0, 111111149.0, 111111149.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5446), "urun aciklamasi 38", true, true, "urun 38", 10m, "1.jpg", 0m, 38, 38, 0, 111111149.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5447), "urun-38" },
                    { 111111150.0, 111111150.0, 111111150.0, 111111150.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5478), "urun aciklamasi 39", true, true, "urun 39", 10m, "1.jpg", 0m, 39, 39, 0, 111111150.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5479), "urun-39" },
                    { 111111151.0, 111111151.0, 111111151.0, 111111151.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5515), "urun aciklamasi 40", true, true, "urun 40", 10m, "1.jpg", 0m, 40, 40, 0, 111111151.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5516), "urun-40" },
                    { 111111152.0, 111111152.0, 111111152.0, 111111152.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5548), "urun aciklamasi 41", true, true, "urun 41", 10m, "1.jpg", 0m, 41, 41, 0, 111111152.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5550), "urun-41" },
                    { 111111153.0, 111111153.0, 111111153.0, 111111153.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5582), "urun aciklamasi 42", true, true, "urun 42", 10m, "1.jpg", 0m, 42, 42, 0, 111111153.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5583), "urun-42" },
                    { 111111154.0, 111111154.0, 111111154.0, 111111154.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5623), "urun aciklamasi 43", true, true, "urun 43", 10m, "1.jpg", 0m, 43, 43, 0, 111111154.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5624), "urun-43" },
                    { 111111155.0, 111111155.0, 111111155.0, 111111155.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5662), "urun aciklamasi 44", true, true, "urun 44", 10m, "1.jpg", 0m, 44, 44, 0, 111111155.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5663), "urun-44" },
                    { 111111156.0, 111111156.0, 111111156.0, 111111156.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5696), "urun aciklamasi 45", true, true, "urun 45", 10m, "1.jpg", 0m, 45, 45, 0, 111111156.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5697), "urun-45" },
                    { 111111157.0, 111111157.0, 111111157.0, 111111157.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5729), "urun aciklamasi 46", true, true, "urun 46", 10m, "1.jpg", 0m, 46, 46, 0, 111111157.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5730), "urun-46" },
                    { 111111158.0, 111111158.0, 111111158.0, 111111158.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5761), "urun aciklamasi 47", true, true, "urun 47", 10m, "1.jpg", 0m, 47, 47, 0, 111111158.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5762), "urun-47" },
                    { 111111159.0, 111111159.0, 111111159.0, 111111159.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5798), "urun aciklamasi 48", true, true, "urun 48", 10m, "1.jpg", 0m, 48, 48, 0, 111111159.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5799), "urun-48" },
                    { 111111160.0, 111111160.0, 111111160.0, 111111160.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5833), "urun aciklamasi 49", true, true, "urun 49", 10m, "1.jpg", 0m, 49, 49, 0, 111111160.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5835), "urun-49" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "CommentRate", "CreatedDate", "Description", "ProductId", "SellerAnswer", "StoreId", "UpdatedDate", "UserFirstname", "UserId", "UserLastname" },
                values: new object[,]
                {
                    { 111111111.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(84), "description - 0", 111111111.0, null, 111111111.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111112.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(121), "description - 1", 111111112.0, null, 111111112.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111113.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(150), "description - 2", 111111113.0, null, 111111113.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111114.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(176), "description - 3", 111111114.0, null, 111111114.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111115.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(207), "description - 4", 111111115.0, null, 111111115.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111116.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(236), "description - 5", 111111116.0, null, 111111116.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111117.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(263), "description - 6", 111111117.0, null, 111111117.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111118.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(288), "description - 7", 111111118.0, null, 111111118.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111119.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(319), "description - 8", 111111119.0, null, 111111119.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111120.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(349), "description - 9", 111111120.0, null, 111111120.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111121.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(374), "description - 10", 111111121.0, null, 111111121.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111122.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(400), "description - 11", 111111122.0, null, 111111122.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111123.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(432), "description - 12", 111111123.0, null, 111111123.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111124.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(458), "description - 13", 111111124.0, null, 111111124.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111125.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(484), "description - 14", 111111125.0, null, 111111125.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111126.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(510), "description - 15", 111111126.0, null, 111111126.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111127.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(552), "description - 16", 111111127.0, null, 111111127.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111128.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(580), "description - 17", 111111128.0, null, 111111128.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111129.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(603), "description - 18", 111111129.0, null, 111111129.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111130.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(627), "description - 19", 111111130.0, null, 111111130.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111131.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(657), "description - 20", 111111131.0, null, 111111131.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111132.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(684), "description - 21", 111111132.0, null, 111111132.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111133.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(710), "description - 22", 111111133.0, null, 111111133.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111134.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(735), "description - 23", 111111134.0, null, 111111134.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111135.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(767), "description - 24", 111111135.0, null, 111111135.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111136.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(793), "description - 25", 111111136.0, null, 111111136.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111137.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(819), "description - 26", 111111137.0, null, 111111137.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111138.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(845), "description - 27", 111111138.0, null, 111111138.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111139.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(875), "description - 28", 111111139.0, null, 111111139.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111140.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(902), "description - 29", 111111140.0, null, 111111140.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111141.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(929), "description - 30", 111111141.0, null, 111111141.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111142.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(958), "description - 31", 111111142.0, null, 111111142.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111143.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(1001), "description - 32", 111111143.0, null, 111111143.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111144.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(1029), "description - 33", 111111144.0, null, 111111144.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111145.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(1054), "description - 34", 111111145.0, null, 111111145.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111146.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(1078), "description - 35", 111111146.0, null, 111111146.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111147.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(1106), "description - 36", 111111147.0, null, 111111147.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111148.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(1131), "description - 37", 111111148.0, null, 111111148.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111149.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(1160), "description - 38", 111111149.0, null, 111111149.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111150.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(1184), "description - 39", 111111150.0, null, 111111150.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111151.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(1215), "description - 40", 111111151.0, null, 111111151.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111152.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(1241), "description - 41", 111111152.0, null, 111111152.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111153.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(1264), "description - 42", 111111153.0, null, 111111153.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111154.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(1287), "description - 43", 111111154.0, null, 111111154.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111155.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(1317), "description - 44", 111111155.0, null, 111111155.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111156.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(1343), "description - 45", 111111156.0, null, 111111156.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111157.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(1367), "description - 46", 111111157.0, null, 111111157.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111158.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(1393), "description - 47", 111111158.0, null, 111111158.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111159.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(1595), "description - 48", 111111159.0, null, 111111159.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111160.0, 1, new DateTime(2023, 9, 18, 15, 35, 28, 454, DateTimeKind.Local).AddTicks(1636), "description - 49", 111111160.0, null, 111111160.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" }
                });

            migrationBuilder.InsertData(
                table: "ImageUrls",
                columns: new[] { "ImageUrlId", "CreatedDate", "ProductId", "StoreId", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 111111111.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5864), 111111111.0, 111111111.0, null, "1.jpg" },
                    { 111111112.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5895), 111111112.0, 111111112.0, null, "1.jpg" },
                    { 111111113.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5919), 111111113.0, 111111113.0, null, "1.jpg" },
                    { 111111114.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5938), 111111114.0, 111111114.0, null, "1.jpg" },
                    { 111111115.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5957), 111111115.0, 111111115.0, null, "1.jpg" },
                    { 111111116.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(5980), 111111116.0, 111111116.0, null, "1.jpg" },
                    { 111111117.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6003), 111111117.0, 111111117.0, null, "1.jpg" },
                    { 111111118.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6030), 111111118.0, 111111118.0, null, "1.jpg" },
                    { 111111119.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6049), 111111119.0, 111111119.0, null, "1.jpg" },
                    { 111111120.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6069), 111111120.0, 111111120.0, null, "1.jpg" },
                    { 111111121.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6091), 111111121.0, 111111121.0, null, "1.jpg" },
                    { 111111122.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6110), 111111122.0, 111111122.0, null, "1.jpg" },
                    { 111111123.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6128), 111111123.0, 111111123.0, null, "1.jpg" },
                    { 111111124.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6147), 111111124.0, 111111124.0, null, "1.jpg" },
                    { 111111125.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6170), 111111125.0, 111111125.0, null, "1.jpg" },
                    { 111111126.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6189), 111111126.0, 111111126.0, null, "1.jpg" },
                    { 111111127.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6207), 111111127.0, 111111127.0, null, "1.jpg" },
                    { 111111128.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6228), 111111128.0, 111111128.0, null, "1.jpg" },
                    { 111111129.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6251), 111111129.0, 111111129.0, null, "1.jpg" },
                    { 111111130.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6270), 111111130.0, 111111130.0, null, "1.jpg" },
                    { 111111131.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6290), 111111131.0, 111111131.0, null, "1.jpg" },
                    { 111111132.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6310), 111111132.0, 111111132.0, null, "1.jpg" },
                    { 111111133.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6335), 111111133.0, 111111133.0, null, "1.jpg" },
                    { 111111134.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6355), 111111134.0, 111111134.0, null, "1.jpg" },
                    { 111111135.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6375), 111111135.0, 111111135.0, null, "1.jpg" },
                    { 111111136.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6394), 111111136.0, 111111136.0, null, "1.jpg" },
                    { 111111137.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6416), 111111137.0, 111111137.0, null, "1.jpg" },
                    { 111111138.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6447), 111111138.0, 111111138.0, null, "1.jpg" },
                    { 111111139.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6466), 111111139.0, 111111139.0, null, "1.jpg" },
                    { 111111140.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6478), 111111140.0, 111111140.0, null, "1.jpg" },
                    { 111111141.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6493), 111111141.0, 111111141.0, null, "1.jpg" },
                    { 111111142.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6505), 111111142.0, 111111142.0, null, "1.jpg" },
                    { 111111143.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6517), 111111143.0, 111111143.0, null, "1.jpg" },
                    { 111111144.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6532), 111111144.0, 111111144.0, null, "1.jpg" },
                    { 111111145.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6547), 111111145.0, 111111145.0, null, "1.jpg" },
                    { 111111146.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6558), 111111146.0, 111111146.0, null, "1.jpg" },
                    { 111111147.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6570), 111111147.0, 111111147.0, null, "1.jpg" },
                    { 111111148.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6582), 111111148.0, 111111148.0, null, "1.jpg" },
                    { 111111149.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6596), 111111149.0, 111111149.0, null, "1.jpg" },
                    { 111111150.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6608), 111111150.0, 111111150.0, null, "1.jpg" },
                    { 111111151.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6620), 111111151.0, 111111151.0, null, "1.jpg" },
                    { 111111152.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6631), 111111152.0, 111111152.0, null, "1.jpg" },
                    { 111111153.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6646), 111111153.0, 111111153.0, null, "1.jpg" },
                    { 111111154.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6658), 111111154.0, 111111154.0, null, "1.jpg" },
                    { 111111155.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6669), 111111155.0, 111111155.0, null, "1.jpg" },
                    { 111111156.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6681), 111111156.0, 111111156.0, null, "1.jpg" },
                    { 111111157.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6703), 111111157.0, 111111157.0, null, "1.jpg" },
                    { 111111158.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6715), 111111158.0, 111111158.0, null, "1.jpg" },
                    { 111111159.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6733), 111111159.0, 111111159.0, null, "1.jpg" },
                    { 111111160.0, new DateTime(2023, 9, 18, 15, 35, 28, 453, DateTimeKind.Local).AddTicks(6752), 111111160.0, 111111160.0, null, "1.jpg" }
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
