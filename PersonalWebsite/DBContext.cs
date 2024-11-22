using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace PersonalWebsite.Models
{
    public class DBContext : DbContext
    {
        public DbSet<Story> Stories { get; set; }
        public DbSet<World> Worlds { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<VisitLog> VisitLogs { get; set; }

        public string DbPath { get; }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
    }
}

