using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazingChat.Server.Data.Migrations
{
    public partial class FixedUserIdColumnsInMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_FromUserId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_ToUserId",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_FromUserId",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_ToUserId",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "FromUserId",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "ToUserId",
                table: "Message");

            migrationBuilder.CreateIndex(
                name: "IX_Message_FromId",
                table: "Message",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_ToId",
                table: "Message",
                column: "ToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_FromId",
                table: "Message",
                column: "FromId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_ToId",
                table: "Message",
                column: "ToId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_FromId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_ToId",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_FromId",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_ToId",
                table: "Message");

            migrationBuilder.AddColumn<int>(
                name: "FromUserId",
                table: "Message",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToUserId",
                table: "Message",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Message_FromUserId",
                table: "Message",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_ToUserId",
                table: "Message",
                column: "ToUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_FromUserId",
                table: "Message",
                column: "FromUserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_ToUserId",
                table: "Message",
                column: "ToUserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
