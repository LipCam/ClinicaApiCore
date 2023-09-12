using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaApiCore.Migrations
{
    /// <inheritdoc />
    public partial class MedicosTab : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MEDICOS_TAB",
                columns: table => new
                {
                    ID_MEDICO_LONG = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME_STR = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CPF_STR = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    NUM_REGISTRO_STR = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEDICOS_TAB", x => x.ID_MEDICO_LONG);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MEDICOS_TAB");
        }
    }
}
