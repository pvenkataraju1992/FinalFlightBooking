using FBS.Service.Booking.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBS.Service.Booking.Api.DataContext
{
    public class BookingDbContext:DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options):base(options)
        {
        }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<Passengers> Passengers { get; set; }
    }
}
