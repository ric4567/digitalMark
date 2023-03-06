using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalMark.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTechnologyOnClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tecnology",
                table: "Client",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tecnology",
                table: "Client");
        }
    }
}
