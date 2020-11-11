using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperheroWebpage.Data.Migrations
{
    public partial class ChangedKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Superhero",
                table: "Superhero");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Superhero",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "SupheroId",
                table: "Superhero",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Superhero",
                table: "Superhero",
                column: "SupheroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Superhero",
                table: "Superhero");

            migrationBuilder.DropColumn(
                name: "SupheroId",
                table: "Superhero");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Superhero",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Superhero",
                table: "Superhero",
                column: "Name");
        }
    }
}
