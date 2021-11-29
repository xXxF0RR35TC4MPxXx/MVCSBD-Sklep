namespace MVCSBD_Sklep.Migrations.XmoreltronikEntities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderEditFix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Zamówienie", "OrderDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Zamówienie", "OrderDate", c => c.DateTime(nullable: false));
        }
    }
}
