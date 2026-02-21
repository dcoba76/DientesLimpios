using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DientesLimpios.Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class tablacitas2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cita_Consultorios_ConsultorioId",
                table: "Cita");

            migrationBuilder.DropForeignKey(
                name: "FK_Cita_Dentistas_DentistaId",
                table: "Cita");

            migrationBuilder.DropForeignKey(
                name: "FK_Cita_Pacientes_PacienteId",
                table: "Cita");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cita",
                table: "Cita");

            migrationBuilder.RenameTable(
                name: "Cita",
                newName: "Citas");

            migrationBuilder.RenameIndex(
                name: "IX_Cita_PacienteId",
                table: "Citas",
                newName: "IX_Citas_PacienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Cita_DentistaId",
                table: "Citas",
                newName: "IX_Citas_DentistaId");

            migrationBuilder.RenameIndex(
                name: "IX_Cita_ConsultorioId",
                table: "Citas",
                newName: "IX_Citas_ConsultorioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Citas",
                table: "Citas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Consultorios_ConsultorioId",
                table: "Citas",
                column: "ConsultorioId",
                principalTable: "Consultorios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Dentistas_DentistaId",
                table: "Citas",
                column: "DentistaId",
                principalTable: "Dentistas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Pacientes_PacienteId",
                table: "Citas",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Consultorios_ConsultorioId",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Dentistas_DentistaId",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Pacientes_PacienteId",
                table: "Citas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Citas",
                table: "Citas");

            migrationBuilder.RenameTable(
                name: "Citas",
                newName: "Cita");

            migrationBuilder.RenameIndex(
                name: "IX_Citas_PacienteId",
                table: "Cita",
                newName: "IX_Cita_PacienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Citas_DentistaId",
                table: "Cita",
                newName: "IX_Cita_DentistaId");

            migrationBuilder.RenameIndex(
                name: "IX_Citas_ConsultorioId",
                table: "Cita",
                newName: "IX_Cita_ConsultorioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cita",
                table: "Cita",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cita_Consultorios_ConsultorioId",
                table: "Cita",
                column: "ConsultorioId",
                principalTable: "Consultorios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cita_Dentistas_DentistaId",
                table: "Cita",
                column: "DentistaId",
                principalTable: "Dentistas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cita_Pacientes_PacienteId",
                table: "Cita",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
