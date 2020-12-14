using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CapstoneJesseGajda.Data.Migrations
{
    public partial class FirstAndLastNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewCustomUsername",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCountry",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "UserCurrentWeight",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UserDOB",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "UserHeight",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "UserPostalCode",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NewCustomUsername",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserCountry",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserCurrentWeight",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserDOB",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserHeight",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserPostalCode",
                table: "AspNetUsers");
        }
    }
}
