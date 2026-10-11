using Microsoft.AspNetCore.Mvc;
using wt_lab4_4mvc_strelchonok.Models;

namespace wt_lab4_4mvc_strelchonok.Controllers
{
    public class BookController : Controller
    {
        private static readonly List<Book> Books = new()
        {
            new Book { Id = 1, Title = "Преступление и наказание", Author = "Ф. М. Достоевский",
                       Genre = "Роман", Year = 1866, Pages = 672, IsAvailable = true },
            new Book { Id = 2, Title = "Война и мир", Author = "Л. Н. Толстой",
                       Genre = "Роман-эпопея", Year = 1869, Pages = 1274, IsAvailable = true },
            new Book { Id = 3, Title = "Мастер и Маргарита", Author = "М. А. Булгаков",
                       Genre = "Мистика", Year = 1967, Pages = 480, IsAvailable = false },
            new Book { Id = 4, Title = "Герой нашего времени", Author = "М. Ю. Лермонтов",
                       Genre = "Роман", Year = 1840, Pages = 224, IsAvailable = true },
            new Book { Id = 5, Title = "Евгений Онегин", Author = "А. С. Пушкин",
                       Genre = "Роман в стихах", Year = 1833, Pages = 320, IsAvailable = false }
        };

        public IActionResult Index()
        {
            return View(Books);
        }

        public IActionResult Details(int id)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();   // вернёт 404
            }
            return View(book);
        }
        //GET:/Book/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST:/Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);   
            }

            book.Id = Books.Any() ? Books.Max(b => b.Id) + 1 : 1;
            Books.Add(book);

            return RedirectToAction("Index");
        }
        //GET:/Book/Edit/1
        public IActionResult Edit(int id)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);
            if (book == null) return NotFound();
            return View(book);
        }

        //POST:/Book/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Book book)
        {
            if (id != book.Id) return BadRequest();

            if (!ModelState.IsValid)
            {
                return View(book);
            }

            var existing = Books.FirstOrDefault(b => b.Id == id);
            if (existing == null) return NotFound();

            existing.Title = book.Title;
            existing.Author = book.Author;
            existing.Genre = book.Genre;
            existing.Year = book.Year;
            existing.Pages = book.Pages;
            existing.IsAvailable = book.IsAvailable;

            return RedirectToAction("Index");
        }
    }

}