using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class addInitDbBaru : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_M_Site",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Supervisor_name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<int>(nullable: false),
                    CreateData = table.Column<DateTimeOffset>(nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(nullable: false),
                    DeleteData = table.Column<DateTimeOffset>(nullable: false),
                    isDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Site", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_Trans_Joblist",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CreateData = table.Column<DateTimeOffset>(nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(nullable: false),
                    DeleteData = table.Column<DateTimeOffset>(nullable: false),
                    isDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Trans_Joblist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Placement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmpId = table.Column<string>(nullable: true),
                    PlacementDate = table.Column<DateTime>(nullable: false),
                    PlacementEndDate = table.Column<DateTime>(nullable: false),
                    SiteId = table.Column<int>(nullable: false),
                    CreateData = table.Column<DateTimeOffset>(nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(nullable: false),
                    DeleteData = table.Column<DateTimeOffset>(nullable: false),
                    isDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Placement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_Placement_TB_M_Site_SiteId",
                        column: x => x.SiteId,
                        principalTable: "TB_M_Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterviewSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Interview_date = table.Column<DateTime>(nullable: false),
                    EmpId = table.Column<string>(nullable: true),
                    JoblistId = table.Column<int>(nullable: false),
                    SiteId = table.Column<int>(nullable: false),
                    CreateData = table.Column<DateTimeOffset>(nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(nullable: false),
                    DeleteData = table.Column<DateTimeOffset>(nullable: false),
                    isDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InterviewSchedules_TB_Trans_Joblist_JoblistId",
                        column: x => x.JoblistId,
                        principalTable: "TB_Trans_Joblist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterviewSchedules_TB_M_Site_SiteId",
                        column: x => x.SiteId,
                        principalTable: "TB_M_Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Replacement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Replacement_reason = table.Column<string>(nullable: true),
                    EmpId = table.Column<string>(nullable: true),
                    SiteId = table.Column<int>(nullable: false),
                    CreateData = table.Column<DateTimeOffset>(nullable: false),
                    UpdateDate = table.Column<DateTimeOffset>(nullable: false),
                    DeleteData = table.Column<DateTimeOffset>(nullable: false),
                    isDelete = table.Column<bool>(nullable: false),
                    PlacementId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Replacement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_Replacement_TB_M_Placement_PlacementId",
                        column: x => x.PlacementId,
                        principalTable: "TB_M_Placement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_M_Replacement_TB_M_Site_SiteId",
                        column: x => x.SiteId,
                        principalTable: "TB_M_Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InterviewSchedules_JoblistId",
                table: "InterviewSchedules",
                column: "JoblistId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewSchedules_SiteId",
                table: "InterviewSchedules",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Placement_SiteId",
                table: "TB_M_Placement",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Replacement_PlacementId",
                table: "TB_M_Replacement",
                column: "PlacementId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Replacement_SiteId",
                table: "TB_M_Replacement",
                column: "SiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterviewSchedules");

            migrationBuilder.DropTable(
                name: "TB_M_Replacement");

            migrationBuilder.DropTable(
                name: "TB_Trans_Joblist");

            migrationBuilder.DropTable(
                name: "TB_M_Placement");

            migrationBuilder.DropTable(
                name: "TB_M_Site");
        }
    }
}
