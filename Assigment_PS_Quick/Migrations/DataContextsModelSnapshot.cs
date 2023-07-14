﻿// <auto-generated />
using System;
using Assigment_PS_Quick.Db_con;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Assigment_PS_Quick.Migrations
{
    [DbContext(typeof(DataContexts))]
    partial class DataContextsModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Assigment_PS_Quick.Models.Department", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("departName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Assigment_PS_Quick.Models.EntryData", b =>
                {
                    b.Property<int>("fileNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("departCode")
                        .HasColumnType("int");

                    b.Property<DateTime>("fileDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("filePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("sectionCode")
                        .HasColumnType("int");

                    b.Property<string>("subject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("fileNo");

                    b.ToTable("EntryDatas");
                });

            modelBuilder.Entity("Assigment_PS_Quick.Models.LoginData", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("Assigment_PS_Quick.Models.Section", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("departsid")
                        .HasColumnType("int");

                    b.Property<string>("sectionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("departsid");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("Assigment_PS_Quick.Models.Section", b =>
                {
                    b.HasOne("Assigment_PS_Quick.Models.Department", "departs")
                        .WithMany("sectionList")
                        .HasForeignKey("departsid");

                    b.Navigation("departs");
                });

            modelBuilder.Entity("Assigment_PS_Quick.Models.Department", b =>
                {
                    b.Navigation("sectionList");
                });
#pragma warning restore 612, 618
        }
    }
}