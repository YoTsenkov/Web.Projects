namespace ColorCraft.Data
{
    using ColorCraft.Data.Migrations;
    using ColorCraft.Models;
    using System.Data.Entity;

    public class ColorDbContext : DbContext, IColorDbContext
    {
        public ColorDbContext()
            : base ("ColorCraftConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ColorDbContext, Configuration>());
        }

        public virtual IDbSet<Color> Colors { get; set; }

        public virtual IDbSet<Painting> Paintings { get; set; }


        public void SaveChanges()
        {
            base.SaveChanges();
        }

        public IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
