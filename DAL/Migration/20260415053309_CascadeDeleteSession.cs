using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDeleteSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantEventDetails_SessionInfo_SessionId",
                table: "ParticipantEventDetails");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantEventDetails_EmailId",
                table: "ParticipantEventDetails",
                column: "EmailId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantEventDetails_SessionInfo_SessionId",
                table: "ParticipantEventDetails",
                column: "SessionId",
                principalTable: "SessionInfo",
                principalColumn: "SessionId ",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantEventDetails_UserInfo_EmailId",
                table: "ParticipantEventDetails",
                column: "EmailId",
                principalTable: "UserInfo",
                principalColumn: "Emailid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantEventDetails_SessionInfo_SessionId",
                table: "ParticipantEventDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantEventDetails_UserInfo_EmailId",
                table: "ParticipantEventDetails");

            migrationBuilder.DropIndex(
                name: "IX_ParticipantEventDetails_EmailId",
                table: "ParticipantEventDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantEventDetails_SessionInfo_SessionId",
                table: "ParticipantEventDetails",
                column: "SessionId",
                principalTable: "SessionInfo",
                principalColumn: "SessionId ",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
