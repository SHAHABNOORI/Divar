﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Divar.Infrastructures.Data.SqlServer.Migrations
{
    [DbContext(typeof(DivarDbContext))]
    partial class DivarDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Divar.Core.Domain.Advertisements.Entities.Advertisement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ApprovedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Price")
                        .HasColumnType("bigint");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Advertisements");
                });

            modelBuilder.Entity("Divar.Core.Domain.Advertisements.Entities.Picture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AdvertisementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdvertisementId");

                    b.ToTable("Picture");
                });

            modelBuilder.Entity("Divar.Core.Domain.Advertisements.Entities.Picture", b =>
                {
                    b.HasOne("Divar.Core.Domain.Advertisements.Entities.Advertisement", null)
                        .WithMany("Pictures")
                        .HasForeignKey("AdvertisementId");

                    b.OwnsOne("Divar.Core.Domain.Advertisements.ValueObjects.PictureSize", "Size", b1 =>
                        {
                            b1.Property<Guid>("PictureId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Height")
                                .HasColumnType("int");

                            b1.Property<int>("Width")
                                .HasColumnType("int");

                            b1.HasKey("PictureId");

                            b1.ToTable("Picture");

                            b1.WithOwner()
                                .HasForeignKey("PictureId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
