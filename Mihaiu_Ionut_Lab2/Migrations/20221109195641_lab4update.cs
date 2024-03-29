﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mihaiu_Ionut_Lab2.Migrations
{
    public partial class lab4update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Author");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_CategoryID",
                table: "Book",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Category_CategoryID",
                table: "Book",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Category_CategoryID",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_CategoryID",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Book");

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Author",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
