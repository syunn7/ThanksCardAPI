﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ThanksCardAPI.Models;

#nullable disable

namespace ThanksCardAPI.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220530084656_MS_ORGANIZATIONsController")]
    partial class MS_ORGANIZATIONsController
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ThanksCardAPI.Models.Department", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Code")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("ThanksCardAPI.Models.MS_EMPLOYEE", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<string>("EMPLOYEE_CD")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EMPLOYEE_NAME")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FURIGANA")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("ORGANIZATIONId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ORGANIZATION_ID")
                        .HasColumnType("bigint");

                    b.Property<string>("PASSWORD")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("ORGANIZATIONId");

                    b.ToTable("EMPOLOYEEs");
                });

            modelBuilder.Entity("ThanksCardAPI.Models.MS_ORGANIZATION", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Organiztioncd")
                        .HasColumnType("integer");

                    b.Property<string>("Organiztionname")
                        .HasColumnType("text");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("ORGANIZATIONs");
                });

            modelBuilder.Entity("ThanksCardAPI.Models.Tag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("ThanksCardAPI.Models.ThanksCard", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Body")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("FromId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<long>("ToId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("FromId");

                    b.HasIndex("ToId");

                    b.ToTable("ThanksCards");
                });

            modelBuilder.Entity("ThanksCardAPI.Models.ThanksCardTag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("TagId")
                        .HasColumnType("bigint");

                    b.Property<long>("ThanksCardId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TagId");

                    b.HasIndex("ThanksCardId");

                    b.ToTable("ThanksCardTag");
                });

            modelBuilder.Entity("ThanksCardAPI.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("DepartmentId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ThanksCardAPI.Models.Department", b =>
                {
                    b.HasOne("ThanksCardAPI.Models.Department", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("ThanksCardAPI.Models.MS_EMPLOYEE", b =>
                {
                    b.HasOne("ThanksCardAPI.Models.MS_ORGANIZATION", "ORGANIZATION")
                        .WithMany("EMPLOYEEs")
                        .HasForeignKey("ORGANIZATIONId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ORGANIZATION");
                });

            modelBuilder.Entity("ThanksCardAPI.Models.MS_ORGANIZATION", b =>
                {
                    b.HasOne("ThanksCardAPI.Models.MS_ORGANIZATION", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("ThanksCardAPI.Models.ThanksCard", b =>
                {
                    b.HasOne("ThanksCardAPI.Models.User", "From")
                        .WithMany()
                        .HasForeignKey("FromId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThanksCardAPI.Models.User", "To")
                        .WithMany()
                        .HasForeignKey("ToId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("From");

                    b.Navigation("To");
                });

            modelBuilder.Entity("ThanksCardAPI.Models.ThanksCardTag", b =>
                {
                    b.HasOne("ThanksCardAPI.Models.Tag", "Tag")
                        .WithMany("ThanksCardTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThanksCardAPI.Models.ThanksCard", "ThanksCard")
                        .WithMany("ThanksCardTags")
                        .HasForeignKey("ThanksCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tag");

                    b.Navigation("ThanksCard");
                });

            modelBuilder.Entity("ThanksCardAPI.Models.User", b =>
                {
                    b.HasOne("ThanksCardAPI.Models.Department", "Department")
                        .WithMany("Users")
                        .HasForeignKey("DepartmentId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ThanksCardAPI.Models.Department", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("ThanksCardAPI.Models.MS_ORGANIZATION", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("EMPLOYEEs");
                });

            modelBuilder.Entity("ThanksCardAPI.Models.Tag", b =>
                {
                    b.Navigation("ThanksCardTags");
                });

            modelBuilder.Entity("ThanksCardAPI.Models.ThanksCard", b =>
                {
                    b.Navigation("ThanksCardTags");
                });
#pragma warning restore 612, 618
        }
    }
}
