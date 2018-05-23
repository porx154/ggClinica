namespace CLINICAMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dnimedicoconsultorio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Medicos", "DniMedico", c => c.String(nullable: false, maxLength: 8));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Medicos", "DniMedico");
        }
    }
}
