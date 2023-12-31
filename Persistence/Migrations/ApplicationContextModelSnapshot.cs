﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Persistence.Entity.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Classes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "ClassName1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "ClassName2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "ClassName3"
                        },
                        new
                        {
                            Id = 4,
                            Name = "ClassName4"
                        },
                        new
                        {
                            Id = 5,
                            Name = "ClassName5"
                        });
                });

            modelBuilder.Entity("Persistence.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ClassesId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClassesId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Address",
                            DateOfBirth = new DateTime(2023, 11, 3, 18, 32, 13, 450, DateTimeKind.Local).AddTicks(3680),
                            Email = "admin@gmail.com",
                            FirstName = "AdminName",
                            LastName = "AdminLastName",
                            Password = "0x6ECE4FD51BC113942692637D9D4B860E",
                            PhoneNumber = "(555) 111-222",
                            Role = "admin"
                        });
                });

            modelBuilder.Entity("Persistence.Entity.User", b =>
                {
                    b.HasOne("Persistence.Entity.Class", "Classes")
                        .WithMany("Users")
                        .HasForeignKey("ClassesId");

                    b.Navigation("Classes");
                });

            modelBuilder.Entity("Persistence.Entity.Class", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
