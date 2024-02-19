using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Code_First.Migrations
{
    /// <inheritdoc />
    public partial class initail1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vipCustomers_tables_Id",
                table: "vipCustomers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tables",
                table: "tables");

            migrationBuilder.RenameTable(
                name: "tables",
                newName: "customers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customers",
                table: "customers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_CustomerId",
                table: "orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductMappings_OrderId",
                table: "OrderProductMappings",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductMappings_ProductId",
                table: "OrderProductMappings",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductMappings_orders_OrderId",
                table: "OrderProductMappings",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProductMappings_products_ProductId",
                table: "OrderProductMappings",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_customers_CustomerId",
                table: "orders",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_vipCustomers_customers_Id",
                table: "vipCustomers",
                column: "Id",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductMappings_orders_OrderId",
                table: "OrderProductMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProductMappings_products_ProductId",
                table: "OrderProductMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_customers_CustomerId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_vipCustomers_customers_Id",
                table: "vipCustomers");

            migrationBuilder.DropIndex(
                name: "IX_orders_CustomerId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderProductMappings_OrderId",
                table: "OrderProductMappings");

            migrationBuilder.DropIndex(
                name: "IX_OrderProductMappings_ProductId",
                table: "OrderProductMappings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_customers",
                table: "customers");

            migrationBuilder.RenameTable(
                name: "customers",
                newName: "tables");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tables",
                table: "tables",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_vipCustomers_tables_Id",
                table: "vipCustomers",
                column: "Id",
                principalTable: "tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
