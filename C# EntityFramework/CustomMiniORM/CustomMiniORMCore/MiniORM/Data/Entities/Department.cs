using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MiniORM.Data.Entities
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]

        public string Name { get; set; }

        public ICollection<Employee> Employees { get; }
    }
}
