using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProjectAPI.Models
{
    public partial class OIC_IBLS_DEMO_1Context : DbContext
    {
        public OIC_IBLS_DEMO_1Context()
        {
        }

        public OIC_IBLS_DEMO_1Context(DbContextOptions<OIC_IBLS_DEMO_1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<TCompany> TCompany { get; set; }
        public virtual DbSet<TMainPolicy> TMainPolicy { get; set; }
        public virtual DbSet<TReference> TReference { get; set; }
        public virtual DbSet<TReferenceDetail> TReferenceDetail { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost,1434;Database=OIC_IBLS_DEMO_1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.RoleName });

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TCompany>(entity =>
            {
                entity.HasKey(e => e.CompanyCode)
                    .HasName("PK_tMainPolicy");

                entity.ToTable("tCompany");

                entity.Property(e => e.CompanyCode).ValueGeneratedNever();
            });

            modelBuilder.Entity<TMainPolicy>(entity =>
            {
                entity.HasKey(e => new { e.CompanyCode, e.PolicyNumber, e.PolicyType, e.OicplanCode })
                    .HasName("PK_tMainPolicy_2");

                entity.ToTable("tMainPolicy");

                entity.Property(e => e.PolicyNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PolicyType)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.OicplanCode)
                    .HasColumnName("OICPlanCode")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.GroupInsurance)
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TReference>(entity =>
            {
                entity.HasKey(e => e.ReferType);

                entity.ToTable("tReference");

                entity.Property(e => e.ReferType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TReferenceDetail>(entity =>
            {
                entity.HasKey(e => new { e.ReferType, e.ReferCode });

                entity.ToTable("tReference_Detail");

                entity.Property(e => e.ReferType)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ReferCode)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_Users_1");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(10)
                    .IsRequired(false)
                    .IsFixedLength();

                entity.Property(e => e.CreateDate)
                    .HasMaxLength(50)
                    .IsRequired(false)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsRequired(false)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsRequired(false)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsRequired(false)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
