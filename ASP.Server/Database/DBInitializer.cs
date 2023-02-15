using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASP.Server.Database
{
    public class DbInitializer
    {
        public static void Initialize(LibraryDbContext bookDbContext)
        {

            if (bookDbContext.Books.Any())
                return;

            Genre SF, Aventure, Autobiographie;
            bookDbContext.Genres.AddRange(
                 Autobiographie = new Genre
                 {
                     Id = 1,
                     GenreLitteraire = GenresPossible.Autobiographie.ToString(),
                     Books = new List<Book>()
                 },
             SF = new Genre
             {
                 Id = 2,
                 GenreLitteraire = GenresPossible.ScienceFiction.ToString(),
                 Books = new List<Book>()
             },
             Aventure = new Genre
             {
                 Id = 3,
                 GenreLitteraire = GenresPossible.Aventure.ToString(),
                 Books = new List<Book>()
             }
            );
            bookDbContext.SaveChanges();

            // Une fois les moèles complété Vous pouvez faire directement
            // new Book() { Author = "xxx", Name = "yyy", Price = n.nnf, Content = "ccc", Genres = new() { Romance, Thriller } }
            Book B1, B2, B3;
            bookDbContext.Books.AddRange(
               B1 = new Book
               {
                   Id = 1,
                   Nom = "Le Nom du vent",
                   Auteur = "Patrick Rothfuss",
                   Prix = 15,
                   Contenu = "Le silence avait un poids et il m'écrasait la poitrine...",
                   Genres = new List<Genre> { SF, Aventure, Autobiographie }
               },
               B2 = new Book
               {
                   Id = 2,
                   Nom = "Milky way",
                   Auteur = "Amine mojito",
                   Prix = 56,
                   Contenu = "Il est lent le lait",
                   Genres = new List<Genre> { Aventure, Autobiographie }
               },
               B3 = new Book
               {
                   Id = 3,
                   Nom = "hAWKMAN",
                   Auteur = "HASSEN KHALIFA",
                   Prix = 1500,
                   Contenu = "OOOOOHHH .... j'ai le droit de vivre un peu !",
                   Genres = new List<Genre> { Autobiographie }
               }
            );
          
            // Vous pouvez initialiser la BDD ici


            bookDbContext.SaveChanges();

            AfficherListeLivres( bookDbContext );
            AfficherListeGenres( bookDbContext );
        }

        public static void AfficherListeLivres(LibraryDbContext dbContext)
        {
            var livres = dbContext.Books.ToList(); // Récupérer la liste des livres depuis la base de données

            foreach (var livre in livres)
            {
                Console.WriteLine("ID : {0}", livre.Id);
                Console.WriteLine("Nom : {0}", livre.Nom);
                Console.WriteLine("Auteur : {0}", livre.Auteur);
                Console.WriteLine("Prix : {0}", livre.Prix);
                Console.WriteLine("Contenu : {0}", livre.Contenu);
                Console.WriteLine("Genres : {0}", string.Join(",", livre.Genres.Select(g => g.GenreLitteraire)));
                Console.WriteLine("----------------------------");
            }
        }




        public static void AfficherListeGenres(LibraryDbContext dbContext)
        {
            var genres = dbContext.Genres.Include(g => g.Books).ToList(); // Récupérer la liste des genres depuis la base de données, en incluant les livres associés

            foreach (var genre in genres)
            {
                Console.WriteLine("ID : {0}", genre.Id);
                Console.WriteLine("Genre : {0}", genre.GenreLitteraire);
                Console.WriteLine("Livres :");

                foreach (var livre in genre.Books)
                {
                    Console.WriteLine("\tID : {0}", livre.Id);
                    Console.WriteLine("\tNom : {0}", livre.Nom);
                    Console.WriteLine("\tAuteur : {0}", livre.Auteur);
                    Console.WriteLine("\tPrix : {0}", livre.Prix);
                    Console.WriteLine("\tContenu : {0}", livre.Contenu);
                    Console.WriteLine("\t----------------------------");
                }
                Console.WriteLine("----------------------------");
            }
        }


    }
}