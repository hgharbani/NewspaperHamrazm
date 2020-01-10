using NewsPaperHamrazm.DataLayer.Repositories;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace NewsPaperHamrazm.DataLayer.Context
{
    public class HamrazmContext : DbContext
    {
        public HamrazmContext() : base("HamrazmContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewsRelations>().HasRequired<City>(x => x.City)
                .WithMany(y => y.NewsRelationses)
                .HasForeignKey(x => x.CityId);

            modelBuilder.Entity<NewsRelations>().HasRequired<Category>(x => x.Category)
                .WithMany(y => y.NewsRelationses)
                .HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<NewsRelations>().HasRequired<Source>(x => x.Source)
                .WithMany(y => y.NewsRelationses)
                .HasForeignKey(x => x.SourceId);

            modelBuilder.Entity<NewsRelations>().HasRequired<Category>(x => x.Category)
                .WithMany(y => y.NewsRelationses)
                .HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<NewsRelations>().HasRequired<News>(x => x.news)
                .WithMany(y => y.NewsRelationses)
                .HasForeignKey(x => x.NewsId);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            InitialDb initializer = new InitialDb(modelBuilder);
            Database.SetInitializer(initializer);
        }
        public DbSet<News> Newses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<NewsRelations> NewsRelationses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
