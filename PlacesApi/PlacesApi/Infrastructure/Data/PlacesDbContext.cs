using Microsoft.EntityFrameworkCore;
using PlacesApi.Domain.Entities;

public class PlacesDbContext : DbContext
{
  public PlacesDbContext(DbContextOptions<PlacesDbContext> options) : base(options) { }

  public DbSet<Place> Place { get; set; }
  public DbSet<TouristicPlace> TouristicPlace { get; set; } // Agregar DbSet para TouristicPlace

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

      // Configurar la relación con TouristicPlaces
      entity.HasMany(p => p.touristic_places)
                .WithOne(t => t.Place)
                .HasForeignKey(t => t.place_id)
                .OnDelete(DeleteBehavior.Cascade);
    });

    // Configuración de la entidad TouristicPlace
    modelBuilder.Entity<TouristicPlace>(entity =>
{
  entity.ToTable("touristic_places");
  entity.HasKey(e => e.id);
  entity.Property(e => e.esp_name)
          .IsRequired()
          .HasMaxLength(100);
  entity.Property(e => e.eng_name)
          .IsRequired()
          .HasMaxLength(100);
  entity.Property(e => e.esp_description)
          .IsRequired()
          .HasMaxLength(3000);
  entity.Property(e => e.eng_description)
          .IsRequired()
          .HasMaxLength(3000);
  entity.Property(e => e.image)
          .IsRequired()
          .HasMaxLength(3000);
  entity.HasOne(e => e.Place)
          .WithMany(p => p.touristic_places)
          .HasForeignKey(e => e.place_id)
          .OnDelete(DeleteBehavior.Cascade);
});

    base.OnModelCreating(modelBuilder);
  }
}
