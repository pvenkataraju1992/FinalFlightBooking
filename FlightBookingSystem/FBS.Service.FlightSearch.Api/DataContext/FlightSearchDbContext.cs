using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inv=FBS.Service.Inventory.Api.Models;

namespace FBS.Service.FlightSearch.Api.DataContext
{
    public class FlightSearchDbContext:DbContext
    {
        public FlightSearchDbContext(DbContextOptions<FlightSearchDbContext> options):base(options)
        {
        }
        public DbSet<Inv.AirlineDetails> Airlines { get; set; }
        public DbSet<Inv.InventoryDetails> Inventories { get; set; }
    }
}
