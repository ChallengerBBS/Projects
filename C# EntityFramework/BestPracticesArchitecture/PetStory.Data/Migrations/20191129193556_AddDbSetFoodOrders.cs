using Microsoft.EntityFrameworkCore.Migrations;

namespace PetStore.Data.Migrations
{
    public partial class AddDbSetFoodOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodOrder_Foods_FoodId",
                table: "FoodOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodOrder_Orders_OrderId",
                table: "FoodOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Brands_BrandId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Categories_CategoryId",
                table: "Foods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Foods",
                table: "Foods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodOrder",
                table: "FoodOrder");

            migrationBuilder.RenameTable(
                name: "Foods",
                newName: "Food");

            migrationBuilder.RenameTable(
                name: "FoodOrder",
                newName: "FoodOrders");

            migrationBuilder.RenameIndex(
                name: "IX_Foods_CategoryId",
                table: "Food",
                newName: "IX_Food_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Foods_BrandId",
                table: "Food",
                newName: "IX_Food_BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodOrder_FoodId",
                table: "FoodOrders",
                newName: "IX_FoodOrders_FoodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Food",
                table: "Food",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodOrders",
                table: "FoodOrders",
                columns: new[] { "OrderId", "FoodId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Brands_BrandId",
                table: "Food",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Categories_CategoryId",
                table: "Food",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodOrders_Food_FoodId",
                table: "FoodOrders",
                column: "FoodId",
                principalTable: "Food",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodOrders_Orders_OrderId",
                table: "FoodOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Brands_BrandId",
                table: "Food");

            migrationBuilder.DropForeignKey(
                name: "FK_Food_Categories_CategoryId",
                table: "Food");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodOrders_Food_FoodId",
                table: "FoodOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodOrders_Orders_OrderId",
                table: "FoodOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodOrders",
                table: "FoodOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Food",
                table: "Food");

            migrationBuilder.RenameTable(
                name: "FoodOrders",
                newName: "FoodOrder");

            migrationBuilder.RenameTable(
                name: "Food",
                newName: "Foods");

            migrationBuilder.RenameIndex(
                name: "IX_FoodOrders_FoodId",
                table: "FoodOrder",
                newName: "IX_FoodOrder_FoodId");

            migrationBuilder.RenameIndex(
                name: "IX_Food_CategoryId",
                table: "Foods",
                newName: "IX_Foods_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Food_BrandId",
                table: "Foods",
                newName: "IX_Foods_BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodOrder",
                table: "FoodOrder",
                columns: new[] { "OrderId", "FoodId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foods",
                table: "Foods",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodOrder_Foods_FoodId",
                table: "FoodOrder",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodOrder_Orders_OrderId",
                table: "FoodOrder",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Brands_BrandId",
                table: "Foods",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Categories_CategoryId",
                table: "Foods",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
