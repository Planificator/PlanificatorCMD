using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class PresentationOneToManySpeakers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_SpeakerProfiles_PhotoId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_PresentationSpeakers_Presentations_PresentationId",
                table: "PresentationSpeakers");

            migrationBuilder.DropForeignKey(
                name: "FK_PresentationSpeakers_SpeakerProfiles_SpeakerId",
                table: "PresentationSpeakers");

            migrationBuilder.DropForeignKey(
                name: "FK_PresentationTags_Presentations_PresentationId",
                table: "PresentationTags");

            migrationBuilder.DropForeignKey(
                name: "FK_PresentationTags_Tags_TagId",
                table: "PresentationTags");

            migrationBuilder.AddColumn<int>(
                name: "PresentationOwnerSpeakerId",
                table: "Presentations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Presentations_PresentationOwnerSpeakerId",
                table: "Presentations",
                column: "PresentationOwnerSpeakerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_SpeakerProfiles_PhotoId",
                table: "Photos",
                column: "PhotoId",
                principalTable: "SpeakerProfiles",
                principalColumn: "SpeakerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Presentations_SpeakerProfiles_PresentationOwnerSpeakerId",
                table: "Presentations",
                column: "PresentationOwnerSpeakerId",
                principalTable: "SpeakerProfiles",
                principalColumn: "SpeakerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PresentationSpeakers_Presentations_PresentationId",
                table: "PresentationSpeakers",
                column: "PresentationId",
                principalTable: "Presentations",
                principalColumn: "PresentationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PresentationSpeakers_SpeakerProfiles_SpeakerId",
                table: "PresentationSpeakers",
                column: "SpeakerId",
                principalTable: "SpeakerProfiles",
                principalColumn: "SpeakerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PresentationTags_Presentations_PresentationId",
                table: "PresentationTags",
                column: "PresentationId",
                principalTable: "Presentations",
                principalColumn: "PresentationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PresentationTags_Tags_TagId",
                table: "PresentationTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_SpeakerProfiles_PhotoId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Presentations_SpeakerProfiles_PresentationOwnerSpeakerId",
                table: "Presentations");

            migrationBuilder.DropForeignKey(
                name: "FK_PresentationSpeakers_Presentations_PresentationId",
                table: "PresentationSpeakers");

            migrationBuilder.DropForeignKey(
                name: "FK_PresentationSpeakers_SpeakerProfiles_SpeakerId",
                table: "PresentationSpeakers");

            migrationBuilder.DropForeignKey(
                name: "FK_PresentationTags_Presentations_PresentationId",
                table: "PresentationTags");

            migrationBuilder.DropForeignKey(
                name: "FK_PresentationTags_Tags_TagId",
                table: "PresentationTags");

            migrationBuilder.DropIndex(
                name: "IX_Presentations_PresentationOwnerSpeakerId",
                table: "Presentations");

            migrationBuilder.DropColumn(
                name: "PresentationOwnerSpeakerId",
                table: "Presentations");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_SpeakerProfiles_PhotoId",
                table: "Photos",
                column: "PhotoId",
                principalTable: "SpeakerProfiles",
                principalColumn: "SpeakerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PresentationSpeakers_Presentations_PresentationId",
                table: "PresentationSpeakers",
                column: "PresentationId",
                principalTable: "Presentations",
                principalColumn: "PresentationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PresentationSpeakers_SpeakerProfiles_SpeakerId",
                table: "PresentationSpeakers",
                column: "SpeakerId",
                principalTable: "SpeakerProfiles",
                principalColumn: "SpeakerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PresentationTags_Presentations_PresentationId",
                table: "PresentationTags",
                column: "PresentationId",
                principalTable: "Presentations",
                principalColumn: "PresentationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PresentationTags_Tags_TagId",
                table: "PresentationTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}