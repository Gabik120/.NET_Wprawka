using System.ComponentModel.DataAnnotations;

namespace Wprawka1.Models
{
    public class Ksiazka
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Tytul { get; set; }

        public int IDwydawcy { get; set; }
        public Wydawca wydawca { get; set; }
        public ICollection<Wypozyczenie> Wypozyczania { get; set; } = new List<Wypozyczenie>();
    }
}
