using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Interviews.Migrations
{
    /// <inheritdoc />
    public partial class DbAppMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    c_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("categories_pkey", x => x.c_id);
                });

            migrationBuilder.CreateTable(
                name: "levels",
                columns: table => new
                {
                    l_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    l_description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("levels_pkey", x => x.l_id);
                });

            migrationBuilder.CreateTable(
                name: "positions",
                columns: table => new
                {
                    p_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    p_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("positions_pkey", x => x.p_id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    passwordhash = table.Column<byte[]>(type: "bytea", nullable: false),
                    passwordsalt = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    comp_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    comp_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    comp_position_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("companies_pkey", x => x.comp_id);
                    table.ForeignKey(
                        name: "comp_pos_fk",
                        column: x => x.comp_position_id,
                        principalTable: "positions",
                        principalColumn: "p_id");
                });

            migrationBuilder.CreateTable(
                name: "resources",
                columns: table => new
                {
                    r_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    r_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    r_url = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    r_category_id = table.Column<int>(type: "integer", nullable: false),
                    r_company_id = table.Column<int>(type: "integer", nullable: false),
                    r_level_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("resources_pkey", x => x.r_id);
                    table.ForeignKey(
                        name: "r_cat_fk",
                        column: x => x.r_category_id,
                        principalTable: "categories",
                        principalColumn: "c_id");
                    table.ForeignKey(
                        name: "r_comp_fk",
                        column: x => x.r_company_id,
                        principalTable: "companies",
                        principalColumn: "comp_id");
                    table.ForeignKey(
                        name: "r_lvl_fk",
                        column: x => x.r_level_id,
                        principalTable: "levels",
                        principalColumn: "l_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_companies_comp_position_id",
                table: "companies",
                column: "comp_position_id");

            migrationBuilder.CreateIndex(
                name: "IX_resources_r_category_id",
                table: "resources",
                column: "r_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_resources_r_company_id",
                table: "resources",
                column: "r_company_id");

            migrationBuilder.CreateIndex(
                name: "IX_resources_r_level_id",
                table: "resources",
                column: "r_level_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "resources");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "companies");

            migrationBuilder.DropTable(
                name: "levels");

            migrationBuilder.DropTable(
                name: "positions");
        }
    }
}
