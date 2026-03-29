using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Wprawka1.Models
{
    public class Wypozyczenie
    {
        public int Id { get; set; }

        [Display(Name = "Czytelnik")]
        [Required(ErrorMessage = "Wybierz czytelnika")]
        public int czytelnikID { get; set; }
        [ValidateNever]
        public Czytelnik czytelnik { get; set; }

        [Display(Name = "Książka")]
        [Required(ErrorMessage = "Wybierz książkę")]
        public int ksiazkaID { get; set; }
        [ValidateNever]
        public Ksiazka ksiazka { get; set; }

        [Display(Name = "Data wypożyczenia")]
        [Required(ErrorMessage = "Data wypożyczenia jest wymagana")]
        [DataType(DataType.Date)]
        public DateTime DataWypozyczenia { get; set; }

        [Display(Name = "Data zwrotu")]
        [DataType(DataType.Date)]
        public DateTime? DataZwrotu { get; set; }
    }
}
