using System.Collections.Generic;
using System.Linq;

namespace InMemoryCrudApp.Models
{
    public class BookRepository
    {
        private static List<Book> Books = new List<Book>
        {
            new Book { Id = 1, Title = "Book 1", Author = "Author 1", Year = 2001 },
            new Book { Id = 2, Title = "Book 2", Author = "Author 2", Year = 2002 }
        };
            
        public List<Book> GetAll() => Books;

        public Book GetById(int id) => Books.FirstOrDefault(b => b.Id == id);

        public void Add(Book book)
        { 
            book.Id = Books.Max(b => b.Id) + 1;
            Books.Add(book); 
        }

        public void Update(Book book) { 
            var existingBook = Books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.Year = book.Year;
            }
        }

        public void Delete(int id) { 
            var book = Books.FirstOrDefault(a => a.Id == id);
            if (book != null) { 
                Books.Remove(book);
            }
        }
    }
}
