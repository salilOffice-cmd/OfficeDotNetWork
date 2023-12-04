using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Prac.Migrations.EF_FluentApiDB
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OfficeFloor1234",
                columns: table => new
                {
                    FloorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Floor_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeFloor1234", x => x.FloorId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Emp_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100, 5"),
                    MyOwnName = table.Column<string>(type: "varchar(200)", nullable: false, defaultValue: "Guest"),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    OfficeFloorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Emp_Id);
                    table.CheckConstraint("CheckName", "Emp_name Like 'a%'");
                    table.ForeignKey(
                        name: "FK_Employees_OfficeFloor1234_OfficeFloorID",
                        column: x => x.OfficeFloorID,
                        principalTable: "OfficeFloor1234",
                        principalColumn: "FloorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemDetails",
                columns: table => new
                {
                    SysDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemDetails", x => x.SysDetailId);
                    table.ForeignKey(
                        name: "FK_SystemDetails_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Emp_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_MyOwnName",
                table: "Employees",
                column: "MyOwnName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_OfficeFloorID",
                table: "Employees",
                column: "OfficeFloorID");

            migrationBuilder.CreateIndex(
                name: "IX_SystemDetails_EmployeeId",
                table: "SystemDetails",
                column: "EmployeeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemDetails");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "OfficeFloor1234");
        }
    }
}
