using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Database;
using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ASP.Server.Controllers
{
    public class CreateGenreModel
    {
        [Required(ErrorMessage = "Please enter the genre name")]
        [Display(Name = "GenreLitteraire")]
        public String Name { get; set; }
    }

    public class GenreController : Controller
    {
        private readonly LibraryDbContext libraryDbContext;

        public GenreController(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }

        public ActionResult<IEnumerable<Genre>> List()
        {
            List<Genre> genres = libraryDbContext.Genres.Include(b => b.Books).ToList();
            return View(genres);
        }

        public ActionResult<CreateGenreModel> Create(CreateGenreModel genre)
        {
            if (ModelState.IsValid)
            {
                Genre newGenre = new Genre
                {
                    GenreLitteraire = genre.Name
                };

                libraryDbContext.Genres.Add(newGenre);
                libraryDbContext.SaveChanges();

                return RedirectToAction(nameof(List));
            }

            return View(genre);


        }
    }
}
