using HRTask.Filters;
using HRTask.Models;
using HRTask.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRTask.Controllers
{
    [Authorize]
    public class GroupsController : Controller
    {
        private readonly IScreenService _screenService;
        private readonly IGroupService _groupService;
        public GroupsController(IScreenService screenService, IGroupService groupService)
        {
            _screenService = screenService;
            _groupService = groupService;
        }
        [AccessFilter("groupsView")]
        public IActionResult Index()
        {
            var model = _groupService.GetAll();
            return View(model);
        }

        [AccessFilter("groupsCreate")]
        public IActionResult Create()
        {
            ViewBag.screens= _screenService.GetAll().ToList();
            return View();
        }


        [HttpPost]
        [AccessFilter("groupsCreate")]
        public IActionResult Create(Group group)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.screens = _screenService.GetAll().ToList();
                return View(group);
            }
            if (_groupService.GetByName(group.Name)!=null)
            {
                ViewBag.screens = _screenService.GetAll().ToList();
                ModelState.AddModelError("Name", "إسم الجروب موجود من  قبل");
                return View(group);
            }
            _groupService.Create(group);
            return RedirectToAction(nameof(Index));
        }
    }
}
