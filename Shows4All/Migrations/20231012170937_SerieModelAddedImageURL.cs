using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shows4All.Migrations
{
    /// <inheritdoc />
    public partial class SerieModelAddedImageURL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imageURL",
                table: "SerieDB",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageURL",
                table: "SerieDB");
        }
    }
}
