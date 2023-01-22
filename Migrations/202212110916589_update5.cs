namespace testest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nbrQuestion = c.Int(),
                        titreTest = c.String(),
                        duree = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Resultat_Test",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        note = c.String(),
                        date_affectation = c.String(),
                        date_expiration = c.String(),
                        Candidat_Id = c.String(maxLength: 128),
                        Test_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Candidat_Id)
                .ForeignKey("dbo.Tests", t => t.Test_Id)
                .Index(t => t.Candidat_Id)
                .Index(t => t.Test_Id);
            
            CreateTable(
                "dbo.Test_Question",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question_Id = c.Int(),
                        Test_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.Question_Id)
                .ForeignKey("dbo.Tests", t => t.Test_Id)
                .Index(t => t.Question_Id)
                .Index(t => t.Test_Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        texte = c.String(),
                        noteTotale = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reponses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        texte = c.String(),
                        correcte = c.Binary(),
                        Question_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.Question_Id)
                .Index(t => t.Question_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Test_Question", "Test_Id", "dbo.Tests");
            DropForeignKey("dbo.Test_Question", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.Reponses", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.Resultat_Test", "Test_Id", "dbo.Tests");
            DropForeignKey("dbo.Resultat_Test", "Candidat_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Reponses", new[] { "Question_Id" });
            DropIndex("dbo.Test_Question", new[] { "Test_Id" });
            DropIndex("dbo.Test_Question", new[] { "Question_Id" });
            DropIndex("dbo.Resultat_Test", new[] { "Test_Id" });
            DropIndex("dbo.Resultat_Test", new[] { "Candidat_Id" });
            DropTable("dbo.Reponses");
            DropTable("dbo.Questions");
            DropTable("dbo.Test_Question");
            DropTable("dbo.Resultat_Test");
            DropTable("dbo.Tests");
        }
    }
}
