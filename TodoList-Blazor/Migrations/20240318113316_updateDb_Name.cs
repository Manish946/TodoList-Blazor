using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoListBlazor.Migrations
{
    /// <inheritdoc />
    public partial class updateDb_Name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cprs_Users_UserId",
                table: "Cprs");

            migrationBuilder.DropForeignKey(
                name: "FK_Todolists_Users_UserID",
                table: "Todolists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Todolists",
                table: "Todolists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cprs",
                table: "Cprs");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Todolists",
                newName: "Todolist");

            migrationBuilder.RenameTable(
                name: "Cprs",
                newName: "Cpr");

            migrationBuilder.RenameIndex(
                name: "IX_Todolists_UserID",
                table: "Todolist",
                newName: "IX_Todolist_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Cprs_UserId",
                table: "Cpr",
                newName: "IX_Cpr_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Todolist",
                table: "Todolist",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cpr",
                table: "Cpr",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cpr_User_UserId",
                table: "Cpr",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Todolist_User_UserID",
                table: "Todolist",
                column: "UserID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cpr_User_UserId",
                table: "Cpr");

            migrationBuilder.DropForeignKey(
                name: "FK_Todolist_User_UserID",
                table: "Todolist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Todolist",
                table: "Todolist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cpr",
                table: "Cpr");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Todolist",
                newName: "Todolists");

            migrationBuilder.RenameTable(
                name: "Cpr",
                newName: "Cprs");

            migrationBuilder.RenameIndex(
                name: "IX_Todolist_UserID",
                table: "Todolists",
                newName: "IX_Todolists_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Cpr_UserId",
                table: "Cprs",
                newName: "IX_Cprs_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Todolists",
                table: "Todolists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cprs",
                table: "Cprs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cprs_Users_UserId",
                table: "Cprs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Todolists_Users_UserID",
                table: "Todolists",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
