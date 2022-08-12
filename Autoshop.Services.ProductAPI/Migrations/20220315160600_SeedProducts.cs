﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autoshop.Services.ProductAPI.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Appetizer", "Praesent scelerisque, mi sed", "", "Samosa", 15.0 },
                    { 2, "Appetizer", "Praesent scelerisque, mi sed", "", "Samosa", 13.99 },
                    { 3, "Dessert", "Praesent scelerisque, mi sed", "", "Samosa", 22.0 },
                    { 4, "Entree", "Praesent scelerisque, mi sed", "", "Samosa", 15.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);
        }
    }
}
