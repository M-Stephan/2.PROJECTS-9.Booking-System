namespace Solution.Data;

//DbContext formule de base integree a entity
public class ContextDataBase(DbContextOptions<ContextDataBase> options) : DbContext(options)
{
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<Offer> Offers { get; set; }


    //Cette méthode configure la structure de votre base de données via l'API Fluent.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.Haskey(u => u.Id);
        });
    }
}