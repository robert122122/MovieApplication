using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieApplication.Data;
using MovieApplication.Models;

namespace MovieApplication.Controllers
{
    public class MoviesController : Controller
    {
        static private List<Movie> movies = new List<Movie>();

        private readonly MovieApplicationContext _context;



        // GET: Movies
        public IActionResult Index()
        {
            return View(movies);
        }

        // GET: Movies/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = movies.Find(m => m.id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("id,name,genre,releaseDate")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                movie.id = Guid.NewGuid();
                movies.Add(movie);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = movies.Find(m => m.id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("id,name,genre,releaseDate")] Movie movie)
        {
            if (id != movie.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               
                    var movieEdit = movies.Find(m => m.id == id);
                movieEdit.name = movie.name;
                movieEdit.genre = movie.genre;
                movieEdit.releaseDate = movie.releaseDate;
                    //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = movies.Find(m => m.id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var movie = movies.Find(m => m.id == id);
            movies.Remove(movie);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(Guid id)
        {
            return _context.Movie.Any(e => e.id == id);
        }
    }
}
