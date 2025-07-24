// using Microsoft.EntityFrameworkCore; utilisation pour mySql 
// using Microsoft.EntityFrameworkCore.Design;  
// using Microsoft.Extensions.Configuration; 
// using System;
// using System.IO;
// using Solution.Data;
//
// namespace Solution.Data
// {
//     public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ContextDataBase>
//     {
//         public ContextDataBase CreateDbContext(string[] args)
//         {
//             // Chargement configuration (tu peux aussi charger .env ici si tu préfères)
//             IConfigurationRoot configuration = new ConfigurationBuilder()
//                 .SetBasePath(Directory.GetCurrentDirectory())
//                 .AddJsonFile("appsettings.json", optional: true)
//                 .Build();
//
//             // Exemple : récupérer la chaîne de connexion dans appsettings.json ou construire ici
//             var connectionString = configuration.GetConnectionString("DefaultConnection") 
//                                    ?? $"server=217.145.72.16;port=3307;database=db_project;uid=root;pwd=HelloWorld";
//
//             var optionsBuilder = new DbContextOptionsBuilder<ContextDataBase>();
//             optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 36)));
//
//             return new ContextDataBase(optionsBuilder.Options);
//         }
//     }
// }