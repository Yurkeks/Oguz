using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Oguz.Migrations
{
    public partial class SetNullableTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Sizes_SizeId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Colors_ColorId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Styles_StyleId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Orders_OrderId",
                table: "Sizes");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "Sizes",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "StyleId",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ColorId",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "SizeId",
                table: "Materials",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Sizes_SizeId",
                table: "Materials",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Colors_ColorId",
                table: "Orders",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Styles_StyleId",
                table: "Orders",
                column: "StyleId",
                principalTable: "Styles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Orders_OrderId",
                table: "Sizes",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Sizes_SizeId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Colors_ColorId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Styles_StyleId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Orders_OrderId",
                table: "Sizes");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "Sizes",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "StyleId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ColorId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SizeId",
                table: "Materials",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Sizes_SizeId",
                table: "Materials",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Colors_ColorId",
                table: "Orders",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Styles_StyleId",
                table: "Orders",
                column: "StyleId",
                principalTable: "Styles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Orders_OrderId",
                table: "Sizes",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
