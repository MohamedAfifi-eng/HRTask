using HRTask.Filters;
using HRTask.Models;
using HRTask.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HRTask.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly string[] daysoff = new string[] { "friday", "saturday","الجمعة" ,"السبت"};
        private readonly IEmployeeService _EmployeeService;
        private readonly IEmployeeAttendanceService _attendanceService;
        private readonly IAnnualVacationService _annualVacationService;

        public EmployeeController(IEmployeeService employeeService, IEmployeeAttendanceService attendanceService, IAnnualVacationService annualVacationService)
        {
            _EmployeeService = employeeService;
            _attendanceService = attendanceService;
            _annualVacationService = annualVacationService;
        }

        #region Employee

        [AccessFilter("employeeView")]
        public IActionResult Index()
        {
            ViewBag.name = "";
            IEnumerable<Employee> model = _EmployeeService.GetAll();
            return View(model);
        }
        [AccessFilter("employeeView")]
        public IActionResult SearchOnEmployees(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                ViewBag.name = name;
                IEnumerable<Employee> model = _EmployeeService.GetAll();
                return View("Index", model);
            }
            else
            {
                ViewBag.name = name;
                IEnumerable<Employee> model = _EmployeeService.GetByName(name);
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
            Employee? model = _EmployeeService.Find(Id);
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
            Employee? model = _EmployeeService.Find(id);
            if (model == null)
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
            Employee? model = _EmployeeService.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            else
            {
                _EmployeeService.Delete(model);
                return RedirectToAction(nameof(Index));
            }
        }
        #endregion




        #region EmployeeAttendance

        public IActionResult AllEmployeeAttendance(DateTime startdate, DateTime enddate)
        {
            List<EmployeeAttendance> model = new List<EmployeeAttendance>();
            DateTime now=DateTime.Now;
            if (startdate==new DateTime()|| startdate==null)
            {
                startdate = new DateTime(now.Year, now.Month, 1);
                enddate = now.AddMonths(1).AddDays(-now.Day);
            }
            model = _attendanceService.GetAttendancesWithEmployeeInfo(startdate, enddate).ToList();

            return View(model);
        }
        [AccessFilter("employee attendanceView")]
        public IActionResult EmployeeAttendance(int Id)
        {
            var emp = _EmployeeService.Find(Id);
            if (emp==null)
            {
                return NotFound();
            }
            List<EmployeeAttendance> model = _attendanceService.GetEmployeeAttendances(Id).ToList();
            ViewBag.Id = Id;
            ViewBag.empname= emp.Name;
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
                var day = model.TimeOfAttendance.Value.ToString("dddd").ToLower();
                if (!daysoff.Contains(day))
                {
                   var isoff= _annualVacationService.GetAll().Any(x => x.Date.ToString("dd/MM/yyyy") == model.TimeOfAttendance.Value.ToString("dd/MM/yyyy"));
                    if (!isoff)
                    {
                        var employee=_EmployeeService.Find(model.EmployeeId);
                        int late =model.TimeOfAttendance.Value.Hour - Convert.ToDateTime(employee.StartTime).Hour;
                        model.discount = 0;
                        if (late>0)
                        {
                            model.discount = employee.discount * late;
                        }
                        var workhours = Convert.ToDateTime(employee.EndTime).Hour - Convert.ToDateTime(employee.StartTime).Hour;
                        var workedHours = (model.TimeOfLeave.Value - model.TimeOfAttendance.Value).Hours;
                        if (workhours- workedHours>0)
                        {
                            model.discount += (employee.discount * (workhours - workedHours));
                        }
                        if (workhours - workedHours < 0)
                        {
                            model.calculatedPonus = 0;
                            model.calculatedPonus += (employee.ExtraTime * (workedHours - workhours));
                        }
                        _attendanceService.Create(model);

                    }
                }
            }
            return RedirectToAction(nameof(EmployeeAttendance), new { Id = model.EmployeeId });
        }
        [AccessFilter("employee attendanceDelete")]

        public IActionResult DeleteEmployeeAttendance(int EmpAttendId)
        {
            EmployeeAttendance? model = _attendanceService.Find(EmpAttendId);
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
            EmployeeAttendance? entity = _attendanceService.Find(EmpAttendId);
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

        #endregion

        #region Salaries

        public IActionResult EmployeesSalary(DateTime date)
        {
            if (date==new DateTime())
            {
                date = DateTime.Now;
            }
            DateTime dateTime = new DateTime(date.Year, date.Month, 1);

            int DaysOfMonth= dateTime.AddMonths(1).AddDays(-1).Day;
            var daysAnual = _annualVacationService.GetAll().Where(x=>x.Date>=dateTime&&x.Date<= dateTime.AddMonths(1).AddDays(-1)).ToList();
            int WorkingDaysWithoutdaysoff=0;
            for (int i = 0; i < DaysOfMonth; i++)
            {
               Boolean isAnual = daysAnual.Any(x => x.Date == dateTime.AddDays(i));
               Boolean isOff= daysoff.Contains( dateTime.AddDays(i).ToString("dddd"));
                if (!isAnual && !isOff)
                {
                    WorkingDaysWithoutdaysoff++;
                }
            }
            ViewBag.WorkingDaysCount = WorkingDaysWithoutdaysoff;
            var model = _EmployeeService.GetEmployeesWithAttendance().ToList();
            return View(model);
        }
        #endregion
    }
}
