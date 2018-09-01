using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoubleDriver.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace DoubleDriver.Dal
{
    public class DoubleDriverContext : DbContext
    {
        public DoubleDriverContext(DbContextOptions options) : base(options)
        {
        }

        protected DoubleDriverContext()
        {
        }

        public DbSet<BunqUser> BunqUsers { get; set; }
    }
}
