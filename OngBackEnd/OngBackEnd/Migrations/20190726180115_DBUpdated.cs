using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OngBackEnd.Migrations
{
    public partial class DBUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    IdAlumno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    pass = table.Column<string>(nullable: true),
                    FechaN = table.Column<DateTime>(nullable: false),
                    Grado = table.Column<string>(nullable: true),
                    Seccion = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.IdAlumno);
                });

            migrationBuilder.CreateTable(
                name: "GradoMaestros",
                columns: table => new
                {
                    IdGrado = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Grado = table.Column<string>(nullable: true),
                    Jornada = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradoMaestros", x => x.IdGrado);
                });

            migrationBuilder.CreateTable(
                name: "Grados",
                columns: table => new
                {
                    IdGrado = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Grado = table.Column<string>(nullable: true),
                    Jornada = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grados", x => x.IdGrado);
                });

            migrationBuilder.CreateTable(
                name: "Maestros",
                columns: table => new
                {
                    IdMaestro = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    pass = table.Column<string>(nullable: true),
                    Grado = table.Column<string>(nullable: true),
                    Seccion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maestros", x => x.IdMaestro);
                });

            migrationBuilder.CreateTable(
                name: "Rols",
                columns: table => new
                {
                    IdRol = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rols", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "Semestres",
                columns: table => new
                {
                    IdSemestre = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Semestre = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semestres", x => x.IdSemestre);
                });

            migrationBuilder.CreateTable(
                name: "Asignaturas",
                columns: table => new
                {
                    IdAsignatura = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Asignatura = table.Column<string>(nullable: true),
                    IdGrado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignaturas", x => x.IdAsignatura);
                    table.ForeignKey(
                        name: "FK_Asignaturas_Grados_IdGrado",
                        column: x => x.IdGrado,
                        principalTable: "Grados",
                        principalColumn: "IdGrado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistorialAcs",
                columns: table => new
                {
                    IdHistoriaAc = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Notas = table.Column<int>(nullable: false),
                    Observaciones = table.Column<string>(nullable: true),
                    IdAlumno = table.Column<int>(nullable: false),
                    IdSemestre = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialAcs", x => x.IdHistoriaAc);
                    table.ForeignKey(
                        name: "FK_HistorialAcs_Alumnos_IdAlumno",
                        column: x => x.IdAlumno,
                        principalTable: "Alumnos",
                        principalColumn: "IdAlumno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistorialAcs_Semestres_IdSemestre",
                        column: x => x.IdSemestre,
                        principalTable: "Semestres",
                        principalColumn: "IdSemestre",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaestroAsignaturas",
                columns: table => new
                {
                    IdMaestroAsignatura = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdMaestro = table.Column<int>(nullable: false),
                    IdAsignatura = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaestroAsignaturas", x => x.IdMaestroAsignatura);
                    table.ForeignKey(
                        name: "FK_MaestroAsignaturas_Asignaturas_IdAsignatura",
                        column: x => x.IdAsignatura,
                        principalTable: "Asignaturas",
                        principalColumn: "IdAsignatura",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaestroAsignaturas_Maestros_IdMaestro",
                        column: x => x.IdMaestro,
                        principalTable: "Maestros",
                        principalColumn: "IdMaestro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    IdNota = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    P1 = table.Column<int>(nullable: false),
                    P2 = table.Column<int>(nullable: false),
                    P3 = table.Column<int>(nullable: false),
                    P4 = table.Column<int>(nullable: false),
                    NotaAcum = table.Column<int>(nullable: false),
                    NotaExa = table.Column<int>(nullable: false),
                    Total = table.Column<int>(nullable: false),
                    IdSemestre = table.Column<int>(nullable: false),
                    IdAlumno = table.Column<int>(nullable: false),
                    IdAsignatura = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.IdNota);
                    table.ForeignKey(
                        name: "FK_Notas_Alumnos_IdAlumno",
                        column: x => x.IdAlumno,
                        principalTable: "Alumnos",
                        principalColumn: "IdAlumno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notas_Asignaturas_IdAsignatura",
                        column: x => x.IdAsignatura,
                        principalTable: "Asignaturas",
                        principalColumn: "IdAsignatura",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notas_Semestres_IdSemestre",
                        column: x => x.IdSemestre,
                        principalTable: "Semestres",
                        principalColumn: "IdSemestre",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asignaturas_IdGrado",
                table: "Asignaturas",
                column: "IdGrado");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialAcs_IdAlumno",
                table: "HistorialAcs",
                column: "IdAlumno");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialAcs_IdSemestre",
                table: "HistorialAcs",
                column: "IdSemestre");

            migrationBuilder.CreateIndex(
                name: "IX_MaestroAsignaturas_IdAsignatura",
                table: "MaestroAsignaturas",
                column: "IdAsignatura");

            migrationBuilder.CreateIndex(
                name: "IX_MaestroAsignaturas_IdMaestro",
                table: "MaestroAsignaturas",
                column: "IdMaestro");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_IdAlumno",
                table: "Notas",
                column: "IdAlumno");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_IdAsignatura",
                table: "Notas",
                column: "IdAsignatura");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_IdSemestre",
                table: "Notas",
                column: "IdSemestre");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GradoMaestros");

            migrationBuilder.DropTable(
                name: "HistorialAcs");

            migrationBuilder.DropTable(
                name: "MaestroAsignaturas");

            migrationBuilder.DropTable(
                name: "Notas");

            migrationBuilder.DropTable(
                name: "Rols");

            migrationBuilder.DropTable(
                name: "Maestros");

            migrationBuilder.DropTable(
                name: "Alumnos");

            migrationBuilder.DropTable(
                name: "Asignaturas");

            migrationBuilder.DropTable(
                name: "Semestres");

            migrationBuilder.DropTable(
                name: "Grados");
        }
    }
}
