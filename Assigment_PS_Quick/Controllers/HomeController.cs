using Assigment_PS_Quick.Db_con;
using Assigment_PS_Quick.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Assigment_PS_Quick.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContexts _DbConn;

        public HomeController(DataContexts DbConn)
        {
            _DbConn = DbConn;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {

             

            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {


            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public  IActionResult Login(LoginData ld)
        {
             

            var res = _DbConn.Logins.Where(m => m.email == ld.email).FirstOrDefault();

            if (res == null)
            {
                TempData["invalid"] = "Email is not foumd";
            }
            else
            {
                if (res.email == ld.email && res.password== ld.password)
                {

                    var claims = new[] { new Claim(ClaimTypes.Role, res.role), new Claim(ClaimTypes.Email, res.email) };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true
                    };

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), authProperties);
                    HttpContext.Session.SetString("Role", ld.role);
                    HttpContext.Session.SetString("Name", ld.name);

                    //var user =  _DbConn.Logins.Find(ld.role);
                    //if ( )
                    //{
                    //    return RedirectToAction("Index", "Admin");
                    //}
                    //else if (await _signInManager.UserManager.IsInRoleAsync(user, "Department"))
                    //{
                    //    return RedirectToAction("Index", "Department");
                    //}
                    //else
                    //{
                    //    return RedirectToAction("Index", "Home");
                    //}

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.inv = "Wrong Email Id or password";
                    return View();
                }
            }

            return View();
        }


        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);


            return View("Login");

        }

        [Authorize(Roles = "Admin , Department")]
        [HttpGet]
        public IActionResult AddDepartment()
        {
            return View();
        }

        [Authorize(Roles = "Admin , Department")]
        [HttpPost]
        public IActionResult AddDepartment(Department dm)
        {
            string msg = string.Empty;

            try
            {
                if (dm.id == 0)
                {
                    _DbConn.Departments.Add(dm);
                    _DbConn.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    _DbConn.Entry(dm).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _DbConn.SaveChanges();
                    return RedirectToAction("Index");
                } 
            }
            catch(Exception ex )
            {
                msg= ex.Message;
                throw;
            }

        }


        [Authorize(Roles = "Admin , Section")]
        [HttpGet]
        public IActionResult AddSection()
        {
            return View();
        }

        [Authorize(Roles = "Admin , Section")]
        [HttpPost]
        public IActionResult AddSection(Section s)
        {

            string msg = string.Empty;

            try
            {
                if (s.id == 0)
                {
                    _DbConn.Sections.Add(s);
                    _DbConn.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    _DbConn.Entry(s).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _DbConn.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                throw;
            }
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
