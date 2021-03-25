using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentHandler.Models
{
    public class PaymentDBContext : DbContext
    {
        public DbSet<Payment> Payments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer( @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PaymentDB;Integrated Security=True");
        }
    }
}
