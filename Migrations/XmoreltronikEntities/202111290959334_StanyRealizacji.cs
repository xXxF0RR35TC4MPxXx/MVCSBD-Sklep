namespace MVCSBD_Sklep.Migrations.XmoreltronikEntities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StanyRealizacji : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeliveryStates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DeliveryStates");
        }
    }
}
