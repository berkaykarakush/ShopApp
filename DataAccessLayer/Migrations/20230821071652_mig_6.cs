using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111112.0, 111111112.0 },
                column: "Id",
                value: 271199535.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111113.0, 111111113.0 },
                column: "Id",
                value: 503843105.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111114.0, 111111114.0 },
                column: "Id",
                value: 176958495.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111115.0, 111111115.0 },
                column: "Id",
                value: 925313917.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111116.0, 111111116.0 },
                column: "Id",
                value: 937179057.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111117.0, 111111117.0 },
                column: "Id",
                value: 649564283.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111118.0, 111111118.0 },
                column: "Id",
                value: 863748044.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111119.0, 111111119.0 },
                column: "Id",
                value: 666871278.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111120.0, 111111120.0 },
                column: "Id",
                value: 875362971.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111112.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111113.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111114.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111115.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111116.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111117.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111118.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111119.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111120.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111121.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111122.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111123.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111124.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111125.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111126.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111127.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111128.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111129.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111130.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111131.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111132.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111133.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111134.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111135.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111136.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111137.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111138.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111139.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111140.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111141.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111142.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111143.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111144.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111145.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111146.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111147.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111148.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111149.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111150.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111151.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111152.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111153.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111154.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111155.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111156.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111157.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111158.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111159.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111160.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:16:52", "2023/08/21 10:16:52" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111112.0, 111111112.0 },
                column: "Id",
                value: 563796250.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111113.0, 111111113.0 },
                column: "Id",
                value: 652123860.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111114.0, 111111114.0 },
                column: "Id",
                value: 122644528.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111115.0, 111111115.0 },
                column: "Id",
                value: 573224294.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111116.0, 111111116.0 },
                column: "Id",
                value: 814851053.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111117.0, 111111117.0 },
                column: "Id",
                value: 243203327.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111118.0, 111111118.0 },
                column: "Id",
                value: 573112945.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111119.0, 111111119.0 },
                column: "Id",
                value: 852371101.0);

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 111111120.0, 111111120.0 },
                column: "Id",
                value: 155993302.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111112.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111113.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111114.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111115.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111116.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111117.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111118.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111119.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111120.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111121.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111122.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111123.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111124.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111125.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111126.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111127.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111128.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111129.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111130.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111131.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111132.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111133.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111134.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111135.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111136.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111137.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111138.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111139.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111140.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111141.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111142.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111143.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111144.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111145.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111146.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111147.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111148.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111149.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111150.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111151.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111152.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111153.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111154.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111155.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111156.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111157.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111158.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111159.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 111111160.0,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { "2023/08/21 10:15:02", "2023/08/21 10:15:02" });
        }
    }
}
