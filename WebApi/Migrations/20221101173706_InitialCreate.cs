using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FeeNos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeeNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeeNos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vs_Ids",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VS_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeeNoRepoId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vs_Ids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vs_Ids_FeeNos_FeeNoRepoId",
                        column: x => x.FeeNoRepoId,
                        principalTable: "FeeNos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HealthItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VS_PART = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VS_RECORD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VS_REASON = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VS_MEMO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATE_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATE_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATE_DATE = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    MODIFY_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MODIFY_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MODIFY_DATE = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    VS_OTHER_MEMO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VS_TYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VS_CARE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vs_IdRepoId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthItem_Vs_Ids_Vs_IdRepoId",
                        column: x => x.Vs_IdRepoId,
                        principalTable: "Vs_Ids",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HealthItem_Vs_IdRepoId",
                table: "HealthItem",
                column: "Vs_IdRepoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vs_Ids_FeeNoRepoId",
                table: "Vs_Ids",
                column: "FeeNoRepoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthItem");

            migrationBuilder.DropTable(
                name: "Vs_Ids");

            migrationBuilder.DropTable(
                name: "FeeNos");
        }
    }
}
