using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Vidly.Migrations
{
    public partial class AddMovieModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded" ,
                table: "Movies" ,
                type: "Date" ,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genre" ,
                table: "Movies" ,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate" ,
                table: "Movies" ,
                type: "Date" ,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded" ,
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Genre" ,
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ReleaseDate" ,
                table: "Movies");
        }
    }
}
