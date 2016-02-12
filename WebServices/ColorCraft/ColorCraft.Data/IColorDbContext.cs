namespace ColorCraft.Data
{
    using ColorCraft.Models;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IColorDbContext
    {
        IDbSet<Color> Colors { get; set; }

        IDbSet<Painting> Paintings { get; set; }

        void SaveChanges();

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
