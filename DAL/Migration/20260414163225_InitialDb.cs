using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventDetails",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EventCategory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDetails", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "SpeakersDetails",
                columns: table => new
                {
                    SpeakerId = table.Column<int>(type: "int", nullable: false),
                    SpeakerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeakersDetails", x => x.SpeakerId);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    Emailid = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Emailid);
                });

            migrationBuilder.CreateTable(
                name: "SessionInfo",
                columns: table => new
                {
                    SessionId = table.Column<int>(name: "SessionId ", type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    SessionTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SpeakerId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(name: "Description ", type: "nvarchar(max)", nullable: false),
                    SessionStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionInfo", x => x.SessionId);
                    table.ForeignKey(
                        name: "FK_SessionInfo_EventDetails_EventId",
                        column: x => x.EventId,
                        principalTable: "EventDetails",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionInfo_SpeakersDetails_SpeakerId",
                        column: x => x.SpeakerId,
                        principalTable: "SpeakersDetails",
                        principalColumn: "SpeakerId");
                });

            migrationBuilder.CreateTable(
                name: "ParticipantEventDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserEmailId = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    IsAttended = table.Column<bool>(type: "bit", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantEventDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ParticipantEventDetails_SessionInfo_SessionId",
                        column: x => x.SessionId,
                        principalTable: "SessionInfo",
                        principalColumn: "SessionId ",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParticipantEventDetails_UserInfo_EmailId",
                        column: x => x.EmailId,
                        principalTable: "UserInfo",
                        principalColumn: "Emailid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParticipantEventDetails_UserInfo_UserEmailId",
                        column: x => x.UserEmailId,
                        principalTable: "UserInfo",
                        principalColumn: "Emailid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserInfo",
                columns: new[] { "Emailid", "Role", "UserName", "Password" },
                values: new object[] { "Admin@gmail.com", "Admin", "Kishore", "admin123" });

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantEventDetails_EmailId",
                table: "ParticipantEventDetails",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantEventDetails_SessionId",
                table: "ParticipantEventDetails",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantEventDetails_UserEmailId",
                table: "ParticipantEventDetails",
                column: "UserEmailId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionInfo_EventId",
                table: "SessionInfo",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionInfo_SpeakerId",
                table: "SessionInfo",
                column: "SpeakerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParticipantEventDetails");

            migrationBuilder.DropTable(
                name: "SessionInfo");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "EventDetails");

            migrationBuilder.DropTable(
                name: "SpeakersDetails");
        }
    }
}
