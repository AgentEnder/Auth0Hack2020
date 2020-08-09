﻿// <auto-generated />
using System;
using Auth0HackBackend.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;

namespace Auth0HackBackend.Migrations
{
    [DbContext(typeof(HackEntities))]
    partial class HackEntitiesModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Auth0HackBackend.Model.ApprovalStatus", b =>
                {
                    b.Property<Guid>("ApprovalStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsFinal")
                        .HasColumnType("bit");

                    b.Property<string>("StatusName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApprovalStatusId");

                    b.ToTable("ApprovalStatus");
                });

            modelBuilder.Entity("Auth0HackBackend.Model.Employee", b =>
                {
                    b.Property<Guid>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Auth0Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<bool>("isApprover")
                        .HasColumnType("bit");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Auth0HackBackend.Model.Office", b =>
                {
                    b.Property<Guid>("OfficeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OfficeCity")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<Point>("OfficeLocation")
                        .HasColumnType("geography");

                    b.Property<int>("OfficeMaxCapacity")
                        .HasColumnType("int");

                    b.Property<string>("OfficeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OfficeSafeCapacity")
                        .HasColumnType("int");

                    b.Property<string>("OfficeState")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("OfficeStreet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OfficeZip")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("OfficeId");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("Auth0HackBackend.Model.OfficeClosure", b =>
                {
                    b.Property<Guid>("OfficeClosureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("EndTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("OfficeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("StartTime")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("OfficeClosureId");

                    b.ToTable("OfficeClosures");
                });

            modelBuilder.Entity("Auth0HackBackend.Model.Section", b =>
                {
                    b.Property<Guid>("SectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OfficeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SectionDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SectionMaxCapacity")
                        .HasColumnType("int");

                    b.Property<string>("SectionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SectionSafeCapacity")
                        .HasColumnType("int");

                    b.HasKey("SectionId");

                    b.HasIndex("OfficeId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("Auth0HackBackend.Model.SectionClosure", b =>
                {
                    b.Property<Guid>("SectionClosureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("EndTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("OfficeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("StartTime")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("SectionClosureId");

                    b.ToTable("SectionClosures");
                });

            modelBuilder.Entity("Auth0HackBackend.Model.WorkRequest", b =>
                {
                    b.Property<Guid>("WorkRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApprovalStatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApproverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ApproverNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("EndTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("OfficeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RequestorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RequestorNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("StartTime")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("WorkRequestId");

                    b.HasIndex("ApprovalStatusId");

                    b.HasIndex("ApproverId");

                    b.HasIndex("OfficeId");

                    b.HasIndex("PersonId");

                    b.HasIndex("RequestorId");

                    b.HasIndex("SectionId");

                    b.ToTable("WorkRequests");
                });

            modelBuilder.Entity("Auth0HackBackend.Model.vWorkRequestCapacity", b =>
                {
                    b.Property<Guid>("WorkRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("OfficeUsedCapacity")
                        .HasColumnType("int");

                    b.Property<int>("SectionUsedCapacity")
                        .HasColumnType("int");

                    b.HasKey("WorkRequestId");

                    b.ToTable("vWorkRequestCapacities");
                });

            modelBuilder.Entity("Auth0HackBackend.Model.Section", b =>
                {
                    b.HasOne("Auth0HackBackend.Model.Office", "Office")
                        .WithMany("Sections")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Auth0HackBackend.Model.WorkRequest", b =>
                {
                    b.HasOne("Auth0HackBackend.Model.ApprovalStatus", "ApprovalStatus")
                        .WithMany("WorkRequests")
                        .HasForeignKey("ApprovalStatusId");

                    b.HasOne("Auth0HackBackend.Model.Employee", "Approver")
                        .WithMany("Approvals")
                        .HasForeignKey("ApproverId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Auth0HackBackend.Model.Office", "Office")
                        .WithMany("WorkRequests")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Auth0HackBackend.Model.Employee", "Person")
                        .WithMany("PersonalWorkRequests")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Auth0HackBackend.Model.Employee", "Requestor")
                        .WithMany("Requests")
                        .HasForeignKey("RequestorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Auth0HackBackend.Model.Section", "Section")
                        .WithMany("WorkRequests")
                        .HasForeignKey("SectionId");
                });
#pragma warning restore 612, 618
        }
    }
}
