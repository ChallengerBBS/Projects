using System;
using System.Globalization;
using System.Linq;
using System.Text;

using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));
            }
        }




        // --- Problem 03 ----
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
              .Select(e => new
              {
                  EmployeeId = e.EmployeeId,
                  FirstName = e.FirstName,
                  MiddleName = e.MiddleName,
                  LastName = e.LastName,
                  JobTitle = e.JobTitle,
                  Salary = e.Salary
              })
              .OrderBy(e => e.EmployeeId)
              .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // --- Problem 04 ----

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)

        {
            var sb = new StringBuilder();

            var employees = context
                               .Employees
                               .Select(e => new
                               {
                                   FirstName = e.FirstName,
                                   Salary = e.Salary
                               })
                               .Where(e => e.Salary > 50000)
                               .OrderBy(e => e.FirstName);

            foreach (var empl in employees)
            {
                sb.AppendLine($"{empl.FirstName} - {empl.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // --- Problem 05 ----

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    DepartmentName = e.Department.Name,
                    Salary = e.Salary,
                    FirstName = e.FirstName,
                    LastName = e.LastName
                })
                .Where(e => e.DepartmentName == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from Research and Development - ${employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();

        }

        // --- Problem 06 ----


        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var sb = new StringBuilder();

            Address address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };


            Employee nakov = context
                            .Employees
                            .First(e => e.LastName == "Nakov");

            nakov.Address = address;

            context.SaveChanges();


            var addressTexts = context
                              .Employees
                              .OrderByDescending(e => e.AddressId)
                              .Select(e => new
                              {
                                  e.Address.AddressText
                              })
                              .Take(10)
                              .ToList();

            foreach (var at in addressTexts)
            {

                sb.AppendLine(at.AddressText);
            }


            return sb.ToString().TrimEnd();

        }

        // --- Problem 07 ----


        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            

            var employees = context
                                .Employees
                                .Where(e => e.EmployeesProjects
                                           .Any(p => p.Project.StartDate.Year >= 2001 &&
                                                   p.Project.StartDate.Year <= 2003))
                                .Select(e => new
                                {
                                    EmployeeName = e.FirstName + " " + e.LastName,
                                    ManagerName = e.Manager.FirstName + " " + e.Manager.LastName,
                                    Projects = e.EmployeesProjects
                                                .Select(p => new
                                                {
                                                    ProjectName = p.Project.Name,
                                                    StartDate = p.Project.StartDate,
                                                    EndDate = p.Project.EndDate
                                                })
                                                .ToList()

                                })
                                .Take(10)
                                .ToList();


            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.EmployeeName} - Manager: {employee.ManagerName}");
                foreach (var project in employee.Projects)
                {
                    var startDate = project.StartDate
                                            .ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

                    var endDate = project.EndDate == null ?
                                           "not finished" :
                                  project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);



                    sb.AppendLine($"--{project.ProjectName} - {startDate} - {endDate}");
                }
            }


            return sb.ToString().TrimEnd();

        }


        // --- Problem 08 ----


        public static string GetAddressesByTown(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var addresses = context
                               .Addresses
                               .Select(a => new
                               {
                                   EmployeesCount = a.Employees.Count,
                                   TownName = a.Town.Name,
                                   AddressText = a.AddressText
                               })
                               .OrderByDescending(a => a.EmployeesCount)
                               .ThenBy(a => a.TownName)
                               .ThenBy(a => a.AddressText)
                               .Take(10)
                               .ToList();
            foreach (var a in addresses)
            {
                sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeesCount} employees");
            }


            return sb.ToString().TrimEnd();
        }

        // --- Problem 09 ----

        public static string GetEmployee147(SoftUniContext context)
        {
            var employees = context.Employees
               .Where(e => e.EmployeeId == 147)
               .Select(e => new
               {
                   FirstName = e.FirstName,
                   LastName = e.LastName,
                   JobTitle = e.JobTitle,
                   ProjectsNames = e.EmployeesProjects
                   .Select(p => new
                   {
                       Name = p.Project.Name
                   })
                   .OrderBy(p => p.Name)
                   .ToList()
               })
               .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

                foreach (var project in employee.ProjectsNames)
                {
                    sb.AppendLine(project.Name);
                }
            }

            return sb.ToString().TrimEnd();
        }


        // --- Problem 10 ----


        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                 .Where(d => d.Employees.Count() > 5)
                 .OrderBy(d => d.Employees.Count())
                 .ThenBy(d => d.Name)
                 .Select(d => new
                 {
                     DepartmentName = d.Name,
                     ManagerFirstName = d.Manager.FirstName,
                     ManagerLastName = d.Manager.LastName,
                     Employees = d.Employees
                     .Select(e => new
                     {
                         EmployeeFirstName = e.FirstName,
                         EmployeeLastName = e.LastName,
                         JobTitile = e.JobTitle
                     })
                     .OrderBy(e => e.EmployeeFirstName)
                     .ThenBy(e => e.EmployeeLastName)
                     .ToList()
                 })
                 .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.DepartmentName} - " +
                    $"{department.ManagerFirstName} {department.ManagerLastName}");

                foreach (var employee in department.Employees)
                {
                    sb.AppendLine($"{employee.EmployeeFirstName} {employee.EmployeeLastName} - " +
                        $"{employee.JobTitile}");
                }
            }

            return sb.ToString().TrimEnd();
        }


        // --- Problem 11 ----


        public static string GetLatestProjects(SoftUniContext context)

        {
            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new
                {
                    Name = p.Name,
                    Description = p.Description,
                    StartDate = p.StartDate
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var project in projects)
            {
                sb.AppendLine($"{project.Name}");
                sb.AppendLine($"{project.Description}");
                sb.AppendLine($"{project.StartDate.ToString("M/d/yyyy h:mm:ss tt")}");
            }

            return sb.ToString().TrimEnd();
        }



        // --- Problem 12 ----

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context
                               .Employees
                               .Where(e => e.Department.Name == "Engineering" ||
                                           e.Department.Name == "Tool Design" || e.Department.Name == "Marketing" ||
                                           e.Department.Name == "Information Services");

            foreach (var e in employees)
            {
                e.Salary *= 1.12m;


            }

            context.SaveChanges();

            var employeesToPrint = employees
                                   .Select(e => new
                                   {
                                       e.FirstName,
                                       e.LastName,
                                       e.Salary
                                   })
                                   .OrderBy(e => e.FirstName)
                                   .ThenBy(e => e.LastName);

            foreach (var e in employeesToPrint)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})");
            }



            return sb.ToString().TrimEnd();
        }


        // --- Problem 13 ----

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context
                             .Employees
                             .Where(e => e.FirstName.StartsWith("Sa"))
                             .Select(e => new
                             {
                                 e.FirstName,
                                 e.LastName,
                                 e.JobTitle,
                                 e.Salary
                             })
                             .OrderBy(e => e.FirstName)
                             .ThenBy(e => e.LastName)
                             .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{ employee.FirstName} { employee.LastName} - { employee.JobTitle} - (${ employee.Salary:F2})");
            }



            return sb.ToString().TrimEnd();
        }


        // --- Problem 14 ----


        public static string DeleteProjectById(SoftUniContext context)
        {
            var targetProject = context.Projects.FirstOrDefault(p => p.ProjectId == 2);
            var targetEmployeeProject = context.EmployeesProjects.FirstOrDefault(ep => ep.ProjectId == 2);

            context.EmployeesProjects.Remove(targetEmployeeProject);
            context.Projects.Remove(targetProject);

            context.SaveChanges();

            var projects = context.Projects
                .Select(p => new
                {
                    p.Name
                })
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
            }

            return sb.ToString().TrimEnd();
        }


        // --- Problem 15 ----


        public static string RemoveTown(SoftUniContext context)
        {
            var employees = context.Employees
               .Where(e => e.Address.Town.Name == "Seattle")
               .ToList();

            foreach (var employee in employees)
            {
                employee.AddressId = null;
                context.SaveChanges();
            }

            var towns = context.Towns
                .Where(t => t.Name == "Seattle")
                .ToList();

            var addresses = context.Addresses
                .Where(a => a.Town.Name == "Seattle")
                .ToList();

            int count = addresses.Count();

            foreach (var address in addresses)
            {
                context.Addresses.Remove(address);
                context.SaveChanges();
            }

            foreach (var town in towns)
            {
                context.Towns.Remove(town);
                context.SaveChanges();
            }

            return $"{count} addresses in Seattle were deleted";

        }

    }
}
