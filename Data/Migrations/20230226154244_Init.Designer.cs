﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(JeopardyContext))]
    [Migration("20230226154244_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Data.Models.Member", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("FIO")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Data.Models.Package", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("char(36)");

                    b.Property<int>("QuestionsCount")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("Data.Models.Professor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("CreatedById")
                        .HasColumnType("char(36)");

                    b.Property<string>("FIO")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("Professors");
                });

            modelBuilder.Entity("Data.Models.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AnswerText")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Hint")
                        .HasColumnType("longtext");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("ThemeId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ThemeId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Data.Models.QuestionOfPackage", b =>
                {
                    b.Property<Guid>("QuestionId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("PackageId")
                        .HasColumnType("char(36)");

                    b.Property<int>("X")
                        .HasColumnType("int");

                    b.Property<int>("Y")
                        .HasColumnType("int");

                    b.HasKey("QuestionId", "PackageId");

                    b.HasIndex("PackageId");

                    b.ToTable("QuestionOfPackages");
                });

            modelBuilder.Entity("Data.Models.Session", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("PackageId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ProfessorId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("PackageId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("Data.Models.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Data.Models.Theme", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Themes");
                });

            modelBuilder.Entity("Data.Models.Member", b =>
                {
                    b.HasOne("Data.Models.Team", "Team")
                        .WithMany("Members")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Data.Models.Package", b =>
                {
                    b.HasOne("Data.Models.Professor", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("Data.Models.Professor", b =>
                {
                    b.HasOne("Data.Models.Professor", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("Data.Models.Question", b =>
                {
                    b.HasOne("Data.Models.Theme", "Theme")
                        .WithMany("Questions")
                        .HasForeignKey("ThemeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Theme");
                });

            modelBuilder.Entity("Data.Models.QuestionOfPackage", b =>
                {
                    b.HasOne("Data.Models.Package", "Package")
                        .WithMany("QuestionOfPackages")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.Question", "Question")
                        .WithMany("QuestionOfPackages")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Package");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Data.Models.Session", b =>
                {
                    b.HasOne("Data.Models.Package", "Package")
                        .WithMany()
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.Professor", "Professor")
                        .WithMany()
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Package");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("Data.Models.Team", b =>
                {
                    b.HasOne("Data.Models.Session", "Session")
                        .WithMany("Teams")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Session");
                });

            modelBuilder.Entity("Data.Models.Package", b =>
                {
                    b.Navigation("QuestionOfPackages");
                });

            modelBuilder.Entity("Data.Models.Question", b =>
                {
                    b.Navigation("QuestionOfPackages");
                });

            modelBuilder.Entity("Data.Models.Session", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("Data.Models.Team", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("Data.Models.Theme", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
