using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.Server.Model
{
    public class Auteur
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Nationalite { get; set; }
        public List<Book> Books { get; set; }

        public void AjouterLivre(Book livre)
        {
            Books.Add(livre);
        }

        public void SupprimerLivre(Book livre)
        {
            Books.Remove(livre);
        }
    }
}

