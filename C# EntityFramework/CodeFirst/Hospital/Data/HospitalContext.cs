namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_HospitalDatabase.Data.Models;


    public class HospitalContext : DbContext

    {
        public HospitalContext(DbContextOptions options)
            : base(options)
        {
        }

        public HospitalContext()
        {
        }

        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<PatientMedicament> PatientMedicaments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity
                    .HasKey(k => k.DoctorId);

               entity
                    .Property(p => p.Name)
                    .HasMaxLength(100)
                    .IsUnicode();

                entity
                    .Property(p => p.Specialty)
                    .HasMaxLength(100)
                    .IsUnicode();
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(p => p.PatientId);

                entity.Property(p => p.FirstName)
                      .HasMaxLength(50)
                      .IsRequired()
                      .IsUnicode();

                entity.Property(p => p.LastName)
                      .HasMaxLength(50)
                      .IsRequired()
                      .IsUnicode();

                entity.Property(p => p.Address)
                      .HasMaxLength(250)
                      .IsRequired()
                      .IsUnicode();

                entity.Property(p => p.Email)
                      .HasMaxLength(80)
                      .IsRequired()
                      .IsUnicode(false);

                entity.Property(p => p.HasInsurance);

                entity.HasMany(p => p.Prescriptions)
                      .WithOne(p => p.Patient)
                      .HasForeignKey(p => p.PatientId);

                entity.HasMany(p => p.Diagnoses)
                     .WithOne(p => p.Patient)
                     .HasForeignKey(d => d.DiagnoseId);
                
                entity.HasMany(p => p.Visitations)
                .WithOne(p => p.Patient)
                .HasForeignKey(k => k.VisitationId);

            });

            modelBuilder.Entity<Visitation>(entity =>
            {
                entity.HasKey(p => p.VisitationId);

                entity.Property(p => p.Comments)
                       .HasMaxLength(250)
                       .IsUnicode();

                entity.HasOne(p => p.Patient)
                      .WithMany(v => v.Visitations)
                      .HasForeignKey(p => p.PatientId);
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(m => m.MedicamentId);
                entity.Property(p => p.Name)
                      .HasMaxLength(50)
                      .IsUnicode();
            });

            modelBuilder.Entity<Diagnose>(entity => 
            {
                entity.HasKey(d => d.DiagnoseId);

                entity.Property(d => d.Name)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

                entity.Property(d => d.Comments)
                .HasMaxLength(250)
                .IsUnicode();

                entity.HasOne(d => d.Patient)
                      .WithMany(p => p.Diagnoses)
                      .HasForeignKey(d => d.PatientId);
            });

            modelBuilder.Entity<PatientMedicament>(entity => 
            {
                entity.HasKey(k => new { k.MedicamentId, k.PatientId });

               entity
                    .HasOne(p => p.Patient)
                    .WithMany(pm => pm.Prescriptions)
                    .HasForeignKey(k => k.PatientId);

                entity
                    .HasOne(p => p.Medicament)
                    .WithMany(pm => pm.Prescriptions)
                    .HasForeignKey(k => k.MedicamentId);
            });
        }
    }
}
