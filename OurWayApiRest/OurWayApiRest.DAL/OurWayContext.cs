using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OurWayApiRest.DAL
{
    public class OurWayContext : DbContext
    {
        public OurWayContext(DbContextOptions<OurWayContext> options) : base(options)
        {
        }
    }
}
