using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shows4All.Migrations
{
    /// <inheritdoc />
    public partial class addedReviewModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvaliacaoDB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvaliacaoTexto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    SerieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacaoDB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvaliacaoDB_ClienteDB_ClientID",
                        column: x => x.ClientID,
                        principalTable: "ClienteDB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvaliacaoDB_SerieDB_SerieID",
                        column: x => x.SerieID,
                        principalTable: "SerieDB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoDB_ClientID",
                table: "AvaliacaoDB",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoDB_SerieID",
                table: "AvaliacaoDB",
                column: "SerieID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvaliacaoDB");
        }
    }
}
