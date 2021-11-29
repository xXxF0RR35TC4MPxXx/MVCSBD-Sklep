namespace MVCSBD_Sklep.Migrations.XmoreltronikEntities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkout1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeliveryTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DiscountCodes",
                c => new
                    {
                        DiscountCodeId = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Discount = c.Int(nullable: false),
                        ValidUntil = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DiscountCodeId);
            
            AddColumn("dbo.Zamówienie", "deliveryTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Zamówienie", "paymentTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Zamówienie", "deliveryTypeId");
            CreateIndex("dbo.Zamówienie", "paymentTypeId");
            AddForeignKey("dbo.Zamówienie", "deliveryTypeId", "dbo.DeliveryTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Zamówienie", "paymentTypeId", "dbo.PaymentTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Zamówienie", "paymentTypeId", "dbo.PaymentTypes");
            DropForeignKey("dbo.Zamówienie", "deliveryTypeId", "dbo.DeliveryTypes");
            DropIndex("dbo.Zamówienie", new[] { "paymentTypeId" });
            DropIndex("dbo.Zamówienie", new[] { "deliveryTypeId" });
            DropColumn("dbo.Zamówienie", "paymentTypeId");
            DropColumn("dbo.Zamówienie", "deliveryTypeId");
            DropTable("dbo.DiscountCodes");
            DropTable("dbo.PaymentTypes");
            DropTable("dbo.DeliveryTypes");
        }
    }
}
