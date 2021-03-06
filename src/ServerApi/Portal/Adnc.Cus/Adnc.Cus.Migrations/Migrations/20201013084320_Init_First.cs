﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Adnc.Cus.Migrations.Migrations
{
    public partial class Init_First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateBy = table.Column<long>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    ModifyBy = table.Column<long>(nullable: true),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    Account = table.Column<string>(maxLength: 32, nullable: false),
                    Nickname = table.Column<string>(maxLength: 32, nullable: false),
                    Realname = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CusTransactionLog",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateBy = table.Column<long>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    Account = table.Column<string>(maxLength: 32, nullable: false),
                    ExchangeType = table.Column<string>(maxLength: 3, nullable: false),
                    ExchageStatus = table.Column<string>(maxLength: 3, nullable: false),
                    ChangingAmount = table.Column<decimal>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    ChangedAmount = table.Column<decimal>(nullable: false),
                    Remark = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CusTransactionLog", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CusFinance",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false),
                    CreateBy = table.Column<long>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    ModifyBy = table.Column<long>(nullable: true),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    CustomerId = table.Column<long>(nullable: false),
                    Account = table.Column<string>(maxLength: 32, nullable: false),
                    Balance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CusFinance", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CusFinance_Customer_ID",
                        column: x => x.ID,
                        principalTable: "Customer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CusFinance");

            migrationBuilder.DropTable(
                name: "CusTransactionLog");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
