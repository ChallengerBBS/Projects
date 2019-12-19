﻿namespace MiniORM.Data.Entities
{
    using Entities;
    public class SoftUniDbContext 
    {
        public SoftUniDbContext(string connectionString)
            : base (connectionString)
        {

        }

        public DbSet<Employee> Employees { get; }
        public DbSet<Department> Departments { get; }

        public DbSet<Project> Projects { get; }

        public DbSet<EmployeeProjects> EmployeesProjects { get; }

    }
}
