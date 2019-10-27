using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MessageScheduler.Persistence.Migrations
{
    public partial class ChangeColumnNameScheduleDay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Schedule");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Schedule",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Day",
                table: "Schedule",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "Schedule");

            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "Schedule",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<int>(
                name: "Date",
                table: "Schedule",
                nullable: false,
                defaultValue: 0);
        }
    }
}
