using Microsoft.EntityFrameworkCore.Migrations;

namespace PRI.Project.Labogids.Infrastructure.Migrations
{
    public partial class CreateNewDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Laboratories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillingCode = table.Column<int>(type: "int", nullable: false),
                    DiagnoseRule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CumulationRule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specimens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specimens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StorageConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temperature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimePeriod = table.Column<int>(type: "int", nullable: false),
                    TimeReference = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageConditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Synonym = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecimenId = table.Column<int>(type: "int", nullable: false),
                    LaboratoryId = table.Column<int>(type: "int", nullable: false),
                    RequestCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestDefinitionId = table.Column<int>(type: "int", nullable: false),
                    TurnAroundTime = table.Column<int>(type: "int", nullable: false),
                    TimePeriod = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_Laboratories_LaboratoryId",
                        column: x => x.LaboratoryId,
                        principalTable: "Laboratories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Properties_RequestDefinitions_RequestDefinitionId",
                        column: x => x.RequestDefinitionId,
                        principalTable: "RequestDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Properties_Specimens_SpecimenId",
                        column: x => x.SpecimenId,
                        principalTable: "Specimens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyStorageCondition",
                columns: table => new
                {
                    PropertiesId = table.Column<int>(type: "int", nullable: false),
                    StorageConditionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyStorageCondition", x => new { x.PropertiesId, x.StorageConditionsId });
                    table.ForeignKey(
                        name: "FK_PropertyStorageCondition_Properties_PropertiesId",
                        column: x => x.PropertiesId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyStorageCondition_StorageConditions_StorageConditionsId",
                        column: x => x.StorageConditionsId,
                        principalTable: "StorageConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReferenceValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinimumValue = table.Column<double>(type: "float", nullable: false),
                    MaximumValue = table.Column<double>(type: "float", nullable: false),
                    StringValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaximalAge = table.Column<int>(type: "int", nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferenceValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReferenceValues_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_LaboratoryId",
                table: "Properties",
                column: "LaboratoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_RequestDefinitionId",
                table: "Properties",
                column: "RequestDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_SpecimenId",
                table: "Properties",
                column: "SpecimenId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyStorageCondition_StorageConditionsId",
                table: "PropertyStorageCondition",
                column: "StorageConditionsId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferenceValues_PropertyId",
                table: "ReferenceValues",
                column: "PropertyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyStorageCondition");

            migrationBuilder.DropTable(
                name: "ReferenceValues");

            migrationBuilder.DropTable(
                name: "StorageConditions");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Laboratories");

            migrationBuilder.DropTable(
                name: "RequestDefinitions");

            migrationBuilder.DropTable(
                name: "Specimens");
        }
    }
}
