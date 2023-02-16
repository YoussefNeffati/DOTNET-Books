using CommunityToolkit.Mvvm.DependencyInjection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WPF.Reader.Model;

namespace WPF.Reader.Service
{
    public class LibraryService
    {
        // A remplacer avec vos propre données !!!!!!!!!!!!!!
        // Pensé qu'il ne faut mieux ne pas réaffecter la variable Books, mais juste lui ajouter et / ou enlever des éléments
        // Donc pas de LibraryService.Instance.Books = ...
        // mais plutot LibraryService.Instance.Books.Add(...)
        // ou LibraryService.Instance.Books.Clear()


        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>()
        {




        };

        public LibraryService()
        {
            List<Book> books = new List<Book>();

            // Créer un premier livre
            Book livre1 = new Book()
            {
                Id = 1,
                Nom = "Le Seigneur des anneaux",
                Prix = 20,
                Auteur = "J.R.R. Tolkien",
                Contenu = "Dans un monde imaginaire appelé la Terre du Milieu, un hobbit nommé Frodon Sacquet doit détruire un anneau magique avant qu'il ne tombe entre les mains du mal.",
                Genres = new List<Genre>(){
                    new Genre(){ Id = 1, GenreLitteraire = "Fantasy" },
                       new Genre(){ Id = 2, GenreLitteraire = "Aventure" },
                    }
            };
            books.Add(livre1);

            // Créer un deuxième livre
            Book livre2 = new Book()
            {
                Id = 2,
                Nom = "Fondation",
                Prix = 18,
                Auteur = "Isaac Asimov",
                Contenu = "Dans un futur lointain, un scientifique créé une fondation destinée à préserver les connaissances de l'humanité face à l'effondrement de la civilisation.",
                Genres = new List<Genre>(){
                     new Genre(){ Id = 3, GenreLitteraire = "Science-fiction" },
                
            }
            };
            books.Add(livre2);

        }

        // C'est aussi ici que vous ajouterez les requête réseau pour récupérer les livres depuis le web service que vous avez fait
        // Vous pourrez alors ajouter les livres obtenu a la variable Books !
        // Faite bien attention a ce que votre requête réseau ne bloque pas l'interface 
    }
}
