using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibraryManagement.Repositories
{
    public class InMemoryBookRepository : IBookRepository
    {
        // In-memory list to store books
        private readonly List<Book> _books = [];
        // Next available Id for new books
        private int _nextId = 1;

        // Returns all books in the repository
        public IEnumerable<Book> GetAllBooks() => _books;

        // Retrieves a book by its Id, throws if not found
        public Book GetBookById(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            return book ?? throw new InvalidOperationException($"Book with Id {id} not found.");
        }

        // Adds a new book and assigns a unique Id
        public void AddBook(Book book)
        {
            book.Id = _nextId++;
            _books.Add(book);
        }

        // Updates an existing book by replacing it in the list
        public void UpdateBook(Book book)
        {
            var index = _books.FindIndex(b => b.Id == book.Id);
            if (index >= 0) _books[index] = book;
        }

        // Deletes a book by its Id
        public void DeleteBook(int id)
        {
            var book = GetBookById(id);
            if (book != null) _books.Remove(book);
        }
    }
}
