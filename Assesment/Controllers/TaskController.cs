using Assesment.Models;
using Assesment.Models.Entities;
using Assesment.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assesment.Controllers
{
    public class TaskController : Controller
    {
        private readonly AppDbContext _context;
        public TaskController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var t=await _context.Tasks.Include(x=>x.TeamMember).ToListAsync();
            return View(t);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
         var t=await _context.Tasks.FindAsync(id);
            var tn = await _context.Projects.ToListAsync();
            var tm=await _context.TeamMembers.ToListAsync();

            vmViewModel v = new vmViewModel()
            {
                projects = tn,
                members = tm


            };
            return View(v);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(task tasks)
        {
            var tn = await _context.Projects.ToListAsync();
            var tm = await _context.TeamMembers.ToListAsync();

            vmViewModel v = new vmViewModel()
            {
                projects=tn,
                members=tm
               
            };
            return RedirectToAction("Index");
        }
        
    }
}
