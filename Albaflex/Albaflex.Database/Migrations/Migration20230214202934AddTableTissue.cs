using FluentMigrator;

namespace Albaflex.Database.Migrations
{
    [Migration(20230214202934, "Added table tissue")]
    public class Migration20230214202934AddTableTissue : Migration
    {
        public override void Up()
        {
            Create.Table("tissue")
                .WithColumn("code").AsInt32().Unique().NotNullable().PrimaryKey()
                .WithColumn("name").AsString().NotNullable()
                .WithColumn("value").AsDouble().NotNullable()
                .WithColumn("created_at").AsDateTime().NotNullable()
                .WithColumn("updated_at").AsDateTime().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("tissue");
        }
    }
}
