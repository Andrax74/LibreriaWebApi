namespace LibreriaWebApi.Dtos
{
    public class LibriDto
    {
        public string Isbn { get; set; }
        public string Titolo { get; set; }
        public string Sinossi { get; set; }
        public string Immagine { get; set; } 
        public string Autore { get; set; }
        public string Prezzo { get; set; }
    }
}