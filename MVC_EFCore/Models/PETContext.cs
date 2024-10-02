using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MVC_EFCore.Models
{
    public partial class PETContext : DbContext
    {
        public PETContext() // Constructor Gốc
        {
        }

        public PETContext(DbContextOptions<PETContext> options) // Constructor Base kế thừa từ DbContext
            : base(options)
        {
        }
        // Mỗi DbSet đại diện cho 1 bảng trong DB, không có DbSet hoặc Dbset không public thì không thể
        // trỏ tới bảng để thực hiện các thao tác dữ liệu
        // DbSet cung cấp cho dev tất cả các phương thức CRUD trên các bảng thông qua cú pháp LinQ
        public virtual DbSet<Pet> Pets { get; set; } = null!;
        public virtual DbSet<Sen> Sens { get; set; } = null!;

        // 2. Phương thức On - 
        // OnConfiguring là phương thức để xác lập các cấu hình kết nối
        // OnModelCreating là phường thức để cấu hình bảng cụ thể
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SHANGHAIK;Database=PET;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>(entity =>
            {
                entity.ToTable("Pet");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ImgURL");

                entity.Property(e => e.Loai).HasMaxLength(100);

                entity.Property(e => e.SenId).HasColumnName("SenID");

                entity.Property(e => e.Ten).HasMaxLength(100);

                entity.HasOne(d => d.Sen)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.SenId)
                    .HasConstraintName("FK_SEN_PET");
            });

            modelBuilder.Entity<Sen>(entity =>
            {
                entity.ToTable("Sen");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DiaChi).HasMaxLength(100);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SDT")
                    .IsFixedLength();

                entity.Property(e => e.Ten).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
