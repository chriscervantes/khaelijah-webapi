using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class updateAddressAssociation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_consumer_address_AddressId",
                table: "consumer");

            migrationBuilder.DropIndex(
                name: "IX_consumer_AddressId",
                table: "consumer");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "consumer");

            migrationBuilder.AlterColumn<string>(
                name: "province_id",
                table: "address",
                type: "varchar(36)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(36)");

            migrationBuilder.AlterColumn<string>(
                name: "municipal_id",
                table: "address",
                type: "varchar(36)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(36)");

            migrationBuilder.AlterColumn<string>(
                name: "barangay_id",
                table: "address",
                type: "varchar(36)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(36)");

            migrationBuilder.AlterColumn<string>(
                name: "address1",
                table: "address",
                type: "varchar(50)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "ConsumerId",
                table: "address",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_address_ConsumerId",
                table: "address",
                column: "ConsumerId");

            migrationBuilder.AddForeignKey(
                name: "FK_address_consumer_ConsumerId",
                table: "address",
                column: "ConsumerId",
                principalTable: "consumer",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address_consumer_ConsumerId",
                table: "address");

            migrationBuilder.DropIndex(
                name: "IX_address_ConsumerId",
                table: "address");

            migrationBuilder.DropColumn(
                name: "ConsumerId",
                table: "address");

            migrationBuilder.AddColumn<string>(
                name: "AddressId",
                table: "consumer",
                type: "varchar(36)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "province_id",
                table: "address",
                type: "varchar(36)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(36)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "municipal_id",
                table: "address",
                type: "varchar(36)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(36)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "barangay_id",
                table: "address",
                type: "varchar(36)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(36)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "address1",
                table: "address",
                type: "varchar(50)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_consumer_AddressId",
                table: "consumer",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_consumer_address_AddressId",
                table: "consumer",
                column: "AddressId",
                principalTable: "address",
                principalColumn: "id");
        }
    }
}
