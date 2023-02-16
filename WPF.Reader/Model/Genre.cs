using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WPF.Reader.Model
{
   

        // Mettez ici les propriété de votre livre: Nom et Livres associés

        // N'oublier pas qu'un genre peut avoir plusieur livres
    
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
