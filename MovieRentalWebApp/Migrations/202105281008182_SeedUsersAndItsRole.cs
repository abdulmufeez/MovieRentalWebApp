namespace MovieRentalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsersAndItsRole : DbMigration
    {
        public override void Up()
        {
            Sql(@"

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7939c77e-ffc3-49b8-80bd-2c8b2df39901', N'admin@movierentalstore.com', 0, N'AKknvQpmvEiEmqcNNg4hvpkeWoG7mrLTRj7naFyw69Sp70F7y9GHN6p19jmWozdgkw==', N'42763bd1-523e-4277-abf1-a115f8d9ccca', NULL, 0, 0, NULL, 1, 0, N'admin@movierentalstore.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9fad238f-640c-47a2-9728-add48d2ebe95', N'guest@movierentalstore.com', 0, N'AMYB58f4vK7pmGSHxfj9DOOGb34NTqlueWV5C5VJOa6+WSbTj0vw/1exRS3iXaBrag==', N'e742f23f-e7a8-444e-85bd-d64388995ffa', NULL, 0, 0, NULL, 1, 0, N'guest@movierentalstore.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b5401c5e-29eb-4a2e-a0e6-445d0fc88426', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7939c77e-ffc3-49b8-80bd-2c8b2df39901', N'b5401c5e-29eb-4a2e-a0e6-445d0fc88426')


");
        }
        
        public override void Down()
        {
        }
    }
}
