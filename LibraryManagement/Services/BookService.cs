using LibraryManagement.Models;
using LibraryManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibraryManagement.Services
{
    public class BookService
    {
        // Repository for accessing book data
        private readonly IBookRepository _repository;

        // Constructor with dependency injection for repository
        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        // Retrieve all books from the repository
        public IEnumerable<Book> GetAllBooks() => _repository.GetAllBooks();

        // Retrieve a single book by its ID
        public Book? GetBookById(int id) => _repository.GetBookById(id);

        // Add a new book after validating its ISBN
        public void AddBook(Book book)
        {
            if (!IsValidIsbn(book.ISBN))
                throw new ArgumentException("Invalid ISBN. Must be 13 digits.");
            _repository.AddBook(book);
        }

        // Update an existing book after validating its ISBN
        public void UpdateBook(Book book)
        {
            if (!IsValidIsbn(book.ISBN))
                throw new ArgumentException("Invalid ISBN. Must be 13 digits.");
            _repository.UpdateBook(book);
        }

        // Delete a book by its ID
        public void DeleteBook(int id) => _repository.DeleteBook(id);

        // Validate that the ISBN is exactly 13 digits
        private bool IsValidIsbn(string isbn) => Regex.IsMatch(isbn, @"^\d{13}$");
    }
}
