﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "ProductQuantity",
                table: "CartItems",
                newName: "Stock");

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111112.0, 111111112.0 },
                column: "Id",
                value: 624787262.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111113.0, 111111113.0 },
                column: "Id",
                value: 801787699.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111114.0, 111111114.0 },
                column: "Id",
                value: 968995744.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111115.0, 111111115.0 },
                column: "Id",
                value: 604191687.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111116.0, 111111116.0 },
                column: "Id",
                value: 148220965.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111117.0, 111111117.0 },
                column: "Id",
                value: 196974084.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111118.0, 111111118.0 },
                column: "Id",
                value: 991766176.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111119.0, 111111119.0 },
                column: "Id",
                value: 694550996.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111120.0, 111111120.0 },
                column: "Id",
                value: 512608318.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111112.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111113.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111114.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111115.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111116.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111117.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111118.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111119.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111120.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111121.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111122.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111123.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111124.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111125.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111126.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111127.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111128.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111129.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111130.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111131.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111132.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111133.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111134.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111135.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111136.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111137.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111138.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111139.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111140.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111141.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111142.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111143.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111144.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111145.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111146.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111147.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111148.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111149.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111150.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111151.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111152.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111153.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111154.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111155.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111156.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111157.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111158.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111159.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111160.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:10:58", "2023/08/21 09:10:58" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "CartItems",
                newName: "ProductQuantity");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111112.0, 111111112.0 },
                column: "Id",
                value: 175385683.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111113.0, 111111113.0 },
                column: "Id",
                value: 716594311.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111114.0, 111111114.0 },
                column: "Id",
                value: 881537415.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111115.0, 111111115.0 },
                column: "Id",
                value: 981069327.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111116.0, 111111116.0 },
                column: "Id",
                value: 919115561.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111117.0, 111111117.0 },
                column: "Id",
                value: 942046954.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111118.0, 111111118.0 },
                column: "Id",
                value: 489940622.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111119.0, 111111119.0 },
                column: "Id",
                value: 710543482.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111120.0, 111111120.0 },
                column: "Id",
                value: 696546498.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111112.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111113.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111114.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111115.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111116.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111117.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111118.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111119.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111120.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111121.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111122.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111123.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111124.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111125.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111126.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111127.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111128.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111129.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111130.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111131.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111132.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111133.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111134.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111135.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111136.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111137.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111138.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111139.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111140.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111141.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111142.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111143.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111144.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111145.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111146.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111147.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111148.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111149.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111150.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111151.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111152.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111153.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111154.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111155.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111156.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111157.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111158.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111159.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111160.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 09:01:28", "2023/08/21 09:01:28" });
        }
    }
}