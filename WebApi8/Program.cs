using Microsoft.EntityFrameworkCore;
using WebApi8.Models;
using System.Text.Json.Serialization;
using WebApi8.Services.Autor;

var builder = WebApplication.CreateBuilder(args);

// Ativa Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddScoped<IAutorInterface, AutorService>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();


record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

// Define AppDbContext if it does not exist
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<AutorModel> Autores { get; set; } = null!;
    public DbSet<LivroModel> Livros { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LivroModel>()
            .HasOne(l => l.Autor)
            .WithMany(a => a.Livros)
            .HasForeignKey(l => l.AutorId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }

}

// Define LivroModel if it does not exist
public class LivroModel
{
    public int Id { get; set; }
    public string? Titulo { get; set; }
    public int AutorId { get; set; }      // FK para Autor
    public AutorModel? Autor { get; set; } // Navegação
}

public class AutorModel
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Sobrenome { get; set; }
    [JsonIgnore]
    public ICollection<LivroModel> Livros { get; set; } = new List<LivroModel>();
}


