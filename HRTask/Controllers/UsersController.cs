using HRTask.Filters;
using HRTask.Models;
using HRTask.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRTask.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IGroupService _groupService;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(IGroupService groupService, UserManager<ApplicationUser> userManager)
        {
            _groupService = groupService;
            _userManager = userManager;
        }
        [AccessFilter("usersView")]

        public IActionResult Index()
        {
         var model=   _userManager.Users.Select(x =>new { x.Id,x.UserName}).ToList();
            return View(model);
        }
        [AccessFilter("usersCreate")]
        public IActionResult Create()
        {
            ViewBag.groups = new SelectList(_groupService.GetAll(), "Id", "Name");
            return View();
        }


        [HttpPost]
        [AccessFilter("usersCreate")]
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
        [AccessFilter("usersDelete")]
        public async Task<IActionResult> Delete(string id)
        {
            var model= await _userManager.FindByIdAsync(id);
            if (model==null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        [AccessFilter("usersDelete")]
        [ActionName("Delete")]
        public async Task<IActionResult> Deleteconfirm(string id)
        {
            var model = await _userManager.FindByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            await _userManager.DeleteAsync(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
