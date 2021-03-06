﻿// <auto-generated />
using System;
using CalificarTaxis.Web.Entiries.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CalificarTaxis.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200217163944_M3")]
    partial class M3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CalificarTaxis.Web.Entiries.Data.TaxiEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Plaque")
                        .IsRequired()
                        .HasMaxLength(6);

                    b.HasKey("Id");

                    b.HasIndex("Plaque")
                        .IsUnique();

                    b.ToTable("taxiEntities");
                });

            modelBuilder.Entity("CalificarTaxis.Web.Entiries.Data.TripDetailEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<int?>("TripId");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("tripDetails");
                });

            modelBuilder.Entity("CalificarTaxis.Web.Entiries.Data.TripEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("EndDate");

                    b.Property<float>("Qualification");

                    b.Property<string>("Remarks");

                    b.Property<string>("Source")
                        .HasMaxLength(100);

                    b.Property<double>("SourceLatitude");

                    b.Property<double>("SourceLongitude");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Target")
                        .HasMaxLength(100);

                    b.Property<double>("TargetLatitude");

                    b.Property<double>("TargetLongitude");

                    b.Property<int?>("TaxiId");

                    b.HasKey("Id");

                    b.HasIndex("TaxiId");

                    b.ToTable("trips");
                });

            modelBuilder.Entity("CalificarTaxis.Web.Entiries.Data.TripDetailEntity", b =>
                {
                    b.HasOne("CalificarTaxis.Web.Entiries.Data.TripEntity", "Trip")
                        .WithMany("tripDetails")
                        .HasForeignKey("TripId");
                });

            modelBuilder.Entity("CalificarTaxis.Web.Entiries.Data.TripEntity", b =>
                {
                    b.HasOne("CalificarTaxis.Web.Entiries.Data.TaxiEntity", "Taxi")
                        .WithMany("trips")
                        .HasForeignKey("TaxiId");
                });
#pragma warning restore 612, 618
        }
    }
}
