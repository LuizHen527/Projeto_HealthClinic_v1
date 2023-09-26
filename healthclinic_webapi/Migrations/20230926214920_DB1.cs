using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace healthclinic_webapi.Migrations
{
    /// <inheritdoc />
    public partial class DB1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clinica",
                columns: table => new
                {
                    IdClinica = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AbertoEm = table.Column<TimeOnly>(type: "time", nullable: false),
                    FechaEm = table.Column<TimeOnly>(type: "time", nullable: false),
                    NomeFantasia = table.Column<string>(type: "VARCHAR(175)", nullable: false),
                    CNPJ = table.Column<string>(type: "VARCHAR(14)", nullable: false),
                    RazaoSocial = table.Column<string>(type: "VARCHAR(175)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinica", x => x.IdClinica);
                });

            migrationBuilder.CreateTable(
                name: "Especialidade",
                columns: table => new
                {
                    IdEspecialidade = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EspecialidadeNome = table.Column<string>(type: "VARCHAR (300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidade", x => x.IdEspecialidade);
                });

            migrationBuilder.CreateTable(
                name: "Prontuario",
                columns: table => new
                {
                    IdProntuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prontuario", x => x.IdProntuario);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CPF = table.Column<string>(type: "VARCHAR(11)", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(350)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    IdEndereco = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VARCHAR300 = table.Column<string>(name: "VARCHAR(300)", type: "nvarchar(max)", nullable: false),
                    IdClinica = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.IdEndereco);
                    table.ForeignKey(
                        name: "FK_Endereco_Clinica_IdClinica",
                        column: x => x.IdClinica,
                        principalTable: "Clinica",
                        principalColumn: "IdClinica",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    IdPerfil = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(350)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.IdPerfil);
                    table.ForeignKey(
                        name: "FK_Perfil_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    IdMedico = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(350)", nullable: true),
                    IdPerfil = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEspecialidade = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.IdMedico);
                    table.ForeignKey(
                        name: "FK_Medico_Especialidade_IdEspecialidade",
                        column: x => x.IdEspecialidade,
                        principalTable: "Especialidade",
                        principalColumn: "IdEspecialidade",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medico_Perfil_IdPerfil",
                        column: x => x.IdPerfil,
                        principalTable: "Perfil",
                        principalColumn: "IdPerfil",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    IdPaciente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Convenio = table.Column<bool>(type: "BIT", nullable: false),
                    IdProntuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPerfil = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.IdPaciente);
                    table.ForeignKey(
                        name: "FK_Paciente_Perfil_IdPerfil",
                        column: x => x.IdPerfil,
                        principalTable: "Perfil",
                        principalColumn: "IdPerfil",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paciente_Prontuario_IdProntuario",
                        column: x => x.IdProntuario,
                        principalTable: "Prontuario",
                        principalColumn: "IdProntuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    IdFeedback = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comentario = table.Column<string>(type: "TEXT", nullable: false),
                    IdPaciente = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.IdFeedback);
                    table.ForeignKey(
                        name: "FK_Feedback_Paciente_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Paciente",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    IdConsulta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Agendamento = table.Column<DateTime>(type: "date", nullable: false),
                    Status = table.Column<bool>(type: "BIT", nullable: false),
                    IdEndereco = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMedico = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPaciente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdFeedback = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.IdConsulta);
                    table.ForeignKey(
                        name: "FK_Consulta_Endereco_IdEndereco",
                        column: x => x.IdEndereco,
                        principalTable: "Endereco",
                        principalColumn: "IdEndereco",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consulta_Feedback_IdFeedback",
                        column: x => x.IdFeedback,
                        principalTable: "Feedback",
                        principalColumn: "IdFeedback",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consulta_Medico_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "Medico",
                        principalColumn: "IdMedico",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consulta_Paciente_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Paciente",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_IdEndereco",
                table: "Consulta",
                column: "IdEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_IdFeedback",
                table: "Consulta",
                column: "IdFeedback");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_IdMedico",
                table: "Consulta",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_IdPaciente",
                table: "Consulta",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_IdClinica",
                table: "Endereco",
                column: "IdClinica");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_IdPaciente",
                table: "Feedback",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_IdEspecialidade",
                table: "Medico",
                column: "IdEspecialidade");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_IdPerfil",
                table: "Medico",
                column: "IdPerfil");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_IdPerfil",
                table: "Paciente",
                column: "IdPerfil");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_IdProntuario",
                table: "Paciente",
                column: "IdProntuario");

            migrationBuilder.CreateIndex(
                name: "IX_Perfil_IdUsuario",
                table: "Perfil",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consulta");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Clinica");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Especialidade");

            migrationBuilder.DropTable(
                name: "Perfil");

            migrationBuilder.DropTable(
                name: "Prontuario");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
