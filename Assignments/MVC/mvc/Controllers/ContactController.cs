using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
namespace mvc.Controllers
{

    public class ContactController : Controller
    {
        private readonly IContactRepository repo;

        public ContactController(IContactRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await repo.GetAllAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contact c)
        {
            if (ModelState.IsValid)
            {
                await repo.CreateAsync(c);
                return RedirectToAction("Index");
            }
            return View(c);
        }

        public async Task<IActionResult> Delete(long id)
        {
            await repo.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}