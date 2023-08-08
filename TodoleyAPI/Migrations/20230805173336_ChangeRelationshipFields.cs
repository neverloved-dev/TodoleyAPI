using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoleyAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationshipFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_TodoList_TodoItemListId",
                table: "TodoItems");

            migrationBuilder.DropIndex(
                name: "IX_TodoItems_TodoItemListId",
                table: "TodoItems");

            migrationBuilder.AddColumn<int>(
                name: "TodoListId",
                table: "TodoItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_TodoListId",
                table: "TodoItems",
                column: "TodoListId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_TodoList_TodoListId",
                table: "TodoItems",
                column: "TodoListId",
                principalTable: "TodoList",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_TodoList_TodoListId",
                table: "TodoItems");

            migrationBuilder.DropIndex(
                name: "IX_TodoItems_TodoListId",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "TodoListId",
                table: "TodoItems");

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_TodoItemListId",
                table: "TodoItems",
                column: "TodoItemListId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_TodoList_TodoItemListId",
                table: "TodoItems",
                column: "TodoItemListId",
                principalTable: "TodoList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
