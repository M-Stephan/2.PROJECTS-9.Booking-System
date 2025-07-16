using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Solution.Data;

// using ReserveEase.Data; // Remplace par ton vrai namespace de DbContext

var builder = WebApplication.CreateBuilder(args);

// Charger le .env � la racine du projet
Env.Load();

// Lire les variables d�environnement
var server = Environment.GetEnvironmentVariable("SERVER_IP");
var database = Environment.GetEnvironmentVariable("DB_NAME");
var user = Environment.GetEnvironmentVariable("USER_ID");
var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

// Construire la cha�ne de connexion MySQL
var connectionString = $"server={server};port=3307;database={database};uid={user};pwd={password}";

// Ajouter le contexte EF Core avec la chaîne de connexion complète
builder.Services.AddDbContext<ContextDataBase>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 36))));

// Ajouter les services MVC
builder.Services.AddControllersWithViews();

// Ajouter Swagger (facultatif, tu peux commenter pour le moment)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuration de la pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Middleware
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Swagger UI (optionnel)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Routes MVC classiques
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
