﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class initreplacementTB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "TB_M_Site",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumber",
                table: "TB_M_Site",
                nullable: false,
                defaultValue: 0);

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
                    isDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Replacement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_Replacement_TB_M_Site_SiteId",
                        column: x => x.SiteId,
                        principalTable: "TB_M_Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Placement_SiteId",
                table: "TB_M_Placement",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Replacement_SiteId",
                table: "TB_M_Replacement",
                column: "SiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_M_Placement");

            migrationBuilder.DropTable(
                name: "TB_M_Replacement");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "TB_M_Site");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "TB_M_Site");
        }
    }
}
