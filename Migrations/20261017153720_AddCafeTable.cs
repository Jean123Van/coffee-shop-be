using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace coffee_note_be.Migrations
{
    /// <inheritdoc />
    public partial class AddCafeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cafes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CafeName = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    AboutUs = table.Column<string>(type: "text", nullable: false),
                    UserCreatorId = table.Column<int>(type: "integer", nullable: false),
                    IsOpenMonday = table.Column<bool>(type: "boolean", nullable: false),
                    MondayStart = table.Column<string>(type: "text", nullable: false),
                    MondayEnd = table.Column<string>(type: "text", nullable: false),
                    IsOpenTuesday = table.Column<bool>(type: "boolean", nullable: false),
                    TuesdayStart = table.Column<string>(type: "text", nullable: false),
                    TuesdayEnd = table.Column<string>(type: "text", nullable: false),
                    IsOpenWednesday = table.Column<bool>(type: "boolean", nullable: false),
                    WednesdayStart = table.Column<string>(type: "text", nullable: false),
                    WednesdayEnd = table.Column<string>(type: "text", nullable: false),
                    IsOpenThursday = table.Column<bool>(type: "boolean", nullable: false),
                    ThursdayStart = table.Column<string>(type: "text", nullable: false),
                    ThursdayEnd = table.Column<string>(type: "text", nullable: false),
                    IsOpenFriday = table.Column<bool>(type: "boolean", nullable: false),
                    FridayStart = table.Column<string>(type: "text", nullable: false),
                    FridayEnd = table.Column<string>(type: "text", nullable: false),
                    IsOpenSaturday = table.Column<bool>(type: "boolean", nullable: false),
                    SaturdayStart = table.Column<string>(type: "text", nullable: false),
                    SaturdayEnd = table.Column<string>(type: "text", nullable: false),
                    IsOpenSunday = table.Column<bool>(type: "boolean", nullable: false),
                    SundayStart = table.Column<string>(type: "text", nullable: false),
                    SundayEnd = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cafes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cafes_Users_UserCreatorId",
                        column: x => x.UserCreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cafes_UserCreatorId",
                table: "Cafes",
                column: "UserCreatorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cafes");
        }
    }
}
