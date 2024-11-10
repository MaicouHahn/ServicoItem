using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicoItem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "itens",
                columns: table => new
                {
                    IdItem = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CodItem = table.Column<string>(type: "TEXT", nullable: false),
                    NomeItem = table.Column<string>(type: "TEXT", nullable: false),
                    DescricaoItem = table.Column<string>(type: "TEXT", nullable: false),
                    PrecoItem = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itens", x => x.IdItem);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "itens");
        }
    }
}
