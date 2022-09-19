using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Registration.Models;
using Registration.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

using Registration.Models;

namespace Registration.Controllers
{
    public class Employee_RegistrationController : Controller
    {
        private readonly ApplicationDbContext _db;
        public Employee_RegistrationController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            
            IEnumerable<Employee_Registration> obj = _db.Employee_Registrations;
            return View(obj);
        }

       
        //get
        public IActionResult Create()
        {
            Employee_Registration employee_Registration = new();
            IEnumerable <SelectListItem> StateDropDown = _db.States.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.ID.ToString()
            });
           
            ViewBag.StateDropDown = StateDropDown;
          
            
            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee_Registration obj)
        {
            

            if (ModelState.IsValid)
            {
               
                _db.Employee_Registrations.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //get
        //edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var RegistrationFromDb = _db.Employee_Registrations.Find(id);
            // var RegistrationFromDb = _db.Employee_Registrations.GetFirstOrDefault(u => u.Id == id);
            //var RegistrationFromDb = _db.Employee_Registrations.SingleOrDefault(u => u.Id == id);
            if (RegistrationFromDb == null)
            {
                return NotFound();
            }
            return View(RegistrationFromDb);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee_Registration obj)
        {
          
           if (ModelState.IsValid)
            {
                _db.Employee_Registrations.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
             return View(obj);
        }

        //get
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var RegistrationFromDb = _db.Employee_Registrations.Find(id);
            //var categoryFromDbh = _db.Employee_Registrations.GetFirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Employee_Registrations.SingleOrDefault(u => u.Id == id);
            if (RegistrationFromDb == null)
            {
                return NotFound();
            }
            return View(RegistrationFromDb);
        }
        //Post
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Employee_Registrations.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Employee_Registrations.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }




    }
}