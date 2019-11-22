using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class ManytoManyPresentationSpeaker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PresentationSpeakers",
                columns: table => new
                {
                    PresentationId = table.Column<int>(nullable: false),
                    SpeakerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresentationSpeakers", x => new { x.PresentationId, x.SpeakerId });
                    table.ForeignKey(
                        name: "FK_PresentationSpeakers_Presentations_PresentationId",
                        column: x => x.PresentationId,
                        principalTable: "Presentations",
                        principalColumn: "PresentationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PresentationSpeakers_SpeakerProfiles_SpeakerId",
                        column: x => x.SpeakerId,
                        principalTable: "SpeakerProfiles",
                        principalColumn: "SpeakerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PresentationSpeakers_SpeakerId",
                table: "PresentationSpeakers",
                column: "SpeakerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PresentationSpeakers");
        }
    }
}