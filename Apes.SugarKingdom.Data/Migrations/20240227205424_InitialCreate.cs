using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apes.SugarKingdom.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VersusPoints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Wallet = table.Column<string>(type: "varchar(100)", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<byte[]>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<byte[]>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VersusPoints", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VersusPoints");
        }
    }
}
