using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exowatch.Migrations
{
    /// <inheritdoc />
    public partial class Air : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sensors_Area_AreaID",
                table: "Sensors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sensors",
                table: "Sensors");

            migrationBuilder.DropIndex(
                name: "IX_Sensors_AreaID",
                table: "Sensors");

            migrationBuilder.DropColumn(
                name: "AreaID",
                table: "Sensors");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Sensors");

            migrationBuilder.DropColumn(
                name: "sensor_type",
                table: "Sensors");

            migrationBuilder.RenameTable(
                name: "Sensors",
                newName: "Sensor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sensor",
                table: "Sensor",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Air",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CarbonMonoxide = table.Column<double>(type: "double precision", nullable: false),
                    NitrogenMonoxide = table.Column<double>(type: "double precision", nullable: false),
                    NitrogenDioxide = table.Column<double>(type: "double precision", nullable: false),
                    Ozone = table.Column<double>(type: "double precision", nullable: false),
                    SulphurDioxide = table.Column<double>(type: "double precision", nullable: false),
                    AreaID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Air", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Air_Area_AreaID",
                        column: x => x.AreaID,
                        principalTable: "Area",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Air_Sensor_Id",
                        column: x => x.Id,
                        principalTable: "Sensor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Temperature",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false),
                    AreaID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temperature_Area_AreaID",
                        column: x => x.AreaID,
                        principalTable: "Area",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Temperature_Sensor_Id",
                        column: x => x.Id,
                        principalTable: "Sensor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Air_AreaID",
                table: "Air",
                column: "AreaID");

            migrationBuilder.CreateIndex(
                name: "IX_Temperature_AreaID",
                table: "Temperature",
                column: "AreaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Air");

            migrationBuilder.DropTable(
                name: "Temperature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sensor",
                table: "Sensor");

            migrationBuilder.RenameTable(
                name: "Sensor",
                newName: "Sensors");

            migrationBuilder.AddColumn<long>(
                name: "AreaID",
                table: "Sensors",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Value",
                table: "Sensors",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "sensor_type",
                table: "Sensors",
                type: "character varying(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sensors",
                table: "Sensors",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_AreaID",
                table: "Sensors",
                column: "AreaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sensors_Area_AreaID",
                table: "Sensors",
                column: "AreaID",
                principalTable: "Area",
                principalColumn: "ID");
        }
    }
}
