namespace MovieRentalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNumberAvailbalePropertyInMoviesClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberAvailable", c => c.Short(nullable: false));
            
            Sql("UPDATE Movies SET NumberAvailable = NumberInStock");
            //for setting the movie availibility according to the numbers in stock
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberAvailable");
        }
    }
}
