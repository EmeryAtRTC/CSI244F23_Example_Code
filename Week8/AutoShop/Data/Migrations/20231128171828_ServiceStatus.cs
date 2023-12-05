using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoShop.Data.Migrations
{
    public partial class ServiceStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceStatusId",
                table: "ServicesPerformed",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ServiceStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServicesPerformed_ServiceStatusId",
                table: "ServicesPerformed",
                column: "ServiceStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServicesPerformed_ServiceStatuses_ServiceStatusId",
                table: "ServicesPerformed",
                column: "ServiceStatusId",
                principalTable: "ServiceStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicesPerformed_ServiceStatuses_ServiceStatusId",
                table: "ServicesPerformed");

            migrationBuilder.DropTable(
                name: "ServiceStatuses");

            migrationBuilder.DropIndex(
                name: "IX_ServicesPerformed_ServiceStatusId",
                table: "ServicesPerformed");

            migrationBuilder.DropColumn(
                name: "ServiceStatusId",
                table: "ServicesPerformed");
        }
    }
}
