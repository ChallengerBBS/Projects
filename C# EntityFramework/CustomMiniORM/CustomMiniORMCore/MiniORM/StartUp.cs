using MiniORM.Data.Entities;

namespace MiniORM
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=.;Database=MiniORM;Integrated Security=true";
            var context = new SoftUniDbContext(connectionString);
            context.Employees.Add(new Employee
            {
                FirstName = "Gosho",
                LastName = "Stamatov",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true
            });

            var employee = context.Employees.Last();
            employee.FirstName = "Modified";
            context.SaveChanges();
        }
    }
}
