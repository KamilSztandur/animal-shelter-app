using AnimalShelter.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Infrastructure.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<ShelterBox> ShelterBoxes { get; set; }
        public DbSet<MedicalProcedure> MedicalProcedures { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>()
                .HasOne(animal => animal.Box)
                .WithOne(box => box.Animal)
                .HasForeignKey<ShelterBox>(box => box.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
