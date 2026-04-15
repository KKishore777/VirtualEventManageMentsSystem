using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDeleteSpeaker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionInfo_SpeakersDetails_SpeakerId",
                table: "SessionInfo");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionInfo_SpeakersDetails_SpeakerId",
                table: "SessionInfo",
                column: "SpeakerId",
                principalTable: "SpeakersDetails",
                principalColumn: "SpeakerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionInfo_SpeakersDetails_SpeakerId",
                table: "SessionInfo");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionInfo_SpeakersDetails_SpeakerId",
                table: "SessionInfo",
                column: "SpeakerId",
                principalTable: "SpeakersDetails",
                principalColumn: "SpeakerId");
        }
    }
}
