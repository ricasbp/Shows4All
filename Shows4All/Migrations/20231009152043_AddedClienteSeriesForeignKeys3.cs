using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shows4All.Migrations
{
    /// <inheritdoc />
    public partial class AddedClienteSeriesForeignKeys3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SerieModel",
                table: "SerieModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientSeriesModel",
                table: "ClientSeriesModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientModel",
                table: "ClientModel");

            migrationBuilder.RenameTable(
                name: "SerieModel",
                newName: "SerieDB");

            migrationBuilder.RenameTable(
                name: "ClientSeriesModel",
                newName: "ClienteSeriesDB");

            migrationBuilder.RenameTable(
                name: "ClientModel",
                newName: "ClienteDB");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SerieDB",
                table: "SerieDB",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClienteSeriesDB",
                table: "ClienteSeriesDB",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClienteDB",
                table: "ClienteDB",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteSeriesDB_ClientID",
                table: "ClienteSeriesDB",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteSeriesDB_SerieID",
                table: "ClienteSeriesDB",
                column: "SerieID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClienteSeriesDB_ClienteDB_ClientID",
                table: "ClienteSeriesDB",
                column: "ClientID",
                principalTable: "ClienteDB",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClienteSeriesDB_SerieDB_SerieID",
                table: "ClienteSeriesDB",
                column: "SerieID",
                principalTable: "SerieDB",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClienteSeriesDB_ClienteDB_ClientID",
                table: "ClienteSeriesDB");

            migrationBuilder.DropForeignKey(
                name: "FK_ClienteSeriesDB_SerieDB_SerieID",
                table: "ClienteSeriesDB");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SerieDB",
                table: "SerieDB");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClienteSeriesDB",
                table: "ClienteSeriesDB");

            migrationBuilder.DropIndex(
                name: "IX_ClienteSeriesDB_ClientID",
                table: "ClienteSeriesDB");

            migrationBuilder.DropIndex(
                name: "IX_ClienteSeriesDB_SerieID",
                table: "ClienteSeriesDB");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClienteDB",
                table: "ClienteDB");

            migrationBuilder.RenameTable(
                name: "SerieDB",
                newName: "SerieModel");

            migrationBuilder.RenameTable(
                name: "ClienteSeriesDB",
                newName: "ClientSeriesModel");

            migrationBuilder.RenameTable(
                name: "ClienteDB",
                newName: "ClientModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SerieModel",
                table: "SerieModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientSeriesModel",
                table: "ClientSeriesModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientModel",
                table: "ClientModel",
                column: "Id");
        }
    }
}
