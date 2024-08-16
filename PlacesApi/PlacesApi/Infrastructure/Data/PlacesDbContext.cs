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
                  entity.HasKey(p => p.Id); // Especifica que Id es la clave primaria
                  entity.Property(p => p.Id)
                    .ValueGeneratedOnAdd(); // Asegura que Id sea autoincremental
                  entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(100); // Configura el campo Name como obligatorio y limita su longitud
                  entity.Property(p => p.Capital)
                    .HasMaxLength(100); // Limita la longitud del campo Capital
                  entity.Property(p => p.Image)
                    .HasMaxLength(8000); // Limita la longitud del campo Image
                  entity.Property(p => p.EspDescription)
                    .HasMaxLength(8000); // Limita la longitud del campo EspDescription
                  entity.Property(p => p.EngDescription)
                    .HasMaxLength(8000); // Limita la longitud del campo EngDescription

                  // Configurar la relación con TouristicPlaces
                  entity.HasMany(p => p.TouristicPlaces)
                    .WithOne(t => t.Place)
                    .HasForeignKey(t => t.PlaceId)
                    .OnDelete(DeleteBehavior.Cascade); 
            });

            // Configuración de la entidad TouristicPlace
            modelBuilder.Entity<TouristicPlace>(entity =>
    {
          entity.HasKey(e => e.Id);
          entity.Property(e => e.EspName)
            .IsRequired()
            .HasMaxLength(100);
          entity.Property(e => e.EngName)
            .IsRequired()
            .HasMaxLength(100);
          entity.Property(e => e.EspDescription)
            .IsRequired()
            .HasMaxLength(8000);
          entity.Property(e => e.EngDescription)
            .IsRequired()
            .HasMaxLength(8000);
          entity.Property(e => e.Image)
            .IsRequired()
            .HasMaxLength(8000);
          entity.HasOne(e => e.Place)
            .WithMany(p => p.TouristicPlaces)
            .HasForeignKey(e => e.PlaceId)
            .OnDelete(DeleteBehavior.Cascade); 
    });

            base.OnModelCreating(modelBuilder);
      }
}
