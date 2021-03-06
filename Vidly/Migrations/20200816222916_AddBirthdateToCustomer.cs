﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
namespace Vidly.Migrations
{
    public partial class AddBirthdateToCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Birthdate" ,
                table: "Customers" ,
                type: "Date" ,
                nullable: true);
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthdate" ,
                table: "Customers");
        }
    }
}
