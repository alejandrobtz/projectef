using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectef.Migrations
{
    /// <inheritdoc />
    public partial class ColumnEffortGrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EffortGrade",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EffortGrade",
                table: "Category");
        }
    }
}
