namespace MovieRentalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNumberInStockInMovieModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberInStock", c => c.Short(nullable: false));            
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberInStock");
        }
    }
}
