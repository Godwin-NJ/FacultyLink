using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FacultyLinkDomain.Migrations
{
    /// <inheritdoc />
    public partial class addedadditionalfieldstotheuserstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 18, 21, 26, 31, 352, DateTimeKind.Utc).AddTicks(6465),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 18, 10, 48, 56, 267, DateTimeKind.Utc).AddTicks(9580));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 18, 21, 26, 31, 352, DateTimeKind.Utc).AddTicks(6056),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 4, 18, 10, 48, 56, 267, DateTimeKind.Utc).AddTicks(9175));

            migrationBuilder.AddColumn<int>(
                name: "ApprovedBy",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApprovedBy", "CreatedDate", "UpdatedBy" },
                values: new object[] { null, new DateTime(2026, 4, 18, 21, 26, 31, 352, DateTimeKind.Utc).AddTicks(6056), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2026, 4, 18, 10, 48, 56, 267, DateTimeKind.Utc).AddTicks(9580),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2026, 4, 18, 21, 26, 31, 352, DateTimeKind.Utc).AddTicks(6465));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 18, 10, 48, 56, 267, DateTimeKind.Utc).AddTicks(9175),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 4, 18, 21, 26, 31, 352, DateTimeKind.Utc).AddTicks(6056));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedBy" },
                values: new object[] { new DateTime(2026, 4, 18, 10, 48, 56, 267, DateTimeKind.Utc).AddTicks(9175), 0 });
        }
    }
}
