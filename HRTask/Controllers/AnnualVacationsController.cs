using HRTask.Filters;
using HRTask.Models;
using HRTask.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRTask.Controllers
{
    [Authorize]
    public class AnnualVacationsController : Controller
    {
        private readonly IAnnualVacationService _annualVacationService;

        public AnnualVacationsController(IAnnualVacationService annualVacationService)
        {
            _annualVacationService = annualVacationService;
        }

        [AccessFilter("annual vecationView")]
        public IActionResult Index()
        {
           var model= _annualVacationService.GetAll();
            return View(model);
        }
        [AccessFilter("annual vecationCreate")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AccessFilter("annual vecationCreate")]
        public IActionResult Create(AnnualVacation model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                _annualVacationService.Create(model);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
