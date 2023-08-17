using Microsoft.EntityFrameworkCore;
using ProjectX.Data.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ProjectX.Data
{


    public class DataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            // Configure relationships, constraints, etc. using Fluent API or data annotations
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Salary)
                .WithOne(s => s.Employee)
                .HasForeignKey<Salary>(s => s.EmployeeId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Attendances)
                .WithOne(a => a.Employee)
                .HasForeignKey(a => a.EmployeeId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.LeaveRequests)
                .WithOne(lr => lr.Employee)
                .HasForeignKey(lr => lr.EmployeeId);

         }
    }

}
