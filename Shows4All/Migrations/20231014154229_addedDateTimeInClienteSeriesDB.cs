using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shows4All.Migrations
{
    /// <inheritdoc />
    public partial class addedDateTimeInClienteSeriesDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvaliacaoDB_ClienteDB_ClientID",
                table: "AvaliacaoDB");

            migrationBuilder.DropForeignKey(
                name: "FK_AvaliacaoDB_SerieDB_SerieID",
                table: "AvaliacaoDB");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeCompra",
                table: "ClienteSeriesDB",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "SerieID",
                table: "AvaliacaoDB",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClientID",
                table: "AvaliacaoDB",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AvaliacaoDB_ClienteDB_ClientID",
                table: "AvaliacaoDB",
                column: "ClientID",
                principalTable: "ClienteDB",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AvaliacaoDB_SerieDB_SerieID",
                table: "AvaliacaoDB",
                column: "SerieID",
                principalTable: "SerieDB",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvaliacaoDB_ClienteDB_ClientID",
                table: "AvaliacaoDB");

            migrationBuilder.DropForeignKey(
                name: "FK_AvaliacaoDB_SerieDB_SerieID",
                table: "AvaliacaoDB");

            migrationBuilder.DropColumn(
                name: "DataDeCompra",
                table: "ClienteSeriesDB");

            migrationBuilder.AlterColumn<int>(
                name: "SerieID",
                table: "AvaliacaoDB",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientID",
                table: "AvaliacaoDB",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AvaliacaoDB_ClienteDB_ClientID",
                table: "AvaliacaoDB",
                column: "ClientID",
                principalTable: "ClienteDB",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AvaliacaoDB_SerieDB_SerieID",
                table: "AvaliacaoDB",
                column: "SerieID",
                principalTable: "SerieDB",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
