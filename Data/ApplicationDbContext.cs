using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Console;

namespace api.Data
{
    public class ApplicationDbContext : DbContext
    {

        public static readonly ILoggerFactory loggerFactory = new LoggerFactory();
        private readonly IConfiguration configuration;

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Consumer> Consumers { get; set; }
        public DbSet<Address> Address { get; set; }

        public ApplicationDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory).UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        }







    }
}


