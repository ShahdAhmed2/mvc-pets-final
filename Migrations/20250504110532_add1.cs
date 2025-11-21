using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace mvcpets.Migrations
{
    /// <inheritdoc />
    public partial class add1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HomeCards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HomeCards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HomeCards",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "HomeCards",
                columns: new[] { "Id", "ButtonClass", "ButtonLink", "ButtonText", "Description", "Title" },
                values: new object[,]
                {
                    { 4561, "btn-success", "/Home/CareGuide", "Learn More", "Access expert advice on how to care for your pets.", "Care Guides" },
                    { 4562, "btn-danger", "/BlogPosts/Index", "Get Help", "Get immediate assistance for lost or injured pets.", "Emergency Help" },
                    { 4563, "btn-warning", "/Donation/Create", "Donate Now", "Your contribution helps us provide better care for pets in need.", "Donation" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HomeCards",
                keyColumn: "Id",
                keyValue: 4561);

            migrationBuilder.DeleteData(
                table: "HomeCards",
                keyColumn: "Id",
                keyValue: 4562);

            migrationBuilder.DeleteData(
                table: "HomeCards",
                keyColumn: "Id",
                keyValue: 4563);

            migrationBuilder.InsertData(
                table: "HomeCards",
                columns: new[] { "Id", "ButtonClass", "ButtonLink", "ButtonText", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "btn-success", "/Home/CareGuide", "Learn More", "Access expert advice on how to care for your pets.", "Care Guides" },
                    { 2, "btn-danger", "/BlogPosts/Index", "Get Help", "Get immediate assistance for lost or injured pets.", "Emergency Help" },
                    { 3, "btn-warning", "/Donation/Create", "Donate Now", "Your contribution helps us provide better care for pets in need.", "Donation" }
                });
        }
    }
}
