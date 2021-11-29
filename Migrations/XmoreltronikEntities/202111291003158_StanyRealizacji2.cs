namespace MVCSBD_Sklep.Migrations.XmoreltronikEntities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StanyRealizacji2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Zamówienie", "DeliveryStateId", c => c.Int(nullable: false, defaultValue: 1));
            CreateIndex("dbo.Zamówienie", "DeliveryStateId");
            AddForeignKey("dbo.Zamówienie", "DeliveryStateId", "dbo.DeliveryStates", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Zamówienie", "DeliveryStateId", "dbo.DeliveryStates");
            DropIndex("dbo.Zamówienie", new[] { "DeliveryStateId" });
            DropColumn("dbo.Zamówienie", "DeliveryStateId");
        }
    }
}
