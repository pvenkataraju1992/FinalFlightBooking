﻿// <auto-generated />
using System;
using FBS.Service.Booking.Api.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FBS.Service.Booking.Api.Migrations
{
    [DbContext(typeof(BookingDbContext))]
    [Migration("20220616010703_initialbookingmigration")]
    partial class initialbookingmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FBS.Service.Booking.Api.Models.Bookings", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailId");

                    b.Property<string>("FlightNumber");

                    b.Property<string>("FromAddress");

                    b.Property<DateTime>("FromDate");

                    b.Property<bool>("IsBookingCancel");

                    b.Property<string>("MealType");

                    b.Property<int>("NumberOfSeats");

                    b.Property<string>("PNRNumber");

                    b.Property<double>("Price");

                    b.Property<string>("ToAddress");

                    b.Property<DateTime?>("ToDate");

                    b.HasKey("BookingId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("FBS.Service.Booking.Api.Models.Passengers", b =>
                {
                    b.Property<int>("PassengerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookingId");

                    b.Property<int>("PassengerAge");

                    b.Property<string>("PassengerGender");

                    b.Property<string>("PassengerName");

                    b.Property<int>("PassengerSeatNumber");

                    b.HasKey("PassengerId");

                    b.HasIndex("BookingId");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("FBS.Service.Booking.Api.Models.Passengers", b =>
                {
                    b.HasOne("FBS.Service.Booking.Api.Models.Bookings", "Booking")
                        .WithMany("Passengers")
                        .HasForeignKey("BookingId");
                });
#pragma warning restore 612, 618
        }
    }
}
