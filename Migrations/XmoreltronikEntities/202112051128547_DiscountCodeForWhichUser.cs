namespace MVCSBD_Sklep.Migrations.XmoreltronikEntities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DiscountCodeForWhichUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DiscountCodes", "DlaKtóregoUżytkownika", c => c.String(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DiscountCodes", "DlaKtóregoUżytkownika");
        }
    }
}
