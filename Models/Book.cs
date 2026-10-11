using System.ComponentModel.DataAnnotations;

namespace wt_lab4_4mvc_strelchonok.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название книги")]
        [Display(Name = "Название")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите автора")]
        [Display(Name = "Автор")]
        public string Author { get; set; } = string.Empty;

        [Display(Name = "Жанр")]
        public string Genre { get; set; } = string.Empty;

        [Range(1000, 2100, ErrorMessage = "Год должен быть в диапазоне 1000–2100")]
        [Display(Name = "Год издания")]
        public int Year { get; set; }

        [Range(1, 10000, ErrorMessage = "Количество страниц должно быть от 1 до 10000")]
        [Display(Name = "Количество страниц")]
        public int Pages { get; set; }

        [Display(Name = "В наличии")]
        public bool IsAvailable { get; set; }
    }
}