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

            Genre SF, Aventure, Autobiographie, Romance, Thriller, Policier, Fantastique, Horreur, Drame, ScienceFiction;
            bookDbContext.Genres.AddRange(
                 Autobiographie = new Genre
                 {
                     Id = 1,
                     GenreLitteraire = GenresPossible.Autobiographie.ToString(),
                     Books = new List<Book>()
                 },
                 ScienceFiction = new Genre
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
                 },
                 Romance = new Genre
                 {
                     Id = 4,
                     GenreLitteraire = GenresPossible.Romance.ToString(),
                     Books = new List<Book>()
                 },
                 Thriller = new Genre
                 {
                 Id = 5,
                 GenreLitteraire = GenresPossible.Thriller.ToString(),
                 Books = new List<Book>()
                },
                Policier = new Genre
                {
                 Id = 6,
                 GenreLitteraire = GenresPossible.Policier.ToString(),
                 Books = new List<Book>()
                },
                Fantastique = new Genre
                {
                Id = 7,
                GenreLitteraire = GenresPossible.Fantastique.ToString(),
                Books = new List<Book>()
                },
                Horreur = new Genre
                {
                 Id = 8,
                 GenreLitteraire = GenresPossible.Horreur.ToString(),
                 Books = new List<Book>()
                },
                Drame = new Genre
                {
                 Id = 9,
                 GenreLitteraire = GenresPossible.Drame.ToString(),
                 Books = new List<Book>()
             }
            );
            bookDbContext.SaveChanges();

            // Une fois les moèles complété Vous pouvez faire directement
            // new Book() { Author = "xxx", Name = "yyy", Price = n.nnf, Content = "ccc", Genres = new() { Romance, Thriller } }
            Book B1 = new Book
            {
                Id = 1,
                Nom = "Le Nom du vent",
                Prix = 15,
                Contenu = "Le silence avait un poids et il m'écrasait la poitrine...",
                Genres = new List<Genre> { ScienceFiction, Aventure, Autobiographie }
            };

            Book B2 = new Book
            {
                Id = 2,
                Nom = "Milky way",
                Prix = 56,
                Contenu = "Il est lent",
                Genres = new List<Genre> { Aventure, Autobiographie }
            };

            Book B3 = new Book
            {
                Id = 3,
                Nom = "Hello World",
                Prix = 1500,
                Contenu = "OOOOOHHH .... j'ai le droit de vivre un peu !",
                Genres = new List<Genre> { Autobiographie }
            };

            Book B4 = new Book
            {
                Id = 4,
                Nom = "Le Cycle de la Fondation",
                Prix = 20,
                Contenu = "Dans un futur très lointain, l'Empire galactique, gouverné par un empereur tout-puissant, est sur le point de s'effondrer...",
                Genres = new List<Genre> { ScienceFiction, Thriller }
            };

            Book B5 = new Book
            {
                Id = 5,
                Nom = "1984",
                Prix = 10,
                Contenu = "Dans une société totalitaire où la liberté de pensée n'existe plus, un homme décide de se rebeller...",
                Genres = new List<Genre> { ScienceFiction, Policier, Drame }
            };

            Book B6 = new Book
            {
                Id = 6,
                Nom = "La Horde du Contrevent",
                Prix = 18,
                Contenu = "Dans un monde où le vent souffle sans cesse, une équipe de spécialistes est chargée de remonter à contre-courant jusqu'à sa source...",
                Genres = new List<Genre> { ScienceFiction, Aventure, Fantastique }
            };

            Book B7 = new Book
            {
                Id = 7,
                Nom = "Les Misérables",
                Prix = 12,
                Contenu = "Le destin de Jean Valjean, ancien bagnard, et de tous les personnages qui croisent sa route, dans une France bouleversée par les changements politiques...",
                Genres = new List<Genre> { Aventure, Fantastique }
            };

            Book B8 = new Book
            {
                Id = 8,
                Nom = "Le Seigneur des Anneaux",
                Prix = 25,
                Contenu = "Le jeune hobbit Frodon Sacquet doit parcourir une longue et dangereuse quête pour détruire l'Anneau Unique et sauver la Terre du Milieu de Sauron...",
                Genres = new List<Genre> { Fantastique, Aventure }
            };

            Book B9 = new Book
            {
                Id = 9,
                Nom = "Les Rois maudits",
                Prix = 17,
                Contenu = "La fin de la dynastie des Capétiens directs, au XIVe siècle, est racontée à travers les luttes de pouvoir et les intrigues politiques qui ont secoué la France...",
                Genres = new List<Genre> { ScienceFiction, Aventure }
            };

            Book B10 = new Book
            {
                Id = 10,
                Nom = "Les Fourmis",
                Prix = 14,
                Contenu = "Dans les forêts tropicales, les fourmis sont organisées en colonies hiérarchisées, mais une découverte extraordinaire va bouleverser leur ordre social...",
                Genres = new List<Genre> { ScienceFiction, Aventure, Policier }
            };

            Book B11 = new Book
            {
                Id = 11,
                Nom = "La Nuit des temps",
                Prix = 16,
                Contenu = "Une expédition scientifique découvre, sous la glace de l'Antarctique, une civilisation très avancée qui aurait vécu des milliers d'années auparavant...",
                Genres = new List<Genre> { ScienceFiction, Romance }
            };

            Auteur auteur1 = new Auteur
            {
                Id = 1,
                Prenom = "Patrick",
                Nom = "Rothfuss",
                Nationalite = "Américain"
            };

            Auteur auteur2 = new Auteur
            {
                Id = 2,
                Prenom = "Amine",
                Nom = "Belkadi",
                Nationalite = "Algérien"
            };

            Auteur auteur3 = new Auteur
            {
                Id = 3,
                Prenom = "Hassen",
                Nom = "Khalifa",
                Nationalite = "Tunisien"
            };

            // Ajouter les livres à la base de données
            bookDbContext.Books.AddRange(B1, B2, B3);

            // Ajouter les auteurs à la base de données
            bookDbContext.Auteurs.AddRange(auteur1, auteur2, auteur3);

            // Ajouter les livres à chaque auteur
            auteur1.Books = new List<Book> { B2, B4, B8 };
            auteur2.Books = new List<Book> { B1, B5, B6, B11 };
            auteur3.Books = new List<Book> { B3, B7, B9, B10 };

            bookDbContext.SaveChanges();

            AfficherListeLivres(bookDbContext);
            AfficherListeGenres(bookDbContext);
            AfficherListeAuteurs(bookDbContext);
        }

        public static void AfficherListeLivres(LibraryDbContext dbContext)
        {
            var livres = dbContext.Books.ToList(); // Récupérer la liste des livres depuis la base de données

            Console.WriteLine("Liste des livres :");

            foreach (var livre in livres)
            {
                Console.WriteLine("ID : {0}", livre.Id);
                Console.WriteLine("Nom : {0}", livre.Nom);
                Console.WriteLine("Auteur : {0}", livre.Auteur.Nom);
                Console.WriteLine("Prix : {0}", livre.Prix);
                Console.WriteLine("Contenu : {0}", livre.Contenu);
                Console.WriteLine("Genres : {0}", string.Join(",", livre.Genres.Select(g => g.GenreLitteraire)));
                Console.WriteLine("----------------------------");
            }
        }

        public static void AfficherListeAuteurs(LibraryDbContext bookDbContext)
        {
            Console.WriteLine("Liste des auteurs :");

            foreach (var auteur in bookDbContext.Auteurs)
            {
                Console.WriteLine($"- {auteur.Id} : {auteur.Prenom} {auteur.Nom} ({auteur.Nationalite})");
                if (auteur.Books.Any())
                {
                    Console.WriteLine("  Livres :");
                    foreach (var livre in auteur.Books)
                    {
                        Console.WriteLine($"  - {livre.Nom}");
                    }
                }
                else
                {
                    Console.WriteLine("  Aucun livre enregistré pour cet auteur.");
                }
            }

            Console.WriteLine();
        }


        public static void AfficherListeGenres(LibraryDbContext dbContext)
        {
            var genres = dbContext.Genres.Include(g => g.Books).ToList(); // Récupérer la liste des genres depuis la base de données, en incluant les livres associés
            Console.WriteLine("Liste des Genres :");

            foreach (var genre in genres)
            {
                Console.WriteLine("ID : {0}", genre.Id);
                Console.WriteLine("Genre : {0}", genre.GenreLitteraire);
                Console.WriteLine("Livres :");

                foreach (var livre in genre.Books)
                {
                    Console.WriteLine("\tID : {0}", livre.Id);
                    Console.WriteLine("\tNom : {0}", livre.Nom);
                    Console.WriteLine("\tAuteur : {0}", livre.Auteur.Nom);
                    Console.WriteLine("\tPrix : {0}", livre.Prix);
                    Console.WriteLine("\tContenu : {0}", livre.Contenu);
                    Console.WriteLine("\t----------------------------");
                }
                Console.WriteLine("----------------------------");
            }
        }


    }
}