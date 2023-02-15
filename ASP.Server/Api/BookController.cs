using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.Server.Database;

namespace ASP.Server.Api
{

    [Route("/api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly LibraryDbContext libraryDbContext;

        public BookController(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }

        // Methode a ajouter : 
        // - GetBooks
        //   - Entrée: Optionel -> Liste d'Id de genre, limit -> defaut à 10, offset -> défaut à 0
        //     Le but de limit et offset est dé créer un pagination pour ne pas retourner la BDD en entier a chaque appel
        //   - Sortie: Liste d'object contenant uniquement: Auteur, Genres, Titre, Id, Prix
        //     la liste restourner doit être compsé des élément entre <offset> et <offset + limit>-
        //     Dans [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20] si offset=8 et limit=5, les élément retourner seront : 8, 9, 10, 11, 12

        // - GetBook
        //   - Entrée: Id du livre
        //   - Sortie: Object livre entier

        // - GetGenres
        //   - Entrée: Rien
        //   - Sortie: Liste des genres

        // Aide:
        // Pour récupéré un objet d'une table :
        //   - libraryDbContext.MyObjectCollection.<Selecteurs>.First()
        // Pour récupéré des objets d'une table :
        //   - libraryDbContext.MyObjectCollection.<Selecteurs>.ToList()
        // Pour faire une requète avec filtre:
        //   - libraryDbContext.MyObjectCollection.<Selecteurs>.Skip().<Selecteurs>
        //   - libraryDbContext.MyObjectCollection.<Selecteurs>.Take().<Selecteurs>
        //   - libraryDbContext.MyObjectCollection.<Selecteurs>.Where(x => x == y).<Selecteurs>
        // Pour récupérer une 2nd table depuis la base:
        //   - .Include(x => x.yyyyy)
        //     ou yyyyy est la propriété liant a une autre table a récupéré
        //
        // Exemple:
        //   - Ex: libraryDbContext.MyObjectCollection.Include(x => x.yyyyy).Where(x => x.yyyyyy.Contains(z)).Skip(i).Take(j).ToList()


        // Je vous montre comment faire la 1er, a vous de la compléter et de faire les autres !
        public ActionResult<List<Book>> GetBooks(int offset = 0, int limit = 10, int? genre = null)
        {
            var booksQuery = libraryDbContext.Books
                .OrderBy(b => b.Id)
                .Skip(offset)
                .Take(limit)
                .Include(b => b.Genres)
                .Where(b => !genre.HasValue || b.Genres.Any(g => g.Id == genre.Value));

            var books = booksQuery.ToList();

            var count = libraryDbContext.Books.Count();
            var range = $"{offset + 1}-{offset + books.Count}/{count}";

            Response.Headers.Add("Pagination", range);

            var booksWithGenres = books.Select(b => new Book
            {
                Id = b.Id,
                Nom = b.Nom,
                Auteur = b.Auteur,
                Prix = b.Prix,
                Contenu = b.Contenu,
                Genres = b.Genres.Select(g => new Genre { Id = g.Id, GenreLitteraire = g.GenreLitteraire }).ToList()
            }).ToList();

            return booksWithGenres;
        }



        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            // Get the book from the database
            var book = libraryDbContext.Books
                .Include(b => b.Genres)
                .FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            // Map the book to the desired response format
            var bookResponse = new
            {
                Id = book.Id,
                Nom = book.Nom,
                Prix = book.Prix,
                Auteur = book.Auteur,
                Contenu = book.Contenu,
                Genres = book.Genres.Select(g => new { Id = g.Id, Name = g.GenreLitteraire }).ToList()

            };

            return Ok(bookResponse);
        }

     

    }
}

