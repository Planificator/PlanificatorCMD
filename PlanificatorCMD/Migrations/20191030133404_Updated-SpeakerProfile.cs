using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanificatorCMD.Migrations
{
    public partial class UpdatedSpeakerProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_SpeakerProfiles_PhotoID",
                table: "Photos");

            migrationBuilder.RenameColumn(
                name: "SpeakerID",
                table: "SpeakerProfiles",
                newName: "SpeakerId");

            migrationBuilder.RenameColumn(
                name: "PhotoID",
                table: "Photos",
                newName: "PhotoId");

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "SpeakerProfiles",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_SpeakerProfiles_PhotoId",
                table: "Photos",
                column: "PhotoId",
                principalTable: "SpeakerProfiles",
                principalColumn: "SpeakerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_SpeakerProfiles_PhotoId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "SpeakerProfiles");

            migrationBuilder.RenameColumn(
                name: "SpeakerId",
                table: "SpeakerProfiles",
                newName: "SpeakerID");

            migrationBuilder.RenameColumn(
                name: "PhotoId",
                table: "Photos",
                newName: "PhotoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_SpeakerProfiles_PhotoID",
                table: "Photos",
                column: "PhotoID",
                principalTable: "SpeakerProfiles",
                principalColumn: "SpeakerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
