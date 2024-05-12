using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Exowatch.Migrations
{
    /// <inheritdoc />
    public partial class AddArea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AreaID",
                table: "Sensor",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Radius = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sensor_AreaID",
                table: "Sensor",
                column: "AreaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sensor_Area_AreaID",
                table: "Sensor",
                column: "AreaID",
                principalTable: "Area",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sensor_Area_AreaID",
                table: "Sensor");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropIndex(
                name: "IX_Sensor_AreaID",
                table: "Sensor");

            migrationBuilder.DropColumn(
                name: "AreaID",
                table: "Sensor");
        }
    }
}
