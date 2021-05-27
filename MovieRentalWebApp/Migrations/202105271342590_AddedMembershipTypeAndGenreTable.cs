namespace MovieRentalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMembershipTypeAndGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO[dbo].[MembershipTypes] ([Id], [SignUpFee], [DurationInMonth], [DiscountRate], [Name]) VALUES(1, 0, 0, 0, N'Pay As You Go')");
            Sql("INSERT INTO[dbo].[MembershipTypes] ([Id], [SignUpFee], [DurationInMonth], [DiscountRate], [Name]) VALUES(2, 30, 1, 10, N'Monthly')");
            Sql("INSERT INTO[dbo].[MembershipTypes] ([Id], [SignUpFee], [DurationInMonth], [DiscountRate], [Name]) VALUES(3, 90, 3, 15, N'Quarterly 3 Month')");
            Sql("INSERT INTO[dbo].[MembershipTypes] ([Id], [SignUpFee], [DurationInMonth], [DiscountRate], [Name]) VALUES(4, 300, 12, 20, N'Yearly')");

            Sql("INSERT INTO[dbo].[Genres] ([Name]) VALUES(N'Action')");
            Sql("INSERT INTO[dbo].[Genres] ([Name]) VALUES(N'Thriller')");
            Sql("INSERT INTO[dbo].[Genres] ([Name]) VALUES(N'Family')");
            Sql("INSERT INTO[dbo].[Genres] ([Name]) VALUES(N'Romance')");
            Sql("INSERT INTO[dbo].[Genres] ([Name]) VALUES(N'Comedy')");
            Sql("INSERT INTO[dbo].[Genres] ([Name]) VALUES(N'Horror')");
            Sql("INSERT INTO[dbo].[Genres] ([Name]) VALUES(N'Sci Fi')");
            Sql("INSERT INTO[dbo].[Genres] ([Name]) VALUES(N'Animation')");
            Sql("INSERT INTO[dbo].[Genres] ([Name]) VALUES(N'Drama')");
            Sql("INSERT INTO[dbo].[Genres] ([Name]) VALUES(N'Crime')");
            Sql("INSERT INTO[dbo].[Genres] ([Name]) VALUES(N'Fantasy')");
            Sql("INSERT INTO[dbo].[Genres] ([Name]) VALUES(N'Mystery')");
            Sql("INSERT INTO[dbo].[Genres] ([Name]) VALUES(N'Other Genre')");
        }
        
        public override void Down()
        {
        }
    }
}
