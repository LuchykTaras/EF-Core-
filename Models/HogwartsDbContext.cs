using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Hogwartz_App.Models
{
    public partial class HogwartsDbContext : DbContext
    {
        public HogwartsDbContext()
        {
        }

        public HogwartsDbContext(DbContextOptions<HogwartsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuditLog> AuditLogs { get; set; }

        public virtual DbSet<HousePoint> HousePoints { get; set; }

        public virtual DbSet<Subject> Subjects { get; set; }

        public virtual DbSet<Wand> Wands { get; set; }

        public virtual DbSet<Wizard> Wizards { get; set; }

        public virtual DbSet<vw_ActiveWizard> vw_ActiveWizard { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=HogwartsDB_CodeFirst1;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditLog>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__AuditLog__3214EC07518F09F6");

                entity.Property(e => e.DateTrigerred)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.LogMessage).HasMaxLength(256);
            });

            modelBuilder.Entity<HousePoint>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__HousePoi__3214EC0723107BDB");

                entity.ToTable(tb => tb.HasTrigger("trg_ProtectGryffindor"));

                entity.Property(e => e.DateRecorded)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Subject).WithMany(p => p.HousePoints)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__HousePoin__Subje__74AE54BC");

                entity.HasOne(d => d.Wizard).WithMany(p => p.HousePoints)
                    .HasForeignKey(d => d.WizardId)
                    .HasConstraintName("FK__HousePoin__Wizar__73BA3083");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Subjects__3214EC07EDBA4748");

                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Teacher).HasMaxLength(100);
            });

            modelBuilder.Entity<VGryffindorSquad>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("v_GryffindorSquad");

                entity.Property(e => e.BloodStatus)
                    .HasMaxLength(30)
                    .HasColumnName("Blood_Status");
                entity.Property(e => e.CoreMaterial)
                    .HasMaxLength(100)
                    .HasColumnName("Core_Material");
                entity.Property(e => e.GryffindorStudent)
                    .HasMaxLength(100)
                    .HasColumnName("Gryffindor_Student");
                entity.Property(e => e.WandLength)
                    .HasColumnType("decimal(4, 1)")
                    .HasColumnName("Wand_Length");
            });

            modelBuilder.Entity<Wand>(entity =>
            {
                entity.HasKey(e => e.WandId).HasName("PK__Wands__BB49E3C8AB983681");

                entity.HasIndex(e => e.WizardId, "UQ_Wands_WizardId").IsUnique();

                entity.Property(e => e.CoreMaterial).HasMaxLength(100);
                entity.Property(e => e.Length).HasColumnType("decimal(4, 1)");

                entity.HasOne(d => d.Wizard).WithOne(p => p.Wand)
                    .HasForeignKey<Wand>(d => d.WizardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wands_Wizards");
            });

            modelBuilder.Entity<Wizard>(entity =>
            {
                entity.HasKey(e => e.WizardId).HasName("PK__Wizards__EB46AA85E24275B4");

                entity.HasIndex(e => e.Name, "IX_Wizards_Name");

                entity.Property(e => e.BloodStatus)
                    .HasMaxLength(30)
                    .HasDefaultValue("Unknown", "DF_Wizards_BloodStatus");
                entity.Property(e => e.House).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<vw_ActiveWizard>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("vw_ActiveWizards");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}