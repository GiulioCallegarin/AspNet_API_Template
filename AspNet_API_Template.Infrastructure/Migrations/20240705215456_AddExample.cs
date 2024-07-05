using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNet_API_Template.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddExample : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExampleMessages",
                columns: table => new
                {
                    ExampleMessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExampleMessages", x => x.ExampleMessageId);
                });

            migrationBuilder.CreateTable(
                name: "Examples",
                columns: table => new
                {
                    ExampleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExampleMessageId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examples", x => x.ExampleId);
                    table.ForeignKey(
                        name: "FK_Examples_ExampleMessages_ExampleMessageId",
                        column: x => x.ExampleMessageId,
                        principalTable: "ExampleMessages",
                        principalColumn: "ExampleMessageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ExampleMessages",
                columns: new[] { "ExampleMessageId", "Message" },
                values: new object[] { new Guid("bf047b2a-eadd-4cf0-a7da-09d19ab3fb9f"), "This is an example" });

            migrationBuilder.InsertData(
                table: "Examples",
                columns: new[] { "ExampleId", "ExampleMessageId" },
                values: new object[] { new Guid("d7bc7043-67e6-4d83-886d-636819e33a23"), new Guid("bf047b2a-eadd-4cf0-a7da-09d19ab3fb9f") });

            migrationBuilder.CreateIndex(
                name: "IX_Examples_ExampleMessageId",
                table: "Examples",
                column: "ExampleMessageId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Examples");

            migrationBuilder.DropTable(
                name: "ExampleMessages");
        }
    }
}
