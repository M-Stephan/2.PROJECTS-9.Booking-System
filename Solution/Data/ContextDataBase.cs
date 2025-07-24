using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.Extensions.Configuration;
using System.IO;
using DotNetEnv;
using Solution.Models;
using Solution.Data;


namespace Solution.Data;

//DbContext formule de base integree a entity
public class ContextDataBase : DbContext
{
    public ContextDataBase(DbContextOptions<ContextDataBase> options) : base(options) { }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<Offer> Offers { get; set; }
    
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => pour mySql
    // {
    //     Env.Load();
    //     var server = Environment.GetEnvironmentVariable("SERVER_IP");
    //     var database = Environment.GetEnvironmentVariable("DB_NAME"); 
    //     var user = Environment.GetEnvironmentVariable("USER_ID");
    //     var password = Environment.GetEnvironmentVariable("DB_PASSWORD");
    //     
    //     Console.WriteLine($"voici la connexion de la db : {server},{database},{user},{password}");
    //     if (string.IsNullOrEmpty(server) || string.IsNullOrEmpty(database) || string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
    //     {
    //         throw new Exception("Variables d'environnement non chargées correctement !");
    //     }
    //     
    //     if (!optionsBuilder.IsConfigured)
    //     {
    //         var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") 
    //                                ?? $"server={server};port=3307;database={database};uid={user};pwd={password};";
    //     
    //         optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 36)));
    //     }
    // }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);
            
            entity.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(48);
            
            entity.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(48);
            
            entity.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(255);
            
            entity.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(128);

            entity.HasIndex(u => u.Email).IsUnique();

            entity.Property(u => u.PhoneNumber)
                .IsRequired()
                .HasMaxLength(128);
            
            entity.Property(u => u.DateCreation)
                .HasColumnType("timestamp")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            
            entity.HasOne<Role>()
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(r => r.Id);

            entity.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(128);
            
            entity.HasIndex(r => r.Name).IsUnique();

            entity.Property(r => r.Level)
                .IsRequired();

        });

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.HasKey(o => o.Id);

            entity.Property(o => o.Title)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(o => o.Description)
                .IsRequired()
                .HasMaxLength(2000);

            entity.Property(o => o.Location)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(o => o.Type)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(o => o.BedNumber)
                .IsRequired();

            entity.Property(o => o.BathNumber)
                .IsRequired();

            entity.Property(o => o.NumberOfRooms)
                .IsRequired();

            entity.Property(o => o.Price)
                .IsRequired()
                .HasPrecision(10, 2);

            entity.Property(o => o.Image)
                .HasMaxLength(500);

            // Relation avec User 
            entity.HasOne<User>()
                .WithMany() // Un utilisateur peut avoir plusieurs offres
                .HasForeignKey(o => o.IdUser)
                .OnDelete(DeleteBehavior.Cascade);
            
        });
        
        base.OnModelCreating(modelBuilder);
    }
    }


