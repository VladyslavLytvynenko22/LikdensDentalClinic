using LikdensDentalClinic.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LikdensDentalClinic.Data
{
    public class LikdensDentalClinicDbContext : DbContext
    {
        public LikdensDentalClinicDbContext()
        { }

        public LikdensDentalClinicDbContext(DbContextOptions<LikdensDentalClinicDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.SetNull);
            });
        }
    }
}