using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "CartItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "ProductImage",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductQuantity",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "ProductImage",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "ProductQuantity",
                table: "CartItems");

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111112.0, 111111112.0 },
                column: "Id",
                value: 116557806.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111113.0, 111111113.0 },
                column: "Id",
                value: 752698525.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111114.0, 111111114.0 },
                column: "Id",
                value: 685307395.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111115.0, 111111115.0 },
                column: "Id",
                value: 563304109.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111116.0, 111111116.0 },
                column: "Id",
                value: 722072845.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111117.0, 111111117.0 },
                column: "Id",
                value: 880317711.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111118.0, 111111118.0 },
                column: "Id",
                value: 365620929.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111119.0, 111111119.0 },
                column: "Id",
                value: 390540500.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111120.0, 111111120.0 },
                column: "Id",
                value: 946048035.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111112.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111113.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111114.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111115.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111116.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111117.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111118.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111119.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111120.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111121.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111122.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111123.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111124.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111125.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111126.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111127.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111128.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111129.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111130.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111131.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111132.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111133.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111134.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111135.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111136.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111137.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111138.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111139.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111140.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111141.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111142.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111143.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111144.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111145.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111146.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111147.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111148.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111149.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111150.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111151.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111152.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111153.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111154.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111155.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111156.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111157.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111158.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111159.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111160.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/17 16:50:59", "2023/08/17 16:50:59" });
        }
    }
}
