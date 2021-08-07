using EnergyCompany.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnergyCompany.Data
{
    public class EnergyCompanyContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<MeterReading> MeterReadings { get; set; }

        public EnergyCompanyContext(DbContextOptions<EnergyCompanyContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }

    public static class EnergyCompanyContextSeeder
    {
        public static void Seed(EnergyCompanyContext context)
        {
            context.Database.EnsureCreated();

            if (context.Accounts.Any())
            {
                return;
            }

            var accounts = new Account[]
            {
                new Account() { AccountId = 2344, FirstName = "Tommy", LastName = "Test" },
                new Account() { AccountId = 2233, FirstName = "Barry", LastName = "Test" },
                new Account() { AccountId = 8766, FirstName = "Sally", LastName = "Test" },
                new Account() { AccountId = 2345, FirstName = "Jerry", LastName = "Test" },
                new Account() { AccountId = 2346, FirstName = "Ollie", LastName = "Test" },
                new Account() { AccountId = 2347, FirstName = "Tara", LastName = "Test" },
                new Account() { AccountId = 2348, FirstName = "Tammy", LastName = "Test" },
                new Account() { AccountId = 2349, FirstName = "Simon", LastName = "Test" },
                new Account() { AccountId = 2350, FirstName = "Colin", LastName = "Test" },
                new Account() { AccountId = 2351, FirstName = "Gladys", LastName = "Test" },
                new Account() { AccountId = 2352, FirstName = "Greg", LastName = "Test" },
                new Account() { AccountId = 2353, FirstName = "Tony", LastName = "Test" },
                new Account() { AccountId = 2355, FirstName = "Arthur", LastName = "Test" },
                new Account() { AccountId = 2356, FirstName = "Craig", LastName = "Test" },
                new Account() { AccountId = 6776, FirstName = "Laura", LastName = "Test" },
                new Account() { AccountId = 4534, FirstName = "JOSH", LastName = "TEST" },
                new Account() { AccountId = 1234, FirstName = "Freya", LastName = "Test" },
                new Account() { AccountId = 1239, FirstName = "Noddy", LastName = "Test" },
                new Account() { AccountId = 1240, FirstName = "Archie", LastName = "Test" },
                new Account() { AccountId = 1241, FirstName = "Lara", LastName = "Test" },
                new Account() { AccountId = 1242, FirstName = "Tim", LastName = "Test" },
                new Account() { AccountId = 1243, FirstName = "Graham", LastName = "Test" },
                new Account() { AccountId = 1244, FirstName = "Tony", LastName = "Test" },
                new Account() { AccountId = 1245, FirstName = "Neville", LastName = "Test" },
                new Account() { AccountId = 1246, FirstName = "Jo", LastName = "Test" },
                new Account() { AccountId = 1247, FirstName = "Jim", LastName = "Test" },
                new Account() { AccountId = 1248, FirstName = "Pam", LastName = "Test" },
            };

            context.Accounts.AddRange(accounts);

            context.SaveChanges();
        }
    }
}
