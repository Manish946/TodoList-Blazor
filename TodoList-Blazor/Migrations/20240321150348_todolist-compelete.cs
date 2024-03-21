using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoListBlazor.Migrations
{
    /// <inheritdoc />
    public partial class todolistcompelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Todolist",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Todolist");
        }
    }
}
