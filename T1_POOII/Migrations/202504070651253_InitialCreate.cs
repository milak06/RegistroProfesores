namespace T1_POOII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Profesores",
                c => new
                    {
                        DNI = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(nullable: false),
                        Apellidos = c.String(nullable: false),
                        Carrera = c.String(nullable: false, maxLength: 20),
                        Correo = c.String(nullable: false),
                        Edad = c.String(nullable: false),
                        Sueldo = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DNI);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Profesores");
        }
    }
}
