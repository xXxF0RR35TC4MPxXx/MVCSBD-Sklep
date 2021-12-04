namespace MVCSBD_Sklep.Migrations.XmoreltronikEntities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "OrderCount", c => c.Int(nullable: false, defaultValue: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "OrderCount");
        }
    }
}
