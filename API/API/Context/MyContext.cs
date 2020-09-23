using API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Joblist> Joblists { get; set; }
        public DbSet<Site> Sites { get; set; }

        public DbSet<Replacement> Replacements { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Replacement>()
                .HasOne(ur => ur.Site)
                .WithMany(b => b.Replacements)
                .HasForeignKey(ur => ur.SiteId);


            base.OnModelCreating(builder);
        }


    }
}
