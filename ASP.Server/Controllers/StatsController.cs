using ASP.Server.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ASP.Server.Controllers
{
    public class StatsController : Controller
    {
        private readonly LibraryDbContext _context;


        public class Data
        {
            [Required]
            [Display(Name = "TotalBooks")]
            public int TotalBooks { get; set; }
            [Required]
            [Display(Name = "maxWords")]
            public int maxWords { get; set; }
            [Required]
            [Display(Name = "minWords")]
            public int minWords { get; set; }
            [Required]
            [Display(Name = "medianWords")]
            public int medianWords { get; set; }

            [Required]
            [Display(Name = "averageWords")]
            public double averageWords { get; set; }


            [Required]
            [Display(Name = "BooksByGenre")]
            public IQueryable<BooksByGenre> BooksByGenre { get; set; }
           
            [Required]
            [Display(Name = "BooksByAuthor")]
            public IQueryable<BooksByAuthor> BooksByAuthor { get; set; }

            

        };
        public class BooksByGenre
        {

            [Required]
            [Display(Name = "Genre")]
            public string Genre { get; set; }

            [Required]
            [Display(Name = "Count")]
            public int Count { get; set; }
            

            // Ajouter ici tous les champ que l'utilisateur devra remplir pour ajouter un livre


        };
        public class BooksByAuthor
        {

            [Required]
            [Display(Name = "Author")]
            public string Author { get; set; }

            [Required]
            [Display(Name = "Count")]
            public int Count { get; set; }


            // Ajouter ici tous les champ que l'utilisateur devra remplir pour ajouter un livre


        };

        public StatsController(LibraryDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Calculer le nombre de livres total disponible
            int totalBooks = _context.Books.Count();

            // Calculer le nombre de livres par auteur
            var booksByAuthor = _context.Books.GroupBy(b => b.Auteur)
                                          .Select(g =>  new BooksByAuthor  { Author = g.Key.Nom, Count = g.Count() });

            // Calculer le nombre maximum, minimum, median et moyen de mots d'un livre
            var wordCounts = _context.Books.ToList().Select(b => b.Contenu.Split(' ').Count());
            int maxWords = wordCounts.Max();
            int minWords = wordCounts.Min();
            int medianWords = (int)wordCounts.OrderBy(c => c).Skip((wordCounts.Count() - 1) / 2).First();
            double averageWords = wordCounts.Average();

            // Calculer le nombre de livres par genre
            var booksByGenre = _context.Genres.Include(g => g.Books)
                                          .Select(g => new BooksByGenre { Genre = g.GenreLitteraire, Count = g.Books.Count() });



            var Data = new Data
            {
                TotalBooks = totalBooks,
                maxWords = maxWords, 
                minWords = minWords, 
                medianWords = medianWords , 
                averageWords  = averageWords , 
                BooksByGenre = booksByGenre,
                BooksByAuthor = booksByAuthor
            };

            return View(Data);
        }
    }
}
