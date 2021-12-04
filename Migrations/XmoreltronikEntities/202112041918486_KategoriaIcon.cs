namespace MVCSBD_Sklep.Migrations.XmoreltronikEntities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KategoriaIcon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kategorias", "IconClassName", c => c.String(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kategorias", "IconClassName");
        }
    }
}
