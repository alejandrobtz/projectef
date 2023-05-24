using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectef.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Todo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "EffortGrade", "Name" },
                values: new object[,]
                {
                    { new Guid("78f16f43-1ed2-4286-a27f-0a8786705e02"), null, 50, "Personal Activities" },
                    { new Guid("78f16f43-1ed2-4286-a27f-0a8786705efc"), null, 20, "Pending Activities" }
                });

            migrationBuilder.InsertData(
                table: "Todo",
                columns: new[] { "TaskId", "CategoryId", "CreatedTime", "Description", "Priority", "Title" },
                values: new object[,]
                {
                    { new Guid("78f16f43-1ed2-4286-a27f-0a8786705e10"), new Guid("78f16f43-1ed2-4286-a27f-0a8786705efc"), new DateTime(2023, 5, 24, 8, 53, 35, 785, DateTimeKind.Local).AddTicks(2531), null, 1, "Pay Bills" },
                    { new Guid("78f16f43-1ed2-4286-a27f-0a8786705e11"), new Guid("78f16f43-1ed2-4286-a27f-0a8786705e02"), new DateTime(2023, 5, 24, 8, 53, 35, 785, DateTimeKind.Local).AddTicks(2578), null, 0, "Watch movie on netflix" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Todo",
                keyColumn: "TaskId",
                keyValue: new Guid("78f16f43-1ed2-4286-a27f-0a8786705e10"));

            migrationBuilder.DeleteData(
                table: "Todo",
                keyColumn: "TaskId",
                keyValue: new Guid("78f16f43-1ed2-4286-a27f-0a8786705e11"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("78f16f43-1ed2-4286-a27f-0a8786705e02"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("78f16f43-1ed2-4286-a27f-0a8786705efc"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Todo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
