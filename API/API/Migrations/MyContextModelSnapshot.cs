﻿// <auto-generated />
using System;
using API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API.Model.InterviewSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreateData");

                    b.Property<DateTimeOffset>("DeleteData");

                    b.Property<string>("EmpId");

                    b.Property<DateTime>("Interview_date");

                    b.Property<int>("JoblistId");

                    b.Property<int>("SiteId");

                    b.Property<DateTimeOffset>("UpdateDate");

                    b.Property<bool>("isDelete");

                    b.HasKey("Id");

                    b.HasIndex("JoblistId");

                    b.HasIndex("SiteId");

                    b.ToTable("InterviewSchedules");
                });

            modelBuilder.Entity("API.Model.Joblist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreateData");

                    b.Property<DateTimeOffset>("DeleteData");

                    b.Property<string>("Name");

                    b.Property<DateTimeOffset>("UpdateDate");

                    b.Property<bool>("isDelete");

                    b.HasKey("Id");

                    b.ToTable("TB_Trans_Joblist");
                });

            modelBuilder.Entity("API.Model.Placement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreateData");

                    b.Property<DateTimeOffset>("DeleteData");

                    b.Property<string>("EmpId");

                    b.Property<DateTime>("PlacementDate");

                    b.Property<DateTime>("PlacementEndDate");

                    b.Property<int>("SiteId");

                    b.Property<DateTimeOffset>("UpdateDate");

                    b.Property<bool>("isDelete");

                    b.HasKey("Id");

                    b.HasIndex("SiteId");

                    b.ToTable("TB_M_Placement");
                });

            modelBuilder.Entity("API.Model.Replacement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreateData");

                    b.Property<DateTimeOffset>("DeleteData");

                    b.Property<string>("EmpId");

                    b.Property<string>("Replacement_reason");

                    b.Property<int>("SiteId");

                    b.Property<DateTimeOffset>("UpdateDate");

                    b.Property<bool>("isDelete");

                    b.HasKey("Id");

                    b.HasIndex("SiteId");

                    b.ToTable("TB_M_Replacement");
                });

            modelBuilder.Entity("API.Model.Site", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTimeOffset>("CreateData");

                    b.Property<DateTimeOffset>("DeleteData");

                    b.Property<string>("Name");

                    b.Property<int>("PhoneNumber");

                    b.Property<string>("Supervisor_name");

                    b.Property<DateTimeOffset>("UpdateDate");

                    b.Property<bool>("isDelete");

                    b.HasKey("Id");

                    b.ToTable("TB_M_Site");
                });

            modelBuilder.Entity("API.Model.InterviewSchedule", b =>
                {
                    b.HasOne("API.Model.Joblist", "Joblist")
                        .WithMany()
                        .HasForeignKey("JoblistId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("API.Model.Site", "Site")
                        .WithMany()
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("API.Model.Placement", b =>
                {
                    b.HasOne("API.Model.Site", "Site")
                        .WithMany()
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("API.Model.Replacement", b =>
                {
                    b.HasOne("API.Model.Site", "Site")
                        .WithMany()
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
