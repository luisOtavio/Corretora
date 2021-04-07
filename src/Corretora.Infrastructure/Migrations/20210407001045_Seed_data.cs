using Microsoft.EntityFrameworkCore.Migrations;

namespace Corretora.Infrastructure.Migrations
{
    public partial class Seed_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
                INSERT INTO [dbo].[User] VALUES ('B63E8E54-5090-4449-A3B3-B3ACA510E6DD', 'José da Silva', '92414263067');
                INSERT INTO [dbo].[User] VALUES ('BC57D5E9-3226-4D96-9A1B-24158EA232C9', 'Maria de Paula', '60849126053');

                INSERT INTO [dbo].[Account] VALUES (NEWID(), '300123', 0, 'B63E8E54-5090-4449-A3B3-B3ACA510E6DD');
                INSERT INTO [dbo].[Account] VALUES (NEWID(), '204125', 0, 'B63E8E54-5090-4449-A3B3-B3ACA510E6DD');";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
