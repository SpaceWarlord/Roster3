using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roster.App.Migrations
{
    /// <inheritdoc />
    public partial class AddObjective : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Objectives",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    PriorityRating = table.Column<string>(type: "TEXT", nullable: false),
                    DateAdded = table.Column<long>(type: "INTEGER", nullable: false),
                    CompleteBy = table.Column<long>(type: "INTEGER", nullable: false),
                    Completed = table.Column<bool>(type: "INTEGER", nullable: false),
                    WorkerId = table.Column<string>(type: "TEXT", nullable: true),
                    ClientId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Objectives_Client_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "TPT",
                        principalTable: "Client",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Objectives_Worker_WorkerId",
                        column: x => x.WorkerId,
                        principalSchema: "TPT",
                        principalTable: "Worker",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Objectives_ClientId",
                table: "Objectives",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Objectives_WorkerId",
                table: "Objectives",
                column: "WorkerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Objectives");
        }
    }
}
