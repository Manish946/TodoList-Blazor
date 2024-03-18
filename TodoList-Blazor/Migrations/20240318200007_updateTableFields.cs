using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoListBlazor.Migrations
{
    /// <inheritdoc />
    public partial class updateTableFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "User",
                newName: "userName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Todolist",
                newName: "Item");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userName",
                table: "User",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "Item",
                table: "Todolist",
                newName: "Name");
        }
    }
}
