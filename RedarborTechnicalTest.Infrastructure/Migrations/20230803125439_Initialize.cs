using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedarborTechnicalTest.Infrastructure.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EMPLOYEE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COMPANYID = table.Column<int>(type: "int", nullable: false),
                    CREATEDON = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DELETEON = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FAX = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LASTLOGIN = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PORTALID = table.Column<int>(type: "int", nullable: false),
                    ROLEID = table.Column<int>(type: "int", nullable: false),
                    STATUSID = table.Column<bool>(type: "bit", nullable: false),
                    TELEPHONE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UPDATEDON = table.Column<DateTime>(type: "datetime2", nullable: false),
                    USERNAME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEE", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EMPLOYEE");
        }
    }
}
