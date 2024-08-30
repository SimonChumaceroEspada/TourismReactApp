using Microsoft.EntityFrameworkCore;
using PlacesApi.Domain.Entities;

public class PlacesDbContext : DbContext
{
  public PlacesDbContext(DbContextOptions<PlacesDbContext> options) : base(options) { }

  public DbSet<Place> Place { get; set; }
  public DbSet<PlacesData> PlacesData { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // Configuración de la entidad Place
    modelBuilder.Entity<Place>(entity =>
    {
      entity.ToTable("places"); // Actualiza el nombre de la tabla
      entity.HasKey(p => p.id);
      entity.Property(p => p.id).ValueGeneratedOnAdd();
      entity.Property(p => p.name).IsRequired().HasMaxLength(100);
      entity.Property(p => p.capital).HasMaxLength(100);
      entity.Property(p => p.image).HasMaxLength(3000);
      entity.Property(p => p.esp_description).HasMaxLength(3000);
      entity.Property(p => p.eng_description).HasMaxLength(3000);
    });

    // Configuración de la entidad PlacesData
    modelBuilder.Entity<PlacesData>(entity =>
    {
      entity.ToTable("places_data");
      entity.HasKey(e => e.id);
      entity.Property(e => e.esp_name).IsRequired().HasMaxLength(100);
      entity.Property(e => e.eng_name).IsRequired().HasMaxLength(100);
      entity.Property(e => e.esp_description).HasMaxLength(3000);
      entity.Property(e => e.eng_description).HasMaxLength(3000);
      entity.Property(e => e.image).HasMaxLength(3000);
      entity.Property(e => e.type).IsRequired().HasMaxLength(50);
      entity.HasOne(e => e.place)
            .WithMany(p => p.places_data)
            .HasForeignKey(e => e.place_id)
            .OnDelete(DeleteBehavior.Cascade);
    });

    base.OnModelCreating(modelBuilder);
  }
}