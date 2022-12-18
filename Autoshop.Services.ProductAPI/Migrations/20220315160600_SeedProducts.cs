using Microsoft.EntityFrameworkCore.Migrations;

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
                    { 1, "Main battle tanks", "", "https://upload.wikimedia.org/wikipedia/commons/thumb/2/24/Leopard_2_A5_der_Bundeswehr.jpg/300px-Leopard_2_A5_der_Bundeswehr.jpg", "Leopard 2", 150000.0 },
                    { 2, "Main battle tanks", "", "https://upload.wikimedia.org/wikipedia/commons/thumb/2/27/ZTZ-99A_MBT_20170716.jpg/300px-ZTZ-99A_MBT_20170716.jpg", "Type 99A", 200000.0 },
                    { 3, "Main battle tanks", "", "https://upload.wikimedia.org/wikipedia/commons/thumb/3/30/Challenger_2_Main_Battle_Tank_patrolling_outside_Basra%2C_Iraq_MOD_45148325.jpg/300px-Challenger_2_Main_Battle_Tank_patrolling_outside_Basra%2C_Iraq_MOD_45148325.jpg", "Challenger 2", 100000.0 },
                    { 4, "Main battle tanks", "", "https://upload.wikimedia.org/wikipedia/commons/thumb/9/92/Mounted_Soldier_System_%28MSS%29.jpg/300px-Mounted_Soldier_System_%28MSS%29.jpg", "M1A2", 175000.0 }
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
