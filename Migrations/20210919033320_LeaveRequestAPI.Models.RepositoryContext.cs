using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveRequestAPI.Migrations
{
    public partial class LeaveRequestAPIModelsRepositoryContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(maxLength: 25, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    IsSupervisor = table.Column<bool>(nullable: false),
                    SupervisorId = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAccruals",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(nullable: false),
                    AccrualType = table.Column<string>(maxLength: 50, nullable: false),
                    Hours = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAccruals", x => new { x.EmployeeId, x.AccrualType });
                    table.ForeignKey(
                        name: "FK_EmployeeAccruals_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    LeaveRequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<string>(maxLength: 25, nullable: false),
                    LeaveType = table.Column<string>(maxLength: 50, nullable: false),
                    LeaveTimeType = table.Column<string>(maxLength: 50, nullable: false),
                    LeaveAt = table.Column<string>(maxLength: 25, nullable: true),
                    InAt = table.Column<string>(maxLength: 25, nullable: true),
                    IsMultiDays = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Hours = table.Column<int>(nullable: false),
                    ApproverId = table.Column<string>(maxLength: 25, nullable: false),
                    AlternateApproverId = table.Column<string>(maxLength: 25, nullable: true),
                    RequestStatus = table.Column<string>(maxLength: 25, nullable: false),
                    SubmitDate = table.Column<DateTime>(nullable: false),
                    ApproveDate = table.Column<DateTime>(nullable: false),
                    ApproveBy = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.LeaveRequestId);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "IsSupervisor", "LastName", "SupervisorId" },
                values: new object[] { "eulee", "Eugene", false, "Lee", "nichaud" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "IsSupervisor", "LastName", "SupervisorId" },
                values: new object[] { "nichaud", "Nishchal", true, "Chaudhary", "" });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_EmployeeId",
                table: "LeaveRequests",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeAccruals");

            migrationBuilder.DropTable(
                name: "LeaveRequests");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
