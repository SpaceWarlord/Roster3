using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roster.App.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TPT");

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Duration = table.Column<int>(type: "INTEGER", nullable: true),
                    Infinite = table.Column<bool>(type: "INTEGER", nullable: false),
                    Required = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    MiddleName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Nickname = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<long>(type: "INTEGER", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    HighlightColor = table.Column<string>(type: "TEXT", nullable: true),
                    Avatar = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suburbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PostCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suburbs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    StartDate = table.Column<long>(type: "INTEGER", nullable: false),
                    EndDate = table.Column<long>(type: "INTEGER", nullable: false),
                    StartTime = table.Column<long>(type: "INTEGER", nullable: false),
                    EndTime = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "TPT",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    UnitNum = table.Column<string>(type: "TEXT", nullable: true),
                    StreetNum = table.Column<string>(type: "TEXT", nullable: true),
                    StreetName = table.Column<string>(type: "TEXT", nullable: true),
                    StreetType = table.Column<string>(type: "TEXT", nullable: true),
                    SuburbId = table.Column<string>(type: "TEXT", nullable: true),
                    SuburbId1 = table.Column<int>(type: "INTEGER", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Suburbs_SuburbId1",
                        column: x => x.SuburbId1,
                        principalTable: "Suburbs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Worker",
                schema: "TPT",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    AddressId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Worker_Address_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "TPT",
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Worker_Person_Id",
                        column: x => x.Id,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                schema: "TPT",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    NDISNumber = table.Column<string>(type: "TEXT", nullable: true),
                    RiskCategory = table.Column<byte>(type: "INTEGER", nullable: false),
                    GenderPreference = table.Column<string>(type: "TEXT", nullable: true),
                    PrimaryWorkerId = table.Column<string>(type: "TEXT", nullable: true),
                    SecondaryWorkerId = table.Column<string>(type: "TEXT", nullable: true),
                    AddressId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Client_Address_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "TPT",
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Client_Person_Id",
                        column: x => x.Id,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Client_Worker_PrimaryWorkerId",
                        column: x => x.PrimaryWorkerId,
                        principalSchema: "TPT",
                        principalTable: "Worker",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Client_Worker_SecondaryWorkerId",
                        column: x => x.SecondaryWorkerId,
                        principalSchema: "TPT",
                        principalTable: "Worker",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkerCertificates",
                columns: table => new
                {
                    WorkerId = table.Column<string>(type: "TEXT", nullable: false),
                    CertificateId = table.Column<string>(type: "TEXT", nullable: false),
                    DateObtained = table.Column<long>(type: "INTEGER", nullable: false),
                    ExpiryDate = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerCertificates", x => new { x.WorkerId, x.CertificateId });
                    table.ForeignKey(
                        name: "FK_WorkerCertificates_Certificates_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkerCertificates_Worker_WorkerId",
                        column: x => x.WorkerId,
                        principalSchema: "TPT",
                        principalTable: "Worker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    StartDate = table.Column<long>(type: "INTEGER", nullable: false),
                    EndDate = table.Column<long>(type: "INTEGER", nullable: false),
                    StartTime = table.Column<long>(type: "INTEGER", nullable: false),
                    EndTime = table.Column<long>(type: "INTEGER", nullable: false),
                    WorkerId = table.Column<string>(type: "TEXT", nullable: true),
                    ClientId = table.Column<string>(type: "TEXT", nullable: true),
                    StartLocationId = table.Column<string>(type: "TEXT", nullable: true),
                    EndLocationId = table.Column<string>(type: "TEXT", nullable: true),
                    TravelTime = table.Column<byte>(type: "INTEGER", nullable: false),
                    MaxTravelDistance = table.Column<short>(type: "INTEGER", nullable: false),
                    ShiftType = table.Column<char>(type: "TEXT", nullable: false),
                    Reoccuring = table.Column<bool>(type: "INTEGER", nullable: false),
                    CaseNoteCompleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    BackgroundColor = table.Column<string>(type: "TEXT", nullable: true),
                    ForegroundColor = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shifts_Address_EndLocationId",
                        column: x => x.EndLocationId,
                        principalSchema: "TPT",
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Shifts_Address_StartLocationId",
                        column: x => x.StartLocationId,
                        principalSchema: "TPT",
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Shifts_Client_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "TPT",
                        principalTable: "Client",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Shifts_Worker_WorkerId",
                        column: x => x.WorkerId,
                        principalSchema: "TPT",
                        principalTable: "Worker",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShiftTemplates",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    WorkerId = table.Column<string>(type: "TEXT", nullable: false),
                    ClientId = table.Column<string>(type: "TEXT", nullable: false),
                    Day = table.Column<string>(type: "TEXT", nullable: true),
                    StartTime = table.Column<string>(type: "TEXT", nullable: true),
                    EndTime = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftTemplates_Client_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "TPT",
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShiftTemplates_Worker_WorkerId",
                        column: x => x.WorkerId,
                        principalSchema: "TPT",
                        principalTable: "Worker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    RouteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartAddressId = table.Column<string>(type: "TEXT", nullable: false),
                    EndAddressId = table.Column<string>(type: "TEXT", nullable: false),
                    Distance = table.Column<float>(type: "REAL", nullable: false),
                    ShiftId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.RouteId);
                    table.ForeignKey(
                        name: "FK_Routes_Address_EndAddressId",
                        column: x => x.EndAddressId,
                        principalSchema: "TPT",
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Routes_Address_StartAddressId",
                        column: x => x.StartAddressId,
                        principalSchema: "TPT",
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Routes_Shifts_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shifts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShiftAddress",
                schema: "TPT",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ShiftId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftAddress_Address_Id",
                        column: x => x.Id,
                        principalSchema: "TPT",
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShiftAddress_Shifts_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shifts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_SuburbId1",
                schema: "TPT",
                table: "Address",
                column: "SuburbId1");

            migrationBuilder.CreateIndex(
                name: "IX_Client_AddressId",
                schema: "TPT",
                table: "Client",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_PrimaryWorkerId",
                schema: "TPT",
                table: "Client",
                column: "PrimaryWorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_SecondaryWorkerId",
                schema: "TPT",
                table: "Client",
                column: "SecondaryWorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_Nickname",
                table: "Person",
                column: "Nickname",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Routes_EndAddressId",
                table: "Routes",
                column: "EndAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_ShiftId",
                table: "Routes",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_StartAddressId",
                table: "Routes",
                column: "StartAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftAddress_ShiftId",
                schema: "TPT",
                table: "ShiftAddress",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_ClientId",
                table: "Shifts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_EndLocationId",
                table: "Shifts",
                column: "EndLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_StartLocationId",
                table: "Shifts",
                column: "StartLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_WorkerId",
                table: "Shifts",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftTemplates_ClientId",
                table: "ShiftTemplates",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftTemplates_WorkerId",
                table: "ShiftTemplates",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Worker_AddressId",
                schema: "TPT",
                table: "Worker",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerCertificates_CertificateId",
                table: "WorkerCertificates",
                column: "CertificateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "ShiftAddress",
                schema: "TPT");

            migrationBuilder.DropTable(
                name: "ShiftTemplates");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WorkerCertificates");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "Client",
                schema: "TPT");

            migrationBuilder.DropTable(
                name: "Worker",
                schema: "TPT");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "TPT");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Suburbs");
        }
    }
}
