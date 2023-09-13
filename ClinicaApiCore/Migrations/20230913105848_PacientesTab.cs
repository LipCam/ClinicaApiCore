using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaApiCore.Migrations
{
    /// <inheritdoc />
    public partial class PacientesTab : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PACIENTES_TAB",
                columns: table => new
                {
                    ID_PACIENTE_LONG = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME_STR = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CPF_STR = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CELULAR_STR = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PACIENTES_TAB", x => x.ID_PACIENTE_LONG);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PACIENTES_TAB");
        }
    }
}
