using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveRequestAPI.Migrations
{
    public partial class requestenddatenull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "LeaveRequests",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "EmployeeAccruals",
                keyColumns: new[] { "EmployeeId", "AccrualType" },
                keyValues: new object[] { "eulee", "Sick Leave" },
                column: "Hours",
                value: 785.8m);

            migrationBuilder.UpdateData(
                table: "EmployeeAccruals",
                keyColumns: new[] { "EmployeeId", "AccrualType" },
                keyValues: new object[] { "eulee", "Vacation" },
                column: "Hours",
                value: 112.5m);

            migrationBuilder.UpdateData(
                table: "EmployeeAccruals",
                keyColumns: new[] { "EmployeeId", "AccrualType" },
                keyValues: new object[] { "nichaud", "Sick Leave" },
                column: "Hours",
                value: 320.3m);

            migrationBuilder.UpdateData(
                table: "EmployeeAccruals",
                keyColumns: new[] { "EmployeeId", "AccrualType" },
                keyValues: new object[] { "nichaud", "Vacation" },
                column: "Hours",
                value: 96.4m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "LeaveRequests",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "EmployeeAccruals",
                keyColumns: new[] { "EmployeeId", "AccrualType" },
                keyValues: new object[] { "eulee", "Sick Leave" },
                column: "Hours",
                value: 785m);

            migrationBuilder.UpdateData(
                table: "EmployeeAccruals",
                keyColumns: new[] { "EmployeeId", "AccrualType" },
                keyValues: new object[] { "eulee", "Vacation" },
                column: "Hours",
                value: 112m);

            migrationBuilder.UpdateData(
                table: "EmployeeAccruals",
                keyColumns: new[] { "EmployeeId", "AccrualType" },
                keyValues: new object[] { "nichaud", "Sick Leave" },
                column: "Hours",
                value: 320m);

            migrationBuilder.UpdateData(
                table: "EmployeeAccruals",
                keyColumns: new[] { "EmployeeId", "AccrualType" },
                keyValues: new object[] { "nichaud", "Vacation" },
                column: "Hours",
                value: 96m);
        }
    }
}
