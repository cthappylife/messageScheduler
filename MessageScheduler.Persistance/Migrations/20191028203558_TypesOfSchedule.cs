using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MessageScheduler.Persistence.Migrations
{
    public partial class TypesOfSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "Schedule");

            migrationBuilder.RenameColumn(
                name: "Weekdays",
                table: "Schedule",
                newName: "WeekDays");

            migrationBuilder.AlterColumn<int>(
                name: "WeekDays",
                table: "Schedule",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Schedule",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MonthDay",
                table: "Schedule",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "MonthDay",
                table: "Schedule");

            migrationBuilder.RenameColumn(
                name: "WeekDays",
                table: "Schedule",
                newName: "Weekdays");

            migrationBuilder.AlterColumn<int>(
                name: "Weekdays",
                table: "Schedule",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Day",
                table: "Schedule",
                nullable: false,
                defaultValue: 0);
        }
    }
}
