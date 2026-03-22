using System.ComponentModel.DataAnnotations;

namespace Wprawka1.Models
{
    public class Wypozyczenie
    {
        public int IDczytelnika { get; set; }
        public Czytelnik czytelnik { get; set; }

        public int IDksiazki { get; set; }
        public Ksiazka ksiazka { get; set; }

        [Required]
        public DateTime DataWypozyczenia { get; set; }

        public DateTime? DataZwrotu { get; set; }
    }
}
