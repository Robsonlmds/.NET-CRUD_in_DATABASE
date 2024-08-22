using Crud_Carros.Models.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Crud_Carros.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base (options) 
        {
        }
        public DbSet<Staff> Staffs { get; set; }

        public DbSet<ModelOfCar> ModelsOfCar { get; set; }

        public virtual DbSet<Car> Cars { get; set; }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientOfStaff> ClientOfStaffs { get; set; }
        
        protected override void OnModelCreating(ModelBuilder Builder)
        {
            Builder.Entity<Staff>()
           .HasMany(p => p.Clients)
           .WithMany(p => p.Staffs)
           .UsingEntity<ClientOfStaff>(
               j => j
                   .HasOne(pt => pt.Client)
                   .WithMany(p => p.ClientOfStaffs)
                   .HasForeignKey(pt => pt.ClientId),
               j => j
                   .HasOne(pt => pt.Staff)
                   .WithMany(p => p.ClientOfStaffs)
                   .HasForeignKey(pt => pt.StaffId)
               );
        }
    }
}
