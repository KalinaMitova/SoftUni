using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<PatientMedicament> PatientMedicament { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Patient
            builder.Entity<Patient>()
                .HasKey(p => p.PatientId);

            builder.Entity<Patient>()
                .Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsUnicode(true);

            builder.Entity<Patient>()
                .Property(p => p.LastName)
                .HasMaxLength(50)
                .IsUnicode(true);

            builder.Entity<Patient>()
                .Property(p => p.Address)
                .HasMaxLength(250)
                .IsUnicode(true);

            builder.Entity<Patient>()
                .Property(p => p.Email)
                .HasMaxLength(80)
                .IsUnicode(false);

            builder.Entity<Patient>()
                .HasMany(p => p.Diagnoses)
                .WithOne(d => d.Patient)
                .HasForeignKey(d => d.PatientId);

            builder.Entity<Patient>()
                .HasMany(p => p.Visitations)
                .WithOne(v => v.Patient)
                .HasForeignKey(v => v.PatientId);

            //Visitation
            builder.Entity<Visitation>()
                .HasKey(v => v.VisitationId);

            builder.Entity<Visitation>()
                .Property(v => v.Comments)
                .HasMaxLength(250)
                .IsUnicode(true);

            //Diagnose
            builder.Entity<Diagnose>()
                .HasKey(d => d.DiagnoseId);

            builder.Entity<Diagnose>()
                .Property(d => d.Name)
                .HasMaxLength(50)
                .IsUnicode(true);

            builder.Entity<Diagnose>()
                .Property(d => d.Comments)
                .HasMaxLength(250)
                .IsUnicode(true);

            //Medicament
            builder.Entity<Medicament>()
                .HasKey(m => m.MedicamentId);

            builder.Entity<Medicament>()
                .Property(m => m.Name)
                .HasMaxLength(50)
                .IsUnicode(true);

            //PatientMedicament
            builder.Entity<PatientMedicament>()
                .HasKey(pm => new { pm.PatientId, pm.MedicamentId });

            builder.Entity<PatientMedicament>()
                .HasOne(pm => pm.Patient)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(pt => pt.PatientId);

            builder.Entity<PatientMedicament>()
                .HasOne(pm => pm.Medicament)
                .WithMany(m => m.Prescriptions)
                .HasForeignKey(pm => pm.MedicamentId);

            //Doctor
            builder.Entity<Doctor>(
                doctor =>
                {
                    doctor.HasKey(p => p.DoctorId);
                    doctor.Property(p => p.Name).HasMaxLength(100).IsUnicode(true);
                    doctor.Property(p => p.Specialty).HasMaxLength(100).IsUnicode(true);
                    doctor.HasMany(d => d.Visitations).WithOne(v => v.Doctor).HasForeignKey(v => v.DoctorId);
                }
            );
        }
    }
}
