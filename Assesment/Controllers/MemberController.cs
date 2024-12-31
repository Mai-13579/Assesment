using Assesment.Models.ViewModel;
using Assesment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assesment.Models.Entities;

namespace Assesment.Controllers
{
    public class MemberController : Controller
    {
        private readonly AppDbContext _context;
        public MemberController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var t = await _context.TeamMembers.ToListAsync();
            return View(t);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var t = await _context.TeamMembers.FindAsync(id);
           

           
            return View(t);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TeamMember member)
        {
            var tn = await _context.Projects.ToListAsync();
            var tm = await _context.TeamMembers.ToListAsync();

            vmViewModel v = new vmViewModel()
            {
                projects = tn,
                members = tm


            };
            return RedirectToAction("Index");
        }

    }
}
