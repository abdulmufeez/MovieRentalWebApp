namespace MovieRentalWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingUsersAndItRoles2 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2348d17d-5e9f-412a-a21f-9c768954efb0', N'abdul_mufeez@outlook.com', 0, N'AAZ9KVneshiK/Oj/wI7jubPSQheHIVHdVNt+kbKcXIbBzrYAJUcjz2fMCR6isGkoZA==', N'4d5bba58-4bc1-461e-891c-f5af887ab4dd', N'+923062727507', 0, 0, NULL, 1, 0, N'Admin')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'89989565-bf4f-4a91-a916-a7157cd6f1ac', N'mufeezmubeen1997@gmail.com', 0, N'AIDdxV0g3O+DOfs2mmhedJAnM7jn77E4Mt9ddeId/sn+XfnknM/urvA05/A7LcBJCg==', N'63fcd22a-a8d3-47cd-b1de-fb4a0672bdc3', N'+923062727507', 0, 0, NULL, 1, 0, N'Staff')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9fad238f-640c-47a2-9728-add48d2ebe95', N'guest@movierentalstore.com', 0, N'AMYB58f4vK7pmGSHxfj9DOOGb34NTqlueWV5C5VJOa6+WSbTj0vw/1exRS3iXaBrag==', N'e742f23f-e7a8-444e-85bd-d64388995ffa', NULL, 0, 0, NULL, 1, 0, N'Guest')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'37f48ada-8952-4bc4-8a9a-6c0305bb45e6', N'CanManageEverything')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a9272d93-26b1-4be4-b92f-bce3baa7122d', N'CanManageCustomerAndRentalOnly')


INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2348d17d-5e9f-412a-a21f-9c768954efb0', N'37f48ada-8952-4bc4-8a9a-6c0305bb45e6')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'89989565-bf4f-4a91-a916-a7157cd6f1ac', N'a9272d93-26b1-4be4-b92f-bce3baa7122d')
");
        }
        
        public override void Down()
        {
        }
    }
}
