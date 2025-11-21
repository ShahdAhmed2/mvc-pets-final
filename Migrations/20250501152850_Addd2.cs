using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvcpets.Migrations
{
    /// <inheritdoc />
    public partial class Addd2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_AspNetUsers_UserId",
                table: "Donations");

            migrationBuilder.DropIndex(
                name: "IX_Donations_UserId",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Donations");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "Donations",
                newName: "Status");

            migrationBuilder.AddColumn<string>(
                name: "AdminNote",
                table: "Donations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Donations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donations_ApplicationUserId",
                table: "Donations",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_AspNetUsers_ApplicationUserId",
                table: "Donations",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_AspNetUsers_ApplicationUserId",
                table: "Donations");

            migrationBuilder.DropIndex(
                name: "IX_Donations_ApplicationUserId",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "AdminNote",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Donations");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Donations",
                newName: "Notes");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Donations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_UserId",
                table: "Donations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_AspNetUsers_UserId",
                table: "Donations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
