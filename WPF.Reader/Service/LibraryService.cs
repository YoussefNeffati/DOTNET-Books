using CommunityToolkit.Mvvm.DependencyInjection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WPF.Reader.Model;
using System.Net.Http;
using System.Threading.Tasks;
using WPF.Reader.Api;
using CommunityToolkit.Mvvm.ComponentModel;

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
        public ObservableCollection<Genre> Genres { get; set; } = new ObservableCollection<Genre>()
        {




        };

        public LibraryService()
        {
            


        }

        // C'est aussi ici que vous ajouterez les requête réseau pour récupérer les livres depuis le web service que vous avez fait
        // Vous pourrez alors ajouter les livres obtenu a la variable Books !
        // Faite bien attention a ce que votre requête réseau ne bloque pas l'interface 

        public void LoadAllBooks()
        {
            var books = new BookApi().BookGetBooks();
            Books.Clear();
            // Add the books to the ObservableCollection
            foreach (Book book in books)
            {
                Books.Add(book);
            }
        }
        public void LoadAllGenres()
        {
            var genres = new GenreApi().GenreGetGenres();
          
            Genres.Clear();
            // Add the books to the ObservableCollection
            foreach (Genre genre in genres)
            {
                Genres.Add(genre);
            }
        }

    }
}
