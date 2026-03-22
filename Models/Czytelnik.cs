using System.ComponentModel.DataAnnotations;

namespace Wprawka1.Models
{
    public class Czytelnik
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Imie { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nazwisko { get; set; }

        [Required]
        [MaxLength(20)]
        public string KartaBiblioteczna { get; set; } 
        public ICollection<Wypozyczenie> Wypozyczenia { get; set; } = new List<Wypozyczenie>();
    }
}
