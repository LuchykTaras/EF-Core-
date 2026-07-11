using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hogwartz_App.Migrations
{
    /// <inheritdoc />
    public partial class AddWizardWandsView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
           CREATE VIEW vw_WizardWands AS
           SELECT 
           w.Name AS WizardName,
           w.House AS House,
           wd.CoreMaterial AS WandMaterial
           FROM Wizards w
           LEFT JOIN Wands wd ON w.WizardId = wd.WizardId
           ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW vw_WizardWands");
        }
    }
}
