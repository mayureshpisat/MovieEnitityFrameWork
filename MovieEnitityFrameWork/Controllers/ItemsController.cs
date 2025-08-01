using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieEnitityFrameWork.Data;
using MovieEnitityFrameWork.Models;

namespace MovieEnitityFrameWork.Controllers
{
    public class ItemsController: Controller
    {

        private readonly MyDbContext _dbcontext;

        public ItemsController(MyDbContext dbcontext)
        {
            _dbcontext = dbcontext;

        }

        public async Task<IActionResult> Index()
        {
            var movies = await _dbcontext.Movies.ToListAsync();
            return View("Index", movies);

        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Directors = new SelectList(
            await _dbcontext.Directors.ToListAsync(),"Id","Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.Movies.Add(movie);
                await _dbcontext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            // If validation fails, reload the dropdown:
            ViewBag.Directors = new SelectList(await _dbcontext.Directors.ToListAsync(), "Id", "Name");
            return View(movie);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movie = _dbcontext.Movies.FirstOrDefault(m => m.Id == id);

            if(movie == null)
            {
                return RedirectToAction("Index");
            }
            return View("Edit", movie);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Movie movie)
        {
            if(id != movie.Id)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                _dbcontext.Update(movie);
                await _dbcontext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(movie);


        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var movie = _dbcontext.Movies.FirstOrDefault(m => m.Id == id);
            
            if (movie == null)
            {
                return RedirectToAction("Index");
            }

            _dbcontext.Remove(movie);
            await _dbcontext.SaveChangesAsync();
            return RedirectToAction("Index");


        }

    }
}
