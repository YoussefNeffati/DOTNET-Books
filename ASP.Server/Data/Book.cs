using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ASP.Server.Model
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string Autheur { get; set; }
        public int Prix { get; set; }
        public string Contenu { get; set; }
        public List<Genre> Genres { get; set;  }


        public void AjouterGenre(Genre genre)
        {
            Genres.Add(genre);
        }

        public void SupprimerGenre(Genre genre)
        {
            Genres.Remove(genre);
        }

        public void AfficherLivre(Book SelectBook)
        {

            Console.WriteLine("ID : {0}", SelectBook.Id);
            Console.WriteLine("Nom : {0}", SelectBook.Nom);
            Console.WriteLine("Auteur : {0}", SelectBook.Autheur);
            Console.WriteLine("Prix : {0}", SelectBook.Prix);
            Console.WriteLine("Contenu : {0}", SelectBook.Contenu);
            Console.WriteLine("Genres : {0}", string.Join(",", SelectBook.Genres.Select(g => g.GenreLitteraire)));
            Console.WriteLine("----------------------------");


        }


        // Mettez ici les propriété de votre livre: Nom, Autheur, Prix, Contenu et Genres associés
        // N'oublier pas qu'un livre peut avoir plusieur genres
    }
}
