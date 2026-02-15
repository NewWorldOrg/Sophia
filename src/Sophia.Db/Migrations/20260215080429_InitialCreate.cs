using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Sophia.Db.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admin_user",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    emai = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true, comment: "メールアドレス"),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, comment: "名前"),
                    role = table.Column<int>(type: "integer", maxLength: 255, nullable: false, comment: "ロール"),
                    status = table.Column<int>(type: "integer", maxLength: 255, nullable: false, comment: "ステータス"),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "作成日時"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "更新日時")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_admin_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_definitive_register_token",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    token = table.Column<string>(type: "text", nullable: false, comment: "トークン"),
                    is_verified = table.Column<bool>(type: "boolean", nullable: false),
                    expired_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "有効期限"),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "作成日時"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "更新日時")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_definitive_register_token", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    emai = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true, comment: "メールアドレス"),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, comment: "名前"),
                    icon_url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, comment: "アイコンURL"),
                    status = table.Column<int>(type: "integer", maxLength: 255, nullable: false, comment: "ステータス"),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "作成日時"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "更新日時")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_user_definitive_register_token_user_id",
                table: "user_definitive_register_token",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_emai",
                table: "users",
                column: "emai",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admin_user");

            migrationBuilder.DropTable(
                name: "user_definitive_register_token");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
