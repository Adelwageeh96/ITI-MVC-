using Microsoft.AspNetCore.Mvc;
using MVC_Lab.Data;
using MVC_Lab.Models;
using MVC_Lab.ModelViews;

namespace MVC_Lab.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult GetAll()
        {
            return View(_context.employees.Select(e=>
               new EmployeeViewModel
               {
                   Id = e.Id,
                   Name = e.Name,
                   Salary = e.Salary,
                   Email = e.Email,
                   Password = e.Password,
                   Age = e.Age,
               }
            ));
        }
        public IActionResult GetById([FromRoute]int id)
        {
            Employee? employee = new();
            employee= _context.employees.Find(id);
            if(employee is not null) 
            { 
                return View(
                  new EmployeeViewModel
                  {
                      Name = employee.Name,
                      Salary = employee.Salary,
                      Email= employee.Email,
                      Password = employee.Password,
                      Age = employee.Age,
                  }
               );
            }
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(EmployeeViewModel model)
        {
            _context.Add(new Employee
            {
                Name = model.Name,
                Salary = model.Salary,
                Address = model.Address,
                Age = model.Age,
                Email = model.Email,
                Password = model.Password,
                OfficeId = model.OfficeId
            });
            _context.SaveChanges();
            return RedirectToAction("GetAll");
        }

        public IActionResult Edit(int id)
        {
            Employee employee = _context.employees.Find(id);
            return View(new EmployeeViewModel
            {
                Id = id,
                Name = employee.Name,
                Salary = employee.Salary,
                Address = employee.Address,
                Age = employee.Age,
                Email = employee.Email,
                OfficeId = employee.OfficeId
            });

        }

        [HttpPost]
        public IActionResult Edit(int id, EmployeeViewModel model)
        {
            Employee employee = _context.employees.Find(id);
            employee.Address = model.Address;
            employee.Salary = model.Salary;
            employee.Email = model.Email;
            employee.Age = model.Age;
            employee.OfficeId = model.OfficeId;
            employee.Name = model.Name;
            

            _context.SaveChanges();
            return RedirectToAction("GetAll");
        }
        
        public IActionResult Delete(int id)
        {
            Employee employee = _context.employees.Find(id);
            if (employee != null)
            {
                _context.employees.Remove(employee);
                _context.SaveChanges();
            }
            return RedirectToAction("GetAll");
        }
    }
}
