using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Prac.BasicCrud
{
    internal class MyDBContext : DbContext
    {
        public DbSet<EmployeeModel> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=DESKTOP-O0RHDOB\SQLEXPRESS2021;
                Database=EFCore_MyconsoleApp;
                Trusted_Connection=True;
                TrustServerCertificate=True;
                MultipleActiveResultSets=true");
        }
    }
}
