using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MessageScheduler.Persistence.Migrations
{
    public partial class addLastSentDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SentMessage");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastSentDate",
                table: "ScheduledMessage",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastSentDate",
                table: "ScheduledMessage");

            migrationBuilder.CreateTable(
                name: "SentMessage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ScheduledMessageId = table.Column<int>(nullable: false),
                    SentSuccessfully = table.Column<bool>(nullable: false),
                    SentTime = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SentMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SentMessage_ScheduledMessage_ScheduledMessageId",
                        column: x => x.ScheduledMessageId,
                        principalTable: "ScheduledMessage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SentMessage_ScheduledMessageId",
                table: "SentMessage",
                column: "ScheduledMessageId");
        }
    }
}
