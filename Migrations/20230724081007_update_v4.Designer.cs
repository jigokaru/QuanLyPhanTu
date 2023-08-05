﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLyPhanTu.Models;

#nullable disable

namespace QuanLyPhanTu.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230724081007_update_v4")]
    partial class update_v4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QuanLyPhanTu.Models.Chuas", b =>
                {
                    b.Property<int>("chuaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("chuaId"));

                    b.Property<DateTime>("capNhap")
                        .HasColumnType("datetime2");

                    b.Property<string>("diaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ngayThanhLap")
                        .HasColumnType("datetime2");

                    b.Property<string>("tenChua")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("chuaId");

                    b.ToTable("Chuas");
                });

            modelBuilder.Entity("QuanLyPhanTu.Models.DaoTrangs", b =>
                {
                    b.Property<int>("daoTrangId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("daoTrangId"));

                    b.Property<bool>("daKetThuc")
                        .HasColumnType("bit");

                    b.Property<string>("noiDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("noiToChuc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("phatTuId")
                        .HasColumnType("int");

                    b.Property<int?>("soThanhVienThamGia")
                        .HasColumnType("int");

                    b.Property<DateTime?>("thoiGianToChuc")
                        .HasColumnType("datetime2");

                    b.HasKey("daoTrangId");

                    b.HasIndex("phatTuId");

                    b.ToTable("DaoTrangs");
                });

            modelBuilder.Entity("QuanLyPhanTu.Models.DonDangKys", b =>
                {
                    b.Property<int>("donDangkyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("donDangkyId"));

                    b.Property<int?>("daoTrangId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ngayGuiDon")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ngayXuLy")
                        .HasColumnType("datetime2");

                    b.Property<int?>("nguoiXuLy")
                        .HasColumnType("int");

                    b.Property<int?>("phatTuId")
                        .HasColumnType("int");

                    b.Property<bool?>("trangThaiDon")
                        .HasColumnType("bit");

                    b.HasKey("donDangkyId");

                    b.HasIndex("daoTrangId");

                    b.HasIndex("phatTuId");

                    b.ToTable("DonDangKys");
                });

            modelBuilder.Entity("QuanLyPhanTu.Models.KieuThanhViens", b =>
                {
                    b.Property<int?>("kieuThanhVienId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("kieuThanhVienId"));

                    b.Property<string>("code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tenKieu")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("kieuThanhVienId");

                    b.ToTable("KieuThanhViens");
                });

            modelBuilder.Entity("QuanLyPhanTu.Models.PhanTu", b =>
                {
                    b.Property<int?>("phatTuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("phatTuId"));

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("anhChup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("chuaId")
                        .HasColumnType("int");

                    b.Property<bool?>("daHoanTuc")
                        .HasColumnType("bit");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gioiTinh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ho")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<int?>("kieuThanhVienId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ngayCapNhap")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ngayHoanTuc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ngaySinh")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ngayXuatGia")
                        .HasColumnType("datetime2");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phapDanh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("soDienThoai")
                        .HasColumnType("int");

                    b.Property<string>("ten")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tenDem")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("phatTuId");

                    b.HasIndex("chuaId");

                    b.HasIndex("kieuThanhVienId");

                    b.ToTable("PhanTu");

                    b.HasData(
                        new
                        {
                            phatTuId = 2,
                            Role = "",
                            email = "",
                            isActive = true,
                            password = ""
                        },
                        new
                        {
                            phatTuId = 3,
                            Role = "",
                            email = "",
                            isActive = true,
                            password = ""
                        },
                        new
                        {
                            phatTuId = 4,
                            Role = "",
                            email = "",
                            isActive = true,
                            password = ""
                        },
                        new
                        {
                            phatTuId = 5,
                            Role = "",
                            email = "",
                            isActive = true,
                            password = ""
                        },
                        new
                        {
                            phatTuId = 6,
                            Role = "",
                            email = "",
                            isActive = true,
                            password = ""
                        },
                        new
                        {
                            phatTuId = 7,
                            Role = "",
                            email = "",
                            isActive = true,
                            password = ""
                        },
                        new
                        {
                            phatTuId = 8,
                            Role = "",
                            email = "",
                            isActive = true,
                            password = ""
                        },
                        new
                        {
                            phatTuId = 9,
                            Role = "",
                            email = "",
                            isActive = true,
                            password = ""
                        },
                        new
                        {
                            phatTuId = 10,
                            Role = "",
                            email = "",
                            isActive = true,
                            password = ""
                        },
                        new
                        {
                            phatTuId = 11,
                            Role = "",
                            email = "",
                            isActive = true,
                            password = ""
                        },
                        new
                        {
                            phatTuId = 12,
                            Role = "",
                            email = "",
                            isActive = true,
                            password = ""
                        },
                        new
                        {
                            phatTuId = 13,
                            Role = "",
                            email = "",
                            isActive = true,
                            password = ""
                        },
                        new
                        {
                            phatTuId = 14,
                            Role = "",
                            email = "",
                            isActive = true,
                            password = ""
                        },
                        new
                        {
                            phatTuId = 15,
                            Role = "",
                            email = "",
                            isActive = true,
                            password = ""
                        },
                        new
                        {
                            phatTuId = 16,
                            Role = "",
                            email = "",
                            isActive = true,
                            password = ""
                        },
                        new
                        {
                            phatTuId = 17,
                            Role = "",
                            email = "",
                            isActive = true,
                            password = ""
                        },
                        new
                        {
                            phatTuId = 18,
                            Role = "",
                            email = "",
                            isActive = true,
                            password = ""
                        },
                        new
                        {
                            phatTuId = 19,
                            Role = "",
                            email = "",
                            isActive = true,
                            password = ""
                        });
                });

            modelBuilder.Entity("QuanLyPhanTu.Models.PhatTuDaoTrangs", b =>
                {
                    b.Property<int>("phatTuDaoTrangId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("phatTuDaoTrangId"));

                    b.Property<bool>("daThamGia")
                        .HasColumnType("bit");

                    b.Property<int?>("daoTrangId")
                        .HasColumnType("int");

                    b.Property<string>("lyDoKhongThamGia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("phatTuId")
                        .HasColumnType("int");

                    b.HasKey("phatTuDaoTrangId");

                    b.HasIndex("daoTrangId");

                    b.HasIndex("phatTuId");

                    b.ToTable("PhatTuDaoTrangs");
                });

            modelBuilder.Entity("QuanLyPhanTu.Models.Token", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<bool?>("expired")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("expiresAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("phatTuId")
                        .HasColumnType("int");

                    b.Property<bool?>("revoked")
                        .HasColumnType("bit");

                    b.Property<string>("stoken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("token_type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("phatTuId");

                    b.ToTable("Token");
                });

            modelBuilder.Entity("QuanLyPhanTu.Models.TokenResetPassword", b =>
                {
                    b.Property<int?>("PasswordResetTokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("PasswordResetTokenId"));

                    b.Property<string>("PasswordResetToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ResetTokenExpires")
                        .HasColumnType("datetime2");

                    b.Property<string>("emailToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("phatTuId")
                        .HasColumnType("int");

                    b.HasKey("PasswordResetTokenId");

                    b.HasIndex("phatTuId");

                    b.ToTable("TokenResetPassword");
                });

            modelBuilder.Entity("QuanLyPhanTu.Models.DaoTrangs", b =>
                {
                    b.HasOne("QuanLyPhanTu.Models.PhanTu", "PhatTu")
                        .WithMany()
                        .HasForeignKey("phatTuId");

                    b.Navigation("PhatTu");
                });

            modelBuilder.Entity("QuanLyPhanTu.Models.DonDangKys", b =>
                {
                    b.HasOne("QuanLyPhanTu.Models.DaoTrangs", "daoTrang")
                        .WithMany()
                        .HasForeignKey("daoTrangId");

                    b.HasOne("QuanLyPhanTu.Models.PhanTu", "phatTu")
                        .WithMany()
                        .HasForeignKey("phatTuId");

                    b.Navigation("daoTrang");

                    b.Navigation("phatTu");
                });

            modelBuilder.Entity("QuanLyPhanTu.Models.PhanTu", b =>
                {
                    b.HasOne("QuanLyPhanTu.Models.Chuas", "chua")
                        .WithMany()
                        .HasForeignKey("chuaId");

                    b.HasOne("QuanLyPhanTu.Models.KieuThanhViens", "kieuThanhVien")
                        .WithMany()
                        .HasForeignKey("kieuThanhVienId");

                    b.Navigation("chua");

                    b.Navigation("kieuThanhVien");
                });

            modelBuilder.Entity("QuanLyPhanTu.Models.PhatTuDaoTrangs", b =>
                {
                    b.HasOne("QuanLyPhanTu.Models.DaoTrangs", "daoTrang")
                        .WithMany()
                        .HasForeignKey("daoTrangId");

                    b.HasOne("QuanLyPhanTu.Models.PhanTu", "phatTu")
                        .WithMany()
                        .HasForeignKey("phatTuId");

                    b.Navigation("daoTrang");

                    b.Navigation("phatTu");
                });

            modelBuilder.Entity("QuanLyPhanTu.Models.Token", b =>
                {
                    b.HasOne("QuanLyPhanTu.Models.PhanTu", "phatTu")
                        .WithMany()
                        .HasForeignKey("phatTuId");

                    b.Navigation("phatTu");
                });

            modelBuilder.Entity("QuanLyPhanTu.Models.TokenResetPassword", b =>
                {
                    b.HasOne("QuanLyPhanTu.Models.PhanTu", "PhatTu")
                        .WithMany()
                        .HasForeignKey("phatTuId");

                    b.Navigation("PhatTu");
                });
#pragma warning restore 612, 618
        }
    }
}
