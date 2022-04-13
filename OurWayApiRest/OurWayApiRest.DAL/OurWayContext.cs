using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using OurWayApiRest.Model;

namespace OurWayApiRest.DAL
{
    public class OurWayContext : DbContext
    {
        public OurWayContext(DbContextOptions<OurWayContext> options) : base(options)
        {
           // Database.EnsureCreated();
        }
        public DbSet<Adress> Adress { get; set; }
    }
}
