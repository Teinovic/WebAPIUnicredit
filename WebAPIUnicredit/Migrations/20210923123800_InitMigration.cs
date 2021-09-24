using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPIUnicredit.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookInstances",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    authorName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    shortDescription = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    yearPublished = table.Column<int>(nullable: false),
                    genre = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    publisher = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookInstances", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookInstances");
        }
    }
}
