using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixEmailId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantEventDetails_UserInfo_EmailId",
                table: "ParticipantEventDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantEventDetails_UserInfo_UserEmailId",
                table: "ParticipantEventDetails");

            migrationBuilder.DropIndex(
                name: "IX_ParticipantEventDetails_EmailId",
                table: "ParticipantEventDetails");

            migrationBuilder.DropIndex(
                name: "IX_ParticipantEventDetails_UserEmailId",
                table: "ParticipantEventDetails");

            migrationBuilder.AlterColumn<string>(
                name: "UserEmailId",
                table: "ParticipantEventDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserEmailId",
                table: "ParticipantEventDetails",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantEventDetails_EmailId",
                table: "ParticipantEventDetails",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantEventDetails_UserEmailId",
                table: "ParticipantEventDetails",
                column: "UserEmailId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantEventDetails_UserInfo_EmailId",
                table: "ParticipantEventDetails",
                column: "EmailId",
                principalTable: "UserInfo",
                principalColumn: "Emailid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantEventDetails_UserInfo_UserEmailId",
                table: "ParticipantEventDetails",
                column: "UserEmailId",
                principalTable: "UserInfo",
                principalColumn: "Emailid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
