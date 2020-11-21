using Microsoft.EntityFrameworkCore.Migrations;

namespace Agreement.Migrations
{
    public partial class InitialDatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agreements",
                columns: table => new
                {
                    CNPCUI = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DenumireCompanie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Judet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NrTelefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcordPrelucrareDate = table.Column<bool>(type: "bit", nullable: false),
                    ComunicareMarketing = table.Column<bool>(type: "bit", nullable: false),
                    ComunicareEmail = table.Column<bool>(type: "bit", nullable: false),
                    ComunicareSMS = table.Column<bool>(type: "bit", nullable: false),
                    ComunicarePosta = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agreements", x => x.CNPCUI);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agreements");
        }
    }
}
