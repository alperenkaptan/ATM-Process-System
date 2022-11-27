﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication2.Entities;

namespace WebApplication2.Context
{
    public class AtmDBContext : DbContext
    {
        public AtmDBContext(DbContextOptions<AtmDBContext> options)
        : base(options)
        {

        }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerAccount>().Property(tn => tn.TransactionNumber).ValueGeneratedOnAdd();

            #region seedwork
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    CustomerName = "testUser",
                    CustomerPassword = "testPassword",
                    CustomerEmail = "alperen9792@gmail.com"
                }
            );
            modelBuilder.Entity<CustomerAccount>().HasData(
                new CustomerAccount
                {
                    CustomerId = 1,
                    CustomerAccountId = Guid.NewGuid(),
                    Money = 100.00,
                    TransactionDate = DateTime.Now,
                    TransactionNumber = 10000
                }
            );
            modelBuilder.Entity<CustomerAccount>().HasData(
                new CustomerAccount
                {
                    CustomerId = 1,
                    CustomerAccountId = Guid.NewGuid(),
                    Money = -25.00,
                    TransactionDate = DateTime.Now,
                    TransactionNumber = 10001
                }
            );
            #endregion
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("AtmDB");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
