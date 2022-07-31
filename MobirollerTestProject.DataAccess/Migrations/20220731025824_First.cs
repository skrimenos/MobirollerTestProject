using Microsoft.EntityFrameworkCore.Migrations;

namespace MobirollerTestProject.DataAccess.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Italian",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dc_Orario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dc_Categoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dc_Evento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Italian", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Turkish",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dc_Zaman = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dc_Kategori = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dc_Olay = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turkish", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    Password = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Italian");

            migrationBuilder.DropTable(
                name: "Turkish");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
