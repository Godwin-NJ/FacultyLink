using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FacultyLinkDomain.Migrations
{
    /// <inheritdoc />
    public partial class setupapptables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 16, 5, 52, 43, 220, DateTimeKind.Utc).AddTicks(8),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 4, 11, 18, 12, 28, 559, DateTimeKind.Utc).AddTicks(3364));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 11, 18, 12, 28, 559, DateTimeKind.Utc).AddTicks(3364),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 4, 16, 5, 52, 43, 220, DateTimeKind.Utc).AddTicks(8));
        }
    }
}
