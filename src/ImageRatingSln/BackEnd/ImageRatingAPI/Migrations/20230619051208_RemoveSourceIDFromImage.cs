using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImageRatingAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSourceIDFromImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SourceID",
                table: "Images");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SourceID",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
