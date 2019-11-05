﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlanificatorCMD.Persistence;

namespace PlanificatorCMD.Migrations
{
    [DbContext(typeof(PlanificatorDbContext))]
    partial class PlanificatorDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PlanificatorCMD.Core.Photo", b =>
                {
                    b.Property<int>("PhotoId")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PhotoId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("PlanificatorCMD.Core.Presentation", b =>
                {
                    b.Property<int>("PresentationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LongDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(800)")
                        .HasMaxLength(800);

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("PresentationId");

                    b.ToTable("Presentations");
                });

            modelBuilder.Entity("PlanificatorCMD.Core.PresentationSpeaker", b =>
                {
                    b.Property<int>("PresentationId")
                        .HasColumnType("int");

                    b.Property<int>("SpeakerId")
                        .HasColumnType("int");

                    b.HasKey("PresentationId", "SpeakerId");

                    b.HasIndex("SpeakerId");

                    b.ToTable("PresentationSpeakers");
                });

            modelBuilder.Entity("PlanificatorCMD.Core.PresentationTag", b =>
                {
                    b.Property<int>("PresentationId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("PresentationId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("PresentationTags");
                });

            modelBuilder.Entity("PlanificatorCMD.Core.SpeakerProfile", b =>
                {
                    b.Property<int>("SpeakerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("SpeakerId");

                    b.ToTable("SpeakerProfiles");
                });

            modelBuilder.Entity("PlanificatorCMD.Core.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("PlanificatorCMD.Core.Photo", b =>
                {
                    b.HasOne("PlanificatorCMD.Core.SpeakerProfile", "SpeakerProfile")
                        .WithOne("Photo")
                        .HasForeignKey("PlanificatorCMD.Core.Photo", "PhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlanificatorCMD.Core.PresentationSpeaker", b =>
                {
                    b.HasOne("PlanificatorCMD.Core.Presentation", "Presentation")
                        .WithMany("PresentationSpeakers")
                        .HasForeignKey("PresentationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlanificatorCMD.Core.SpeakerProfile", "SpeakerProfile")
                        .WithMany("PresentationSpeakers")
                        .HasForeignKey("SpeakerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlanificatorCMD.Core.PresentationTag", b =>
                {
                    b.HasOne("PlanificatorCMD.Core.Presentation", "Presentation")
                        .WithMany("PresentationTags")
                        .HasForeignKey("PresentationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlanificatorCMD.Core.Tag", "Tag")
                        .WithMany("PresentationTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
