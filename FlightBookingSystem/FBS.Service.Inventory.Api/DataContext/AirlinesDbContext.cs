using FBS.Service.Inventory.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBS.Service.Inventory.Api.DataContext
{
    public class AirlinesDbContext:DbContext
    {
        public AirlinesDbContext(DbContextOptions<AirlinesDbContext> options) : base(options)
        {
        }
        public DbSet<AirlineDetails> Airlines { get; set; }
        public DbSet<InventoryDetails> Inventories { get; set; }
    }
}
