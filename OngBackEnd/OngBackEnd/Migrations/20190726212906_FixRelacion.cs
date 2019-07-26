using Microsoft.EntityFrameworkCore.Migrations;

namespace OngBackEnd.Migrations
{
    public partial class FixRelacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdGradoMaestro",
                table: "Asignaturas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Asignaturas_IdGradoMaestro",
                table: "Asignaturas",
                column: "IdGradoMaestro");

            migrationBuilder.AddForeignKey(
                name: "FK_Asignaturas_GradoMaestros_IdGradoMaestro",
                table: "Asignaturas",
                column: "IdGradoMaestro",
                principalTable: "GradoMaestros",
                principalColumn: "IdGrado",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asignaturas_GradoMaestros_IdGradoMaestro",
                table: "Asignaturas");

            migrationBuilder.DropIndex(
                name: "IX_Asignaturas_IdGradoMaestro",
                table: "Asignaturas");

            migrationBuilder.DropColumn(
                name: "IdGradoMaestro",
                table: "Asignaturas");
        }
    }
}
