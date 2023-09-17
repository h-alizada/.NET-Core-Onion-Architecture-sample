﻿// <auto-generated />
using System;
using CareerSite.Onion.Infrastructure.Sql.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CareerSite.Onion.Infrastructure.Sql.Migrations
{
    [DbContext(typeof(CareerSiteContext))]
    [Migration("20211002091502_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CareerSite.Onion.Infrastructure.Sql.Entities.JobApplicationEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AppicantFullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicantEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicantLinkedinUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ApplicantSalaryExpectations")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ApplicantYearsOfExperience")
                        .HasColumnType("int");

                    b.Property<string>("PositionLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PositionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JobApplications");
                });
#pragma warning restore 612, 618
        }
    }
}
