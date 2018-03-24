namespace Model.Migrations
{
    using Model;
    using System;
    using System.Data.Entity.Migrations;
    using TeduShop.Model;
    using TeduShop.Model.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<KShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(KShopDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            //add visitor
            //context.VisitorStatistics.AddOrUpdate(a => a.ID,
            //    new VisitorStatistic() { VisitedDate = DateTime.Parse("22/3/2018"), IPAddress = "Nam Định" },
            //   new VisitorStatistic() { VisitedDate = DateTime.Parse("23/3/2018"), IPAddress = "Bình Định" }
            //);
            //add user
            //context.Users.AddOrUpdate(a=>a.MaTV,new User() { });
        }
    }
}