using BinanceMonitor.Core.Responces;
using BinanceMonitor.Core.Responces.Symbols;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinanceMonitor.Core
{
    class ApplicationContext:DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BinanceMonitorDb;Trusted_Connection=True;");
        }
        public DbSet<TradeSymbol> Symbols { get; set; }

    }
}
