using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exowatch.Migrations
{
    /// <inheritdoc />
    public partial class TPH : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sensor_Area_AreaID",
                table: "Sensor");

            migrationBuilder.DropTable(
                name: "Temperature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sensor",
                table: "Sensor");

            migrationBuilder.RenameTable(
                name: "Sensor",
                newName: "Sensors");

            migrationBuilder.RenameIndex(
                name: "IX_Sensor_AreaID",
                table: "Sensors",
                newName: "IX_Sensors_AreaID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Sensors_Area_AreaID",
                table: "Sensors",
                column: "AreaID",
                principalTable: "Area",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sensors_Area_AreaID",
                table: "Sensors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sensors",
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

            migrationBuilder.RenameIndex(
                name: "IX_Sensors_AreaID",
                table: "Sensor",
                newName: "IX_Sensor_AreaID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sensor",
                table: "Sensor",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Temperature",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temperature_Sensor_Id",
                        column: x => x.Id,
                        principalTable: "Sensor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Sensor_Area_AreaID",
                table: "Sensor",
                column: "AreaID",
                principalTable: "Area",
                principalColumn: "ID");
        }
    }
}
