using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace testsite.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    AgreePolicy = table.Column<bool>(nullable: false),
                    BirthDay = table.Column<DateTime>(nullable: true),
                    FamousPoint = table.Column<int>(nullable: false),
                    IsAccept = table.Column<bool>(nullable: true),
                    IsVip = table.Column<bool>(nullable: false),
                    Issue = table.Column<string>(nullable: true),
                    JobTypeId = table.Column<int>(nullable: false),
                    MailAddress = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NameKana = table.Column<string>(nullable: true),
                    Office = table.Column<string>(nullable: true),
                    PostNo = table.Column<string>(nullable: true),
                    RepeatCount = table.Column<int>(nullable: false),
                    SkillPoint = table.Column<int>(nullable: false),
                    Twitter = table.Column<string>(nullable: true),
                    UserNotes = table.Column<string>(nullable: true),
                    WacateNotes = table.Column<string>(nullable: true),
                    Yakushoku = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobTypes");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
