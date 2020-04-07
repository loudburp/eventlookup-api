﻿// <auto-generated />
using System;
using EventLookup.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EventLookup.Migrations
{
    [DbContext(typeof(EventLookupContext))]
    [Migration("20200219184031_InitialCreate2")]
    partial class InitialCreate2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EventLookup.Domain.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("Lat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lng")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street2")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EventId")
                        .IsUnique()
                        .HasFilter("[EventId] IS NOT NULL");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("EventLookup.Domain.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DaysEventActive")
                        .HasColumnType("int");

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GoingPeopleCount")
                        .HasColumnType("int");

                    b.Property<int>("InterestedPeopleCount")
                        .HasColumnType("int");

                    b.Property<string>("LongDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("EventLookup.Domain.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Base64Format")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Caption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCover")
                        .HasColumnType("bit");

                    b.Property<string>("PathOnServer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("TicketId")
                        .IsUnique()
                        .HasFilter("[TicketId] IS NOT NULL");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("EventLookup.Domain.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Distributor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DistributorUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("EventLookup.Domain.Models.Address", b =>
                {
                    b.HasOne("EventLookup.Domain.Models.Event", "Event")
                        .WithOne("Address")
                        .HasForeignKey("EventLookup.Domain.Models.Address", "EventId");
                });

            modelBuilder.Entity("EventLookup.Domain.Models.Image", b =>
                {
                    b.HasOne("EventLookup.Domain.Models.Event", "Event")
                        .WithMany("Images")
                        .HasForeignKey("EventId");

                    b.HasOne("EventLookup.Domain.Models.Ticket", "Ticket")
                        .WithOne("Image")
                        .HasForeignKey("EventLookup.Domain.Models.Image", "TicketId");
                });

            modelBuilder.Entity("EventLookup.Domain.Models.Ticket", b =>
                {
                    b.HasOne("EventLookup.Domain.Models.Event", "Event")
                        .WithMany("Tickets")
                        .HasForeignKey("EventId");
                });
#pragma warning restore 612, 618
        }
    }
}
