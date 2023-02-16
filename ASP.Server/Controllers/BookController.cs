using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Database;
using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ASP.Server.Controllers
{
    public class CreateBookModel
    {
        [Required]
        [Display(Name = "Nom")]
        public String Name { get; set; }

        // Ajouter ici tous les champ que l'utilisateur devra remplir pour ajouter un livre
        [Required]
        [Display(Name = "Auteur")]
        public string Auteur { get; set; }

        [Required]
        [Display(Name = "Prix")]
        public int Prix { get; set; }

        [Required]
        [Display(Name = "Contenu")]
        public string Contenu { get; set; }

        // Liste des genres séléctionné par l'utilisateur
        public List<int> Genres { get; set; }

        // Liste des genres a afficher à l'utilisateur
        public IEnumerable<Genre> AllGenres { get; init;  }
    }

    public class BookController : Controller
    {
        private readonly LibraryDbContext libraryDbContext;

        public BookController(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }

        public ActionResult<IEnumerable<Book>> List()
        {
            // Retrieve the list of books from the database
            List<Book> listBooks = libraryDbContext.Books.Include(b => b.Genres).ToList();

            return View(listBooks);
        }

        public ActionResult<CreateBookModel> Create(CreateBookModel book)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the list of genres from the database
                List<Genre> genres = libraryDbContext.Genres.ToList();

                // Create a new book and add it to the database
                Book newBook = new Book
                {
                    Nom = book.Name,
                    Prix = book.Prix,
                    Contenu = book.Contenu,
                    Auteur= book.Auteur,
                    // Set other properties of the book here
                    Genres = genres.Where(g => book.Genres.Contains(g.Id)).ToList()

                };
                libraryDbContext.Add(newBook);
                libraryDbContext.SaveChanges();
            }

            // Retrieve the list of genres from the database and pass it to the view
            List<Genre> allGenres = libraryDbContext.Genres.ToList();
            return View(new CreateBookModel { AllGenres = allGenres });
        }

        public ActionResult DeleteBook(int id)
        {
            var book = libraryDbContext.Books.Find(id);
            if (book != null)
            {
                libraryDbContext.Books.Remove(book);
                libraryDbContext.SaveChanges();
            }
            return RedirectToAction(nameof(List));
        }
    }
}
