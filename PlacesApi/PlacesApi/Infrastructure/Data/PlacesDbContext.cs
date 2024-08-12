using Microsoft.EntityFrameworkCore;
using PlacesApi.Domain.Entities;

public class PlacesDbContext : DbContext
{
    public PlacesDbContext(DbContextOptions<PlacesDbContext> options) : base(options) { }

    public DbSet<Place> Places { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Place>()
            .HasKey(p => p.Id); // Especifica que Id es la clave primaria

        modelBuilder.Entity<Place>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd(); // Asegura que Id sea autoincremental

        modelBuilder.Entity<Place>()
            .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100); // Configura el campo Name como obligatorio y limita su longitud

        modelBuilder.Entity<Place>()
            .Property(p => p.Capital)
            .HasMaxLength(100); // Limita la longitud del campo Capital

        modelBuilder.Entity<Place>()
            .Property(p => p.Image)
            .HasMaxLength(500); // Limita la longitud del campo Image

        modelBuilder.Entity<Place>()
            .Property(p => p.Description)
            .HasMaxLength(1000); // Limita la longitud del campo Description

        // Opcionalmente, puedes agregar un índice único en el campo Name si es necesario
        // modelBuilder.Entity<Place>()
        //     .HasIndex(p => p.Name)
        //     .IsUnique();
    }

}