using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace PersonalWebsite.Models
{
    public class StatsDBContext : DbContext
    {
        public DbSet<VisitLog> VisitLogs { get; set; }

        public string DbPath { get; }

        public StatsDBContext(DbContextOptions<StatsDBContext> options) : base(options)
        {

        }
    }
}

