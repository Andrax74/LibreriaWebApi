using System.Collections.Generic;
using System.Threading.Tasks;
using LibreriaWebApi.Models;

namespace LibreriaWebApi.Service
{
    public class LibriRepository : ILibriRepository
    {
        Libri[] libri = new Libri[]
        {
            new Libri {Isbn = "B08KH1B786", Titolo = "Grishaverse - Tenebre e ossa", Sinossi = "Alina Starkov non ha grandi...", Immagine ="book1.jpg", Autore = "Leigh Bardugo"  },
            new Libri {Isbn = "B08R5MD353", Titolo = "Grishaverse - Assedio e tempesta", Sinossi = "Ricercata per tutto il Mare Vero...", Immagine ="book2.jpg", Autore = "Leigh Bardugo"  },
            new Libri {Isbn = "B08XWV5SMR", Titolo = "Grishaverse - Rovina e ascesa", Sinossi = "L'Oscuro ha ormai esteso...", Immagine ="book3.jpg", Autore = "Leigh Bardugo" }
        };

        public ICollection<Libri> SelAll()
        {
            return this.libri;
        }
    }
}