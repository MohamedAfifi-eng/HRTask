using HRTask.Models;
using HRTask.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRTask.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _EmployeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _EmployeeService = employeeService;
        }

        public IActionResult Index()
        {
            var model= _EmployeeService.GetAll();
            return View(model);
        }
        public IActionResult CreateNewEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateNewEmployee(Employee emp)
        {
            if (!ModelState.IsValid)
            {
                return View(emp);
            }
            if (_EmployeeService.GetByNtionalId(emp.NationalId) != null)
            {
                ModelState.AddModelError("NationalId", "الرقم القومي مسجل من قبل");
                return View(emp);
            }
            else
            {
                _EmployeeService.Create(emp);

                return RedirectToAction("index","Home");
            }
        }
    }
}
