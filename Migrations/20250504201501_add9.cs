using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvcpets.Migrations
{
    /// <inheritdoc />
    public partial class add9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Adoptions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adoptions_ApplicationUserId",
                table: "Adoptions",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adoptions_AspNetUsers_ApplicationUserId",
                table: "Adoptions",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adoptions_AspNetUsers_ApplicationUserId",
                table: "Adoptions");

            migrationBuilder.DropIndex(
                name: "IX_Adoptions_ApplicationUserId",
                table: "Adoptions");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Adoptions");
        }
    }
}
