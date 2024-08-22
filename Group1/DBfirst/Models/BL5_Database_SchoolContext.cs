using Microsoft.EntityFrameworkCore;

namespace DBfirst.Models
{
    public partial class BL5_Database_SchoolContext : DbContext
    {
        public BL5_Database_SchoolContext()
        {
        }

        public BL5_Database_SchoolContext(DbContextOptions<BL5_Database_SchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Evaluation> Evaluations { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentDetail> StudentDetails { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Email).HasMaxLength(30);

                entity.Property(e => e.Password).HasMaxLength(30);
            });

            modelBuilder.Entity<Evaluation>(entity =>
            {
                entity.ToTable("Evaluation");

                entity.Property(e => e.AdditionExplanation).HasMaxLength(100);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Evaluations)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_Evaluation_Student");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Student_Account");

                entity.HasMany(d => d.Subjects)
                    .WithMany(p => p.Students)
                    .UsingEntity<Dictionary<string, object>>(
                        "StudentSubject",
                        l => l.HasOne<Subject>().WithMany().HasForeignKey("SubjectId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_StudentSubject_Subject"),
                        r => r.HasOne<Student>().WithMany().HasForeignKey("StudentId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_StudentSubject_Student"),
                        j =>
                        {
                            j.HasKey("StudentId", "SubjectId").HasName("PK__StudentS__A80491A3793893EC");

                            j.ToTable("StudentSubject");
                        });
            });

            modelBuilder.Entity<StudentDetail>(entity =>
            {
                entity.HasKey(e => e.StudentDetailsId)
                    .HasName("PK__StudentD__3963A24FB9E3732A");

                entity.Property(e => e.AdditionalInformation).HasMaxLength(50);

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentDetails)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_StudentDetails_Student");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.SubjectName).HasMaxLength(30);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Teacher_Account");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Teacher_Subject");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
