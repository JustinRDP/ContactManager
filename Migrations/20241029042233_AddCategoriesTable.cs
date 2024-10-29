using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment_2.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoriesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Create the Categories table
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            // Add initial categories (optional)
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Name" },
                values: new object[,]
                {
            { "Work" },
            { "Personal" },
            { "Family" }
                });

            // Add the CategoryId column to the Contacts table
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 1); // Assuming you want to set a default category

            // Add the foreign key constraint
            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Categories_CategoryId",
                table: "Contacts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the foreign key constraint first
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Categories_CategoryId",
                table: "Contacts");

            // Drop the CategoryId column
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Contacts");

            // Drop the Categories table
            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
