﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace TezosNotifyBot.Storage.Migrations
{
    public partial class AddedMessageStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "message",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "message");
        }
    }
}
