using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //bring in a MovieDbContext
        private MovieDbContext context { get; set; }

        //Constructor
        public HomeController(ILogger<HomeController> logger, MovieDbContext con)
        {
            _logger = logger;
            context = con;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcast()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(Films addMovie)
        {
            if (ModelState.IsValid)
            {
                //Assign movie values to variables in database
                context.Film.Add(addMovie);

                //Save changes to database
                context.SaveChanges();
                //TempStorage.AddMovie(addMovie);

                //Return the confirmation page
                return View("Confirmation", addMovie);
            }
            else
            {
                return View();
            }
            
        }

        public IActionResult MovieCollection()
        {
            return View(context.Film);
        }

        //Set up Editing functionality with a get and post
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //match up passed id with id in database
            var movie = context.Film.Where(s => s.MovieId == id).FirstOrDefault();

            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(Films movie)
        {
            //match up passed id with id in database
            var mov = context.Film.Where(s => s.MovieId == movie.MovieId).FirstOrDefault();

            context.Film.Remove(mov);
            context.Film.Add(movie);
            //Save changes
            context.SaveChanges();

            return RedirectToAction("MovieCollection", context.Film);
        }

        //Set up delete functionality
        public IActionResult Delete(int id)
        {
            //match up passed id with id in database
            var movie = context.Film.Where(s => s.MovieId == id).FirstOrDefault();

            context.Film.Remove(movie);
            //Save Changes
            context.SaveChanges();

            return RedirectToAction("MovieCollection");
        }


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
