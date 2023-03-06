using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalMark.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixTechnologyColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tecnology",
                table: "Client",
                newName: "Technology");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Technology",
                table: "Client",
                newName: "Tecnology");
        }
    }
}
