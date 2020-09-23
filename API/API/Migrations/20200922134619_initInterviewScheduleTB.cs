using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class initInterviewScheduleTB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InterviewSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    interview_date = table.Column<DateTime>(nullable: false),
                    empId = table.Column<string>(nullable: true),
                    joblistId = table.Column<int>(nullable: true),
                    siteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InterviewSchedules_TB_Trans_Joblist_joblistId",
                        column: x => x.joblistId,
                        principalTable: "TB_Trans_Joblist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InterviewSchedules_TB_M_Site_siteId",
                        column: x => x.siteId,
                        principalTable: "TB_M_Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InterviewSchedules_joblistId",
                table: "InterviewSchedules",
                column: "joblistId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewSchedules_siteId",
                table: "InterviewSchedules",
                column: "siteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterviewSchedules");
        }
    }
}
