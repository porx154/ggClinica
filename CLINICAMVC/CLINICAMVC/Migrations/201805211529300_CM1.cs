namespace CLINICAMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CM1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Medicos", "consultorio_Id", "dbo.Consultorios");
            DropForeignKey("dbo.Medicos", "especialidad_Id", "dbo.Especialidads");
            DropIndex("dbo.Medicos", new[] { "consultorio_Id" });
            DropIndex("dbo.Medicos", new[] { "especialidad_Id" });
            RenameColumn(table: "dbo.Medicos", name: "consultorio_Id", newName: "ConsultorioId");
            RenameColumn(table: "dbo.Medicos", name: "especialidad_Id", newName: "EspecialidadId");
            AlterColumn("dbo.Medicos", "ConsultorioId", c => c.Int(nullable: false));
            AlterColumn("dbo.Medicos", "EspecialidadId", c => c.Int(nullable: false));
            CreateIndex("dbo.Medicos", "EspecialidadId");
            CreateIndex("dbo.Medicos", "ConsultorioId");
            AddForeignKey("dbo.Medicos", "ConsultorioId", "dbo.Consultorios", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Medicos", "EspecialidadId", "dbo.Especialidads", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medicos", "EspecialidadId", "dbo.Especialidads");
            DropForeignKey("dbo.Medicos", "ConsultorioId", "dbo.Consultorios");
            DropIndex("dbo.Medicos", new[] { "ConsultorioId" });
            DropIndex("dbo.Medicos", new[] { "EspecialidadId" });
            AlterColumn("dbo.Medicos", "EspecialidadId", c => c.Int());
            AlterColumn("dbo.Medicos", "ConsultorioId", c => c.Int());
            RenameColumn(table: "dbo.Medicos", name: "EspecialidadId", newName: "especialidad_Id");
            RenameColumn(table: "dbo.Medicos", name: "ConsultorioId", newName: "consultorio_Id");
            CreateIndex("dbo.Medicos", "especialidad_Id");
            CreateIndex("dbo.Medicos", "consultorio_Id");
            AddForeignKey("dbo.Medicos", "especialidad_Id", "dbo.Especialidads", "Id");
            AddForeignKey("dbo.Medicos", "consultorio_Id", "dbo.Consultorios", "Id");
        }
    }
}
