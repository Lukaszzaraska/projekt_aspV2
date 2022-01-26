using Microsoft.EntityFrameworkCore.Migrations;

namespace projekt_asp.Migrations
{
    public partial class MojeTabele1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "registerModelUserId",
                table: "User_Msg",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Msg_registerModelUserId",
                table: "User_Msg",
                column: "registerModelUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Msg_Users_registerModelUserId",
                table: "User_Msg",
                column: "registerModelUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Msg_Users_registerModelUserId",
                table: "User_Msg");

            migrationBuilder.DropIndex(
                name: "IX_User_Msg_registerModelUserId",
                table: "User_Msg");

            migrationBuilder.DropColumn(
                name: "registerModelUserId",
                table: "User_Msg");
        }
    }
}
