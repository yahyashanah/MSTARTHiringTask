using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSTARTHiringTask.Migrations
{
    public partial class firstdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_ID = table.Column<int>(nullable: false),
                    Server_DateTime = table.Column<DateTime>(nullable: false),
                    DateTime_UTC = table.Column<DateTime>(nullable: false),
                    Update_DateTime_UTC = table.Column<DateTime>(nullable: false),
                    Account_Number = table.Column<string>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false),
                    Currency = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Server_DateTime = table.Column<DateTime>(nullable: false),
                    DateTime_UTC = table.Column<DateTime>(nullable: false),
                    Update_DateTime_UTC = table.Column<DateTime>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    First_Name = table.Column<string>(nullable: false),
                    Last_Name = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Date_Of_Birth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
