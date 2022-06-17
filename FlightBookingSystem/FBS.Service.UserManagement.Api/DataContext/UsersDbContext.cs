using FBS.Service.UserManagement.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBS.Service.UserManagement.Api.DataContext
{
    public class UsersDbContext:DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options):base(options)
        {
        }
        public DbSet<UserRegister> Users { get; set; }
    }
}
