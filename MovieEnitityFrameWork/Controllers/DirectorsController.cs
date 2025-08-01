using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieEnitityFrameWork.Data;
using MovieEnitityFrameWork.Models;

namespace MovieEnitityFrameWork.Controllers
{
    public class DirectorsController : Controller
    {
        private readonly MyDbContext _dbcontext;

        public DirectorsController(MyDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<IActionResult> Index()
        {
            var directors = await _dbcontext.Directors.Include(d => d.Movies).ToListAsync();
            return View(directors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Director Director)
        {

            _dbcontext.Directors.Add(Director);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
