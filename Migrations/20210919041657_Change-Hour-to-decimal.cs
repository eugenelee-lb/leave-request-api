using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveRequestAPI.Migrations
{
    public partial class ChangeHourtodecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Hours",
                table: "LeaveRequests",
                type: "decimal(7,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Hours",
                table: "EmployeeAccruals",
                type: "decimal(7,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "EmployeeAccruals",
                columns: new[] { "EmployeeId", "AccrualType", "Hours" },
                values: new object[,]
                {
                    { "eulee", "Vacation", 112m },
                    { "eulee", "Personal Leave", 36m },
                    { "eulee", "Sick Leave", 785m },
                    { "nichaud", "Vacation", 96m },
                    { "nichaud", "Personal Leave", 42m },
                    { "nichaud", "Sick Leave", 320m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeAccruals",
                keyColumns: new[] { "EmployeeId", "AccrualType" },
                keyValues: new object[] { "eulee", "Personal Leave" });

            migrationBuilder.DeleteData(
                table: "EmployeeAccruals",
                keyColumns: new[] { "EmployeeId", "AccrualType" },
                keyValues: new object[] { "eulee", "Sick Leave" });

            migrationBuilder.DeleteData(
                table: "EmployeeAccruals",
                keyColumns: new[] { "EmployeeId", "AccrualType" },
                keyValues: new object[] { "eulee", "Vacation" });

            migrationBuilder.DeleteData(
                table: "EmployeeAccruals",
                keyColumns: new[] { "EmployeeId", "AccrualType" },
                keyValues: new object[] { "nichaud", "Personal Leave" });

            migrationBuilder.DeleteData(
                table: "EmployeeAccruals",
                keyColumns: new[] { "EmployeeId", "AccrualType" },
                keyValues: new object[] { "nichaud", "Sick Leave" });

            migrationBuilder.DeleteData(
                table: "EmployeeAccruals",
                keyColumns: new[] { "EmployeeId", "AccrualType" },
                keyValues: new object[] { "nichaud", "Vacation" });

            migrationBuilder.AlterColumn<int>(
                name: "Hours",
                table: "LeaveRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Hours",
                table: "EmployeeAccruals",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,2)");
        }
    }
}
