using System;
using System.Collections.Generic;
using System.Text;
using Common.DTO;
using Microsoft.EntityFrameworkCore;



namespace DataAccess.Extensions
{
    //Following this article
    //https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-3.1
    public class FCTContext : DbContext
    {
        public FCTContext(DbContextOptions<FCTContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
        }
    }
}
