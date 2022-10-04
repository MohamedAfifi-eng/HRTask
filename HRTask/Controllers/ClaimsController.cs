using HRTask.Filters;
using HRTask.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace HRTask.Controllers
{
    public class ClaimsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ClaimsController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        [AccessFilter("progressView")]
        public IActionResult Index()
        {

                return Content("Accepted");
        }
        public IActionResult edit()
        {
            return Content("ok");
        }
    }
}
