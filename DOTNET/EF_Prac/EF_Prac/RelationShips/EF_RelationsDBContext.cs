﻿using EF_Prac.RelationShips;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Prac.RelationShips
{
    internal class EF_RelationsDBContext : DbContext
    {
        public DbSet<OfficeFloor> Floors { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<SystemDetail> SystemDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=DESKTOP-O0RHDOB\SQLEXPRESS2021;
                Database=EF_RelationsDB;
                Trusted_Connection=True;
                TrustServerCertificate=True;
                MultipleActiveResultSets=true");
        }
    }
}
