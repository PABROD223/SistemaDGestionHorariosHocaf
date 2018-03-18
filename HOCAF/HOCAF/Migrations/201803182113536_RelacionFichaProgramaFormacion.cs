namespace HOCAF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelacionFichaProgramaFormacion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ficha", "idPrograma", c => c.Int(nullable: false));
            CreateIndex("dbo.Ficha", "idPrograma");
            AddForeignKey("dbo.Ficha", "idPrograma", "dbo.ProgramaDeFormacion", "idPrograma", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ficha", "idPrograma", "dbo.ProgramaDeFormacion");
            DropIndex("dbo.Ficha", new[] { "idPrograma" });
            DropColumn("dbo.Ficha", "idPrograma");
        }
    }
}
