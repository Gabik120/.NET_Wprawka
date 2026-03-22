using System.ComponentModel.DataAnnotations;

namespace Wprawka1.Models
{
    public class Wydawca
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nazwa { get; set; }
        public ICollection<Ksiazka> Ksiazki { get; set; } = new List<Ksiazka>();
    }
}
