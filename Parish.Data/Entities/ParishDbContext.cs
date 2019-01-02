using Microsoft.EntityFrameworkCore;

namespace Parish.Data.Entities
{
    public partial class ParishDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public static string ConnectionString;
        public ParishDbContext()
        {
        }

        public ParishDbContext(DbContextOptions<ParishDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contribution> Contribution { get; set; }
        public virtual DbSet<Family> Family { get; set; }
        public virtual DbSet<FamilyMember> FamilyMember { get; set; }
        public virtual DbSet<Member> Member { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contribution>(entity =>
            {
                entity.Property(e => e.Date).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Notes)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Family)
                    .WithMany(p => p.Contribution)
                    .HasForeignKey(d => d.FamilyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contribution_Family");
            });

            modelBuilder.Entity<Family>(entity =>
            {
                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Family)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Family_Member");
            });

            modelBuilder.Entity<FamilyMember>(entity =>
            {
                entity.HasOne(d => d.Family)
                    .WithMany(p => p.FamilyMember)
                    .HasForeignKey(d => d.FamilyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FamilyMember_Family");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.FamilyMember)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FamilyMember_Member");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
