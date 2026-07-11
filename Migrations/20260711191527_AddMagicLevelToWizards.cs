using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hogwartz_App.Migrations
{
    /// <inheritdoc />
    public partial class AddMagicLevelToWizards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MagicLevel",
                table: "Wizards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MagicLevel",
                table: "Wizards");
        }
    }
}
