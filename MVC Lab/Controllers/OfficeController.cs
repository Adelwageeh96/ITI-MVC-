using Microsoft.AspNetCore.Mvc;
using MVC_Lab.Data;
using MVC_Lab.Models;
using MVC_Lab.ViewModels;


namespace MVC_Lab.Controllers
{
    public class OfficeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OfficeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult GetAll()
        {
            return View(_context.Offices.Select(e =>
               new OfficeViewModel
               {
                   Id = e.Id,
                   Name = e.Name,
                   Location= e.Location
               }
            ));
        }
        public IActionResult GetById([FromRoute] int id)
        {
            Office? office = new();
            office = _context.Offices.Find(id);
            if (office is not null)
            {
                return View(
                  new OfficeViewModel
                  {
                      Name = office.Name,
                      Location = office.Location
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
        public IActionResult Add(OfficeViewModel model)
        {
            _context.Add(new Office
            {
                Name = model.Name,
                Location = model.Location
            });
            _context.SaveChanges();
            return RedirectToAction("GetAll");
        }

        public IActionResult Edit(int id)
        {
            Office office= _context.Offices.Find(id);
            return View(new OfficeViewModel
            {
                Id = id,
                Name = office.Name,
                Location = office.Location
            });

        }

        [HttpPost]
        public IActionResult Edit(int id, OfficeViewModel model)
        {
            Office office = _context.Offices.Find(id);
            office.Name = model.Name;
            office.Location = model.Location;
            _context.SaveChanges();
            return RedirectToAction("GetAll");
        }

        public IActionResult Delete(int id)
        {
            Office office= _context.Offices.Find(id);
            if (office != null)
            {
                _context.Offices.Remove(office);
                _context.SaveChanges();
            }
            return RedirectToAction("GetAll");
        }

    }
}
