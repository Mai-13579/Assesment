using Assesment.Models;
using Assesment.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assesment.Controllers
{
    public class ProjectController : Controller
    {
        private readonly AppDbContext _context;
        public ProjectController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var p=await _context.Projects.Include(x=>x.Tasks)
                .ThenInclude(x=>x.TeamMember).ThenInclude(x=>x.tasks).ToListAsync();
            return View(p);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Project project)
        {
            if (project != null)
            {
                await _context.Projects.AddAsync(project);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var t=await _context.Projects.FindAsync(id);
            return View(t);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Project project)
        {
            if (project != null)
            {
                _context.Projects.Update(project);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var t=await _context.Projects.FirstOrDefaultAsync(x=>x.Id==id);
            return View(t);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Project project)
        {
            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Details(int id,Project project)
        {
            var t= await _context.Projects.FirstOrDefaultAsync(x=>x.Id==id);
            await _context.Projects.ToListAsync();
            await _context.SaveChangesAsync();
            return View(t);
        }

    }
}
