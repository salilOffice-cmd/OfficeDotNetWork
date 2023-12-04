using AssessmentTest1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentTest1
{
    internal class DeliveryManagementSystemContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<CustomerInfo> CustomerInfos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"
            Server=DESKTOP-O0RHDOB\SQLEXPRESS2021;
            Database=DeliveryManagementSystem;
            Trusted_Connection=true;
            TrustServerCertificate=true;
            MultipleActiveResultSets=true;
            ");
        }


    }
}
