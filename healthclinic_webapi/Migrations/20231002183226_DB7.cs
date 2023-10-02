using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace healthclinic_webapi.Migrations
{
    /// <inheritdoc />
    public partial class DB7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Agendamento",
                table: "Consulta",
                newName: "AgendamentoData");

            migrationBuilder.AddColumn<TimeOnly>(
                name: "AgendamentoHora",
                table: "Consulta",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgendamentoHora",
                table: "Consulta");

            migrationBuilder.RenameColumn(
                name: "AgendamentoData",
                table: "Consulta",
                newName: "Agendamento");
        }
    }
}
