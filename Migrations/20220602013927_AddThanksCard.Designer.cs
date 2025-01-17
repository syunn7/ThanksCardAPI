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
    [Migration("20220602013927_AddThanksCard")]
    partial class AddThanksCard
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ThanksCardAPI.Models.Classification", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("ClassificationName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Classifications");
                });

            modelBuilder.Entity("ThanksCardAPI.Models.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("EmployeeCd")
                        .HasColumnType("text");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("text");

                    b.Property<string>("Furigana")
                        .HasColumnType("text");

                    b.Property<long?>("OrganizationId")
                        .HasColumnType("bigint");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ThanksCardAPI.Models.Organization", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("OrganizationCd")
                        .HasColumnType("integer");

                    b.Property<string>("OrganizationName")
                        .HasColumnType("text");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("ThanksCardAPI.Models.ThanksCard", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Check")
                        .HasColumnType("text");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<string>("Contents")
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("FromId")
                        .HasColumnType("integer");

                    b.Property<long?>("FromId1")
                        .HasColumnType("bigint");

                    b.Property<string>("Kidoku")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<int>("ToId")
                        .HasColumnType("integer");

                    b.Property<long?>("ToId1")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("FromId1");

                    b.HasIndex("ToId1");

                    b.ToTable("ThanksCards");
                });

            modelBuilder.Entity("ThanksCardAPI.Models.ThanksCardClassification", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ClassificationId")
                        .HasColumnType("bigint");

                    b.Property<long>("ThanksCardId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ClassificationId");

                    b.HasIndex("ThanksCardId");

                    b.ToTable("ThanksCardClassification");
                });

            modelBuilder.Entity("ThanksCardAPI.Models.Employee", b =>
                {
                    b.HasOne("ThanksCardAPI.Models.Organization", "Organization")
                        .WithMany("Employees")
                        .HasForeignKey("OrganizationId");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("ThanksCardAPI.Models.Organization", b =>
                {
                    b.HasOne("ThanksCardAPI.Models.Organization", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("ThanksCardAPI.Models.ThanksCard", b =>
                {
                    b.HasOne("ThanksCardAPI.Models.Employee", "From")
                        .WithMany()
                        .HasForeignKey("FromId1");

                    b.HasOne("ThanksCardAPI.Models.Employee", "To")
                        .WithMany()
                        .HasForeignKey("ToId1");

                    b.Navigation("From");

                    b.Navigation("To");
                });

            modelBuilder.Entity("ThanksCardAPI.Models.ThanksCardClassification", b =>
                {
                    b.HasOne("ThanksCardAPI.Models.Classification", "classification")
                        .WithMany("ThanksCardClassification")
                        .HasForeignKey("ClassificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThanksCardAPI.Models.ThanksCard", "ThanksCard")
                        .WithMany("ThanksCardClassifications")
                        .HasForeignKey("ThanksCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ThanksCard");

                    b.Navigation("classification");
                });

            modelBuilder.Entity("ThanksCardAPI.Models.Classification", b =>
                {
                    b.Navigation("ThanksCardClassification");
                });

            modelBuilder.Entity("ThanksCardAPI.Models.Organization", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("ThanksCardAPI.Models.ThanksCard", b =>
                {
                    b.Navigation("ThanksCardClassifications");
                });
#pragma warning restore 612, 618
        }
    }
}
