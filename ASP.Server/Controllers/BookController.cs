using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Database;
using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Diagnostics;

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
        public Auteur Auteur { get; set; }

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

    public class EditBookModel
    {
        [Required]
        [Display(Name = "Nom")]
        public String Name { get; set; }

        // Ajouter ici tous les champ que l'utilisateur devra remplir pour ajouter un livre
        [Required]
        [Display(Name = "Auteur")]
        public Auteur Auteur { get; set; }

        [Required]
        [Display(Name = "Prix")]
        [Range(0, double.MaxValue, ErrorMessage = "Le prix doit être supérieur ou égal à 0.")]
        public int Prix { get; set; }

        [Required]
        [Display(Name = "Contenu")]
        public string Contenu { get; set; }

        // Liste des genres séléctionné par l'utilisateur
        public List<int> Genres { get; set; }

        // Liste des genres a afficher à l'utilisateur
        public IEnumerable<Genre> AllGenres { get; set; }
        public int Id { get; internal set; }
    }

    public class BookController : Controller
    {
        private readonly LibraryDbContext libraryDbContext;

        public BookController(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }

        public ActionResult<IEnumerable<Book>> List(string authorName, string genreName)
        {
            // Retrieve the list of books from the database
            List<Book> listBooks = libraryDbContext.Books.Include(b => b.Auteur).Include(b => b.Genres).ToList();

            if (!string.IsNullOrEmpty(authorName))
            {
                // Filter the list of books by author name
                listBooks = listBooks.Where(b => b.Auteur.Nom.Contains(authorName) || b.Auteur.Prenom.Contains(authorName)).ToList();
            }

            if (!string.IsNullOrEmpty(genreName))
            {
                // Filter the list of books by genre name
                listBooks = listBooks.Where(b => b.Genres.Any(g => g.GenreLitteraire.Contains(genreName))).ToList();
            }



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
                return RedirectToAction(nameof(List));
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


        public ActionResult<EditBookModel> Edit(EditBookModel editBook, int? id)
        {

            
            Book book = libraryDbContext.Books.Include(b => b.Genres).Single(b => b.Id==(id??editBook.Id));

            if (book == null)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
            

                book.Nom = editBook.Name;
                book.Auteur = editBook.Auteur;
                book.Prix = editBook.Prix;
                book.Contenu = editBook.Contenu;

                // Clear current genres and add the selected genres
                book.Genres.Clear();
                foreach (int genreId in editBook.Genres)
                {
                    Genre genre = libraryDbContext.Genres.Find(genreId);
                    if (genre != null)
                    {
                        book.Genres.Add(genre);
                    }
                }

                libraryDbContext.SaveChanges();
                return RedirectToAction(nameof(List));
            }

            EditBookModel editbook2 = new EditBookModel() {
                Id = book.Id,
                Name = book.Nom,
                Auteur = book.Auteur,
                Prix = book.Prix,
                Contenu = book.Contenu,
                Genres = book.Genres.Select(g => g.Id).ToList(),
                AllGenres = libraryDbContext.Genres.ToList()
        };
            
            
            return View(editbook2);
        }

    }
}
