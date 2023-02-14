using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.Server.Model
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key]
        public int Id { get; set; }

        public string GenreLitteraire { get; set; }
        public List<Book> Books { get; set; }


        public void AjouterLivre( Book livre)
        {
            Books.Add(livre);
        }

        public void SupprimerLivre(Book livre)
        {
            Books.Remove(livre);
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

