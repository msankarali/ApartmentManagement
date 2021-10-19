﻿// <auto-generated />
using System;
using ApartmentManagement.DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApartmentManagement.DataAccess.Migrations
{
    [DbContext(typeof(ApartmentManagementDbContext))]
    partial class ApartmentManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApartmentManagement.Entities.Models.Apartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Block")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Door")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Floor")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsOwner")
                        .HasColumnType("bit");

                    b.Property<int?>("OccupantId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("OccupantId");

                    b.ToTable("Apartments");
                });

            modelBuilder.Entity("ApartmentManagement.Entities.Models.ChatGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<int>("OccupantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId")
                        .IsUnique();

                    b.HasIndex("OccupantId")
                        .IsUnique();

                    b.ToTable("ChatGroups");
                });

            modelBuilder.Entity("ApartmentManagement.Entities.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AmountPayable")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ApartmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InvoiceTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("InvoiceTypeId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("ApartmentManagement.Entities.Models.InvoiceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("InvoiceTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Aidat"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Elektrik"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Su"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Doğalgaz"
                        });
                });

            modelBuilder.Entity("ApartmentManagement.Entities.Models.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varbinary(128)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("ApartmentManagement.Entities.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChatGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ChatGroupId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("ApartmentManagement.Entities.Models.Occupant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarPlate")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("IdentityNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<bool>("IsCarOwner")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varbinary(128)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Occupants");
                });

            modelBuilder.Entity("ApartmentManagement.Entities.Models.Apartment", b =>
                {
                    b.HasOne("ApartmentManagement.Entities.Models.Occupant", "Occupant")
                        .WithMany("Apartments")
                        .HasForeignKey("OccupantId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Occupant");
                });

            modelBuilder.Entity("ApartmentManagement.Entities.Models.ChatGroup", b =>
                {
                    b.HasOne("ApartmentManagement.Entities.Models.Manager", "Manager")
                        .WithOne("ChatGroup")
                        .HasForeignKey("ApartmentManagement.Entities.Models.ChatGroup", "ManagerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ApartmentManagement.Entities.Models.Occupant", "Occupant")
                        .WithOne("ChatGroup")
                        .HasForeignKey("ApartmentManagement.Entities.Models.ChatGroup", "OccupantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Manager");

                    b.Navigation("Occupant");
                });

            modelBuilder.Entity("ApartmentManagement.Entities.Models.Invoice", b =>
                {
                    b.HasOne("ApartmentManagement.Entities.Models.Apartment", "Apartment")
                        .WithMany("Invoices")
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ApartmentManagement.Entities.Models.InvoiceType", "InvoiceType")
                        .WithMany("Invoices")
                        .HasForeignKey("InvoiceTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Apartment");

                    b.Navigation("InvoiceType");
                });

            modelBuilder.Entity("ApartmentManagement.Entities.Models.Message", b =>
                {
                    b.HasOne("ApartmentManagement.Entities.Models.ChatGroup", "ChatGroup")
                        .WithMany("Messages")
                        .HasForeignKey("ChatGroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ChatGroup");
                });

            modelBuilder.Entity("ApartmentManagement.Entities.Models.Apartment", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("ApartmentManagement.Entities.Models.ChatGroup", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("ApartmentManagement.Entities.Models.InvoiceType", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("ApartmentManagement.Entities.Models.Manager", b =>
                {
                    b.Navigation("ChatGroup");
                });

            modelBuilder.Entity("ApartmentManagement.Entities.Models.Occupant", b =>
                {
                    b.Navigation("Apartments");

                    b.Navigation("ChatGroup");
                });
#pragma warning restore 612, 618
        }
    }
}
