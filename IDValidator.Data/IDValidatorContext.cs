using IDValidator.Data.Configuration;
using IDValidator.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace IDValidator.Data
{
    public class IDValidatorContext:DbContext
    {

        public DbSet<Request> Requests { get; set; }

        public IDValidatorContext(DbContextOptions <IDValidatorContext> options):
            base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RequestConfiguration());
            base.OnModelCreating(builder);
        }

    }
}
