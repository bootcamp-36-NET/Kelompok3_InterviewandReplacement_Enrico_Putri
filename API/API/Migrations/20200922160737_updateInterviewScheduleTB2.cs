using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class updateInterviewScheduleTB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterviewSchedules_TB_Trans_Joblist_joblistId",
                table: "InterviewSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewSchedules_TB_M_Site_siteId",
                table: "InterviewSchedules");

            migrationBuilder.RenameColumn(
                name: "siteId",
                table: "InterviewSchedules",
                newName: "SiteId");

            migrationBuilder.RenameColumn(
                name: "joblistId",
                table: "InterviewSchedules",
                newName: "JoblistId");

            migrationBuilder.RenameColumn(
                name: "interview_date",
                table: "InterviewSchedules",
                newName: "Interview_date");

            migrationBuilder.RenameColumn(
                name: "empId",
                table: "InterviewSchedules",
                newName: "EmpId");

            migrationBuilder.RenameIndex(
                name: "IX_InterviewSchedules_siteId",
                table: "InterviewSchedules",
                newName: "IX_InterviewSchedules_SiteId");

            migrationBuilder.RenameIndex(
                name: "IX_InterviewSchedules_joblistId",
                table: "InterviewSchedules",
                newName: "IX_InterviewSchedules_JoblistId");

            migrationBuilder.AlterColumn<int>(
                name: "SiteId",
                table: "InterviewSchedules",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "JoblistId",
                table: "InterviewSchedules",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewSchedules_TB_Trans_Joblist_JoblistId",
                table: "InterviewSchedules",
                column: "JoblistId",
                principalTable: "TB_Trans_Joblist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewSchedules_TB_M_Site_SiteId",
                table: "InterviewSchedules",
                column: "SiteId",
                principalTable: "TB_M_Site",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterviewSchedules_TB_Trans_Joblist_JoblistId",
                table: "InterviewSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_InterviewSchedules_TB_M_Site_SiteId",
                table: "InterviewSchedules");

            migrationBuilder.RenameColumn(
                name: "SiteId",
                table: "InterviewSchedules",
                newName: "siteId");

            migrationBuilder.RenameColumn(
                name: "JoblistId",
                table: "InterviewSchedules",
                newName: "joblistId");

            migrationBuilder.RenameColumn(
                name: "Interview_date",
                table: "InterviewSchedules",
                newName: "interview_date");

            migrationBuilder.RenameColumn(
                name: "EmpId",
                table: "InterviewSchedules",
                newName: "empId");

            migrationBuilder.RenameIndex(
                name: "IX_InterviewSchedules_SiteId",
                table: "InterviewSchedules",
                newName: "IX_InterviewSchedules_siteId");

            migrationBuilder.RenameIndex(
                name: "IX_InterviewSchedules_JoblistId",
                table: "InterviewSchedules",
                newName: "IX_InterviewSchedules_joblistId");

            migrationBuilder.AlterColumn<int>(
                name: "siteId",
                table: "InterviewSchedules",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "joblistId",
                table: "InterviewSchedules",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewSchedules_TB_Trans_Joblist_joblistId",
                table: "InterviewSchedules",
                column: "joblistId",
                principalTable: "TB_Trans_Joblist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InterviewSchedules_TB_M_Site_siteId",
                table: "InterviewSchedules",
                column: "siteId",
                principalTable: "TB_M_Site",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
