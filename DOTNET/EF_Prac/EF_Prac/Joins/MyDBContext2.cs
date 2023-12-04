using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Prac.Joins
{
    internal class MyDBContext2 : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=DESKTOP-O0RHDOB\SQLEXPRESS2021;
                  Database=EFCore_MyDB;
                  Trusted_Connection=true;
                  TrustServerCertificate=true;
                  MultipleActiveResultSets=true
                "
            );
        }
    }
}
