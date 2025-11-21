using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvcpets.Migrations
{
    /// <inheritdoc />
    public partial class add6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_AspNetUsers_ApplicationUserId",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "SentDate",
                table: "Notifications");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Donations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_AspNetUsers_ApplicationUserId",
                table: "Donations",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_AspNetUsers_ApplicationUserId",
                table: "Donations");

            migrationBuilder.AddColumn<DateTime>(
                name: "SentDate",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Donations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_AspNetUsers_ApplicationUserId",
                table: "Donations",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
