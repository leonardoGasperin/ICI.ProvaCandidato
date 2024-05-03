using Microsoft.EntityFrameworkCore.Migrations;

namespace ICI.ProvaCandidato.Negocio.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "Noticias",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "varchar(50)", nullable: false),
                    Texto = table.Column<string>(type: "TEXT", nullable: false),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noticias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Noticias_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "TagNoticias",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NoticiaId = table.Column<int>(type: "INTERGER", nullable: false),
                    TagId = table.Column<int>(type: "INTERGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagNoticias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagNoticias_Noticias_NoticiaId",
                        column: x => x.NoticiaId,
                        principalTable: "Noticias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_Noticias_UsuarioId",
                table: "Noticias",
                column: "UsuarioId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_TagNoticias_NoticiaId",
                table: "TagNoticias",
                column: "NoticiaId"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "TagNoticias");

            migrationBuilder.DropTable(name: "Tags");

            migrationBuilder.DropTable(name: "Noticias");

            migrationBuilder.DropTable(name: "Usuarios");
        }
    }
}
