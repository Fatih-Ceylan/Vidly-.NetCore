using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Migrations
{
    public partial class Genres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (1, 'Action')");
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (2, 'Thriller')");
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (3, 'Family')");
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (4, 'Romance')");
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (5, 'Comedy')");
            migrationBuilder.Sql("INSERT INTO Genre (Id, Name) VALUES (6, 'Sci-Fi')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
