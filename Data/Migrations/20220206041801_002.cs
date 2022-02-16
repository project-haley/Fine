using Microsoft.EntityFrameworkCore.Migrations;

namespace Fine.Data.Migrations
{
    public partial class _002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_AspNetUsers_ChatUserId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_ChatHistory_ChatHistoryId",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatHistory",
                table: "ChatHistory");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Messages");

            migrationBuilder.RenameTable(
                name: "ChatHistory",
                newName: "ChatHistories");

            migrationBuilder.RenameIndex(
                name: "IX_Message_ChatUserId",
                table: "Messages",
                newName: "IX_Messages_ChatUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_ChatHistoryId",
                table: "Messages",
                newName: "IX_Messages_ChatHistoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatHistories",
                table: "ChatHistories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_ChatUserId",
                table: "Messages",
                column: "ChatUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_ChatHistories_ChatHistoryId",
                table: "Messages",
                column: "ChatHistoryId",
                principalTable: "ChatHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_ChatUserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_ChatHistories_ChatHistoryId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatHistories",
                table: "ChatHistories");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message");

            migrationBuilder.RenameTable(
                name: "ChatHistories",
                newName: "ChatHistory");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ChatUserId",
                table: "Message",
                newName: "IX_Message_ChatUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ChatHistoryId",
                table: "Message",
                newName: "IX_Message_ChatHistoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatHistory",
                table: "ChatHistory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_AspNetUsers_ChatUserId",
                table: "Message",
                column: "ChatUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_ChatHistory_ChatHistoryId",
                table: "Message",
                column: "ChatHistoryId",
                principalTable: "ChatHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
