namespace MovieDbAppByM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieDB_v10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actor",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        ProfileImage = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovieActor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        ActorId = c.Int(nullable: false),
                        CastOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Actor", t => t.ActorId, cascadeDelete: true)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.ActorId);
            
            CreateTable(
                "dbo.Movie",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ImdbId = c.String(nullable: false, maxLength: 200),
                        ImdbVote = c.Single(nullable: false),
                        OriginalTitle = c.String(nullable: false, maxLength: 200),
                        Title = c.String(nullable: false, maxLength: 200),
                        Tagline = c.String(nullable: false, maxLength: 1000),
                        Overview = c.String(nullable: false, maxLength: 4000),
                        Genres = c.String(nullable: false, maxLength: 200),
                        Runtime = c.Int(nullable: false),
                        ReleaseDate = c.String(nullable: false),
                        BackdropImage = c.Binary(nullable: false),
                        PosterImage = c.Binary(nullable: false),
                        Homepage = c.String(maxLength: 200),
                        HasWatched = c.Boolean(nullable: false),
                        PersonalComments = c.String(maxLength: 4000),
                        FreeText1 = c.String(maxLength: 4000),
                        FreeText2 = c.String(maxLength: 4000),
                        FreeText3 = c.String(maxLength: 4000),
                        FreeText4 = c.String(maxLength: 4000),
                        FreeText5 = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieActor", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.MovieActor", "ActorId", "dbo.Actor");
            DropIndex("dbo.MovieActor", new[] { "ActorId" });
            DropIndex("dbo.MovieActor", new[] { "MovieId" });
            DropTable("dbo.Movie");
            DropTable("dbo.MovieActor");
            DropTable("dbo.Actor");
        }
    }
}
