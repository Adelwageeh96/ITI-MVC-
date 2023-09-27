using System.ComponentModel.DataAnnotations;

namespace MVC_Lab.ViewModels
{
    public class EmployeeViewModel
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(10, 100)]
        public int Age { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [RegularExpression("^(?=.*[A-Za-z])(?=.*[0-9])[A-Za-z0-9]{8,}$")]
        public string? Password { get; set; }

        public string Address { get; set; }
        [Range(3000, 100000)]
        public double Salary { get; set; }
        public int OfficeId { get; set; }
    }
}
