using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class MakeAddressOptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_consumer_address_AddressId",
                table: "consumer");

            migrationBuilder.AlterColumn<string>(
                name: "AddressId",
                table: "consumer",
                type: "varchar(36)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(36)");

            migrationBuilder.AddForeignKey(
                name: "FK_consumer_address_AddressId",
                table: "consumer",
                column: "AddressId",
                principalTable: "address",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_consumer_address_AddressId",
                table: "consumer");

            migrationBuilder.AlterColumn<string>(
                name: "AddressId",
                table: "consumer",
                type: "varchar(36)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(36)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_consumer_address_AddressId",
                table: "consumer",
                column: "AddressId",
                principalTable: "address",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
