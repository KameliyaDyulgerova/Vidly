namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'42f1fadd-9604-4968-a5f8-1f32ecefb630', N'admin@vidly.com', 0, N'APP8k5OpbarBPxssBOu/47ALuAUyw1U9zJRHc1HNycoT4gr6+BLyvKzUNdK9yulPIg==', N'e5f1c2d0-132e-402a-a71c-1a22d91aa14e', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b148d667-669b-42fe-b285-63aec97d5b12', N'guest@vidly.com', 0, N'AJt5hb76Vnria92IVWfox1vfuyjgbfHitoUA6DRdirwy0jZkYBd41dpc5G/eQcGHgg==', N'5fb4c739-bac7-40ea-be1e-a49e07909cf5', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9a502658-a518-4eef-a010-22713511ccfb', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'42f1fadd-9604-4968-a5f8-1f32ecefb630', N'9a502658-a518-4eef-a010-22713511ccfb')

");
        }
        
        public override void Down()
        {
        }
    }
}
