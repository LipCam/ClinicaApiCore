using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaApiCore.Migrations
{
    /// <inheritdoc />
    public partial class AgendasTab : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AGENDAS_TAB",
                columns: table => new
                {
                    ID_AGENDA_LONG = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DATA_DTI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_STATUS_INT = table.Column<int>(type: "int", nullable: false),
                    ID_PACIENTE_LONG = table.Column<long>(type: "bigint", nullable: true),
                    ID_MEDICO_LONG = table.Column<long>(type: "bigint", nullable: false),
                    ID_PROCEDIMENTO_LONG = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGENDAS_TAB", x => x.ID_AGENDA_LONG);
                    table.ForeignKey(
                        name: "FK_AGENDAS_TAB_MEDICOS_TAB_ID_MEDICO_LONG",
                        column: x => x.ID_MEDICO_LONG,
                        principalTable: "MEDICOS_TAB",
                        principalColumn: "ID_MEDICO_LONG",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AGENDAS_TAB_PACIENTES_TAB_ID_PACIENTE_LONG",
                        column: x => x.ID_PACIENTE_LONG,
                        principalTable: "PACIENTES_TAB",
                        principalColumn: "ID_PACIENTE_LONG");
                    table.ForeignKey(
                        name: "FK_AGENDAS_TAB_PROCEDIMENTOS_TAB_ID_PROCEDIMENTO_LONG",
                        column: x => x.ID_PROCEDIMENTO_LONG,
                        principalTable: "PROCEDIMENTOS_TAB",
                        principalColumn: "ID_PROCEDIMENTO_LONG",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AGENDAS_TAB_ID_MEDICO_LONG",
                table: "AGENDAS_TAB",
                column: "ID_MEDICO_LONG");

            migrationBuilder.CreateIndex(
                name: "IX_AGENDAS_TAB_ID_PACIENTE_LONG",
                table: "AGENDAS_TAB",
                column: "ID_PACIENTE_LONG");

            migrationBuilder.CreateIndex(
                name: "IX_AGENDAS_TAB_ID_PROCEDIMENTO_LONG",
                table: "AGENDAS_TAB",
                column: "ID_PROCEDIMENTO_LONG");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AGENDAS_TAB");
        }
    }
}
