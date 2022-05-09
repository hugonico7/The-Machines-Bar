using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRest.Migrations
{
    public partial class initial_create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(50)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "mesa",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(50)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    estado = table.Column<string>(type: "enum('Libre','Reservada','Ocupada')", nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mesa", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(50)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre_Cliente = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefono = table.Column<int>(type: "int(50)", nullable: false),
                    cantidad_personas = table.Column<int>(type: "int(50)", nullable: false),
                    hora_fecha = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(50)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    apellidos = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NSS = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id);
                    table.UniqueConstraint("AK_Usuario_username", x => x.username);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(50)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    precio = table.Column<decimal>(type: "decimal(2,2)", precision: 2, scale: 2, nullable: false),
                    id_cat = table.Column<int>(type: "int(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.id);
                    table.ForeignKey(
                        name: "FK_Producto_Categoria_id_cat",
                        column: x => x.id_cat,
                        principalTable: "Categoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(50)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    precio_total = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    estado = table.Column<string>(type: "enum('Pagado','Pendiente')", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_mesa = table.Column<int>(type: "int(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pedido_mesa_id_mesa",
                        column: x => x.id_mesa,
                        principalTable: "mesa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "MesaReserva",
                columns: table => new
                {
                    IdMesa = table.Column<int>(type: "int(50)", nullable: false),
                    IdReserva = table.Column<int>(type: "int(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MesaReserva", x => new { x.IdMesa, x.IdReserva });
                    table.ForeignKey(
                        name: "FK_MesaReserva_mesa_IdMesa",
                        column: x => x.IdMesa,
                        principalTable: "mesa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MesaReserva_Reserva_IdReserva",
                        column: x => x.IdReserva,
                        principalTable: "Reserva",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "Camarero",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camarero", x => x.id);
                    table.ForeignKey(
                        name: "FK_Camarero_Usuario_id",
                        column: x => x.id,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "Cocinero",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cocinero", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cocinero_Usuario_id",
                        column: x => x.id,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "Gerente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gerente", x => x.id);
                    table.ForeignKey(
                        name: "FK_Gerente_Usuario_id",
                        column: x => x.id,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "Comanda",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(50)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_camarero = table.Column<int>(type: "int(50)", nullable: false),
                    id_cocinero = table.Column<int>(type: "int(50)", nullable: true),
                    id_producto = table.Column<int>(type: "int(50)", nullable: false),
                    id_pedido = table.Column<int>(type: "int(50)", nullable: false),
                    descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    estado = table.Column<string>(type: "enum('Pendiente','En Preparación','Preparado','Entregado')", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comanda", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comanda_Camarero_id_camarero",
                        column: x => x.id_camarero,
                        principalTable: "Camarero",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comanda_Cocinero_id_cocinero",
                        column: x => x.id_cocinero,
                        principalTable: "Cocinero",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Comanda_Pedido_id_pedido",
                        column: x => x.id_pedido,
                        principalTable: "Pedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comanda_Producto_id_producto",
                        column: x => x.id_producto,
                        principalTable: "Producto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateIndex(
                name: "fk_camarerocomanda",
                table: "Comanda",
                column: "id_camarero");

            migrationBuilder.CreateIndex(
                name: "fk_cocinerocomanda",
                table: "Comanda",
                column: "id_cocinero");

            migrationBuilder.CreateIndex(
                name: "fk_pedidocomanda",
                table: "Comanda",
                column: "id_pedido");

            migrationBuilder.CreateIndex(
                name: "fk_productocomanda",
                table: "Comanda",
                column: "id_producto");

            migrationBuilder.CreateIndex(
                name: "IX_MesaReserva_IdReserva",
                table: "MesaReserva",
                column: "IdReserva");

            migrationBuilder.CreateIndex(
                name: "fk_idmesa",
                table: "Pedido",
                column: "id_mesa");

            migrationBuilder.CreateIndex(
                name: "fk_catProd",
                table: "Producto",
                column: "id_cat");

            migrationBuilder.CreateIndex(
                name: "username",
                table: "Usuario",
                column: "username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comanda");

            migrationBuilder.DropTable(
                name: "Gerente");

            migrationBuilder.DropTable(
                name: "MesaReserva");

            migrationBuilder.DropTable(
                name: "Camarero");

            migrationBuilder.DropTable(
                name: "Cocinero");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "mesa");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
