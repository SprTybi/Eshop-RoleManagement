using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Security.Domain.Migrations
{
    public partial class initialshoping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectAreas",
                columns: table => new
                {
                    ProjectAreaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersianTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectAreas", x => x.ProjectAreaID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "projectControllers",
                columns: table => new
                {
                    ProjectControllerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectControllerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersianTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectAreaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectControllers", x => x.ProjectControllerID);
                    table.ForeignKey(
                        name: "FK_projectControllers_ProjectAreas_ProjectAreaID",
                        column: x => x.ProjectAreaID,
                        principalTable: "ProjectAreas",
                        principalColumn: "ProjectAreaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEmailActivated = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projectActions",
                columns: table => new
                {
                    ProjectActionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectActionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersianTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectControllerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectActions", x => x.ProjectActionID);
                    table.ForeignKey(
                        name: "FK_projectActions_projectControllers_ProjectControllerID",
                        column: x => x.ProjectControllerID,
                        principalTable: "projectControllers",
                        principalColumn: "ProjectControllerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleActions",
                columns: table => new
                {
                    RoleActionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    ProjectActionID = table.Column<int>(type: "int", nullable: false),
                    HasPermission = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleActions", x => x.RoleActionID);
                    table.ForeignKey(
                        name: "FK_RoleActions_projectActions_ProjectActionID",
                        column: x => x.ProjectActionID,
                        principalTable: "projectActions",
                        principalColumn: "ProjectActionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleActions_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_projectActions_ProjectControllerID",
                table: "projectActions",
                column: "ProjectControllerID");

            migrationBuilder.CreateIndex(
                name: "IX_projectControllers_ProjectAreaID",
                table: "projectControllers",
                column: "ProjectAreaID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleActions_ProjectActionID",
                table: "RoleActions",
                column: "ProjectActionID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleActions_RoleID",
                table: "RoleActions",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleActions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "projectActions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "projectControllers");

            migrationBuilder.DropTable(
                name: "ProjectAreas");
        }
    }
}
