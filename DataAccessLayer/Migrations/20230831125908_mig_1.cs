﻿using System;
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
                    Price = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "getdate()"),
                    UpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SalesCount = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsHome = table.Column<bool>(type: "bit", nullable: false),
                    BrandId = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<double>(type: "float", nullable: true),
                    Category2Id = table.Column<double>(type: "float", nullable: true)
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
                        principalColumn: "CategoryId");
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
                    Price = table.Column<double>(type: "float", nullable: false),
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
                    ProductId = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserFirstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserLastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    ProductId = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<double>(type: "float", nullable: false),
                    OrderId = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    { 111111111.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111111", true, "Campaign 111111111", null },
                    { 111111112.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111112", true, "Campaign 111111112", null },
                    { 111111113.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111113", true, "Campaign 111111113", null },
                    { 111111114.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111114", true, "Campaign 111111114", null },
                    { 111111115.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111115", true, "Campaign 111111115", null },
                    { 111111116.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111116", true, "Campaign 111111116", null },
                    { 111111117.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111117", true, "Campaign 111111117", null },
                    { 111111118.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111118", true, "Campaign 111111118", null },
                    { 111111119.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111119", true, "Campaign 111111119", null },
                    { 111111120.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111120", true, "Campaign 111111120", null },
                    { 111111121.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111121", true, "Campaign 111111121", null },
                    { 111111122.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111122", true, "Campaign 111111122", null },
                    { 111111123.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111123", true, "Campaign 111111123", null },
                    { 111111124.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111124", true, "Campaign 111111124", null },
                    { 111111125.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111125", true, "Campaign 111111125", null },
                    { 111111126.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111126", true, "Campaign 111111126", null },
                    { 111111127.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111127", true, "Campaign 111111127", null },
                    { 111111128.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111128", true, "Campaign 111111128", null },
                    { 111111129.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111129", true, "Campaign 111111129", null },
                    { 111111130.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111130", true, "Campaign 111111130", null },
                    { 111111131.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111131", true, "Campaign 111111131", null },
                    { 111111132.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111132", true, "Campaign 111111132", null },
                    { 111111133.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111133", true, "Campaign 111111133", null },
                    { 111111134.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111134", true, "Campaign 111111134", null },
                    { 111111135.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111135", true, "Campaign 111111135", null },
                    { 111111136.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111136", true, "Campaign 111111136", null },
                    { 111111137.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111137", true, "Campaign 111111137", null },
                    { 111111138.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111138", true, "Campaign 111111138", null },
                    { 111111139.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111139", true, "Campaign 111111139", null },
                    { 111111140.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111140", true, "Campaign 111111140", null },
                    { 111111141.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111141", true, "Campaign 111111141", null },
                    { 111111142.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111142", true, "Campaign 111111142", null },
                    { 111111143.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111143", true, "Campaign 111111143", null },
                    { 111111144.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111144", true, "Campaign 111111144", null },
                    { 111111145.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111145", true, "Campaign 111111145", null },
                    { 111111146.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111146", true, "Campaign 111111146", null },
                    { 111111147.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111147", true, "Campaign 111111147", null },
                    { 111111148.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111148", true, "Campaign 111111148", null },
                    { 111111149.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111149", true, "Campaign 111111149", null },
                    { 111111150.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111150", true, "Campaign 111111150", null },
                    { 111111151.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111151", true, "Campaign 111111151", null },
                    { 111111152.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111152", true, "Campaign 111111152", null },
                    { 111111153.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111153", true, "Campaign 111111153", null },
                    { 111111154.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111154", true, "Campaign 111111154", null },
                    { 111111155.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111155", true, "Campaign 111111155", null },
                    { 111111156.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111156", true, "Campaign 111111156", null },
                    { 111111157.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111157", true, "Campaign 111111157", null },
                    { 111111158.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111158", true, "Campaign 111111158", null },
                    { 111111159.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111159", true, "Campaign 111111159", null },
                    { 111111160.0, "1.jpg", "23sdasdasd", "2023/08/31 15:59:08", "Description: 111111160", true, "Campaign 111111160", null }
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
                    { 111111121.0, "2023/08/31 15:59:08", "category 0", null, "category-0" },
                    { 111111122.0, "2023/08/31 15:59:08", "category 1", null, "category-1" },
                    { 111111123.0, "2023/08/31 15:59:08", "category 2", null, "category-2" },
                    { 111111124.0, "2023/08/31 15:59:08", "category 3", null, "category-3" },
                    { 111111125.0, "2023/08/31 15:59:08", "category 4", null, "category-4" },
                    { 111111126.0, "2023/08/31 15:59:08", "category 5", null, "category-5" },
                    { 111111127.0, "2023/08/31 15:59:08", "category 6", null, "category-6" },
                    { 111111128.0, "2023/08/31 15:59:08", "category 7", null, "category-7" },
                    { 111111129.0, "2023/08/31 15:59:08", "category 8", null, "category-8" },
                    { 111111130.0, "2023/08/31 15:59:08", "category 9", null, "category-9" },
                    { 111111131.0, "2023/08/31 15:59:08", "category 10", null, "category-10" },
                    { 111111132.0, "2023/08/31 15:59:08", "category 11", null, "category-11" },
                    { 111111133.0, "2023/08/31 15:59:08", "category 12", null, "category-12" },
                    { 111111134.0, "2023/08/31 15:59:08", "category 13", null, "category-13" },
                    { 111111135.0, "2023/08/31 15:59:08", "category 14", null, "category-14" },
                    { 111111136.0, "2023/08/31 15:59:08", "category 15", null, "category-15" },
                    { 111111137.0, "2023/08/31 15:59:08", "category 16", null, "category-16" },
                    { 111111138.0, "2023/08/31 15:59:08", "category 17", null, "category-17" },
                    { 111111139.0, "2023/08/31 15:59:08", "category 18", null, "category-18" },
                    { 111111140.0, "2023/08/31 15:59:08", "category 19", null, "category-19" },
                    { 111111141.0, "2023/08/31 15:59:08", "category 20", null, "category-20" },
                    { 111111142.0, "2023/08/31 15:59:08", "category 21", null, "category-21" },
                    { 111111143.0, "2023/08/31 15:59:08", "category 22", null, "category-22" },
                    { 111111144.0, "2023/08/31 15:59:08", "category 23", null, "category-23" },
                    { 111111145.0, "2023/08/31 15:59:08", "category 24", null, "category-24" },
                    { 111111146.0, "2023/08/31 15:59:08", "category 25", null, "category-25" },
                    { 111111147.0, "2023/08/31 15:59:08", "category 26", null, "category-26" },
                    { 111111148.0, "2023/08/31 15:59:08", "category 27", null, "category-27" },
                    { 111111149.0, "2023/08/31 15:59:08", "category 28", null, "category-28" },
                    { 111111150.0, "2023/08/31 15:59:08", "category 29", null, "category-29" },
                    { 111111151.0, "2023/08/31 15:59:08", "category 30", null, "category-30" },
                    { 111111152.0, "2023/08/31 15:59:08", "category 31", null, "category-31" },
                    { 111111153.0, "2023/08/31 15:59:08", "category 32", null, "category-32" },
                    { 111111154.0, "2023/08/31 15:59:08", "category 33", null, "category-33" },
                    { 111111155.0, "2023/08/31 15:59:08", "category 34", null, "category-34" },
                    { 111111156.0, "2023/08/31 15:59:08", "category 35", null, "category-35" },
                    { 111111157.0, "2023/08/31 15:59:08", "category 36", null, "category-36" },
                    { 111111158.0, "2023/08/31 15:59:08", "category 37", null, "category-37" },
                    { 111111159.0, "2023/08/31 15:59:08", "category 38", null, "category-38" },
                    { 111111160.0, "2023/08/31 15:59:08", "category 39", null, "category-39" }
                });

            migrationBuilder.InsertData(
                table: "Categories2",
                columns: new[] { "Category2Id", "CategoryId", "CreatedDate", "Name", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 111111111.0, 111111111.0, "2023/08/31 15:59:08", "category2 0", null, "category2-0" },
                    { 111111112.0, 111111112.0, "2023/08/31 15:59:08", "category2 1", null, "category2-1" },
                    { 111111113.0, 111111113.0, "2023/08/31 15:59:08", "category2 2", null, "category2-2" },
                    { 111111114.0, 111111114.0, "2023/08/31 15:59:08", "category2 3", null, "category2-3" },
                    { 111111115.0, 111111115.0, "2023/08/31 15:59:08", "category2 4", null, "category2-4" },
                    { 111111116.0, 111111116.0, "2023/08/31 15:59:08", "category2 5", null, "category2-5" },
                    { 111111117.0, 111111117.0, "2023/08/31 15:59:08", "category2 6", null, "category2-6" },
                    { 111111118.0, 111111118.0, "2023/08/31 15:59:08", "category2 7", null, "category2-7" },
                    { 111111119.0, 111111119.0, "2023/08/31 15:59:08", "category2 8", null, "category2-8" },
                    { 111111120.0, 111111120.0, "2023/08/31 15:59:08", "category2 9", null, "category2-9" },
                    { 111111121.0, 111111121.0, "2023/08/31 15:59:08", "category2 10", null, "category2-10" },
                    { 111111122.0, 111111122.0, "2023/08/31 15:59:08", "category2 11", null, "category2-11" },
                    { 111111123.0, 111111123.0, "2023/08/31 15:59:08", "category2 12", null, "category2-12" },
                    { 111111124.0, 111111124.0, "2023/08/31 15:59:08", "category2 13", null, "category2-13" },
                    { 111111125.0, 111111125.0, "2023/08/31 15:59:08", "category2 14", null, "category2-14" },
                    { 111111126.0, 111111126.0, "2023/08/31 15:59:08", "category2 15", null, "category2-15" },
                    { 111111127.0, 111111127.0, "2023/08/31 15:59:08", "category2 16", null, "category2-16" },
                    { 111111128.0, 111111128.0, "2023/08/31 15:59:08", "category2 17", null, "category2-17" },
                    { 111111129.0, 111111129.0, "2023/08/31 15:59:08", "category2 18", null, "category2-18" },
                    { 111111130.0, 111111130.0, "2023/08/31 15:59:08", "category2 19", null, "category2-19" },
                    { 111111131.0, 111111131.0, "2023/08/31 15:59:08", "category2 20", null, "category2-20" },
                    { 111111132.0, 111111132.0, "2023/08/31 15:59:08", "category2 21", null, "category2-21" },
                    { 111111133.0, 111111133.0, "2023/08/31 15:59:08", "category2 22", null, "category2-22" },
                    { 111111134.0, 111111134.0, "2023/08/31 15:59:08", "category2 23", null, "category2-23" },
                    { 111111135.0, 111111135.0, "2023/08/31 15:59:08", "category2 24", null, "category2-24" },
                    { 111111136.0, 111111136.0, "2023/08/31 15:59:08", "category2 25", null, "category2-25" },
                    { 111111137.0, 111111137.0, "2023/08/31 15:59:08", "category2 26", null, "category2-26" },
                    { 111111138.0, 111111138.0, "2023/08/31 15:59:08", "category2 27", null, "category2-27" },
                    { 111111139.0, 111111139.0, "2023/08/31 15:59:08", "category2 28", null, "category2-28" },
                    { 111111140.0, 111111140.0, "2023/08/31 15:59:08", "category2 29", null, "category2-29" },
                    { 111111141.0, 111111141.0, "2023/08/31 15:59:08", "category2 30", null, "category2-30" },
                    { 111111142.0, 111111142.0, "2023/08/31 15:59:08", "category2 31", null, "category2-31" },
                    { 111111143.0, 111111143.0, "2023/08/31 15:59:08", "category2 32", null, "category2-32" },
                    { 111111144.0, 111111144.0, "2023/08/31 15:59:08", "category2 33", null, "category2-33" },
                    { 111111145.0, 111111145.0, "2023/08/31 15:59:08", "category2 34", null, "category2-34" },
                    { 111111146.0, 111111146.0, "2023/08/31 15:59:08", "category2 35", null, "category2-35" },
                    { 111111147.0, 111111147.0, "2023/08/31 15:59:08", "category2 36", null, "category2-36" },
                    { 111111148.0, 111111148.0, "2023/08/31 15:59:08", "category2 37", null, "category2-37" },
                    { 111111149.0, 111111149.0, "2023/08/31 15:59:08", "category2 38", null, "category2-38" },
                    { 111111150.0, 111111150.0, "2023/08/31 15:59:08", "category2 39", null, "category2-39" },
                    { 111111151.0, 111111151.0, "2023/08/31 15:59:08", "category2 40", null, "category2-40" },
                    { 111111152.0, 111111152.0, "2023/08/31 15:59:08", "category2 41", null, "category2-41" },
                    { 111111153.0, 111111153.0, "2023/08/31 15:59:08", "category2 42", null, "category2-42" },
                    { 111111154.0, 111111154.0, "2023/08/31 15:59:08", "category2 43", null, "category2-43" },
                    { 111111155.0, 111111155.0, "2023/08/31 15:59:08", "category2 44", null, "category2-44" },
                    { 111111156.0, 111111156.0, "2023/08/31 15:59:08", "category2 45", null, "category2-45" },
                    { 111111157.0, 111111157.0, "2023/08/31 15:59:08", "category2 46", null, "category2-46" },
                    { 111111158.0, 111111158.0, "2023/08/31 15:59:08", "category2 47", null, "category2-47" },
                    { 111111159.0, 111111159.0, "2023/08/31 15:59:08", "category2 48", null, "category2-48" },
                    { 111111160.0, 111111160.0, "2023/08/31 15:59:08", "category2 49", null, "category2-49" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "BrandId", "Category2Id", "CategoryId", "CreatedDate", "Description", "IsApproved", "IsHome", "Name", "Price", "ProductImage", "Quantity", "SalesCount", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 111111111.0, 111111111.0, 111111111.0, 111111111.0, "2023/08/31 15:59:08", "urun aciklamasi 0", true, false, "urun 0", 10.0, "1.jpg", 0, 0, "2023/08/31 15:59:08", "urun-0" },
                    { 111111112.0, 111111112.0, 111111112.0, 111111112.0, "2023/08/31 15:59:08", "urun aciklamasi 1", true, false, "urun 1", 10.0, "1.jpg", 1, 1, "2023/08/31 15:59:08", "urun-1" },
                    { 111111113.0, 111111113.0, 111111113.0, 111111113.0, "2023/08/31 15:59:08", "urun aciklamasi 2", true, false, "urun 2", 10.0, "1.jpg", 2, 2, "2023/08/31 15:59:08", "urun-2" },
                    { 111111114.0, 111111114.0, 111111114.0, 111111114.0, "2023/08/31 15:59:08", "urun aciklamasi 3", true, false, "urun 3", 10.0, "1.jpg", 3, 3, "2023/08/31 15:59:08", "urun-3" },
                    { 111111115.0, 111111115.0, 111111115.0, 111111115.0, "2023/08/31 15:59:08", "urun aciklamasi 4", true, false, "urun 4", 10.0, "1.jpg", 4, 4, "2023/08/31 15:59:08", "urun-4" },
                    { 111111116.0, 111111116.0, 111111116.0, 111111116.0, "2023/08/31 15:59:08", "urun aciklamasi 5", true, false, "urun 5", 10.0, "1.jpg", 5, 5, "2023/08/31 15:59:08", "urun-5" },
                    { 111111117.0, 111111117.0, 111111117.0, 111111117.0, "2023/08/31 15:59:08", "urun aciklamasi 6", true, false, "urun 6", 10.0, "1.jpg", 6, 6, "2023/08/31 15:59:08", "urun-6" },
                    { 111111118.0, 111111118.0, 111111118.0, 111111118.0, "2023/08/31 15:59:08", "urun aciklamasi 7", true, false, "urun 7", 10.0, "1.jpg", 7, 7, "2023/08/31 15:59:08", "urun-7" },
                    { 111111119.0, 111111119.0, 111111119.0, 111111119.0, "2023/08/31 15:59:08", "urun aciklamasi 8", true, false, "urun 8", 10.0, "1.jpg", 8, 8, "2023/08/31 15:59:08", "urun-8" },
                    { 111111120.0, 111111120.0, 111111120.0, 111111120.0, "2023/08/31 15:59:08", "urun aciklamasi 9", true, false, "urun 9", 10.0, "1.jpg", 9, 9, "2023/08/31 15:59:08", "urun-9" },
                    { 111111121.0, 111111121.0, 111111121.0, 111111121.0, "2023/08/31 15:59:08", "urun aciklamasi 10", true, false, "urun 10", 10.0, "1.jpg", 10, 10, "2023/08/31 15:59:08", "urun-10" },
                    { 111111122.0, 111111122.0, 111111122.0, 111111122.0, "2023/08/31 15:59:08", "urun aciklamasi 11", true, false, "urun 11", 10.0, "1.jpg", 11, 11, "2023/08/31 15:59:08", "urun-11" },
                    { 111111123.0, 111111123.0, 111111123.0, 111111123.0, "2023/08/31 15:59:08", "urun aciklamasi 12", true, false, "urun 12", 10.0, "1.jpg", 12, 12, "2023/08/31 15:59:08", "urun-12" },
                    { 111111124.0, 111111124.0, 111111124.0, 111111124.0, "2023/08/31 15:59:08", "urun aciklamasi 13", true, false, "urun 13", 10.0, "1.jpg", 13, 13, "2023/08/31 15:59:08", "urun-13" },
                    { 111111125.0, 111111125.0, 111111125.0, 111111125.0, "2023/08/31 15:59:08", "urun aciklamasi 14", true, false, "urun 14", 10.0, "1.jpg", 14, 14, "2023/08/31 15:59:08", "urun-14" },
                    { 111111126.0, 111111126.0, 111111126.0, 111111126.0, "2023/08/31 15:59:08", "urun aciklamasi 15", true, false, "urun 15", 10.0, "1.jpg", 15, 15, "2023/08/31 15:59:08", "urun-15" },
                    { 111111127.0, 111111127.0, 111111127.0, 111111127.0, "2023/08/31 15:59:08", "urun aciklamasi 16", true, false, "urun 16", 10.0, "1.jpg", 16, 16, "2023/08/31 15:59:08", "urun-16" },
                    { 111111128.0, 111111128.0, 111111128.0, 111111128.0, "2023/08/31 15:59:08", "urun aciklamasi 17", true, false, "urun 17", 10.0, "1.jpg", 17, 17, "2023/08/31 15:59:08", "urun-17" },
                    { 111111129.0, 111111129.0, 111111129.0, 111111129.0, "2023/08/31 15:59:08", "urun aciklamasi 18", true, false, "urun 18", 10.0, "1.jpg", 18, 18, "2023/08/31 15:59:08", "urun-18" },
                    { 111111130.0, 111111130.0, 111111130.0, 111111130.0, "2023/08/31 15:59:08", "urun aciklamasi 19", true, false, "urun 19", 10.0, "1.jpg", 19, 19, "2023/08/31 15:59:08", "urun-19" },
                    { 111111131.0, 111111131.0, 111111131.0, 111111131.0, "2023/08/31 15:59:08", "urun aciklamasi 20", true, false, "urun 20", 10.0, "1.jpg", 20, 20, "2023/08/31 15:59:08", "urun-20" },
                    { 111111132.0, 111111132.0, 111111132.0, 111111132.0, "2023/08/31 15:59:08", "urun aciklamasi 21", true, false, "urun 21", 10.0, "1.jpg", 21, 21, "2023/08/31 15:59:08", "urun-21" },
                    { 111111133.0, 111111133.0, 111111133.0, 111111133.0, "2023/08/31 15:59:08", "urun aciklamasi 22", true, false, "urun 22", 10.0, "1.jpg", 22, 22, "2023/08/31 15:59:08", "urun-22" },
                    { 111111134.0, 111111134.0, 111111134.0, 111111134.0, "2023/08/31 15:59:08", "urun aciklamasi 23", true, false, "urun 23", 10.0, "1.jpg", 23, 23, "2023/08/31 15:59:08", "urun-23" },
                    { 111111135.0, 111111135.0, 111111135.0, 111111135.0, "2023/08/31 15:59:08", "urun aciklamasi 24", true, false, "urun 24", 10.0, "1.jpg", 24, 24, "2023/08/31 15:59:08", "urun-24" },
                    { 111111136.0, 111111136.0, 111111136.0, 111111136.0, "2023/08/31 15:59:08", "urun aciklamasi 25", true, false, "urun 25", 10.0, "1.jpg", 25, 25, "2023/08/31 15:59:08", "urun-25" },
                    { 111111137.0, 111111137.0, 111111137.0, 111111137.0, "2023/08/31 15:59:08", "urun aciklamasi 26", true, false, "urun 26", 10.0, "1.jpg", 26, 26, "2023/08/31 15:59:08", "urun-26" },
                    { 111111138.0, 111111138.0, 111111138.0, 111111138.0, "2023/08/31 15:59:08", "urun aciklamasi 27", true, false, "urun 27", 10.0, "1.jpg", 27, 27, "2023/08/31 15:59:08", "urun-27" },
                    { 111111139.0, 111111139.0, 111111139.0, 111111139.0, "2023/08/31 15:59:08", "urun aciklamasi 28", true, false, "urun 28", 10.0, "1.jpg", 28, 28, "2023/08/31 15:59:08", "urun-28" },
                    { 111111140.0, 111111140.0, 111111140.0, 111111140.0, "2023/08/31 15:59:08", "urun aciklamasi 29", true, false, "urun 29", 10.0, "1.jpg", 29, 29, "2023/08/31 15:59:08", "urun-29" },
                    { 111111141.0, 111111141.0, 111111141.0, 111111141.0, "2023/08/31 15:59:08", "urun aciklamasi 30", true, false, "urun 30", 10.0, "1.jpg", 30, 30, "2023/08/31 15:59:08", "urun-30" },
                    { 111111142.0, 111111142.0, 111111142.0, 111111142.0, "2023/08/31 15:59:08", "urun aciklamasi 31", true, false, "urun 31", 10.0, "1.jpg", 31, 31, "2023/08/31 15:59:08", "urun-31" },
                    { 111111143.0, 111111143.0, 111111143.0, 111111143.0, "2023/08/31 15:59:08", "urun aciklamasi 32", true, false, "urun 32", 10.0, "1.jpg", 32, 32, "2023/08/31 15:59:08", "urun-32" },
                    { 111111144.0, 111111144.0, 111111144.0, 111111144.0, "2023/08/31 15:59:08", "urun aciklamasi 33", true, false, "urun 33", 10.0, "1.jpg", 33, 33, "2023/08/31 15:59:08", "urun-33" },
                    { 111111145.0, 111111145.0, 111111145.0, 111111145.0, "2023/08/31 15:59:08", "urun aciklamasi 34", true, false, "urun 34", 10.0, "1.jpg", 34, 34, "2023/08/31 15:59:08", "urun-34" },
                    { 111111146.0, 111111146.0, 111111146.0, 111111146.0, "2023/08/31 15:59:08", "urun aciklamasi 35", true, false, "urun 35", 10.0, "1.jpg", 35, 35, "2023/08/31 15:59:08", "urun-35" },
                    { 111111147.0, 111111147.0, 111111147.0, 111111147.0, "2023/08/31 15:59:08", "urun aciklamasi 36", true, false, "urun 36", 10.0, "1.jpg", 36, 36, "2023/08/31 15:59:08", "urun-36" },
                    { 111111148.0, 111111148.0, 111111148.0, 111111148.0, "2023/08/31 15:59:08", "urun aciklamasi 37", true, false, "urun 37", 10.0, "1.jpg", 37, 37, "2023/08/31 15:59:08", "urun-37" },
                    { 111111149.0, 111111149.0, 111111149.0, 111111149.0, "2023/08/31 15:59:08", "urun aciklamasi 38", true, false, "urun 38", 10.0, "1.jpg", 38, 38, "2023/08/31 15:59:08", "urun-38" },
                    { 111111150.0, 111111150.0, 111111150.0, 111111150.0, "2023/08/31 15:59:08", "urun aciklamasi 39", true, false, "urun 39", 10.0, "1.jpg", 39, 39, "2023/08/31 15:59:08", "urun-39" },
                    { 111111151.0, 111111151.0, 111111151.0, 111111151.0, "2023/08/31 15:59:08", "urun aciklamasi 40", true, false, "urun 40", 10.0, "1.jpg", 40, 40, "2023/08/31 15:59:08", "urun-40" },
                    { 111111152.0, 111111152.0, 111111152.0, 111111152.0, "2023/08/31 15:59:08", "urun aciklamasi 41", true, false, "urun 41", 10.0, "1.jpg", 41, 41, "2023/08/31 15:59:08", "urun-41" },
                    { 111111153.0, 111111153.0, 111111153.0, 111111153.0, "2023/08/31 15:59:08", "urun aciklamasi 42", true, false, "urun 42", 10.0, "1.jpg", 42, 42, "2023/08/31 15:59:08", "urun-42" },
                    { 111111154.0, 111111154.0, 111111154.0, 111111154.0, "2023/08/31 15:59:08", "urun aciklamasi 43", true, false, "urun 43", 10.0, "1.jpg", 43, 43, "2023/08/31 15:59:08", "urun-43" },
                    { 111111155.0, 111111155.0, 111111155.0, 111111155.0, "2023/08/31 15:59:08", "urun aciklamasi 44", true, false, "urun 44", 10.0, "1.jpg", 44, 44, "2023/08/31 15:59:08", "urun-44" },
                    { 111111156.0, 111111156.0, 111111156.0, 111111156.0, "2023/08/31 15:59:08", "urun aciklamasi 45", true, false, "urun 45", 10.0, "1.jpg", 45, 45, "2023/08/31 15:59:08", "urun-45" },
                    { 111111157.0, 111111157.0, 111111157.0, 111111157.0, "2023/08/31 15:59:08", "urun aciklamasi 46", true, false, "urun 46", 10.0, "1.jpg", 46, 46, "2023/08/31 15:59:08", "urun-46" },
                    { 111111158.0, 111111158.0, 111111158.0, 111111158.0, "2023/08/31 15:59:08", "urun aciklamasi 47", true, false, "urun 47", 10.0, "1.jpg", 47, 47, "2023/08/31 15:59:08", "urun-47" },
                    { 111111159.0, 111111159.0, 111111159.0, 111111159.0, "2023/08/31 15:59:08", "urun aciklamasi 48", true, false, "urun 48", 10.0, "1.jpg", 48, 48, "2023/08/31 15:59:08", "urun-48" },
                    { 111111160.0, 111111160.0, 111111160.0, 111111160.0, "2023/08/31 15:59:08", "urun aciklamasi 49", true, false, "urun 49", 10.0, "1.jpg", 49, 49, "2023/08/31 15:59:08", "urun-49" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "CreatedDate", "Description", "ProductId", "UpdatedDate", "UserFirstname", "UserId", "UserLastname" },
                values: new object[,]
                {
                    { 111111111.0, "2023/08/31 15:59:08", "description - 0", 111111111.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111112.0, "2023/08/31 15:59:08", "description - 1", 111111112.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111113.0, "2023/08/31 15:59:08", "description - 2", 111111113.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111114.0, "2023/08/31 15:59:08", "description - 3", 111111114.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111115.0, "2023/08/31 15:59:08", "description - 4", 111111115.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111116.0, "2023/08/31 15:59:08", "description - 5", 111111116.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111117.0, "2023/08/31 15:59:08", "description - 6", 111111117.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111118.0, "2023/08/31 15:59:08", "description - 7", 111111118.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111119.0, "2023/08/31 15:59:08", "description - 8", 111111119.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111120.0, "2023/08/31 15:59:08", "description - 9", 111111120.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111121.0, "2023/08/31 15:59:08", "description - 10", 111111121.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111122.0, "2023/08/31 15:59:08", "description - 11", 111111122.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111123.0, "2023/08/31 15:59:08", "description - 12", 111111123.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111124.0, "2023/08/31 15:59:08", "description - 13", 111111124.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111125.0, "2023/08/31 15:59:08", "description - 14", 111111125.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111126.0, "2023/08/31 15:59:08", "description - 15", 111111126.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111127.0, "2023/08/31 15:59:08", "description - 16", 111111127.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111128.0, "2023/08/31 15:59:08", "description - 17", 111111128.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111129.0, "2023/08/31 15:59:08", "description - 18", 111111129.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111130.0, "2023/08/31 15:59:08", "description - 19", 111111130.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111131.0, "2023/08/31 15:59:08", "description - 20", 111111131.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111132.0, "2023/08/31 15:59:08", "description - 21", 111111132.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111133.0, "2023/08/31 15:59:08", "description - 22", 111111133.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111134.0, "2023/08/31 15:59:08", "description - 23", 111111134.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111135.0, "2023/08/31 15:59:08", "description - 24", 111111135.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111136.0, "2023/08/31 15:59:08", "description - 25", 111111136.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111137.0, "2023/08/31 15:59:08", "description - 26", 111111137.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111138.0, "2023/08/31 15:59:08", "description - 27", 111111138.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111139.0, "2023/08/31 15:59:08", "description - 28", 111111139.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111140.0, "2023/08/31 15:59:08", "description - 29", 111111140.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111141.0, "2023/08/31 15:59:08", "description - 30", 111111141.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111142.0, "2023/08/31 15:59:08", "description - 31", 111111142.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111143.0, "2023/08/31 15:59:08", "description - 32", 111111143.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111144.0, "2023/08/31 15:59:08", "description - 33", 111111144.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111145.0, "2023/08/31 15:59:08", "description - 34", 111111145.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111146.0, "2023/08/31 15:59:08", "description - 35", 111111146.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111147.0, "2023/08/31 15:59:08", "description - 36", 111111147.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111148.0, "2023/08/31 15:59:08", "description - 37", 111111148.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111149.0, "2023/08/31 15:59:08", "description - 38", 111111149.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111150.0, "2023/08/31 15:59:08", "description - 39", 111111150.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111151.0, "2023/08/31 15:59:08", "description - 40", 111111151.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111152.0, "2023/08/31 15:59:08", "description - 41", 111111152.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111153.0, "2023/08/31 15:59:08", "description - 42", 111111153.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111154.0, "2023/08/31 15:59:08", "description - 43", 111111154.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111155.0, "2023/08/31 15:59:08", "description - 44", 111111155.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111156.0, "2023/08/31 15:59:08", "description - 45", 111111156.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111157.0, "2023/08/31 15:59:08", "description - 46", 111111157.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111158.0, "2023/08/31 15:59:08", "description - 47", 111111158.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111159.0, "2023/08/31 15:59:08", "description - 48", 111111159.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" },
                    { 111111160.0, "2023/08/31 15:59:08", "description - 49", 111111160.0, null, "John", "2c828e40-4226-42b7-808d-de6f20863d13", "Doe" }
                });

            migrationBuilder.InsertData(
                table: "ImageUrls",
                columns: new[] { "ImageUrlId", "CreatedDate", "ProductId", "UpdatedDate", "Url" },
                values: new object[,]
                {
                    { 111111111.0, null, 111111111.0, null, "1.jpg" },
                    { 111111112.0, null, 111111112.0, null, "1.jpg" },
                    { 111111113.0, null, 111111113.0, null, "1.jpg" },
                    { 111111114.0, null, 111111114.0, null, "1.jpg" },
                    { 111111115.0, null, 111111115.0, null, "1.jpg" },
                    { 111111116.0, null, 111111116.0, null, "1.jpg" },
                    { 111111117.0, null, 111111117.0, null, "1.jpg" },
                    { 111111118.0, null, 111111118.0, null, "1.jpg" },
                    { 111111119.0, null, 111111119.0, null, "1.jpg" },
                    { 111111120.0, null, 111111120.0, null, "1.jpg" },
                    { 111111121.0, null, 111111121.0, null, "1.jpg" },
                    { 111111122.0, null, 111111122.0, null, "1.jpg" },
                    { 111111123.0, null, 111111123.0, null, "1.jpg" },
                    { 111111124.0, null, 111111124.0, null, "1.jpg" },
                    { 111111125.0, null, 111111125.0, null, "1.jpg" },
                    { 111111126.0, null, 111111126.0, null, "1.jpg" },
                    { 111111127.0, null, 111111127.0, null, "1.jpg" },
                    { 111111128.0, null, 111111128.0, null, "1.jpg" },
                    { 111111129.0, null, 111111129.0, null, "1.jpg" },
                    { 111111130.0, null, 111111130.0, null, "1.jpg" },
                    { 111111131.0, null, 111111131.0, null, "1.jpg" },
                    { 111111132.0, null, 111111132.0, null, "1.jpg" },
                    { 111111133.0, null, 111111133.0, null, "1.jpg" },
                    { 111111134.0, null, 111111134.0, null, "1.jpg" },
                    { 111111135.0, null, 111111135.0, null, "1.jpg" },
                    { 111111136.0, null, 111111136.0, null, "1.jpg" },
                    { 111111137.0, null, 111111137.0, null, "1.jpg" },
                    { 111111138.0, null, 111111138.0, null, "1.jpg" },
                    { 111111139.0, null, 111111139.0, null, "1.jpg" },
                    { 111111140.0, null, 111111140.0, null, "1.jpg" },
                    { 111111141.0, null, 111111141.0, null, "1.jpg" },
                    { 111111142.0, null, 111111142.0, null, "1.jpg" },
                    { 111111143.0, null, 111111143.0, null, "1.jpg" },
                    { 111111144.0, null, 111111144.0, null, "1.jpg" },
                    { 111111145.0, null, 111111145.0, null, "1.jpg" },
                    { 111111146.0, null, 111111146.0, null, "1.jpg" },
                    { 111111147.0, null, 111111147.0, null, "1.jpg" },
                    { 111111148.0, null, 111111148.0, null, "1.jpg" },
                    { 111111149.0, null, 111111149.0, null, "1.jpg" },
                    { 111111150.0, null, 111111150.0, null, "1.jpg" },
                    { 111111151.0, null, 111111151.0, null, "1.jpg" },
                    { 111111152.0, null, 111111152.0, null, "1.jpg" },
                    { 111111153.0, null, 111111153.0, null, "1.jpg" },
                    { 111111154.0, null, 111111154.0, null, "1.jpg" },
                    { 111111155.0, null, 111111155.0, null, "1.jpg" },
                    { 111111156.0, null, 111111156.0, null, "1.jpg" },
                    { 111111157.0, null, 111111157.0, null, "1.jpg" },
                    { 111111158.0, null, 111111158.0, null, "1.jpg" },
                    { 111111159.0, null, 111111159.0, null, "1.jpg" },
                    { 111111160.0, null, 111111160.0, null, "1.jpg" }
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
                name: "Categories");
        }
    }
}