using Microsoft.EntityFrameworkCore;
using SmartDataTest2.EF.FluentApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDataTest2.EF.FluentApi
{
    internal class EF_FluentApiDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<OfficeFloor> OfficeFloor { get; set; }
        public DbSet<SystemDetail> SystemDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"
            Server=DESKTOP-O0RHDOB\SQLEXPRESS2021;
            Database=EF_FluentApiDB;
            Trusted_Connection=true;
            TrustServerCertificate=true;
            MultipleActiveResultSets=true;
            ");
        }

        // [Obsolete]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Table Level Constraints

            // 1. Primary Key
            modelBuilder.Entity<OfficeFloor>()
                            .ToTable("OfficeFloor1234")
                            .HasKey(floor => floor.FloorId);

            modelBuilder.Entity<Employee>()
                            .HasKey(emp => emp.Emp_Id);
            
            //OR
            modelBuilder.Entity<Employee>()
                            .HasKey("Emp_Id");

            modelBuilder.Entity<SystemDetail>()
                            .HasKey(sd => sd.SysDetailId);


            // 2. This is how you can add check constraint 
            modelBuilder.Entity<Employee>()
                        .HasCheckConstraint("CheckName", "Emp_name Like 'a%'");


            // 3. To apply unique constraint 
            // (for giving unique constraint, we add a constraint on table level)
            modelBuilder.Entity<Employee>()
                        .HasIndex(emp => emp.Emp_Name)
                        .IsUnique();


            // 4. Define Relationships
            // This is how you can define relationships
            // Define one-to-many relationship between OfficeFloor and Employee
            modelBuilder.Entity<OfficeFloor>()
                                .HasMany(of => of.Employees)
                                .WithOne(e => e.OfficeFloor)
                                .HasForeignKey(e => e.OfficeFloorID);

            // Defines one-to-one relationship between Employee and SystemDetail
            modelBuilder.Entity<Employee>()
                        .HasOne(emp => emp.SystemDetail)
                        .WithOne(sys => sys.Employee)
                        .HasForeignKey<SystemDetail>(sys => sys.EmployeeId);



            // Column Level Constraints
            modelBuilder.Entity<Employee>()
                        .Property(emp => emp.Emp_Name)
                        .HasColumnName("MyOwnName")
                        .HasColumnType("varchar(200)")
                        .HasDefaultValue("Guest")
                        .IsRequired();


            // To give identity to a Column
            modelBuilder.Entity<Employee>()
                        .Property(emp => emp.Emp_Id)
                        .ValueGeneratedOnAdd()
                        .UseIdentityColumn(100, 5);

        }
    }
}
