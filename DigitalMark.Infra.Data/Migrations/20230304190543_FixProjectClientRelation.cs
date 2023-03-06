using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalMark.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixProjectClientRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Client_ClientId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Client_ClientId1",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_ClientId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_ClientId1",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ClientId1",
                table: "Project");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "Client",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Client_ProjectId",
                table: "Client",
                column: "ProjectId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Project_ProjectId",
                table: "Client",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Project_ProjectId",
                table: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Client_ProjectId",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Client");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "Project",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId1",
                table: "Project",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Project_ClientId",
                table: "Project",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ClientId1",
                table: "Project",
                column: "ClientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Client_ClientId",
                table: "Project",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Client_ClientId1",
                table: "Project",
                column: "ClientId1",
                principalTable: "Client",
                principalColumn: "Id");
        }
    }
}
