using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaApiCore.Migrations
{
    /// <inheritdoc />
    public partial class AgendasTab_add_DATA_AGENDAMENTO_DTI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DATA_AGENDAMENTO_DTI",
                table: "AGENDAS_TAB",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AgendasVW",
                columns: table => new
                {
                    ID_AGENDA_LONG = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DATA_DTI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_STATUS_INT = table.Column<int>(type: "int", nullable: false),
                    ID_MEDICO_LONG = table.Column<long>(type: "bigint", nullable: false),
                    MEDICO_STR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_PROCEDIMENTO_LONG = table.Column<long>(type: "bigint", nullable: false),
                    PROCEDIMENTO_STR = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendasVW", x => x.ID_AGENDA_LONG);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgendasVW");

            migrationBuilder.DropColumn(
                name: "DATA_AGENDAMENTO_DTI",
                table: "AGENDAS_TAB");
        }
    }
}
