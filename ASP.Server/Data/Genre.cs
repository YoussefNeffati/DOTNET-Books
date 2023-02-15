using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ASP.Server.Model
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key]
        public int Id { get; set; }

        public string GenreLitteraire { get; set; }
        [JsonIgnore]
        public List<Book> Books { get; set; }


        public void AjouterLivre( Book livre)
        {
            Books.Add(livre);
        }

        public void SupprimerLivre(Book livre)
        {
            Books.Remove(livre);
        }
        public void AfficherGenre(Genre genre)
        {
            Console.WriteLine("ID : {0}", genre.Id);
            Console.WriteLine("Genre littéraire : {0}", genre.GenreLitteraire);

            if (genre.Books != null)
            {
                Console.WriteLine("Liste des livres :");
                foreach (var livre in genre.Books)
                {
                    Console.WriteLine("\tNom : {0}", livre.Nom);
                    Console.WriteLine("\tAuteur : {0}", livre.Auteur);
                    Console.WriteLine("\tPrix : {0}", livre.Prix);
                    Console.WriteLine("\tContenu : {0}", livre.Contenu);
                    Console.WriteLine("\t-----------------------");
                }
            }
            else
            {
                Console.WriteLine("Aucun livre trouvé pour ce genre.");
            }
        }






        // Mettez ici les propriété de votre livre: Nom et Livres associés

        // N'oublier pas qu'un genre peut avoir plusieur livres
    }
    public enum GenresPossible
    {
        Roman,
        Nouvelle,
        Poesie,
        Theatre,
        Essai,
        Biographie,
        Autobiographie,
        Memoire,
        ScienceFiction,
        Fantastique,
        Policier,
        Horreur,
        Romance,
        Aventure,
        Historique,
        Epistolaire,
        Humoristique,
        Erotique,
        Jeunesse,
        TheorieLitteraire
    }

}

