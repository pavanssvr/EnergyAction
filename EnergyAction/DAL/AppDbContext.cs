using Microsoft.EntityFrameworkCore;
using Model;
using System;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {

        }
        public DbSet<Event> Events { get; set; }
    }
}
