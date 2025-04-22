using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roster.App.Migrations
{
    /// <inheritdoc />
    public partial class ObjectiveEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PriorityRating",
                table: "Objectives",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Objectives",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Objectives");

            migrationBuilder.AlterColumn<string>(
                name: "PriorityRating",
                table: "Objectives",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }
    }
}
