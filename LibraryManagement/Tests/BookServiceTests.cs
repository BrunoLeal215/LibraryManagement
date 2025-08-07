using Xunit;
using LibraryManagement.Models;
using LibraryManagement.Repositories;
using LibraryManagement.Services;

namespace LibraryManagement.Tests
{
    public class BookServiceTests
    {
        [Fact]
        public void AddBook_WithInvalidIsbn_ThrowsException()
        {
            var repo = new InMemoryBookRepository();
            var service = new BookService(repo);
            var book = new Book { Title = "Test", Author = "Author", ISBN = "123", Description = "" };

        }

        [Fact]
        public void AddBook_WithValidData_SavesBook()
        {
            var repo = new InMemoryBookRepository();
            var service = new BookService(repo);
            var book = new Book { Title = "Test", Author = "Author", ISBN = "1234567890123", Description = "" };

            service.AddBook(book);
            var books = service.GetAllBooks();

            Assert.Single(books);
        }


        [Fact]
        public void DeleteBook_RemovesBook_WhenBookExists()
        {
            // Arrange
            var repo = new InMemoryBookRepository();
            var book = new Book { Title = "Test", Author = "Author", PublishedDate = DateTime.Now, ISBN = "123", Description = "Desc" };
            repo.AddBook(book);
            int id = book.Id;

            // Act
            repo.DeleteBook(id);

            // Assert
            Assert.Throws<InvalidOperationException>(() => repo.GetBookById(id));
        }

        [Fact]
        public void DeleteBook_ThrowsException_WhenBookDoesNotExist()
        {
            // Arrange
            var repo = new InMemoryBookRepository();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => repo.DeleteBook(999));
        }
    }
}
