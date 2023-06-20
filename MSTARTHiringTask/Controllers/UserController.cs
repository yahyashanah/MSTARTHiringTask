using Microsoft.AspNetCore.Mvc;
using MSTARTHiringTask.Data;
using MSTARTHiringTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSTARTHiringTask.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.users = _context.users.ToList();
            return View();
        }
        // Search User
        public IActionResult Search(string search)
        {
            IQueryable<User> query = _context.users;

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x =>
                x.Username.Contains(search) || 
                x.Email.Contains(search) ||
                x.ID.ToString() == search
                );
            }

            List<User> users = query.ToList();
            
            return View(users);
        }


        // Add User
        [HttpPost]
        public IActionResult Add(User user)
        {
            if (!ModelState.IsValid)
            {
                if (user.ID == 0)
                {
                    // add new user
                    _context.users.Add(user);
                }
                else
                {
                    // Edit user
                    _context.users.Update(user);
                }

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View("Index");
        }

        // Edit User
        public IActionResult Add(int? id)
        {
            if (id == null)
            {
                // Add new user
                return View(new User());
            }

            var user = _context.users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // Delete User
        public IActionResult Delete(int id)
        {
            var user = _context.users.Find(id);

            if (user != null)
            {
                user.Status = (int)UserStatus.Deleted;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}
