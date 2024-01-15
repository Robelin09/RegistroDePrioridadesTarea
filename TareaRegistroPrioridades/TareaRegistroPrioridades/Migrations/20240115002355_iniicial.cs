using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TareaRegistroPrioridades.Migrations
{
    /// <inheritdoc />
    public partial class iniicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripción",
                table: "Prioridades",
                newName: "Descripcion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Prioridades",
                newName: "Descripción");
        }
    }
}
