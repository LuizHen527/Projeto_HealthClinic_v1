using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace healthclinic_webapi.Migrations
{
    /// <inheritdoc />
    public partial class DB11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TiposUsuario_Perfil_IdPerfil",
                table: "TiposUsuario");

            migrationBuilder.DropIndex(
                name: "IX_TiposUsuario_IdPerfil",
                table: "TiposUsuario");

            migrationBuilder.DropColumn(
                name: "IdPerfil",
                table: "TiposUsuario");

            migrationBuilder.AddColumn<Guid>(
                name: "IdTiposUsuario",
                table: "Perfil",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Perfil_IdTiposUsuario",
                table: "Perfil",
                column: "IdTiposUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Perfil_TiposUsuario_IdTiposUsuario",
                table: "Perfil",
                column: "IdTiposUsuario",
                principalTable: "TiposUsuario",
                principalColumn: "IdTiposUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfil_TiposUsuario_IdTiposUsuario",
                table: "Perfil");

            migrationBuilder.DropIndex(
                name: "IX_Perfil_IdTiposUsuario",
                table: "Perfil");

            migrationBuilder.DropColumn(
                name: "IdTiposUsuario",
                table: "Perfil");

            migrationBuilder.AddColumn<Guid>(
                name: "IdPerfil",
                table: "TiposUsuario",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TiposUsuario_IdPerfil",
                table: "TiposUsuario",
                column: "IdPerfil");

            migrationBuilder.AddForeignKey(
                name: "FK_TiposUsuario_Perfil_IdPerfil",
                table: "TiposUsuario",
                column: "IdPerfil",
                principalTable: "Perfil",
                principalColumn: "IdPerfil",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
