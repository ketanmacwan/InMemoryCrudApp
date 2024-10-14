using InMemoryCrudApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace InMemoryCrudApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookRepository _repository;

        public BooksController()
        {
            _repository = new BookRepository();
        }

        public IActionResult Index()
        {
            List<Book> books = _repository.GetAll();
            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,Author,Year")] Book book)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _repository.GetById(id.Value);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,Author,Year")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _repository.Update(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _repository.GetById(id.Value);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
