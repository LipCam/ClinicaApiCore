using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaApiCore.Migrations
{
    /// <inheritdoc />
    public partial class ProcedimentosTab : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PROCEDIMENTOS_TAB",
                columns: table => new
                {
                    ID_PROCEDIMENTO_LONG = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRICAO_STR = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    VALOR_DEC = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROCEDIMENTOS_TAB", x => x.ID_PROCEDIMENTO_LONG);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PROCEDIMENTOS_TAB");
        }
    }
}
