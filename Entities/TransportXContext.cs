using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore_Project.Entities;

public partial class TransportXContext : DbContext
{
    public TransportXContext()
    {
    }

    public TransportXContext(DbContextOptions<TransportXContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<BaoGium> BaoGia { get; set; }

    public virtual DbSet<BuuCuc> BuuCucs { get; set; }

    public virtual DbSet<DichVu> DichVus { get; set; }

    public virtual DbSet<DonHang> DonHangs { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhieuGui> PhieuGuis { get; set; }

    public virtual DbSet<PhongBan> PhongBans { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=Vietanh-PC;Initial Catalog=Transport_X;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3213E83F37B4A1C1");

            entity.ToTable("Account");

            entity.HasIndex(e => e.UserName, "UQ__Account__5F1A1086650E0BB2").IsUnique();

            entity.HasIndex(e => e.UserEmail, "UQ__Account__EB5FD3468192FC9D").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Role).HasMaxLength(255);
            entity.Property(e => e.UserEmail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("User_email");
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("User_name");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("User_password");
        });

        modelBuilder.Entity<BaoGium>(entity =>
        {
            entity.HasKey(e => e.MaBg).HasName("PK__Bao_gia__2E67755ECDE3A702");

            entity.ToTable("Bao_gia");

            entity.Property(e => e.MaBg)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Ma_BG");
            entity.Property(e => e.GiaDv)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Gia_DV");
            entity.Property(e => e.MaDv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Ma_DV");

            entity.HasOne(d => d.MaDvNavigation).WithMany(p => p.BaoGia)
                .HasForeignKey(d => d.MaDv)
                .HasConstraintName("FK__Bao_gia__Ma_DV__17036CC0");
        });

        modelBuilder.Entity<BuuCuc>(entity =>
        {
            entity.HasKey(e => e.MaBc).HasName("PK__Buu_cuc__2E67755A1179AC0B");

            entity.ToTable("Buu_cuc");

            entity.Property(e => e.MaBc)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Ma_BC");
            entity.Property(e => e.DiachiBc)
                .HasColumnType("text")
                .HasColumnName("Diachi_BC");
            entity.Property(e => e.SdtBc)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Sdt_BC");
            entity.Property(e => e.TenBc)
                .HasMaxLength(255)
                .HasColumnName("Ten_BC");
        });

        modelBuilder.Entity<DichVu>(entity =>
        {
            entity.HasKey(e => e.MaDv).HasName("PK__Dich_vu__2E6744ED72726FDC");

            entity.ToTable("Dich_vu");

            entity.Property(e => e.MaDv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Ma_DV");
            entity.Property(e => e.TenDv)
                .HasMaxLength(255)
                .HasColumnName("Ten_DV");
            entity.Property(e => e.TrongLuong)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Trong_luong");
            entity.Property(e => e.TuyenDv)
                .HasMaxLength(255)
                .HasColumnName("Tuyen_DV");
        });

        modelBuilder.Entity<DonHang>(entity =>
        {
            entity.HasKey(e => e.MaDh).HasName("PK__Don_hang__2E6744E301F9C307");

            entity.ToTable("Don_hang");

            entity.Property(e => e.MaDh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Ma_DH");
            entity.Property(e => e.BaoGia)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Bao_gia");
            entity.Property(e => e.DiaChiGui)
                .HasColumnType("text")
                .HasColumnName("Dia_chi_gui");
            entity.Property(e => e.DiaChiNhan)
                .HasColumnType("text")
                .HasColumnName("Dia_chi_nhan");
            entity.Property(e => e.NgayGui)
                .HasColumnType("date")
                .HasColumnName("Ngay_gui");
            entity.Property(e => e.NgayNhan)
                .HasColumnType("date")
                .HasColumnName("Ngay_nhan");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(255)
                .HasColumnName("Trang_thai");
            entity.Property(e => e.TrongLuong).HasColumnName("Trong_luong");

            entity.HasOne(d => d.BaoGiaNavigation).WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.BaoGia)
                .HasConstraintName("FK__Don_hang__Bao_gi__1BC821DD");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh).HasName("PK__Khach_Ha__2E62B256B0249FC5");

            entity.ToTable("Khach_Hang");

            entity.HasIndex(e => e.SdtKh, "UQ__Khach_Ha__52EB95C1818D5286").IsUnique();

            entity.HasIndex(e => e.EmailKh, "UQ__Khach_Ha__B795E7C3820DC6E0").IsUnique();

            entity.Property(e => e.MaKh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Ma_KH");
            entity.Property(e => e.DiachiKh)
                .HasColumnType("text")
                .HasColumnName("Diachi_KH");
            entity.Property(e => e.EmailKh)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Email_KH");
            entity.Property(e => e.SdtKh)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Sdt_KH");
            entity.Property(e => e.TenKh)
                .HasMaxLength(255)
                .HasColumnName("Ten_KH");
            entity.Property(e => e.UserId).HasColumnName("User_id");

            entity.HasOne(d => d.User).WithMany(p => p.KhachHangs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Khach_Han__User___123EB7A3");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv).HasName("PK__Nhan_vie__2E628DA00325D1F5");

            entity.ToTable("Nhan_vien");

            entity.HasIndex(e => e.SdtNv, "UQ__Nhan_vie__52EBBC70FA99DBF0").IsUnique();

            entity.HasIndex(e => e.EmailNv, "UQ__Nhan_vie__B7958F35863C3525").IsUnique();

            entity.Property(e => e.MaNv)
                .ValueGeneratedNever()
                .HasColumnName("Ma_NV");
            entity.Property(e => e.BuuCuc)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Buu_cuc");
            entity.Property(e => e.EmailNv)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Email_NV");
            entity.Property(e => e.PhongBan)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Phong_ban");
            entity.Property(e => e.SdtNv)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Sdt_NV");
            entity.Property(e => e.TenNv)
                .HasMaxLength(255)
                .HasColumnName("Ten_NV");
            entity.Property(e => e.UserId).HasColumnName("User_id");

            entity.HasOne(d => d.BuuCucNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.BuuCuc)
                .HasConstraintName("FK__Nhan_vien__Buu_c__0C85DE4D");

            entity.HasOne(d => d.PhongBanNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.PhongBan)
                .HasConstraintName("FK__Nhan_vien__Phong__0B91BA14");

            entity.HasOne(d => d.User).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Nhan_vien__User___0D7A0286");
        });

        modelBuilder.Entity<PhieuGui>(entity =>
        {
            entity.HasKey(e => e.MaPg).HasName("PK__Phieu_gu__2E629DF12E08FEAA");

            entity.ToTable("Phieu_gui");

            entity.Property(e => e.MaPg)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Ma_PG");
            entity.Property(e => e.CuocPhi).HasColumnName("Cuoc_phi");
            entity.Property(e => e.NgayGui)
                .HasColumnType("date")
                .HasColumnName("Ngay_gui");
            entity.Property(e => e.NgayNhan)
                .HasColumnType("date")
                .HasColumnName("Ngay_nhan");
            entity.Property(e => e.TrongLuong)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Trong_luong");
        });

        modelBuilder.Entity<PhongBan>(entity =>
        {
            entity.HasKey(e => e.MaPb).HasName("PK__Phong_ba__2E629DF67A2E87C3");

            entity.ToTable("Phong_ban");

            entity.Property(e => e.MaPb)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Ma_PB");
            entity.Property(e => e.TenPb)
                .HasMaxLength(255)
                .HasColumnName("Ten_PB");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
