using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ASP.Server.Model
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
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


        // Mettez ici les propriété de votre livre: Nom, Autheur, Prix, Contenu et Genres associés
        // N'oublier pas qu'un livre peut avoir plusieur genres
    }
}
