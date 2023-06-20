using Microsoft.AspNetCore.Mvc;
using MSTARTHiringTask.Data;
using MSTARTHiringTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MSTARTHiringTask.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.accounts = _context.accounts.ToList();
            return View();
        }

        public IActionResult Index(string search)
        {
            IQueryable<Account> accounts = _context.accounts;

            if (!string.IsNullOrEmpty(search))
            {
                accounts = accounts.Where(x =>
                x.User_ID.ToString() == search ||
                x.Account_Number.Contains(search) ||
                x.ID.ToString() == search
                );
            }

            List<Account> query = accounts.ToList();

            return View(accounts);
        }

        // Add Account
        [HttpPost]
        public IActionResult Add(Account account)
        {
            if (!ModelState.IsValid)
            {
                // Validate User ID
                var userExists = _context.users.Any(x => x.ID == account.User_ID);
                if (!userExists)
                {
                    ModelState.AddModelError(nameof(account.User_ID), "Invalid user ID");
                    return View(account);
                }

                // Validate Account Number uniqueness

                var accountUnique = _context.accounts.Any(x =>
                x.Account_Number == account.Account_Number && x.ID != account.ID );

                if (accountUnique)
                {
                    ModelState.AddModelError(nameof(account.Account_Number), "Account number already exists");
                    return View(account);
                }

                // Validate Account Number format (7 digits)
                if (!Regex.IsMatch(account.Account_Number, @"^\d{7}$"))
                {
                    ModelState.AddModelError(nameof(account.Account_Number), "Account number must be 7 digits");
                    return View(account);
                }

                // Validate Balance
                if (account.Balance <= 0)
                {
                    ModelState.AddModelError(nameof(account.Balance), "Balance must be a positive value");
                    return View(account);
                }

                if (account.ID == 0)
                {
                    // add new account
                    _context.accounts.Add(account);
                }
                else
                {
                    // Edit account
                    _context.accounts.Update(account);
                }

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View("Index");
        }

        // Edit Account
        public IActionResult Add(int? id)
        {
            if (id == null)
            {
                // Add new account
                return View(new Account());
            }

            var account = _context.accounts.Find(id);

            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // Delete Account
        public IActionResult Delete(int id)
        {
            var account = _context.accounts.Find(id);

            if (account != null)
            {
                account.Status = (int)UserStatus.Deleted;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
