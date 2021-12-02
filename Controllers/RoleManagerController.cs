using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSBD_Sklep.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleManagerController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleManagerController()
        {
            _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
        }
        public RoleManagerController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public ActionResult Index()
        {
            return View(_roleManager.Roles.ToList());
        }
        [HttpGet]
        public ActionResult AddRole(string roleName)
        {
            if (roleName != null)
            {
                _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));
            }
            return RedirectToAction("Index");
        }
    }
}