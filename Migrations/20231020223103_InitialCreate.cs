using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MotivTest.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Region_CId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locality_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locality_RId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalityId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_LId",
                        column: x => x.LocalityId,
                        principalTable: "Locality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Request_DId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Request_UId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[,]
                {
                    { 1, "Россия", "RUS" },
                    { 2, "Казахстан", "KZ" }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Офис обслуживания" },
                    { 2, "Контакт-Центр" }
                });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { 1, 1, "Свердловская область" });

            migrationBuilder.InsertData(
                table: "Locality",
                columns: new[] { "Id", "Name", "RegionId" },
                values: new object[] { 1, "Екатеринбург", 1 });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "LocalityId", "MiddleName", "Name", "Number", "Surname" },
                values: new object[] { 1, null, 1, null, "Иван", "81112223344", "Иванов" });

            migrationBuilder.InsertData(
                table: "Request",
                columns: new[] { "Id", "Date", "DepartmentId", "Name", "Reason", "UserId" },
                values: new object[] { 1, new DateTime(2023, 10, 21, 3, 31, 3, 531, DateTimeKind.Local).AddTicks(9893), 2, "Обращение 1", "Замена номера", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Country_Id",
                table: "Country",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Department_Id",
                table: "Department",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Locality_Id",
                table: "Locality",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Locality_RId",
                table: "Locality",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Region_CId",
                table: "Region",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Region_Id",
                table: "Region",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Request_DId",
                table: "Request",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_Id",
                table: "Request",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Request_UId",
                table: "Request",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Id",
                table: "User",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_LId",
                table: "User",
                column: "LocalityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Locality");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
