using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Wprawka1.Models
{
    public class Ksiazka
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Tytul { get; set; }

        [Display(Name = "Wydawnictwo")]
        public int wydawcaID { get; set; }
        [ValidateNever]
        public Wydawca wydawca { get; set; }
        public ICollection<Wypozyczenie> Wypozyczania { get; set; } = new List<Wypozyczenie>();
    }
}
