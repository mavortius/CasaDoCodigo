using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CasaDoCodigo.Migrations
{
    public partial class Cadastro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Pedidos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Pedidos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "Pedidos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Pedidos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Pedidos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Municipio",
                table: "Pedidos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Pedidos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Pedidos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Uf",
                table: "Pedidos",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Municipio",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Uf",
                table: "Pedidos");
        }
    }
}
