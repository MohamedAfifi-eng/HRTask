using HRTask.Filters;
using HRTask.Models;
using HRTask.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRTask.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _EmployeeService;
        private readonly IEmployeeAttendanceService _attendanceService;

        public EmployeeController(IEmployeeService employeeService, IEmployeeAttendanceService attendanceService)
        {
            _EmployeeService = employeeService;
            _attendanceService = attendanceService;
        }

        [AccessFilter("employeeView")]
        public IActionResult Index()
        {
            ViewBag.name = "";
            var model = _EmployeeService.GetAll();
            return View(model);
        }
        [AccessFilter("employeeView")]
        public IActionResult SearchOnEmployees(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                ViewBag.name = name;
                var model = _EmployeeService.GetAll();
                return View("Index", model);
            }
            else
            {
                ViewBag.name = name;
                var model = _EmployeeService.GetByName(name);
                return View("Index", model);
            }
        }
        [AccessFilter("employeeCreate")]
        public IActionResult CreateNewEmployee()
        {
            return View();
        }
        [AccessFilter("employeeCreate")]
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

                return RedirectToAction("index", "Home");
            }
        }
        [AccessFilter("employeeEdit")]
        public IActionResult Edit(int Id)
        {
            var model = _EmployeeService.Find(Id);
            if (model == null)
            {
                return NotFound();
            }
            return View("CreateNewEmployee", model);
        }
        [AccessFilter("employeeEdit")]
        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            try
            {
                _EmployeeService.Update(emp);
            }
            catch (Exception)
            {

            }
            return RedirectToAction(nameof(Index));
        }
        [AccessFilter("employeeDelete")]
        public IActionResult Delete(int id)
        {
            var model = _EmployeeService.Find(id);
            if (model==null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [AccessFilter("employeeDelete")]
        public IActionResult DeleteEmployee(int id)
        {
            var model = _EmployeeService.Find(id);
            if (model==null)
            {
                return NotFound();
            }
            else
            {
                _EmployeeService.Delete(model);
                return RedirectToAction(nameof(Index));
            }
        }
        [AccessFilter("employee attendanceView")]
        public IActionResult EmployeeAttendance(int Id)
        {
            var model = _attendanceService.GetEmployeeAttendances(Id);
            ViewBag.Id = Id;
            return View(model);
        }
        [AccessFilter("employee attendanceCreate")]
        public IActionResult AddEmployeeAttendance(int empId)
        {
            Models.EmployeeAttendance model = new EmployeeAttendance() { EmployeeId = empId };
            return View(model);
        }
        [HttpPost]
        [AccessFilter("employee attendanceCreate")]
        public IActionResult AddEmployeeAttendance(EmployeeAttendance model)
        {
            if (ModelState.IsValid)
            {
                _attendanceService.Create(model);
            }
            return RedirectToAction(nameof(EmployeeAttendance), new { Id = model.EmployeeId });
        }
        [AccessFilter("employee attendanceDelete")]

        public IActionResult DeleteEmployeeAttendance(int EmpAttendId)
        {
            var model = _attendanceService.Find(EmpAttendId);
            if (model == null)
            {
                return NotFound();
            }
            else
            {

            }
            return View(model);
        }
        [HttpPost]
        [AccessFilter("employee attendanceDelete")]
        public IActionResult ConfirmDeleteEmployeeAttendance(int EmpAttendId)
        {
            var entity = _attendanceService.Find(EmpAttendId);
            if (entity == null)
            {
                return NotFound();
            }
            else
            {
                _attendanceService.Delete(entity);
            }
            return RedirectToAction(nameof(EmployeeAttendance), new { Id = entity.EmployeeId });
        }
    }
}
