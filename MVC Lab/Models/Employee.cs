using System.ComponentModel.DataAnnotations;

namespace MVC_Lab.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public double Salary { get; set; }
        public int OfficeId { get; set; }
        public Office Office { get; set; }
        public List<EmployeeProject> EmployeeProjects { get; set; }

    }
}
