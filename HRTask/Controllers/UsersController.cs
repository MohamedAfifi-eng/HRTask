using HRTask.Models;
using HRTask.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRTask.Controllers
{
    public class UsersController : Controller
    {
        private readonly IGroupService _groupService;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(IGroupService groupService, UserManager<ApplicationUser> userManager)
        {
            _groupService = groupService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            ViewBag.groups = new SelectList(_groupService.GetAll(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ApplicationUser model)
        {
            if (model.Email == null || model.GroupId_FK == null)
            {
                ViewBag.groups = new SelectList(_groupService.GetAll(), "Id", "Name");
                return View(model);
            }
            if (await _userManager.FindByEmailAsync(model.Email) != null)
            {
                ViewBag.groups = new SelectList(_groupService.GetAll(), "Id", "Name");
                ModelState.AddModelError("Email", "الايميل موجود من قبل");
                return View(model);
            }
            model.EmailConfirmed = true;
            model.PhoneNumberConfirmed = false;
            model.TwoFactorEnabled = false;
            model.AccessFailedCount = 0;
            model.UserName = model.Email;
            await _userManager.CreateAsync(model, model.Email);
            return RedirectToAction("index", "Home");

        }
    }
}
