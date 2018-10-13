namespace MovieDbAppByM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieDbv10 : DbMigration
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
                "dbo.Movie",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ImdbId = c.String(nullable: false, maxLength: 200),
                        ImdbVote = c.Single(nullable: false),
                        Popularity = c.Int(nullable: false),
                        OriginalTitle = c.String(nullable: false, maxLength: 200),
                        Title = c.String(nullable: false, maxLength: 200),
                        Tagline = c.String(maxLength: 1000),
                        Overview = c.String(maxLength: 4000),
                        Genres = c.String(maxLength: 200),
                        Runtime = c.Int(nullable: false),
                        ReleaseDate = c.String(),
                        BackdropImage = c.Binary(),
                        PosterImage = c.Binary(),
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
            
            CreateTable(
                "dbo.Director",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        ProfileImage = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ImdbMovie",
                c => new
                    {
                        ImdbId = c.String(nullable: false, maxLength: 128),
                        Status = c.String(nullable: false, maxLength: 10),
                        StatusText = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.ImdbId);
            
            CreateTable(
                "dbo.MovieActors",
                c => new
                    {
                        Movie_Id = c.Int(nullable: false),
                        Actor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_Id, t.Actor_Id })
                .ForeignKey("dbo.Movie", t => t.Movie_Id, cascadeDelete: true)
                .ForeignKey("dbo.Actor", t => t.Actor_Id, cascadeDelete: true)
                .Index(t => t.Movie_Id)
                .Index(t => t.Actor_Id);
            
            CreateTable(
                "dbo.DirectorMovies",
                c => new
                    {
                        Director_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Director_Id, t.Movie_Id })
                .ForeignKey("dbo.Director", t => t.Director_Id, cascadeDelete: true)
                .ForeignKey("dbo.Movie", t => t.Movie_Id, cascadeDelete: true)
                .Index(t => t.Director_Id)
                .Index(t => t.Movie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DirectorMovies", "Movie_Id", "dbo.Movie");
            DropForeignKey("dbo.DirectorMovies", "Director_Id", "dbo.Director");
            DropForeignKey("dbo.MovieActors", "Actor_Id", "dbo.Actor");
            DropForeignKey("dbo.MovieActors", "Movie_Id", "dbo.Movie");
            DropIndex("dbo.DirectorMovies", new[] { "Movie_Id" });
            DropIndex("dbo.DirectorMovies", new[] { "Director_Id" });
            DropIndex("dbo.MovieActors", new[] { "Actor_Id" });
            DropIndex("dbo.MovieActors", new[] { "Movie_Id" });
            DropTable("dbo.DirectorMovies");
            DropTable("dbo.MovieActors");
            DropTable("dbo.ImdbMovie");
            DropTable("dbo.Director");
            DropTable("dbo.Movie");
            DropTable("dbo.Actor");
        }
    }
}
