using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace testsite.Migrations
{
    public partial class AddJoyType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Members_JobTypeId",
                table: "Members",
                column: "JobTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_JobTypes_JobTypeId",
                table: "Members",
                column: "JobTypeId",
                principalTable: "JobTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_JobTypes_JobTypeId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_JobTypeId",
                table: "Members");
        }
    }
}
